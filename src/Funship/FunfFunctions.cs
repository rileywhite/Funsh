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
        /// Composes <paramref name="f"/> and <paramref name="g"/> to create a new
        /// <see cref="Funf"/> that applies its arguments first to <paramref name="f"/> and
        /// then to <paramref name="g"/>. The result of <paramref name="f"/> becomes one of the
        /// arguments passed to <paramref name="g"/>.
        /// </summary>
        /// <param name="f"><see cref="Funf"/> to which arguments will be applied first and whose result will become an argument to <paramref name="g"/></param>
        /// <param name="g"><see cref="Funf"/> to which arguments will be applied second, including the result from <paramref name="f"/></param>
        /// <returns>New composed <see cref="Funf"/></returns>
        /// <remarks>
        /// The mathematical description of composed functions is: <c>h(x) -> g(f(x))</c>.
        /// If <paramref name="f"/> and <paramref name="g"/> each take one argument, then that
        /// is exactly what you will get upon calling the composed <see cref="Funf"/>.
        /// </remarks>
        /// <example>
        /// var f = funf(x => x - 2);
        /// var g = funf(y => y * 2);
        ///
        /// var h = compose(f, g);      // h(x) -> g(f(x))
        /// var x = call(h, 10);        // x = 16
        /// 
        /// var i = compose(h, f);      // i(x) -> f(h(x)) -> f(g(f(x)))
        /// var y = call(i, 10);        // y = 14
        /// </example>
        public static Funf<TFResult> compose<TFResult, TGResult>(Funf<TFResult> f, Funf<TGResult> g)
        {
            return (f.arity, f.overflow_args.Any(), g.arity, g.overflow_args.Any()) switch
            {
                (1, false, var b, false) when b >= 0 /* when condition should always be true here */ => b switch
                {
                    0 => WFunf<TFResult>.create(compose_func_0<TFResult>(f.func, g.func)),
                    1 => WFunf<TFResult>.create(compose_func_1<TFResult>(f.func, g.func)),
                    2 => WFunf<TFResult>.create(compose_func_2<TFResult>(f.func, g.func)),
                    3 => WFunf<TFResult>.create(compose_func_3<TFResult>(f.func, g.func)),
                    4 => WFunf<TFResult>.create(compose_func_4<TFResult>(f.func, g.func)),
                    5 => WFunf<TFResult>.create(compose_func_5<TFResult>(f.func, g.func)),
                    6 => WFunf<TFResult>.create(compose_func_6<TFResult>(f.func, g.func)),
                    7 => WFunf<TFResult>.create(compose_func_7<TFResult>(f.func, g.func)),
                    8 => WFunf<TFResult>.create(compose_func_8<TFResult>(f.func, g.func)),
                    9 => WFunf<TFResult>.create(compose_func_9<TFResult>(f.func, g.func)),
                    10 => WFunf<TFResult>.create(compose_func_10<TFResult>(f.func, g.func)),
                    11 => WFunf<TFResult>.create(compose_func_11<TFResult>(f.func, g.func)),
                    12 => WFunf<TFResult>.create(compose_func_12<TFResult>(f.func, g.func)),
                    13 => WFunf<TFResult>.create(compose_func_13<TFResult>(f.func, g.func)),
                    14 => WFunf<TFResult>.create(compose_func_14<TFResult>(f.func, g.func)),
                    15 => WFunf<TFResult>.create(compose_func_15<TFResult>(f.func, g.func)),
                    16 => WFunf<TFResult>.create(compose_func_16<TFResult>(f.func, g.func)),
                    _ => throw new NotSupportedException($"Cannot create a composed function with {b} arguments"),
                },
                //(var a, _, 0, _) => throw new NotImplementedException($"({f.arity}, {f.overflow_args.Any()}, {g.arity}, {g.overflow_args.Any()})"), // a > 0
                //(0, _, var b, _) => throw new NotImplementedException($"({f.arity}, {f.overflow_args.Any()}, {g.arity}, {g.overflow_args.Any()})"), // b > 0
                //(var a, false, var b, false) => (a + b - 1) switch // a > 0 && b > 0, so a + b - 1 >= 1
                //{
                //    _ => throw new NotImplementedException(),
                //},
                _ => throw new NotSupportedException(
                    $"Unexpected combination of arities and overflows: ({f.arity}, {f.overflow_args.Any()}, {g.arity}, {g.overflow_args.Any()})"),
            };
            //var arity = f.arity + g.arity - 1;

            //return arity switch
            //{
            //    0 => new WFunf(compose_func_0(f, g), arity, arity >= 0 ? Enumerable.Empty<dynamic>() : ),
            //    1 => funf(compose_func_1(f, g)),
            //    2 => funf(compose_func_2<TFResult>(f.func, g.func)),
            //    3 => funf(compose_func_3<TFResult>(f.func, g.func)),
            //    4 => funf(compose_func_4<TFResult>(f.func, g.func)),
            //    5 => funf(compose_func_5<TFResult>(f.func, g.func)),
            //    6 => funf(compose_func_6<TFResult>(f.func, g.func)),
            //    7 => funf(compose_func_7<TFResult>(f.func, g.func)),
            //    8 => funf(compose_func_8<TFResult>(f.func, g.func)),
            //    9 => funf(compose_func_9<TFResult>(f.func, g.func)),
            //    10 => funf(compose_func_10<TFResult>(f.func, g.func)),
            //    11 => funf(compose_func_11<TFResult>(f.func, g.func)),
            //    12 => funf(compose_func_12<TFResult>(f.func, g.func)),
            //    13 => funf(compose_func_13<TFResult>(f.func, g.func)),
            //    14 => funf(compose_func_14<TFResult>(f.func, g.func)),
            //    15 => funf(compose_func_15<TFResult>(f.func, g.func)),
            //    16 => funf(compose_func_16<TFResult>(f.func, g.func)),
            //    var l when l < 0 => funf(compose_func_0<TFResult>(f.func, g.func, g.arity, g.overflow_args)),
            //};
        }

        private static Func<TResult> compose_func_0<TResult>(Delegate f, Delegate g) =>
            () => __composed_func<TResult>(f, g, new object[0]);

        private static Func<dynamic, TResult> compose_func_1<TResult>(Delegate f, Delegate g) =>
            arg1 => __composed_func<TResult>(f, g, new object[] { arg1 });

        private static Func<dynamic, dynamic, TResult> compose_func_2<TResult>(Delegate f, Delegate g) =>
            (arg1, arg2) => __composed_func<TResult>(f, g, new object[] { arg1, arg2 });

        private static Func<dynamic, dynamic, dynamic, TResult> compose_func_3<TResult>(Delegate f, Delegate g) =>
            (arg1, arg2, arg3) => __composed_func<TResult>(f, g, new object[] { arg1, arg2, arg3 });

        private static Func<dynamic, dynamic, dynamic, dynamic, TResult> compose_func_4<TResult>(Delegate f, Delegate g) =>
            (arg1, arg2, arg3, arg4) => __composed_func<TResult>(f, g, new object[] { arg1, arg2, arg3, arg4 });

        private static Func<dynamic, dynamic, dynamic, dynamic, dynamic, TResult> compose_func_5<TResult>(Delegate f, Delegate g) =>
            (arg1, arg2, arg3, arg4, arg5) => __composed_func<TResult>(f, g, new object[] { arg1, arg2, arg3, arg4, arg5 });

        private static Func<dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, TResult> compose_func_6<TResult>(Delegate f, Delegate g) =>
            (arg1, arg2, arg3, arg4, arg5, arg6) => __composed_func<TResult>(f, g, new object[] { arg1, arg2, arg3, arg4, arg5, arg6 });

        private static Func<dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, TResult> compose_func_7<TResult>(Delegate f, Delegate g) =>
            (arg1, arg2, arg3, arg4, arg5, arg6, arg7) => __composed_func<TResult>(f, g, new object[] { arg1, arg2, arg3, arg4, arg5, arg6, arg7 });

        private static Func<dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, TResult> compose_func_8<TResult>(Delegate f, Delegate g) =>
            (arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8) => __composed_func<TResult>(f, g, new object[] { arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8 });

        private static Func<dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, TResult> compose_func_9<TResult>(Delegate f, Delegate g) =>
            (arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9) => __composed_func<TResult>(f, g, new object[] { arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9 });

        private static Func<dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, TResult> compose_func_10<TResult>(Delegate f, Delegate g) =>
            (arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10) => __composed_func<TResult>(f, g, new object[] { arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10 });

        private static Func<dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, TResult> compose_func_11<TResult>(Delegate f, Delegate g) =>
            (arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11) => __composed_func<TResult>(f, g, new object[] { arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11 });

        private static Func<dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, TResult> compose_func_12<TResult>(Delegate f, Delegate g) =>
            (arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12) => __composed_func<TResult>(f, g, new object[] { arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12 });

        private static Func<dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, TResult> compose_func_13<TResult>(Delegate f, Delegate g) =>
            (arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13) => __composed_func<TResult>(f, g, new object[] { arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13 });

        private static Func<dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, TResult> compose_func_14<TResult>(Delegate f, Delegate g) =>
            (arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14) => __composed_func<TResult>(f, g, new object[] { arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14 });

        private static Func<dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, TResult> compose_func_15<TResult>(Delegate f, Delegate g) =>
            (arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15) => __composed_func<TResult>(f, g, new object[] { arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15 });

        private static Func<dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, dynamic, TResult> compose_func_16<TResult>(Delegate f, Delegate g) =>
            (arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15, arg16) => __composed_func<TResult>(f, g, new object[] { arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15, arg16 });

        private static TResult __composed_func<TResult>(
            Delegate f,
            Delegate g,
            object[] args)
        {
            var g_result = g.DynamicInvoke(args);
            return (TResult)f.DynamicInvoke(g_result)!;
        }

        /// <summary>
        /// Creates a new <see cref="Funf"/> with passed args enclosed. 
        /// </summary>
        /// <param name="f"><see cref="Funf"/> which will be enclosed with the given arguments</param>
        /// <param name="args">Arguments </param>
        /// <returns>New <see cref="Funf"/> enclosing <paramref name="f"/> and the captured <paramref name="args"/></returns>
        /// <remarks>
        /// The <see cref="arity"/> of the new <see cref="Funf"/> will be reduced by the number of passed
        /// arguments. This may cause it to become negative, and that's okay.
        ///
        /// If any passed item in <paramref name="args"/> is a <see cref="Funf"/>, then it will be composed
        /// with the <paramref name="f"/> such that arguments following the new <see cref="Funf"/> will be
        /// applied to it first, and upon calling the returned <see cref="Funf"/>, the result from the passed
        /// <see cref="Funf"/> will become an argument that is sent to <paramref name="f"/>, replacing the
        /// passed <see cref="Funf"/> and any args that it may have consumed.
        /// </remarks>
        /// <example>
        /// var f = funf((x, y, z) => x + y - z);
        /// var g = capture(f, 2);
        /// var h = capture(g, 3);
        /// var i = capture(g, f, 10);
        ///
        /// var v = call(f, 5, 4, 18);  // v = -9
        /// var w = call(g, 4, 18);     // w = -12
        /// var x = call(h, 18);        // x = -13
        /// var y = call(i);            // y = -13
        /// var z = call(h, 18, 24, 30) // z = <see cref="IEnumerable{dynamic}"/> of [-13, 24, 30]
        /// </example>
        public static Funf<TResult> capture<TResult>(Funf<TResult> f, params dynamic[] args) => capture(f, fist((IEnumerable<dynamic>)args));
        private static Funf<TResult> capture<TResult>(Funf<TResult> f, IEnumerable<dynamic> args) => capture_and_compose(f, args) switch
        {
            (Funf<TResult> fun, var empty) when !empty.Any() => fun,
            (Funf<TResult> fun, var final_args) => throw new NotImplementedException(),
            //capture(new CapFunf<TResult>(fun, final_args, fun.arity - final_args.Count())),
        };

        /// <summary>
        /// Attempts to fully execute a <paramref name="f"/> using a combination of any enclosed args, which
        /// are applied first, and the passed <paramref name="args"/>.
        /// </summary>
        /// <param name="f"><see cref="Funf"/> to call</param>
        /// <param name="args">Arguments to apply in the call</param>
        /// <returns>
        /// If the number of arguments passed is fewer than <see cref="arity"/>, then a <see cref="Funf"/>
        /// is returned with the passed args captured.
        ///
        /// If the number of arguments passed is equal to <see cref="arity"/>, then the result of the execution
        /// is returned.
        ///
        /// If the number of arguments passes is greater than <see cref="arity"/>, then an <see cref="IEnumerable{dynamic}"/>
        /// is returned comprised of the result of executing <paramref name="f"/> followed by the unused values
        /// from <paramref name="args"/>.
        /// </returns>
        /// <remarks>
        /// If any passed item in <paramref name="args"/> is a <see cref="Funf"/>, then it will be composed
        /// with the <paramref name="f"/> such that arguments following the new <see cref="Funf"/> will be
        /// applied to it first, and the result from the passed <see cref="Funf"/> will become an argument
        /// that is sent to <paramref name="f"/>, replacing the passed <see cref="Funf"/> and any args that
        /// it may have consumed.
        /// </remarks>
        /// <example>
        /// var f = funf((x, y, z) => x + y - z);
        /// var g = capture(f, 2);
        /// var h = capture(g, 3);
        /// var i = capture(g, f, 10);
        ///
        /// var v = call(f, 5, 4, 18);  // v = -9
        /// var w = call(g, 4, 18);     // w = -12
        /// var x = call(h, 18);        // x = -13
        /// var y = call(i);            // y = -13
        /// var z = call(h, 18, 24, 30) // z = <see cref="IEnumerable{dynamic}"/> of [-13, 24, 30]
        /// </example>
        public static CallResult<TResult> call<TResult>(Funf<TResult> f, params dynamic[] args) => call(f, args.AsEnumerable());
        private static CallResult<TResult> call<TResult>(Funf<TResult> f, IEnumerable<dynamic> args)
        {
            (var fun, var final_args) = capture_and_compose(f, args);
            return ((WFunf<TResult>)fun).invoke_func(final_args);
        }

        private static (Funf<TResult>, IEnumerable<dynamic> args) capture_and_compose<TResult>(Funf<TResult> f, params dynamic[] args) => capture_and_compose(f, args.AsEnumerable());
        private static (Funf<TResult>, IEnumerable<dynamic> args) capture_and_compose<TResult>(Funf<TResult> f, IEnumerable<dynamic> args) =>
            args.SkipWhile(arg => !(arg is Funf)) switch
            {
                var empty when !empty.Any() => (f, args),
                var g_and_args => (compose(f, capture(g_and_args.First(), g_and_args.Skip(1))), args.TakeWhile(arg => !(arg is Funf))),
            };
    }
}
