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

using static Funship.Fist;

namespace Funship
{
    public partial interface Funf
    {
        /// <summary>
        /// Number of arguments the <see cref="Funf"/> needs before execution can complete
        /// </summary>
        int arity { get; }

        IEnumerable<dynamic> args { get; }

        /// <summary>
        /// Gets a version of the <see cref="Funf"/> that is partially called with the given set of arguments.
        /// </summary>
        /// <remarks>
        /// All arguments may be supplied, in which case the return Funf may be executed at any time by calling
        /// <see cref="call"/> with no arguments.
        ///
        /// Differs from <see cref="call(dynamic[])"/> in these ways:
        /// 1. The <see cref="Funf"/> will never be executed.
        /// 2. A new <see cref="Funf"/> will be created with the new set of collected arguments, but no additional hierarchy depth of closures will be created.
        /// </remarks>
        /// <param name="args"></param>
        /// <returns>Partially called <see cref="Funf"/></returns>
        //public Funf this[params dynamic[] args] { get; }

        /// <summary>
        /// If length of <paramref name="args"/> matches <see cref="arity"/>, then executes the <see cref="Funf"/> and returns
        /// the result. Otherwise, returns a <see cref="Funf"/> that is partially called with the given set of arguments.
        /// </summary>
        /// <remarks>
        /// Differs from <see cref="this[dynamic[]]"/> in these ways:
        /// 1. The <see cref="Funf"/> will be executed if enough arguments are passed.
        /// 2. If too few arguments are passed, then a new closure is created that encloses the arguments received so far and that expects the remaining arguments.
        /// 3. If too many arguments are passed, then execution will occur. The return value will be converted into a Funf if necessary, and <see cref="call(dynamic[])"/> will be invoked with the remaining arguments.
        /// </remarks>
        /// <param name="args"></param>
        /// <returns></returns>
        dynamic call();

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
                this.Func = func;
                this.arity = 0;
            }

            internal WFunf(Func<dynamic, dynamic> func)
            {
                this.Func = func ?? (x => x);
                this.arity = 1;
            }

            internal WFunf(Func<dynamic, dynamic, dynamic> func)
            {
                this.Func = func ?? ((x1, x2) => (x1, x2));
                this.arity = 2;
            }

            internal WFunf(Func<dynamic, dynamic, dynamic, dynamic> func)
            {
                this.Func = func ?? ((x1, x2, x3) => (x1, x2, x3));
                this.arity = 3;
            }

            internal WFunf(Func<dynamic, dynamic, dynamic, dynamic, dynamic> func)
            {
                this.Func = func ?? ((x1, x2, x3, x4) => (x1, x2, x3, x4));
                this.arity = 4;
            }

            internal WFunf(Func<dynamic, dynamic, dynamic, dynamic, dynamic, dynamic> func)
            {
                this.Func = func ?? ((x1, x2, x3, x4, x5) => (x1, x2, x3, x4, x5));
                this.arity = 5;
            }

            internal WFunf(Func<dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic> func)
            {
                this.Func = func ?? ((x1, x2, x3, x4, x5, x6) => (x1, x2, x3, x4, x5, x6));
                this.arity = 6;
            }

            internal WFunf(Func<dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic> func)
            {
                this.Func = func ?? ((x1, x2, x3, x4, x5, x6, x7) => (x1, x2, x3, x4, x5, x6, x7));
                this.arity = 7;
            }

            internal WFunf(Func<dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic> func)
            {
                this.Func = func ?? ((x1, x2, x3, x4, x5, x6, x7, x8) => (x1, x2, x3, x4, x5, x6, x7, x8));
                this.arity = 8;
            }

            internal WFunf(Func<dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic> func)
            {
                this.Func = func ?? ((x1, x2, x3, x4, x5, x6, x7, x8, x9) => (x1, x2, x3, x4, x5, x6, x7, x8, x9));
                this.arity = 9;
            }

            internal WFunf(Func<dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic> func)
            {
                this.Func = func ?? ((x1, x2, x3, x4, x5, x6, x7, x8, x9, x10) => (x1, x2, x3, x4, x5, x6, x7, x8, x9, x10));
                this.arity = 10;
            }

