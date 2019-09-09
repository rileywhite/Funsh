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
        public static Funf compose(Funf f, Funf g) => new CompFunf(f, g, g.arity + f.arity - 1, nilf);

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
        public static Funf capture(Funf f, params dynamic[] args) => capture(f, to_fist(args));
        private static Funf capture(Funf f, IEnumerable<dynamic> args) => capture_and_compose(f, args) switch
        {
            (var fun, var empty) when !empty.Any() => fun,
            (var fun, var final_args) => capture(new CapFunf(fun, final_args, fun.arity - final_args.Count())),
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
        public static dynamic call(Funf f, params dynamic[] args) => call(f, args.AsEnumerable());
        private static dynamic call(Funf f, IEnumerable<dynamic> args) => capture_and_compose(f, args) switch
        {
            (WFunf fun, var final_args) => fun.invoke_func(final_args),
            (CapFunf fun, var final_args) => fun.collect_args_and_call(final_args),
            (CompFunf fun, var final_args) => fun.collect_args_and_call(final_args),
            _ => throw new NotSupportedException(),
        };

        private static (Funf, IEnumerable<dynamic> args) capture_and_compose(Funf g, params dynamic[] args) => capture_and_compose(g, args.AsEnumerable());
        private static (Funf, IEnumerable<dynamic> args) capture_and_compose(Funf g, IEnumerable<dynamic> args) =>
            args.SkipWhile(arg => !(arg is Funf)) switch
            {
                var empty when !empty.Any() => (g, args),
                var f_and_args => (compose(capture(f_and_args.First(), f_and_args.Skip(1)), g), args.TakeWhile(arg => !(arg is Funf))),
            };
    }
}
