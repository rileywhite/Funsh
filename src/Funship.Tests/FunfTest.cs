/***************************************************************************/
// Copyright 2019 Riley White
// 
// Licensed under the Apache License, Version 2.0 (the "License"));
// you may not use this file eacept in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either eapress or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
/***************************************************************************/

using System;
using Xunit;

using static Funship.Funf;

namespace Funship.Tests
{
    public class FunfTest
    {
        [Fact]
        public void can_wrap_and_call_funcs()
        {
            var fun0 = funf(() => 0);
            var fun1 = funf<int>(a1 => (a1).GetHashCode());
            var fun2 = funf((a1, a2) => (a1, a2).GetHashCode());
            var fun3 = funf((a1, a2, a3) => (a1, a2, a3).GetHashCode());
            var fun4 = funf((a1, a2, a3, a4) => (a1, a2, a3, a4).GetHashCode());
            var fun5 = funf((a1, a2, a3, a4, a5) => (a1, a2, a3, a4, a5).GetHashCode());
            var fun6 = funf((a1, a2, a3, a4, a5, a6) => (a1, a2, a3, a4, a5, a6).GetHashCode());
            var fun7 = funf((a1, a2, a3, a4, a5, a6, a7) => (a1, a2, a3, a4, a5, a6, a7).GetHashCode());
            var fun8 = funf((a1, a2, a3, a4, a5, a6, a7, a8) => (a1, a2, a3, a4, a5, a6, a7, a8).GetHashCode());
            var fun9 = funf((a1, a2, a3, a4, a5, a6, a7, a8, a9) => (a1, a2, a3, a4, a5, a6, a7, a8, a9).GetHashCode());
            var fun10 = funf((a1, a2, a3, a4, a5, a6, a7, a8, a9, a10) => (a1, a2, a3, a4, a5, a6, a7, a8, a9, a10).GetHashCode());
            var fun11 = funf((a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11) => (a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11).GetHashCode());
            var fun12 = funf((a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12) => (a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12).GetHashCode());
            var fun13 = funf((a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13) => (a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13).GetHashCode());
            var fun14 = funf((a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13, a14) => (a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13, a14).GetHashCode());
            var fun15 = funf((a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13, a14, a15) => (a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13, a14, a15).GetHashCode());
            var fun16 = funf((a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13, a14, a15, a16) => (a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13, a14, a15, a16).GetHashCode());

            var result0 = call(fun0);
            var result1 = call(fun1, 1);
            var result2 = call(fun2, 1, 2);
            var result3 = call(fun3, 1, 2, 3);
            var result4 = call(fun4, 1, 2, 3, 4);
            var result5 = call(fun5, 1, 2, 3, 4, 5);
            var result6 = call(fun6, 1, 2, 3, 4, 5, 6);
            var result7 = call(fun7, 1, 2, 3, 4, 5, 6, 7);
            var result8 = call(fun8, 1, 2, 3, 4, 5, 6, 7, 8);
            var result9 = call(fun9, 1, 2, 3, 4, 5, 6, 7, 8, 9);
            var result10 = call(fun10, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10);
            var result11 = call(fun11, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11);
            var result12 = call(fun12, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12);
            var result13 = call(fun13, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13);
            var result14 = call(fun14, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14);
            var result15 = call(fun15, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15);
            var result16 = call(fun16, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);

            Assert.Equal(0, fun0.arity);
            Assert.Equal(CallResultType.Full, result0.result_type);
            Assert.Equal(0, result0.result);
            Assert.Empty(result0.overflow_args);

            Assert.Equal(1, fun1.arity);
            Assert.Equal(CallResultType.Full, result1.result_type);
            Assert.Equal((1).GetHashCode(), result1.result);
            Assert.Empty(result1.overflow_args);

            Assert.Equal(2, fun2.arity);
            Assert.Equal(CallResultType.Full, result2.result_type);
            Assert.Equal((1, 2).GetHashCode(), result2.result);
            Assert.Empty(result2.overflow_args);

            Assert.Equal(3, fun3.arity);
            Assert.Equal(CallResultType.Full, result3.result_type);
            Assert.Equal((1, 2, 3).GetHashCode(), result3.result);
            Assert.Empty(result3.overflow_args);

            Assert.Equal(4, fun4.arity);
            Assert.Equal(CallResultType.Full, result4.result_type);
            Assert.Equal((1, 2, 3, 4).GetHashCode(), result4.result);
            Assert.Empty(result4.overflow_args);

            Assert.Equal(5, fun5.arity);
            Assert.Equal(CallResultType.Full, result5.result_type);
            Assert.Equal((1, 2, 3, 4, 5).GetHashCode(), result5.result);
            Assert.Empty(result5.overflow_args);

            Assert.Equal(6, fun6.arity);
            Assert.Equal(CallResultType.Full, result6.result_type);
            Assert.Equal((1, 2, 3, 4, 5, 6).GetHashCode(), result6.result);
            Assert.Empty(result6.overflow_args);

            Assert.Equal(7, fun7.arity);
            Assert.Equal(CallResultType.Full, result7.result_type);
            Assert.Equal((1, 2, 3, 4, 5, 6, 7).GetHashCode(), result7.result);
            Assert.Empty(result7.overflow_args);

            Assert.Equal(8, fun8.arity);
            Assert.Equal(CallResultType.Full, result8.result_type);
            Assert.Equal((1, 2, 3, 4, 5, 6, 7, 8).GetHashCode(), result8.result);
            Assert.Empty(result8.overflow_args);

            Assert.Equal(9, fun9.arity);
            Assert.Equal(CallResultType.Full, result9.result_type);
            Assert.Equal((1, 2, 3, 4, 5, 6, 7, 8, 9).GetHashCode(), result9.result);
            Assert.Empty(result9.overflow_args);

            Assert.Equal(10, fun10.arity);
            Assert.Equal(CallResultType.Full, result10.result_type);
            Assert.Equal((1, 2, 3, 4, 5, 6, 7, 8, 9, 10).GetHashCode(), result10.result);
            Assert.Empty(result10.overflow_args);

            Assert.Equal(11, fun11.arity);
            Assert.Equal(CallResultType.Full, result11.result_type);
            Assert.Equal((1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11).GetHashCode(), result11.result);
            Assert.Empty(result11.overflow_args);

            Assert.Equal(12, fun12.arity);
            Assert.Equal(CallResultType.Full, result12.result_type);
            Assert.Equal((1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12).GetHashCode(), result12.result);
            Assert.Empty(result12.overflow_args);

            Assert.Equal(13, fun13.arity);
            Assert.Equal(CallResultType.Full, result13.result_type);
            Assert.Equal((1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13).GetHashCode(), result13.result);
            Assert.Empty(result13.overflow_args);

            Assert.Equal(14, fun14.arity);
            Assert.Equal(CallResultType.Full, result14.result_type);
            Assert.Equal((1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14).GetHashCode(), result14.result);
            Assert.Empty(result14.overflow_args);

            Assert.Equal(15, fun15.arity);
            Assert.Equal(CallResultType.Full, result15.result_type);
            Assert.Equal((1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15).GetHashCode(), result15.result);
            Assert.Empty(result15.overflow_args);

            Assert.Equal(16, fun16.arity);
            Assert.Equal(CallResultType.Full, result16.result_type);
            Assert.Equal((1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16).GetHashCode(), result16.result);
            Assert.Empty(result16.overflow_args);
        }