            internal WFunf(Func<dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic> func)
            {
                this.Func = func ?? ((x1, x2, x3, x4, x5, x6, x7, x8, x9, x10, x11) => (x1, x2, x3, x4, x5, x6, x7, x8, x9, x10, x11));
                this.arity = 11;
            }

            internal WFunf(Func<dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic> func)
            {
                this.Func = func ?? ((x1, x2, x3, x4, x5, x6, x7, x8, x9, x10, x11, x12) => (x1, x2, x3, x4, x5, x6, x7, x8, x9, x10, x11, x12));
                this.arity = 12;
            }

            internal WFunf(Func<dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic> func)
            {
                this.Func = func ?? ((x1, x2, x3, x4, x5, x6, x7, x8, x9, x10, x11, x12, x13) => (x1, x2, x3, x4, x5, x6, x7, x8, x9, x10, x11, x12, x13));
                this.arity = 13;
            }

            internal WFunf(Func<dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic> func)
            {
                this.Func = func ?? ((x1, x2, x3, x4, x5, x6, x7, x8, x9, x10, x11, x12, x13, x14) => (x1, x2, x3, x4, x5, x6, x7, x8, x9, x10, x11, x12, x13, x14));
                this.arity = 14;
            }

            internal WFunf(Func<dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic> func)
            {
                this.Func = func ?? ((x1, x2, x3, x4, x5, x6, x7, x8, x9, x10, x11, x12, x13, x14, x15) => (x1, x2, x3, x4, x5, x6, x7, x8, x9, x10, x11, x12, x13, x14, x15));
                this.arity = 15;
            }

            internal WFunf(Func<dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic> func)
            {
                this.Func = func ?? ((x1, x2, x3, x4, x5, x6, x7, x8, x9, x10, x11, x12, x13, x14, x15, x16) => (x1, x2, x3, x4, x5, x6, x7, x8, x9, x10, x11, x12, x13, x14, x15, x16));
                this.arity = 16;
            }

            internal WFunf(params dynamic[] args) : this(() => args) { }

            #endregion

            private dynamic Func { get; }

            public int arity { get; }
            public IEnumerable<dynamic> args => nilf;

            dynamic Funf.call() => invoke_func();

            public dynamic invoke_func(IEnumerable<dynamic> args) => invoke_func(args.ToArray());
            public dynamic invoke_func(params dynamic[] args) => args.Length switch
            {
                int l when l > arity => Enumerable.Prepend(args.Skip(arity), this.Func.DynamicInvoke(args.Take(arity).ToArray())),
                int l when l == arity => this.Func.DynamicInvoke(args),
                _ => capture(this, args),
            };
        }

        /// <summary>
        /// Partially called function that has some args set and expects the rest
        /// </summary>
        private readonly struct PFunf : Funf
        {
            public PFunf(Funf fun, IEnumerable<dynamic> args, int arity)
            {
                this.f = fun;
                this.args = args;
                this.arity = arity;
            }

            private Funf f { get; }
            public IEnumerable<dynamic> args { get; }
            public int arity { get; }
            dynamic Funf.call() => this.collect_args_and_call();

            public dynamic collect_args_and_call(params dynamic[] moreArgs) => this.collect_args_and_call(moreArgs.AsEnumerable());
            public dynamic collect_args_and_call(IEnumerable<dynamic> moreArgs) => call(f, this.args.Concat(moreArgs));
        }

        /// <summary>
        /// Composed function that, when executed, will pass its outcome to another function
        /// </summary>
        private readonly struct CFunf : Funf
        {
            public CFunf(Funf f, Funf g, int arity, IEnumerable<dynamic> args)
            {
                this.f = f;
                this.g = g;
                this.args = args;
                this.arity = arity;
            }

            private Funf f { get; }
            private Funf g { get; }
            public IEnumerable<dynamic> args { get; }
            public int arity { get; }
            dynamic Funf.call() => this.collect_args_and_call();


            public dynamic collect_args_and_call(params dynamic[] moreArgs) => this.collect_args_and_call(moreArgs.AsEnumerable());
            public dynamic collect_args_and_call(IEnumerable<dynamic> moreArgs)
            {
                var allArgs = this.args.Concat(moreArgs).ToArray();
                return allArgs.Length switch
                {
                    var l when l < f.arity => new CFunf(f, g, f.arity + g.arity - l, allArgs),
                    _ => call(g, call(f, allArgs))
                };
            }
        }
    }
}
