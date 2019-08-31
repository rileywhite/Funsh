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

using static Funship.Fist;

namespace Funship
{
    public interface Funf
    {
        dynamic x(params dynamic[] args);

        #region Factories

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

        private readonly struct WFunf : Funf
        {
            #region Constructors

            internal WFunf(Func<dynamic, dynamic> func)
            {
                this.Func = func;
                this.ParameterCount = 1;
            }

            internal WFunf(Func<dynamic, dynamic, dynamic> func)
            {
                this.Func = func;
                this.ParameterCount = 2;
            }

            internal WFunf(Func<dynamic, dynamic, dynamic, dynamic> func)
            {
                this.Func = func;
                this.ParameterCount = 3;
            }

            internal WFunf(Func<dynamic, dynamic, dynamic, dynamic, dynamic> func)
            {
                this.Func = func;
                this.ParameterCount = 4;
            }

            internal WFunf(Func<dynamic, dynamic, dynamic, dynamic, dynamic, dynamic> func)
            {
                this.Func = func;
                this.ParameterCount = 5;
            }

            internal WFunf(Func<dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic> func)
            {
                this.Func = func;
                this.ParameterCount = 6;
            }

            internal WFunf(Func<dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic> func)
            {
                this.Func = func;
                this.ParameterCount = 7;
            }

            internal WFunf(Func<dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic> func)
            {
                this.Func = func;
                this.ParameterCount = 8;
            }

            internal WFunf(Func<dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic> func)
            {
                this.Func = func;
                this.ParameterCount = 9;
            }

            internal WFunf(Func<dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic> func)
            {
                this.Func = func;
                this.ParameterCount = 10;
            }

            internal WFunf(Func<dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic> func)
            {
                this.Func = func;
                this.ParameterCount = 11;
            }

            internal WFunf(Func<dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic> func)
            {
                this.Func = func;
                this.ParameterCount = 12;
            }

            internal WFunf(Func<dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic> func)
            {
                this.Func = func;
                this.ParameterCount = 13;
            }

            internal WFunf(Func<dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic> func)
            {
                this.Func = func;
                this.ParameterCount = 14;
            }

            internal WFunf(Func<dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic> func)
            {
                this.Func = func;
                this.ParameterCount = 15;
            }

            internal WFunf(Func<dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic> func)
            {
                this.Func = func;
                this.ParameterCount = 16;
            }

            #endregion

            private dynamic Func { get; }
            private int ParameterCount { get; }

            public dynamic x(params dynamic[] args)
            {
                if (args.Length == this.ParameterCount) { return this.Func.DynamicInvoke(args); }

                return new NFunf(this, args);
            }
        }

        private readonly struct NFunf : Funf
        {
            internal NFunf(Funf fun, params dynamic[] args)
            {
                this.Fun = fun;
                this.Args = args;
            }

            private Funf Fun { get; }
            private dynamic[] Args { get; }

            public dynamic x(params dynamic[] args) => this.Fun.x(this.Args.Concat(args).ToArray());
        }

        //public static Funf curry<T1, TResult>(Func<T1, TResult> func)
        //{
        //    return new WFunf01<T1>(t1 => func(t1)); 
        //}

        //public static Funf curry<T1, T2, TResult>(Func<T1, T2, TResult> func)
        //{
        //    return new WFunf01<T1>(t1 => curry<T2, TResult>(t2 => func(t1, t2)));
        //}

        //public static Funf curry<T1, T2, TResult>(Func<T1, T2, TResult> func)
        //{
        //    return new WFunf01<T1>(t1 => curry<T2, TResult>(t2 => func(t1, t2)));
        //}
    }
}
