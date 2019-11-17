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
using System.Linq;
using Xunit;

using static Funship.Fist;
using static Funship.Funf;

namespace Funship.Tests
{
    public class FunfTest
    {
        [Fact]
        public void can_wrap_and_call_funcs()
        {
            var fun0 = empty<int>();
            var fun1 = funf((int a1) => (a1).GetHashCode());
            var fun2 = funf((int a1, int a2) => (a1, a2).GetHashCode());
            var fun3 = funf((int a1, int a2, int a3) => (a1, a2, a3).GetHashCode());
            var fun4 = funf((int a1, int a2, int a3, int a4) => (a1, a2, a3, a4).GetHashCode());
            var fun5 = funf((int a1, int a2, int a3, int a4, int a5) => (a1, a2, a3, a4, a5).GetHashCode());
            var fun6 = funf((int a1, int a2, int a3, int a4, int a5, int a6) => (a1, a2, a3, a4, a5, a6).GetHashCode());
            var fun7 = funf((int a1, int a2, int a3, int a4, int a5, int a6, int a7) => (a1, a2, a3, a4, a5, a6, a7).GetHashCode());
            var fun8 = funf((int a1, int a2, int a3, int a4, int a5, int a6, int a7, int a8) => (a1, a2, a3, a4, a5, a6, a7, a8).GetHashCode());
            var fun9 = funf((int a1, int a2, int a3, int a4, int a5, int a6, int a7, int a8, int a9) => (a1, a2, a3, a4, a5, a6, a7, a8, a9).GetHashCode());
            var fun10 = funf((int a1, int a2, int a3, int a4, int a5, int a6, int a7, int a8, int a9, int a10) => (a1, a2, a3, a4, a5, a6, a7, a8, a9, a10).GetHashCode());
            var fun11 = funf((int a1, int a2, int a3, int a4, int a5, int a6, int a7, int a8, int a9, int a10, int a11) => (a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11).GetHashCode());
            var fun12 = funf((int a1, int a2, int a3, int a4, int a5, int a6, int a7, int a8, int a9, int a10, int a11, int a12) => (a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12).GetHashCode());
            var fun13 = funf((int a1, int a2, int a3, int a4, int a5, int a6, int a7, int a8, int a9, int a10, int a11, int a12, int a13) => (a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13).GetHashCode());
            var fun14 = funf((int a1, int a2, int a3, int a4, int a5, int a6, int a7, int a8, int a9, int a10, int a11, int a12, int a13, int a14) => (a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13, a14).GetHashCode());
            var fun15 = funf((int a1, int a2, int a3, int a4, int a5, int a6, int a7, int a8, int a9, int a10, int a11, int a12, int a13, int a14, int a15) => (a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13, a14, a15).GetHashCode());
            var fun16 = funf((int a1, int a2, int a3, int a4, int a5, int a6, int a7, int a8, int a9, int a10, int a11, int a12, int a13, int a14, int a15, int a16) => (a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13, a14, a15, a16).GetHashCode());

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
        public void can_compose_1_arg_function_with_no_captured_args_with_any_other_function_with_no_captured_args()
        {
            var f = funf<int, int>(x => 2 * x);

            var g0 = empty<int>();
            var g1 = funf((int a1) => (a1).GetHashCode());
            var g2 = funf((int a1, int a2) => (a1, a2).GetHashCode());
            var g3 = funf((int a1, int a2, int a3) => (a1, a2, a3).GetHashCode());
            var g4 = funf((int a1, int a2, int a3, int a4) => (a1, a2, a3, a4).GetHashCode());
            var g5 = funf((int a1, int a2, int a3, int a4, int a5) => (a1, a2, a3, a4, a5).GetHashCode());
            var g6 = funf((int a1, int a2, int a3, int a4, int a5, int a6) => (a1, a2, a3, a4, a5, a6).GetHashCode());
            var g7 = funf((int a1, int a2, int a3, int a4, int a5, int a6, int a7) => (a1, a2, a3, a4, a5, a6, a7).GetHashCode());
            var g8 = funf((int a1, int a2, int a3, int a4, int a5, int a6, int a7, int a8) => (a1, a2, a3, a4, a5, a6, a7, a8).GetHashCode());
            var g9 = funf((int a1, int a2, int a3, int a4, int a5, int a6, int a7, int a8, int a9) => (a1, a2, a3, a4, a5, a6, a7, a8, a9).GetHashCode());
            var g10 = funf((int a1, int a2, int a3, int a4, int a5, int a6, int a7, int a8, int a9, int a10) => (a1, a2, a3, a4, a5, a6, a7, a8, a9, a10).GetHashCode());
            var g11 = funf((int a1, int a2, int a3, int a4, int a5, int a6, int a7, int a8, int a9, int a10, int a11) => (a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11).GetHashCode());
            var g12 = funf((int a1, int a2, int a3, int a4, int a5, int a6, int a7, int a8, int a9, int a10, int a11, int a12) => (a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12).GetHashCode());
            var g13 = funf((int a1, int a2, int a3, int a4, int a5, int a6, int a7, int a8, int a9, int a10, int a11, int a12, int a13) => (a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13).GetHashCode());
            var g14 = funf((int a1, int a2, int a3, int a4, int a5, int a6, int a7, int a8, int a9, int a10, int a11, int a12, int a13, int a14) => (a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13, a14).GetHashCode());
            var g15 = funf((int a1, int a2, int a3, int a4, int a5, int a6, int a7, int a8, int a9, int a10, int a11, int a12, int a13, int a14, int a15) => (a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13, a14, a15).GetHashCode());
            var g16 = funf((int a1, int a2, int a3, int a4, int a5, int a6, int a7, int a8, int a9, int a10, int a11, int a12, int a13, int a14, int a15, int a16) => (a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13, a14, a15, a16).GetHashCode());

            var h0 = compose(f, g0);
            var h1 = compose(f, g1);
            var h2 = compose(f, g2);
            var h3 = compose(f, g3);
            var h4 = compose(f, g4);
            var h5 = compose(f, g5);
            var h6 = compose(f, g6);
            var h7 = compose(f, g7);
            var h8 = compose(f, g8);
            var h9 = compose(f, g9);
            var h10 = compose(f, g10);
            var h11 = compose(f, g11);
            var h12 = compose(f, g12);
            var h13 = compose(f, g13);
            var h14 = compose(f, g14);
            var h15 = compose(f, g15);
            var h16 = compose(f, g16);

            var result0 = call(h0);
            var result1 = call(h1, 1);
            var result2 = call(h2, 1, 2);
            var result3 = call(h3, 1, 2, 3);
            var result4 = call(h4, 1, 2, 3, 4);
            var result5 = call(h5, 1, 2, 3, 4, 5);
            var result6 = call(h6, 1, 2, 3, 4, 5, 6);
            var result7 = call(h7, 1, 2, 3, 4, 5, 6, 7);
            var result8 = call(h8, 1, 2, 3, 4, 5, 6, 7, 8);
            var result9 = call(h9, 1, 2, 3, 4, 5, 6, 7, 8, 9);
            var result10 = call(h10, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10);
            var result11 = call(h11, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11);
            var result12 = call(h12, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12);
            var result13 = call(h13, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13);
            var result14 = call(h14, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14);
            var result15 = call(h15, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15);
            var result16 = call(h16, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);

            Assert.Equal(0, h0.arity);
            Assert.Equal(CallResultType.Full, result0.result_type);
            Assert.Equal(0, result0.result);
            Assert.Empty(result0.overflow_args);

            Assert.Equal(1, h1.arity);
            Assert.Equal(CallResultType.Full, result1.result_type);
            Assert.Equal(2 * (1).GetHashCode(), result1.result);
            Assert.Empty(result1.overflow_args);

            Assert.Equal(2, h2.arity);
            Assert.Equal(CallResultType.Full, result2.result_type);
            Assert.Equal(2 * (1, 2).GetHashCode(), result2.result);
            Assert.Empty(result2.overflow_args);

            Assert.Equal(3, h3.arity);
            Assert.Equal(CallResultType.Full, result3.result_type);
            Assert.Equal(2 * (1, 2, 3).GetHashCode(), result3.result);
            Assert.Empty(result3.overflow_args);

            Assert.Equal(4, h4.arity);
            Assert.Equal(CallResultType.Full, result4.result_type);
            Assert.Equal(2 * (1, 2, 3, 4).GetHashCode(), result4.result);
            Assert.Empty(result4.overflow_args);

            Assert.Equal(5, h5.arity);
            Assert.Equal(CallResultType.Full, result5.result_type);
            Assert.Equal(2 * (1, 2, 3, 4, 5).GetHashCode(), result5.result);
            Assert.Empty(result5.overflow_args);

            Assert.Equal(6, h6.arity);
            Assert.Equal(CallResultType.Full, result6.result_type);
            Assert.Equal(2 * (1, 2, 3, 4, 5, 6).GetHashCode(), result6.result);
            Assert.Empty(result6.overflow_args);

            Assert.Equal(7, h7.arity);
            Assert.Equal(CallResultType.Full, result7.result_type);
            Assert.Equal(2 * (1, 2, 3, 4, 5, 6, 7).GetHashCode(), result7.result);
            Assert.Empty(result7.overflow_args);

            Assert.Equal(8, h8.arity);
            Assert.Equal(CallResultType.Full, result8.result_type);
            Assert.Equal(2 * (1, 2, 3, 4, 5, 6, 7, 8).GetHashCode(), result8.result);
            Assert.Empty(result8.overflow_args);

            Assert.Equal(9, h9.arity);
            Assert.Equal(CallResultType.Full, result9.result_type);
            Assert.Equal(2 * (1, 2, 3, 4, 5, 6, 7, 8, 9).GetHashCode(), result9.result);
            Assert.Empty(result9.overflow_args);

            Assert.Equal(10, h10.arity);
            Assert.Equal(CallResultType.Full, result10.result_type);
            Assert.Equal(2 * (1, 2, 3, 4, 5, 6, 7, 8, 9, 10).GetHashCode(), result10.result);
            Assert.Empty(result10.overflow_args);

            Assert.Equal(11, h11.arity);
            Assert.Equal(CallResultType.Full, result11.result_type);
            Assert.Equal(2 * (1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11).GetHashCode(), result11.result);
            Assert.Empty(result11.overflow_args);

            Assert.Equal(12, h12.arity);
            Assert.Equal(CallResultType.Full, result12.result_type);
            Assert.Equal(2 * (1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12).GetHashCode(), result12.result);
            Assert.Empty(result12.overflow_args);

            Assert.Equal(13, h13.arity);
            Assert.Equal(CallResultType.Full, result13.result_type);
            Assert.Equal(2 * (1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13).GetHashCode(), result13.result);
            Assert.Empty(result13.overflow_args);

            Assert.Equal(14, h14.arity);
            Assert.Equal(CallResultType.Full, result14.result_type);
            Assert.Equal(2 * (1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14).GetHashCode(), result14.result);
            Assert.Empty(result14.overflow_args);

            Assert.Equal(15, h15.arity);
            Assert.Equal(CallResultType.Full, result15.result_type);
            Assert.Equal(2 * (1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15).GetHashCode(), result15.result);
            Assert.Empty(result15.overflow_args);

            Assert.Equal(16, h16.arity);
            Assert.Equal(CallResultType.Full, result16.result_type);
            Assert.Equal(2 * (1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16).GetHashCode(), result16.result);
            Assert.Empty(result16.overflow_args);
        }

        [Fact]
        public void can_compose_multi_arg_function_with_no_captured_args_with_any_other_function_with_no_captured_args()
        {
            var fs = new []
            {
                funf((int a1, int a2) => (a1, a2).GetHashCode().GetHashCode()),
                funf((int a1, int a2, int a3) => (a1, a2, a3).GetHashCode().GetHashCode()),
                funf((int a1, int a2, int a3, int a4) => (a1, a2, a3, a4).GetHashCode().GetHashCode()),
                funf((int a1, int a2, int a3, int a4, int a5) => (a1, a2, a3, a4, a5).GetHashCode().GetHashCode()),
                funf((int a1, int a2, int a3, int a4, int a5, int a6) => (a1, a2, a3, a4, a5, a6).GetHashCode().GetHashCode()),
                funf((int a1, int a2, int a3, int a4, int a5, int a6, int a7) => (a1, a2, a3, a4, a5, a6, a7).GetHashCode().GetHashCode()),
                funf((int a1, int a2, int a3, int a4, int a5, int a6, int a7, int a8) => (a1, a2, a3, a4, a5, a6, a7, a8).GetHashCode().GetHashCode()),
                funf((int a1, int a2, int a3, int a4, int a5, int a6, int a7, int a8, int a9) => (a1, a2, a3, a4, a5, a6, a7, a8, a9).GetHashCode().GetHashCode()),
                funf((int a1, int a2, int a3, int a4, int a5, int a6, int a7, int a8, int a9, int a10) => (a1, a2, a3, a4, a5, a6, a7, a8, a9, a10).GetHashCode().GetHashCode()),
                funf((int a1, int a2, int a3, int a4, int a5, int a6, int a7, int a8, int a9, int a10, int a11) => (a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11).GetHashCode().GetHashCode()),
                funf((int a1, int a2, int a3, int a4, int a5, int a6, int a7, int a8, int a9, int a10, int a11, int a12) => (a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12).GetHashCode().GetHashCode()),
                funf((int a1, int a2, int a3, int a4, int a5, int a6, int a7, int a8, int a9, int a10, int a11, int a12, int a13) => (a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13).GetHashCode().GetHashCode()),
                funf((int a1, int a2, int a3, int a4, int a5, int a6, int a7, int a8, int a9, int a10, int a11, int a12, int a13, int a14) => (a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13, a14).GetHashCode().GetHashCode()),
                funf((int a1, int a2, int a3, int a4, int a5, int a6, int a7, int a8, int a9, int a10, int a11, int a12, int a13, int a14, int a15) => (a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13, a14, a15).GetHashCode().GetHashCode()),
                funf((int a1, int a2, int a3, int a4, int a5, int a6, int a7, int a8, int a9, int a10, int a11, int a12, int a13, int a14, int a15, int a16) => (a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13, a14, a15, a16).GetHashCode().GetHashCode()),
            };

            var gs = new []
            {
                empty<int>(),
                funf((int a1) => (a1).GetHashCode()),
                funf((int a1, int a2) => (a1, a2).GetHashCode()),
                funf((int a1, int a2, int a3) => (a1, a2, a3).GetHashCode()),
                funf((int a1, int a2, int a3, int a4) => (a1, a2, a3, a4).GetHashCode()),
                funf((int a1, int a2, int a3, int a4, int a5) => (a1, a2, a3, a4, a5).GetHashCode()),
                funf((int a1, int a2, int a3, int a4, int a5, int a6) => (a1, a2, a3, a4, a5, a6).GetHashCode()),
                funf((int a1, int a2, int a3, int a4, int a5, int a6, int a7) => (a1, a2, a3, a4, a5, a6, a7).GetHashCode()),
                funf((int a1, int a2, int a3, int a4, int a5, int a6, int a7, int a8) => (a1, a2, a3, a4, a5, a6, a7, a8).GetHashCode()),
                funf((int a1, int a2, int a3, int a4, int a5, int a6, int a7, int a8, int a9) => (a1, a2, a3, a4, a5, a6, a7, a8, a9).GetHashCode()),
                funf((int a1, int a2, int a3, int a4, int a5, int a6, int a7, int a8, int a9, int a10) => (a1, a2, a3, a4, a5, a6, a7, a8, a9, a10).GetHashCode()),
                funf((int a1, int a2, int a3, int a4, int a5, int a6, int a7, int a8, int a9, int a10, int a11) => (a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11).GetHashCode()),
                funf((int a1, int a2, int a3, int a4, int a5, int a6, int a7, int a8, int a9, int a10, int a11, int a12) => (a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12).GetHashCode()),
                funf((int a1, int a2, int a3, int a4, int a5, int a6, int a7, int a8, int a9, int a10, int a11, int a12, int a13) => (a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13).GetHashCode()),
                funf((int a1, int a2, int a3, int a4, int a5, int a6, int a7, int a8, int a9, int a10, int a11, int a12, int a13, int a14) => (a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13, a14).GetHashCode()),
                funf((int a1, int a2, int a3, int a4, int a5, int a6, int a7, int a8, int a9, int a10, int a11, int a12, int a13, int a14, int a15) => (a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13, a14, a15).GetHashCode()),
            };

            for (var i = 0; i < fs.Length; ++i)
            {
                var args = Fist<dynamic>.nilf;
                for (var j = 0; j < gs.Length - i; ++j)
                {
                    var h = compose(fs[i], gs[j]);
                    var result = call(h, args);

                    var closure = result.closure;

                    Assert.Equal(i + j + 1, h.arity);

                    Assert.Equal(CallResultType.Partial, result.result_type);
                    Assert.Empty(result.overflow_args);
                    Assert.Equal(default, result.result);

                    Assert.Equal(i + 1, closure.arity);

                    args = fist(j + 1, args);
                }
            }
        }
    }
}