        [Fact]
        public void can_call_with_one_captured_arg()
        {
            var f = funf<int>((x, y, z) => x + y - z);
            var g = capture(f, 2);

            var result = call(g, 3, 18);

            Assert.Equal(2, g.arity);
            Assert.Equal(CallResultType.Full, result.result_type);
            Assert.Equal(-13, result.result);
            Assert.Empty(result.overflow_args);
        }

        [Fact]
        public void can_call_with_multiple_captured_arg()
        {
            var f = funf<int>((x, y, z) => x + y - z);
            var g = capture(f, 2, 3);

            var result = call(g, 18);

            Assert.Equal(1, g.arity);
            Assert.Equal(CallResultType.Full, result.result_type);
            Assert.Equal(-13, result.result);
            Assert.Empty(result.overflow_args);
        }

        [Fact]
        public void can_call_with_two_separate_captured_arg()
        {
            var f = funf<int>((x, y, z) => x + y - z);
            var g = capture(f, 2);
            var h = capture(g, 3);

            var fResult = call(f, 5, 4, 18);
            var gResult = call(g, 4, 18);
            var hResult = call(h, 18);

            Assert.Equal(3, f.arity);
            Assert.Equal(CallResultType.Full, fResult.result_type);
            Assert.Equal(-9, fResult.result);
            Assert.Empty(fResult.overflow_args);

            Assert.Equal(2, g.arity);
            Assert.Equal(CallResultType.Full, gResult.result_type);
            Assert.Equal(-12, gResult.result);
            Assert.Empty(gResult.overflow_args);

            Assert.Equal(1, h.arity);
            Assert.Equal(CallResultType.Full, hResult.result_type);
            Assert.Equal(-13, hResult.result);
            Assert.Empty(hResult.overflow_args);
        }

