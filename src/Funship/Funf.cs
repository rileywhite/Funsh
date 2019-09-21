/***************************************************************************/
// Copyright 2019 Riley White
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
/***************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;

namespace Funship
{
    /// <summary>
    /// Represents a functional-style function.
    /// </summary>
    /// <remarks>
    /// A basic <see cref="Funf"/> is a container for one of the various <see cref="Func{TResult}"/>
    /// types, of which there are 17 variants (0 to 16 arguments). See the overloads of
    /// <see cref="funf{TResult}(Func{TResult})"/> for a full list of functional delegate types that can be wrapped.
    ///
    /// They can get more advanced.
    ///
    /// For example, when a <see cref="Funf"/> is called via <see cref="call(Funf, dynamic[])"/>,
    /// depending on the number of arguments passed and the <see cref="arity"/>, it may be partially called,
    /// fully called, or even overflowed, returning its own return value along with the extra arguments.
    /// See documentation for <see cref="call(Funf, dynamic[])"/> for more information.
    ///
    /// A <see cref="Funf"/> may also capture arguments without attempting to execute via a call to
    /// <see cref="capture(Funf, dynamic[])"/>. This creates a new <see cref="Funf"/>
    /// that encloses the passed arguments such that they will be used at the time the <see cref="Funf"/>
    /// is called.
    ///
    /// Additionally, calling <see cref="compose(Funf, Funf)"/> allows you to create a new
    /// function <c>h</c> that composes given functions <c>f</c> and <c>g</c> such that
    /// upon being called, <c>h</c> applies arguments to <c>f</c> until <c>f</c> can be executed,
    /// at which time any results from <c>f</c> are applied to <c>g</c> along with any remaining
    /// arguments that were not used by <c>f</c>.
    ///
    /// Any time a <see cref="Funf"/> is passed as an argument to <see cref="call(Funf, dynamic[])"/>
    /// or <see cref="capture(Funf, dynamic[])"/>, the returned <see cref="Funf"/> will compose the
    /// argument Funf together with the original.
    /// </remarks>
    /// <seealso cref="call(Funf, dynamic[])"/>
    /// <seealso cref="capture(Funf, dynamic[])"/>
    /// <seealso cref="compose(Funf, Funf)"/>
    public partial interface Funf
    {
        /// <summary>
        /// Gets the number of arguments the <see cref="Funf"/> needs before it can be fully called.
        /// </summary>
        /// <remarks>
        /// This may be a negative number indicating that the arguments are overflowing. If such a
        /// <see cref="Funf"/> is called, then the return value will be an <see cref="IEnumerable{dynamic}"/>
        /// with the return value as the first item followed by the unneeded arguments.
        /// </remarks>
        int arity { get; }

        public enum CallResultType
        {
            Error,
            Partial,
            Full
        }

        public interface CallResult<out TResult>
        {
            CallResultType result_type { get; }
            Funf<TResult> closure => empty<TResult>();
            TResult result => default;
            IEnumerable<dynamic> overflow_args => Enumerable.Empty<dynamic>();

            public void Deconstruct(out CallResultType result_type, out Funf closure)
            {
                result_type = this.result_type;
                closure = this.closure;
            }

            public void Deconstruct(out CallResultType result_type, out dynamic result, out IEnumerable<dynamic> overflow_args)
            {
                result_type = this.result_type;
                result = this.result;
                overflow_args = this.overflow_args;
            }
        }

        private readonly struct PartialCallResult<TResult> : CallResult<TResult>
        {
            public PartialCallResult(Funf<TResult> closure)
            {
                this.closure = closure;
            }

            public CallResultType result_type => CallResultType.Partial;
            public Funf<TResult> closure { get; }
        }

        private readonly struct FullCallResult<TResult> : CallResult<TResult>
        {
            public FullCallResult(TResult result) : this(result, new dynamic[0]) { }

            public FullCallResult(TResult result, IEnumerable<dynamic> overflow_args)
            {
                this.result = result;
                this.overflow_args = overflow_args;
            }

            public CallResultType result_type => CallResultType.Full;
            public TResult result { get; }
            public IEnumerable<dynamic> overflow_args { get; }

            public static implicit operator TResult(FullCallResult<TResult> result) => result.result;
        }

        private static CallResult<TResult> partial_call_result<TResult>(Funf<TResult> closure) =>
            new PartialCallResult<TResult>(closure);

        private static CallResult<TResult> full_call_result<TResult>(TResult result, IEnumerable<dynamic> overflow_args) =>
            new FullCallResult<TResult>(result, overflow_args);

        private static CallResult<TResult> full_call_result<TResult>(TResult result) =>
            new FullCallResult<TResult>(result);

        public static Funf<T> empty<T>() => new WFunf<T>(() => default);

        #region Factories

        /// <summary>
        /// Creates a new <see cref="Funf"/> from a given
        /// <see cref="Func{TResult}"/>
        /// </summary>
        /// <param name="func">Function that will be executed upon successful call</param>
        /// <returns>New <see cref="Funf"/></returns>
        /// <example>
        /// var f = Funf(() => 0);
        /// var x = call(f);        // x = 0
        /// </example>
        public static Funf<TResult> funf<TResult>(Func<TResult> func) => new WFunf<TResult>(func);

        /// <summary>
        /// Creates a new <see cref="Funf"/> from a given
        /// <see cref="Func{T1, TResult}"/>
        /// </summary>
        /// <param name="func">Function that will be executed upon successful call</param>
        /// <returns>New <see cref="Funf"/></returns>
        /// <example>
        /// var f = Funf((arg) => arg);
        /// var x = call(f, 1);        // x = 1
        /// </example>
        public static Funf<TResult> funf<TResult>(Func<dynamic, TResult> func) => new WFunf<TResult>(func);

        /// <summary>
        /// Creates a new <see cref="Funf"/> from a given
        /// <see cref="Func{T1, T2, TResult}"/>
        /// </summary>
        /// <param name="func">Function that will be executed upon successful call</param>
        /// <returns>New <see cref="Funf"/></returns>
        /// <example>
        /// var f = Funf((a1, a2) => a1 + a2);
        /// var x = call(f, 1, 1);        // x = 2
        /// </example>
        public static Funf<TResult> funf<TResult>(Func<dynamic, dynamic, TResult> func) => new WFunf<TResult>(func);

        /// <summary>
        /// Creates a new <see cref="Funf"/> from a given
        /// <see cref="Func{T1, T2, T3, TResult}"/>
        /// </summary>
        /// <param name="func">Function that will be executed upon successful call</param>
        /// <returns>New <see cref="Funf"/></returns>
        /// <example>
        /// var f = Funf((a1, a2, a3) => a1 + a2 + a3);
        /// var x = call(f, 1, 1, 1);        // x = 3
        /// </example>
        public static Funf<TResult> funf<TResult>(Func<dynamic, dynamic, dynamic, TResult> func) => new WFunf<TResult>(func);

        /// <summary>
        /// Creates a new <see cref="Funf"/> from a given
        /// <see cref="Func{T1, T2, T3, T4, TResult}"/>
        /// </summary>
        /// <param name="func">Function that will be executed upon successful call</param>
        /// <returns>New <see cref="Funf"/></returns>
        /// <example>
        /// var f = Funf((a1, a2, a3, a4) => a1 + a2 + a3 + a4);
        /// var x = call(f, 1, 1, 1, 1);        // x = 4
        /// </example>
        public static Funf<TResult> funf<TResult>(Func<dynamic, dynamic, dynamic, dynamic, TResult> func) => new WFunf<TResult>(func);

        /// <summary>
        /// Creates a new <see cref="Funf"/> from a given
        /// <see cref="Func{T1, T2, T3, T4, T5, TResult}"/>
        /// </summary>
        /// <param name="func">Function that will be executed upon successful call</param>
        /// <returns>New <see cref="Funf"/></returns>
        /// <example>
        /// var f = Funf((a1, a2, a3, a4, a5) => a1 + a2 + a3 + a4 + a5);
        /// var x = call(f, 1, 1, 1, 1, 1);        // x = 5
        /// </example>
        public static Funf<TResult> funf<TResult>(Func<dynamic, dynamic, dynamic, dynamic, dynamic, TResult> func) => new WFunf<TResult>(func);

        /// <summary>
        /// Creates a new <see cref="Funf"/> from a given
        /// <see cref="Func{T1, T2, T3, T4, T5, T6, TResult}"/>
        /// </summary>
        /// <param name="func">Function that will be executed upon successful call</param>
        /// <returns>New <see cref="Funf"/></returns>
        /// <example>
        /// var f = Funf((a1, a2, a3, a4, a5, a6) => a1 + a2 + a3 + a4 + a5 + a6);
        /// var x = call(f, 1, 1, 1, 1, 1, 1);        // x = 6
        /// </example>
        public static Funf<TResult> funf<TResult>(Func<dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, TResult> func) => new WFunf<TResult>(func);

        /// <summary>
        /// Creates a new <see cref="Funf"/> from a given
        /// <see cref="Func{T1, T2, T3, T4, T5, T6, T7, TResult}"/>
        /// </summary>
        /// <param name="func">Function that will be executed upon successful call</param>
        /// <returns>New <see cref="Funf"/></returns>
        /// <example>
        /// var f = Funf((a1, a2, a3, a4, a5, a6, a7) => a1 + a2 + a3 + a4 + a5 + a6 + a7);
        /// var x = call(f, 1, 1, 1, 1, 1, 1, 1);        // x = 7
        /// </example>
        public static Funf<TResult> funf<TResult>(Func<dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, TResult> func) => new WFunf<TResult>(func);

        /// <summary>
        /// Creates a new <see cref="Funf"/> from a given
        /// <see cref="Func{T1, T2, T3, T4, T5, T6, T7, T8, TResult}"/>
        /// </summary>
        /// <param name="func">Function that will be executed upon successful call</param>
        /// <returns>New <see cref="Funf"/></returns>
        /// <example>
        /// var f = Funf((a1, a2, a3, a4, a5, a6, a7, a8) => a1 + a2 + a3 + a4 + a5 + a6 + a7 + a8);
        /// var x = call(f, 1, 1, 1, 1, 1, 1, 1, 1);        // x = 8
        /// </example>
        public static Funf<TResult> funf<TResult>(Func<dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, TResult> func) => new WFunf<TResult>(func);

        /// <summary>
        /// Creates a new <see cref="Funf"/> from a given
        /// <see cref="Func{T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult}"/>
        /// </summary>
        /// <param name="func">Function that will be executed upon successful call</param>
        /// <returns>New <see cref="Funf"/></returns>
        /// <example>
        /// var f = Funf((a1, a2, a3, a4, a5, a6, a7, a8, a9) => a1 + a2 + a3 + a4 + a5 + a6 + a7 + a8 + a9);
        /// var x = call(f, 1, 1, 1, 1, 1, 1, 1, 1, 1);        // x = 9
        /// </example>
        public static Funf<TResult> funf<TResult>(Func<dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, TResult> func) => new WFunf<TResult>(func);

        /// <summary>
        /// Creates a new <see cref="Funf"/> from a given
        /// <see cref="Func{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult}"/>
        /// </summary>
        /// <param name="func">Function that will be executed upon successful call</param>
        /// <returns>New <see cref="Funf"/></returns>
        /// <example>
        /// var f = Funf((a1, a2, a3, a4, a5, a6, a7, a8, a9, a10) => a1 + a2 + a3 + a4 + a5 + a6 + a7 + a8 + a9 + a10);
        /// var x = call(f, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1);        // x = 10
        /// </example>
        public static Funf<TResult> funf<TResult>(Func<dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, TResult> func) => new WFunf<TResult>(func);

        /// <summary>
        /// Creates a new <see cref="Funf"/> from a given
        /// <see cref="Func{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult}"/>
        /// </summary>
        /// <param name="func">Function that will be executed upon successful call</param>
        /// <returns>New <see cref="Funf"/></returns>
        /// <example>
        /// var f = Funf((a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11) => a1 + a2 + a3 + a4 + a5 + a6 + a7 + a8 + a9 + a10 + a11);
        /// var x = call(f, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1);        // x = 11
        /// </example>
        public static Funf<TResult> funf<TResult>(Func<dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, TResult> func) => new WFunf<TResult>(func);

        /// <summary>
        /// Creates a new <see cref="Funf"/> from a given
        /// <see cref="Func{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult}"/>
        /// </summary>
        /// <param name="func">Function that will be executed upon successful call</param>
        /// <returns>New <see cref="Funf"/></returns>
        /// <example>
        /// var f = Funf((a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12) => a1 + a2 + a3 + a4 + a5 + a6 + a7 + a8 + a9 + a10 + a11 + a12);
        /// var x = call(f, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1);        // x = 12
        /// </example>
        public static Funf<TResult> funf<TResult>(Func<dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, TResult> func) => new WFunf<TResult>(func);

        /// <summary>
        /// Creates a new <see cref="Funf"/> from a given
        /// <see cref="Func{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult}"/>
        /// </summary>
        /// <param name="func">Function that will be executed upon successful call</param>
        /// <returns>New <see cref="Funf"/></returns>
        /// <example>
        /// var f = Funf((a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13) => a1 + a2 + a3 + a4 + a5 + a6 + a7 + a8 + a9 + a10 + a11 + a12 + a13);
        /// var x = call(f, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1);        // x = 13
        /// </example>
        public static Funf<TResult> funf<TResult>(Func<dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, TResult> func) => new WFunf<TResult>(func);

        /// <summary>
        /// Creates a new <see cref="Funf"/> from a given
        /// <see cref="Func{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult}"/>
        /// </summary>
        /// <param name="func">Function that will be executed upon successful call</param>
        /// <returns>New <see cref="Funf"/></returns>
        /// <example>
        /// var f = Funf((a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13, a14) => a1 + a2 + a3 + a4 + a5 + a6 + a7 + a8 + a9 + a10 + a11 + a12 + a13 + a14);
        /// var x = call(f, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1);        // x = 14
        /// </example>
        public static Funf<TResult> funf<TResult>(Func<dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, TResult> func) => new WFunf<TResult>(func);

        /// <summary>
        /// Creates a new <see cref="Funf"/> from a given
        /// <see cref="Func{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult}"/>
        /// </summary>
        /// <param name="func">Function that will be executed upon successful call</param>
        /// <returns>New <see cref="Funf"/></returns>
        /// <example>
        /// var f = Funf((a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13, a14, a15) => a1 + a2 + a3 + a4 + a5 + a6 + a7 + a8 + a9 + a10 + a11 + a12 + a13 + a14 + a15);
        /// var x = call(f, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1);        // x = 15
        /// </example>
        public static Funf<TResult> funf<TResult>(Func<dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, TResult> func) => new WFunf<TResult>(func);

        /// <summary>
        /// Creates a new <see cref="Funf"/> from a given
        /// <see cref="Func{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult}"/>
        /// </summary>
        /// <param name="func">Function that will be executed upon successful call</param>
        /// <returns>New <see cref="Funf"/></returns>
        /// <example>
        /// var f = Funf((a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13, a14, a15, a16) => a1 + a2 + a3 + a4 + a5 + a6 + a7 + a8 + a9 + a10 + a11 + a12 + a13 + a14 + a15 + a16);
        /// var x = call(f, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1);        // x = 16
        /// </example>
        public static Funf<TResult> funf<TResult>(Func<dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, TResult> func) => new WFunf<TResult>(func);

        #endregion

        /// <summary>
        /// Simple wrapped dotnet function
        /// </summary>
        internal readonly struct WFunf<TResult> : Funf<TResult>
        {
            #region Constructors

            public WFunf(Func<TResult> func)
            {
                this.Func = func;
                this.arity = 0;
            }

            public WFunf(Func<dynamic, TResult> func)
            {
                this.Func = func;
                this.arity = 1;
            }

            public WFunf(Func<dynamic, dynamic, TResult> func)
            {
                this.Func = func;
                this.arity = 2;
            }

            public WFunf(Func<dynamic, dynamic, dynamic, TResult> func)
            {
                this.Func = func;
                this.arity = 3;
            }

            public WFunf(Func<dynamic, dynamic, dynamic, dynamic, TResult> func)
            {
                this.Func = func;
                this.arity = 4;
            }

            public WFunf(Func<dynamic, dynamic, dynamic, dynamic, dynamic, TResult> func)
            {
                this.Func = func;
                this.arity = 5;
            }

            public WFunf(Func<dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, TResult> func)
            {
                this.Func = func;
                this.arity = 6;
            }

            public WFunf(Func<dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, TResult> func)
            {
                this.Func = func;
                this.arity = 7;
            }

            public WFunf(Func<dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, TResult> func)
            {
                this.Func = func;
                this.arity = 8;
            }

            public WFunf(Func<dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, TResult> func)
            {
                this.Func = func;
                this.arity = 9;
            }

            public WFunf(Func<dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, TResult> func)
            {
                this.Func = func;
                this.arity = 10;
            }

            public WFunf(Func<dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, TResult> func)
            {
                this.Func = func;
                this.arity = 11;
            }

            public WFunf(Func<dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, TResult> func)
            {
                this.Func = func;
                this.arity = 12;
            }

            public WFunf(Func<dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, TResult> func)
            {
                this.Func = func;
                this.arity = 13;
            }

            public WFunf(Func<dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, TResult> func)
            {
                this.Func = func;
                this.arity = 14;
            }

            public WFunf(Func<dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, TResult> func)
            {
                this.Func = func;
                this.arity = 15;
            }

            public WFunf(Func<dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, TResult> func)
            {
                this.Func = func;
                this.arity = 16;
            }

            #endregion

            public dynamic Func { get; }

            public int arity { get; }
            private IEnumerable<dynamic> args => new dynamic[0];

            public CallResult<TResult> invoke_func(IEnumerable<dynamic> args) => invoke_func(args.ToArray());
            public CallResult<TResult> invoke_func(params dynamic[] args) => args.Length switch
            {
                int l when l > arity => full_call_result((TResult)this.Func.DynamicInvoke(args.Take(arity).ToArray()), args.Skip(arity)),
                int l when l == arity => full_call_result((TResult)this.Func.DynamicInvoke(args), new dynamic[0]),
                _ => partial_call_result(capture(this, args)),
            };
        }

        /// <summary>
        /// A function that encloses some captured args
        /// </summary>
        private readonly struct CapFunf<TResult> : Funf<TResult>
        {
            public CapFunf(Funf<TResult> f, IEnumerable<dynamic> args, int arity)
            {
                this.f = f;
                this.args = args;
                this.arity = arity;
            }

            private Funf<TResult> f { get; }
            private IEnumerable<dynamic> args { get; }
            public int arity { get; }

            public CallResult<TResult> collect_args_and_call(params dynamic[] moreArgs) => this.collect_args_and_call(moreArgs.AsEnumerable());
            public CallResult<TResult> collect_args_and_call(IEnumerable<dynamic> moreArgs) => call(f, this.args.Concat(moreArgs));
        }

        /// <summary>
        /// Composed function that, when executed, will pass its outcome to another function
        /// </summary>
        private readonly struct CompFunf<TFResult> : Funf<TFResult>
        {
            public CompFunf(Funf<TFResult> f, Funf<dynamic> g, int arity, IEnumerable<dynamic> args)
            {
                this.f = f;
                this.g = g;
                this.args = args;
                this.arity = arity;
            }

            private Funf<TFResult> f { get; }
            private Funf<dynamic> g { get; }
            private IEnumerable<dynamic> args { get; }
            public int arity { get; }


            public CallResult<TFResult> collect_args_and_call(params dynamic[] moreArgs) => this.collect_args_and_call(moreArgs.AsEnumerable());
            public CallResult<TFResult> collect_args_and_call(IEnumerable<dynamic> moreArgs)
            {
                var allArgs = this.args.Concat(moreArgs).ToArray();
                return allArgs.Length switch
                {
                    var l when l < g.arity => partial_call_result(new CompFunf<TFResult>(f, g, f.arity + g.arity - l, allArgs)),
                    _ => call(g, allArgs) switch
                    {
                        (CallResultType.Full, var result, var overflow_args) => call(f, Enumerable.Prepend(overflow_args, result)),
                        (_, Funf closure) => call(f, allArgs.Prepend(closure))
                    },
                };
            }
        }

        public interface Funf<out TResult> : Funf
        {
            //public static Funf<TResult> operator <(Funf<TResult> f, Funf g) => compose(f, g);

            //public static Funf<TResult> operator >(Funf f, Funf<TResult> g) => compose(g, f);

            ///// <summary>
            ///// Back pipe
            ///// </summary>
            ///// <param name="f"><see cref="Funf"/> which should receive the args piped from the right</param>
            ///// <param name="args">Args that should be piped to <paramref name="f"/></param>
            ///// <returns></returns>
            //public static Funf<TResult> operator <(Funf<TResult> f, IEnumerable<dynamic> args) => capture(f, args);

            ///// <summary>
            ///// Forward pipe
            ///// </summary>
            ///// <param name="args">Args that should be piped to <paramref name="f"/></param>
            ///// <param name="f"><see cref="Funf"/> that should recevie the piped args</param>
            ///// <returns></returns>
            //public static Funf<TResult> operator >(Funf<TResult> f, IEnumerable<dynamic> args) => args switch
            //{
            //    //       Funf<TResult> g => capture(g, f),
            //    _ => funf(() => args.Append(f)),
            //};
        }
    }
}
