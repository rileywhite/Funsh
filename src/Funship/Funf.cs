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
using System.Linq;

namespace Funship
{
    public interface Funf
    {
        /// <summary>
        /// Number of arguments the <see cref="Funf"/> needs before execution can complete
        /// </summary>
        int arity { get; }

        /// <summary>
        /// Gets a version of the <see cref="Funf"/> that is partially called with the given set of arguments.
        /// </summary>
        /// <remarks>
        /// All arguments may be supplied, in which case the return Funf may be executed at any time by calling
        /// <see cref="x"/> with no arguments.
        ///
        /// Differs from <see cref="x(dynamic[])"/> in these ways:
        /// 1. The <see cref="Funf"/> will never be executed.
        /// 2. A new <see cref="Funf"/> will be created with the new set of collected arguments, but no additional hierarchy depth of closures will be created.
        /// </remarks>
        /// <param name="args"></param>
        /// <returns>Partially called <see cref="Funf"/></returns>
        public Funf this[params dynamic[] args] { get; }

        /// <summary>
        /// If length of <paramref name="args"/> matches <see cref="arity"/>, then executes the <see cref="Funf"/> and returns
        /// the result. Otherwise, returns a <see cref="Funf"/> that is partially called with the given set of arguments.
        /// </summary>
        /// <remarks>
        /// Differs from <see cref="this[dynamic[]]"/> in these ways:
        /// 1. The <see cref="Funf"/> will be executed if enough arguments are passed.
        /// 2. If too few arguments are passed, then a new closure is created that encloses the arguments received so far and that expects the remaining arguments.
        /// 3. If too many arguments are passed, then execution will occur. The return value will be converted into a Funf if necessary, and <see cref="x(dynamic[])"/> will be invoked with the remaining arguments.
        /// </remarks>
        /// <param name="args"></param>
        /// <returns></returns>
        dynamic x(params dynamic[] args);

        #region Factories

        public static Funf funf(Func<dynamic> func) => new WFunf(func);
        public static Funf funf(Func<dynamic, dynamic> func) => new WFunf(func);
        public static Funf funf(Func<dynamic, dynamic, dynamic> func) => new WFunf(func);
        public static Funf funf(Func<dynamic, dynamic, dynamic, dynamic> func) => new WFunf(func);
        public static Funf funf(Func<dynamic, dynamic, dynamic, dynamic, dynamic> func) => new WFunf(func);
        public static Funf funf(Func<dynamic, dynamic, dynamic, dynamic, dynamic, dynamic> func) => new WFunf(func);
        public static Funf funf(Func<dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic> func) => new WFunf(func);
        public static Funf funf(Func<dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic> func) => new WFunf(func);
        public static Funf funf(Func<dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic> func) => new WFunf(func);
        public static Funf funf(Func<dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic> func) => new WFunf(func);
        public static Funf funf(Func<dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic> func) => new WFunf(func);
        public static Funf funf(Func<dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic> func) => new WFunf(func);
        public static Funf funf(Func<dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic> func) => new WFunf(func);
        public static Funf funf(Func<dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic> func) => new WFunf(func);
        public static Funf funf(Func<dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic> func) => new WFunf(func);
        public static Funf funf(Func<dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic> func) => new WFunf(func);
        public static Funf funf(Func<dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic> func) => new WFunf(func);

        #endregion

