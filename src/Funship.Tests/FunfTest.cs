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
using System.Collections.Generic;
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
            var fun0 = funf(() => 0);
            var fun1 = funf(a1 => (a1).GetHashCode());
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

            Assert.Equal(0, fun0.arity);
            Assert.Equal(1, fun1.arity);
            Assert.Equal(2, fun2.arity);
            Assert.Equal(3, fun3.arity);
            Assert.Equal(4, fun4.arity);
            Assert.Equal(5, fun5.arity);
            Assert.Equal(6, fun6.arity);
            Assert.Equal(7, fun7.arity);
            Assert.Equal(8, fun8.arity);
            Assert.Equal(9, fun9.arity);
            Assert.Equal(10, fun10.arity);
            Assert.Equal(11, fun11.arity);
            Assert.Equal(12, fun12.arity);
            Assert.Equal(13, fun13.arity);
            Assert.Equal(14, fun14.arity);
            Assert.Equal(15, fun15.arity);
            Assert.Equal(16, fun16.arity);

            Assert.Equal(0, call(fun0));
            Assert.Equal((1).GetHashCode(), call(fun1, 1));
            Assert.Equal((1, 2).GetHashCode(), call(fun2, 1, 2));
            Assert.Equal((1, 2, 3).GetHashCode(), call(fun3, 1, 2, 3));
            Assert.Equal((1, 2, 3, 4).GetHashCode(), call(fun4, 1, 2, 3, 4));
            Assert.Equal((1, 2, 3, 4, 5).GetHashCode(), call(fun5, 1, 2, 3, 4, 5));
            Assert.Equal((1, 2, 3, 4, 5, 6).GetHashCode(), call(fun6, 1, 2, 3, 4, 5, 6));
            Assert.Equal((1, 2, 3, 4, 5, 6, 7).GetHashCode(), call(fun7, 1, 2, 3, 4, 5, 6, 7));
            Assert.Equal((1, 2, 3, 4, 5, 6, 7, 8).GetHashCode(), call(fun8, 1, 2, 3, 4, 5, 6, 7, 8));
            Assert.Equal((1, 2, 3, 4, 5, 6, 7, 8, 9).GetHashCode(), call(fun9, 1, 2, 3, 4, 5, 6, 7, 8, 9));
            Assert.Equal((1, 2, 3, 4, 5, 6, 7, 8, 9, 10).GetHashCode(), call(fun10, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10));
            Assert.Equal((1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11).GetHashCode(), call(fun11, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11));
            Assert.Equal((1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12).GetHashCode(), call(fun12, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12));
            Assert.Equal((1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13).GetHashCode(), call(fun13, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13));
            Assert.Equal((1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14).GetHashCode(), call(fun14, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14));
            Assert.Equal((1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15).GetHashCode(), call(fun15, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15));
            Assert.Equal((1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16).GetHashCode(), call(fun16, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16));
        }

        [Fact]
        public void can_call_with_one_captured_arg()
        {
            var f = funf((x, y, z) => x + y - z);
            var g = capture(f, 2);
            Assert.Equal(-13, call(g, 3, 18));
        }

        [Fact]
        public void can_call_with_multiple_captured_arg()
        {
            var f = funf((x, y, z) => x + y - z);
            var g = capture(f, 2, 3);
            Assert.Equal(-13, call(g, 18));
        }

        [Fact]
        public void can_call_with_two_separate_captured_arg()
        {
            var f = funf((x, y, z) => x + y - z);
            var g = capture(f, 2);
            var h = capture(g, 3);

            Assert.Equal(-9, call(f, 5, 4, 18));
            Assert.Equal(-12, call(g, 4, 18));
            Assert.Equal(-13, call(h, 18));
        }

        [Fact]
        public void can_call_with_extra_args()
        {
            var f = funf(x => 3 * x);
            Assert.Equal(new dynamic[] { 3, 2 }, call(f, 1, 2));
        }

        [Fact]
        public void can_call_with_captured_args_and_extra_args()
        {
            var f = funf((x, y, z) => x + y - z);
            var g = capture(f, 2);
            var h = capture(g, 3);

            Assert.Equal(new dynamic[] { -9, 44, 23 }, call(f, 5, 4, 18, 44, 23));
            Assert.Equal(new dynamic[] { -12, 44, 23 }, call(g, 4, 18, 44, 23));
            Assert.Equal(new dynamic[] { -13, 44, 23 }, call(h, 18, 44, 23));
        }

        [Fact]
        public void can_compose_two_funs()
        {
            var f = funf(x => x - 2);
            var g = funf(y => y * 2);

            var h = compose(f, g);

            Assert.Equal(16, call(h, 10));
        }
    }
}