        [Fact]
        public void can_call_with_extra_args()
        {
            var f = funf<int>(x => 3 * x);

            var result = call(f, 1, 2);

            Assert.Equal(1, f.arity);
            Assert.Equal(CallResultType.Full, result.result_type);
            Assert.Equal(3, result.result);
            Assert.Equal(new dynamic[] { 2 }, result.overflow_args);
        }

        [Fact]
        public void can_call_with_captured_args_and_extra_args()
        {
            var f = funf((x, y, z) => x + y - z);
            var g = capture(f, 2);
            var h = capture(g, 3);

            var fResult = call(f, 5, 4, 18, 44, 23);
            var gResult = call(g, 4, 18, 44, 23);
            var hResult = call(h, 18, 44, 23);

            Assert.Equal(3, f.arity);
            Assert.Equal(CallResultType.Full, fResult.result_type);
            Assert.Equal(-9, fResult.result);
            Assert.Equal(new dynamic[] { 44, 23 }, fResult.overflow_args);

            Assert.Equal(2, g.arity);
            Assert.Equal(CallResultType.Full, gResult.result_type);
            Assert.Equal(-12, gResult.result);
            Assert.Equal(new dynamic[] { 44, 23 }, gResult.overflow_args);

            Assert.Equal(1, h.arity);
            Assert.Equal(CallResultType.Full, hResult.result_type);
            Assert.Equal(-13, hResult.result);
            Assert.Equal(new dynamic[] { 44, 23 }, hResult.overflow_args);
        }

        [Fact]
        public void can_compose()
        {
            var f = funf(x => x - 2);
            var g = funf(y => y * 2);

            var h = compose(f, g);
            var i = compose(h, f);

            var hResult = call(h, 10);
            var iResult = call(i, 10);

            Assert.Equal(1, h.arity);
            Assert.Equal(CallResultType.Full, hResult.result_type);
            Assert.Equal(18, hResult.result);
            Assert.Empty(hResult.overflow_args);

            Assert.Equal(1, i.arity);
            Assert.Equal(CallResultType.Full, iResult.result_type);
            Assert.Equal(14, iResult.result);
            Assert.Empty(iResult.overflow_args);
        }

        [Fact]
        public void can_call_compose_inferred()
        {
            var f = funf(x => x - 2);
            var g = funf(y => y * 2);
            var h = capture(g, f, 10);

            var gfResult = call(g, f, 10);
            var fgfResult = call(f, g, f, 10);
            var hResult = call(h);

            Assert.Equal(1, f.arity);
            Assert.Equal(1, g.arity);
            Assert.Equal(0, h.arity);

            Assert.Equal(CallResultType.Full, gfResult.result_type);
            Assert.Equal(16, gfResult.result);
            Assert.Empty(gfResult.overflow_args);

            Assert.Equal(CallResultType.Full, fgfResult.result_type);
            Assert.Equal(14, fgfResult.result);
            Assert.Empty(fgfResult.overflow_args);

            Assert.Equal(CallResultType.Full, hResult.result_type);
            Assert.Equal(16, hResult.result);
            Assert.Empty(hResult.overflow_args);
        }
    }
}