        /// <summary>
        /// Simple wrapped Func<>
        /// </summary>
        private readonly struct WFunf : Funf
        {
            #region Constructors

            internal WFunf(Func<dynamic> func)
            {
                this.Func = func ?? (() => ValueTuple.Create());
                this.ParameterCount = 0;
            }

            internal WFunf(Func<dynamic, dynamic> func)
            {
                this.Func = func ?? (x => x);
                this.ParameterCount = 1;
            }

            internal WFunf(Func<dynamic, dynamic, dynamic> func)
            {
                this.Func = func ?? ((x1, x2) => (x1, x2));
                this.ParameterCount = 2;
            }

            internal WFunf(Func<dynamic, dynamic, dynamic, dynamic> func)
            {
                this.Func = func ?? ((x1, x2, x3) => (x1, x2, x3));
                this.ParameterCount = 3;
            }

            internal WFunf(Func<dynamic, dynamic, dynamic, dynamic, dynamic> func)
            {
                this.Func = func ?? ((x1, x2, x3, x4) => (x1, x2, x3, x4));
                this.ParameterCount = 4;
            }

            internal WFunf(Func<dynamic, dynamic, dynamic, dynamic, dynamic, dynamic> func)
            {
                this.Func = func ?? ((x1, x2, x3, x4, x5) => (x1, x2, x3, x4, x5));
                this.ParameterCount = 5;
            }

            internal WFunf(Func<dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic> func)
            {
                this.Func = func ?? ((x1, x2, x3, x4, x5, x6) => (x1, x2, x3, x4, x5, x6));
                this.ParameterCount = 6;
            }

            internal WFunf(Func<dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic> func)
            {
                this.Func = func ?? ((x1, x2, x3, x4, x5, x6, x7) => (x1, x2, x3, x4, x5, x6, x7));
                this.ParameterCount = 7;
            }

            internal WFunf(Func<dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic> func)
            {
                this.Func = func ?? ((x1, x2, x3, x4, x5, x6, x7, x8) => (x1, x2, x3, x4, x5, x6, x7, x8));
                this.ParameterCount = 8;
            }

            internal WFunf(Func<dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic> func)
            {
                this.Func = func ?? ((x1, x2, x3, x4, x5, x6, x7, x8, x9) => (x1, x2, x3, x4, x5, x6, x7, x8, x9));
                this.ParameterCount = 9;
            }

            internal WFunf(Func<dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic> func)
            {
                this.Func = func ?? ((x1, x2, x3, x4, x5, x6, x7, x8, x9, x10) => (x1, x2, x3, x4, x5, x6, x7, x8, x9, x10));
                this.ParameterCount = 10;
            }

            internal WFunf(Func<dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic> func)
            {
                this.Func = func ?? ((x1, x2, x3, x4, x5, x6, x7, x8, x9, x10, x11) => (x1, x2, x3, x4, x5, x6, x7, x8, x9, x10, x11));
                this.ParameterCount = 11;
            }

            internal WFunf(Func<dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic> func)
            {
                this.Func = func ?? ((x1, x2, x3, x4, x5, x6, x7, x8, x9, x10, x11, x12) => (x1, x2, x3, x4, x5, x6, x7, x8, x9, x10, x11, x12));
                this.ParameterCount = 12;
            }

            internal WFunf(Func<dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic> func)
            {
                this.Func = func ?? ((x1, x2, x3, x4, x5, x6, x7, x8, x9, x10, x11, x12, x13) => (x1, x2, x3, x4, x5, x6, x7, x8, x9, x10, x11, x12, x13));
                this.ParameterCount = 13;
            }

            internal WFunf(Func<dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic> func)
            {
                this.Func = func ?? ((x1, x2, x3, x4, x5, x6, x7, x8, x9, x10, x11, x12, x13, x14) => (x1, x2, x3, x4, x5, x6, x7, x8, x9, x10, x11, x12, x13, x14));
                this.ParameterCount = 14;
            }

            internal WFunf(Func<dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic> func)
            {
                this.Func = func ?? ((x1, x2, x3, x4, x5, x6, x7, x8, x9, x10, x11, x12, x13, x14, x15) => (x1, x2, x3, x4, x5, x6, x7, x8, x9, x10, x11, x12, x13, x14, x15));
                this.ParameterCount = 15;
            }

            internal WFunf(Func<dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic> func)
            {
                this.Func = func ?? ((x1, x2, x3, x4, x5, x6, x7, x8, x9, x10, x11, x12, x13, x14, x15, x16) => (x1, x2, x3, x4, x5, x6, x7, x8, x9, x10, x11, x12, x13, x14, x15, x16));
                this.ParameterCount = 16;
            }

            internal WFunf(params dynamic[] args) : this(() => args) { }

            #endregion

            private dynamic Func { get; }
            private int ParameterCount { get; }

            public int arity => this.ParameterCount;

            public Funf this[params dynamic[] args] => new PFunf(this, args);

            public dynamic x(params dynamic[] args) => args.Length switch
            {
                var l when l == this.ParameterCount => this.Func.DynamicInvoke(args),
                var l when l < this.ParameterCount =>
                    (this, this.ParameterCount - l) switch
                    {
                        (var self, 1) => new WFunf((arg1) => self.x(args.Concat(new[] { arg1 }).ToArray())),
                        (var self, 2) => new WFunf((arg1, arg2) => self.x(args.Concat(new[] { arg1, arg2 }).ToArray())),
                        (var self, 3) => new WFunf((arg1, arg2, arg3) => self.x(args.Concat(new[] { arg1, arg2, arg3 }).ToArray())),
                        (var self, 4) => new WFunf((arg1, arg2, arg3, arg4) => self.x(args.Concat(new[] { arg1, arg2, arg3, arg4 }).ToArray())),
                        (var self, 5) => new WFunf((arg1, arg2, arg3, arg4, arg5) => self.x(args.Concat(new[] { arg1, arg2, arg3, arg4, arg5 }).ToArray())),
                        (var self, 6) => new WFunf((arg1, arg2, arg3, arg4, arg5, arg6) => self.x(args.Concat(new[] { arg1, arg2, arg3, arg4, arg5, arg6 }).ToArray())),
                        (var self, 7) => new WFunf((arg1, arg2, arg3, arg4, arg5, arg6, arg7) => self.x(args.Concat(new[] { arg1, arg2, arg3, arg4, arg5, arg6, arg7 }).ToArray())),
                        (var self, 8) => new WFunf((arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8) => self.x(args.Concat(new[] { arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8 }).ToArray())),
                        (var self, 9) => new WFunf((arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9) => self.x(args.Concat(new[] { arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9 }).ToArray())),
                        (var self, 10) => new WFunf((arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10) => self.x(args.Concat(new[] { arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10 }).ToArray())),
                        (var self, 11) => new WFunf((arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11) => self.x(args.Concat(new[] { arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11 }).ToArray())),
                        (var self, 12) => new WFunf((arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12) => self.x(args.Concat(new[] { arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12 }).ToArray())),
                        (var self, 13) => new WFunf((arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13) => self.x(args.Concat(new[] { arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13 }).ToArray())),
                        (var self, 14) => new WFunf((arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14) => self.x(args.Concat(new[] { arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14 }).ToArray())),
                        (var self, 15) => new WFunf((arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15) => self.x(args.Concat(new[] { arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15 }).ToArray())),
                        (var self, 16) => new WFunf((arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15, arg16) => self.x(args.Concat(new[] { arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15, arg16 }).ToArray())),
                        (var self, var n) => throw new ArgumentException($"Only up to 16 parameters can be passed to the next method. {n} parameters were passed."),
                    },
                _ =>
                    this.Func.DynamicInvoke(args.Take(this.ParameterCount).ToArray()) switch
                    {
                        Funf fun => new WFunf(fun).x(args.Skip(this.ParameterCount).ToArray()),
                        Func<object> func => new WFunf(() => func()).x(args.Skip(this.ParameterCount).ToArray()),
                        Func<object, object> func => new WFunf((arg) => func(arg)).x(args.Skip(this.ParameterCount).ToArray()),
                        Func<object, object, object> func => new WFunf((arg1, arg2) => func(arg1, arg2)).x(args.Skip(this.ParameterCount).ToArray()),
                        Func<object, object, object, object> func => new WFunf((arg1, arg2, arg3) => func(arg1, arg2, arg3)).x(args.Skip(this.ParameterCount).ToArray()),
                        Func<object, object, object, object, object> func => new WFunf((arg1, arg2, arg3, arg4) => func(arg1, arg2, arg3, arg4)).x(args.Skip(this.ParameterCount).ToArray()),
                        Func<object, object, object, object, object, object> func => new WFunf((arg1, arg2, arg3, arg4, arg5) => func(arg1, arg2, arg3, arg4, arg5)).x(args.Skip(this.ParameterCount).ToArray()),
                        Func<object, object, object, object, object, object, object> func => new WFunf((arg1, arg2, arg3, arg4, arg5, arg6) => func(arg1, arg2, arg3, arg4, arg5, arg6)).x(args.Skip(this.ParameterCount).ToArray()),
                        Func<object, object, object, object, object, object, object, object> func => new WFunf((arg1, arg2, arg3, arg4, arg5, arg6, arg7) => func(arg1, arg2, arg3, arg4, arg5, arg6, arg7)).x(args.Skip(this.ParameterCount).ToArray()),
                        Func<object, object, object, object, object, object, object, object, object> func => new WFunf((arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8) => func(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8)).x(args.Skip(this.ParameterCount).ToArray()),
                        Func<object, object, object, object, object, object, object, object, object, object> func => new WFunf((arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9) => func(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9)).x(args.Skip(this.ParameterCount).ToArray()),
                        Func<object, object, object, object, object, object, object, object, object, object, object> func => new WFunf((arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10) => func(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10)).x(args.Skip(this.ParameterCount).ToArray()),
                        Func<object, object, object, object, object, object, object, object, object, object, object, object> func => new WFunf((arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11) => func(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11)).x(args.Skip(this.ParameterCount).ToArray()),
                        Func<object, object, object, object, object, object, object, object, object, object, object, object, object> func => new WFunf((arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12) => func(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12)).x(args.Skip(this.ParameterCount).ToArray()),
                        Func<object, object, object, object, object, object, object, object, object, object, object, object, object, object> func => new WFunf((arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13) => func(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13)).x(args.Skip(this.ParameterCount).ToArray()),
                        Func<object, object, object, object, object, object, object, object, object, object, object, object, object, object, object> func => new WFunf((arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14) => func(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14)).x(args.Skip(this.ParameterCount).ToArray()),
                        Func<object, object, object, object, object, object, object, object, object, object, object, object, object, object, object, object> func => new WFunf((arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15) => func(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15)).x(args.Skip(this.ParameterCount).ToArray()),
                        Func<object, object, object, object, object, object, object, object, object, object, object, object, object, object, object, object, object> func => new WFunf((arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15, arg16) => func(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15, arg16)).x(args.Skip(this.ParameterCount).ToArray()),
                        var any => new PFunf(new WFunf(any),args.Skip(this.ParameterCount).ToArray()),
                    }
            };
        }

        /// <summary>
        /// Partially called function that has some args set and expects the rest
        /// </summary>
        private readonly struct PFunf : Funf
        {
            internal PFunf(Funf fun, params dynamic[] args)
            {
                this.Fun = fun ?? new WFunf();
                this.Args = args;
            }

            private Funf Fun { get; }
            private dynamic[] Args { get; }

            public int arity => this.Fun.arity - this.Args.Length;

            public Funf this[params dynamic[] args]
            {
                get => this.Fun[this.Args.Concat(args).ToArray()];
            }

            public dynamic x(params dynamic[] args) => this.Fun.x(this.Args.Concat(args).ToArray());
        }
    }
}
