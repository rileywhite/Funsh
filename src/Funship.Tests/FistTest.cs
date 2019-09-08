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
using System.IO;
using System.Linq;
using Microsoft.CSharp.RuntimeBinder;
using Xunit;

using static Funship.Fist;
using static Funship.Funf;

namespace Funship.Tests
{
    public class FistTest
    {
        [Fact]
        public void can_test_equality_and_hashcode()
        {
            var list = fist(2, 4, 6, 8);
            var dynamicList = to_fist(Enumerable.Range(1, 4));
            var mappedList = map(fist(1, 2, 3, 4), x => 2 * x);

            Assert.Equal(fist(2, 4, 6, 8), list);
            Assert.Equal(fist(2, 4, 6, 8).GetHashCode(), list.GetHashCode());

            Assert.Equal(nilf, nilf);
            Assert.Equal(nilf.GetHashCode(), nilf.GetHashCode());
            Assert.Equal(0, nilf.GetHashCode());

            Assert.NotEqual(fist(2, 4, 6, 8), nilf);
            Assert.NotEqual(fist(2, 4, 6, 8).GetHashCode(), nilf.GetHashCode());

            Assert.Equal(fist(2, 4, 6, 8), mappedList);
            Assert.Equal(fist(2, 4, 6, 8).GetHashCode(), mappedList.GetHashCode());

            Assert.Equal(fist(1, 2, 3, 4), dynamicList);
            Assert.Equal(fist(1, 2, 3, 4).GetHashCode(), dynamicList.GetHashCode());

            Assert.NotEqual(fist(2, 3, 4, 5), list);
            Assert.NotEqual(fist(2, 3, 4, 5).GetHashCode(), list.GetHashCode());

            Assert.NotEqual(fist(2, 4, 8), list);
            Assert.NotEqual(fist(2, 4, 8).GetHashCode(), list.GetHashCode());

            Assert.NotEqual(fist(8, 6, 4, 2), list);
            Assert.NotEqual(fist(8, 6, 4, 2).GetHashCode(), list.GetHashCode());
        }

        [Fact]
        public void nilf_is_a_singleton()
        {
            Assert.Same(nilf, fist());
            Assert.Same(nilf, to_fist(new int[] { }));
            Assert.NotSame(nilf, to_fist(new int[] { 1 }));
        }

        [Fact]
        public void can_reduce_list()
        {
            var list = fist(1, 2, 3, 4);
            var result = reduce(list, (x, acc) => x * acc);
            Assert.Equal(24, result);
        }

        [Fact]
        public void can_map_list()
        {
            var list = fist(1, 2, 3, 4);
            var result = map(fist(1, 2, 3, 4), x => x * 2);
            Assert.Equal(result, fist(2, 4, 6, 8));
        }

        [Fact]
        public void print_works_with_custom_delimiter()
        {
            using var sw = new StringWriter();
            print(fist(1, 2, 3, 4, 5), sw, "__093409832978973243509092__");

            Assert.Equal(
                "1__093409832978973243509092__2__093409832978973243509092__3__093409832978973243509092__4__093409832978973243509092__5",
                sw.ToString());
        }

        [Fact]
        public void print_works_with_default_delimiter()
        {
            using var sw = new StringWriter();
            print(fist(1, 2, 3, 4, 5), sw);

            Assert.Equal("1 2 3 4 5", sw.ToString());
        }

        [Fact]
        public void println_works_with_custom_delimiter()
        {
            using var sw = new StringWriter();
            println(fist(1, 2, 3, 4, 5), sw, "__093409832978973243509092__");

            Assert.Equal(
                $"1__093409832978973243509092__2__093409832978973243509092__3__093409832978973243509092__4__093409832978973243509092__5{Environment.NewLine}",
                sw.ToString());
        }

        [Fact]
        public void println_works_with_default_delimiter()
        {
            using var sw = new StringWriter();
            println(fist(1, 2, 3, 4, 5), sw);

            Assert.Equal($"1 2 3 4 5{Environment.NewLine}", sw.ToString());
        }

        [Fact]
        public void all_works_with_valid_fun()
        {
            Assert.True(all(nilf, funf(x => x > 5)));
            Assert.True(all(fist(6, 7, 8, 9), funf(x => x > 5)));
            Assert.True(all(fist(6), funf(x => x > 5)));
            Assert.False(all(fist(4, 8, 9), funf(x => x > 5)));
            Assert.False(all(fist(4), funf(x => x > 5)));
            Assert.False(all(fist(4, 7, 8, 9), funf(x => x > 5)));
            Assert.False(all(fist(6, 4, 8, 9), funf(x => x > 5)));
            Assert.False(all(fist(6, 7, 8, 4), funf(x => x > 5)));
        }

        [Fact]
        public void all_works_on_nilf_with_invalid_fun() => Assert.True(all(nilf, funf(x => 12)));

        [Fact]
        public void all_fails_on_nonempty_fist_with_invalid_fun() =>
            Assert.Throws<RuntimeBinderException>(() => all(fist(1), funf(x => 12)));

        [Fact]
        public void any_works_with_valid_fun()
        {
            Assert.False(any(nilf, funf(x => x > 5)));

            Assert.False(any(fist(5, 4, 3, 2), funf(x => x > 5)));
            Assert.False(any(fist(5), funf(x => x > 5)));

            Assert.True(any(fist(6, 4, 3), funf(x => x > 5)));
            Assert.True(any(fist(6), funf(x => x > 5)));
            Assert.True(any(fist(6, 2, 3, 4), funf(x => x > 5)));
            Assert.True(any(fist(5, 6, 4, 3), funf(x => x > 5)));
            Assert.True(any(fist(2, 3, 4, 6), funf(x => x > 5)));
        }

        [Fact]
        public void any_works_on_nilf_with_invalid_fun() => Assert.False(any(nilf, funf(x => 12)));

        [Fact]
        public void any_fails_on_nonempty_fist_with_invalid_fun() =>
            Assert.Throws<RuntimeBinderException>(() => any(fist(1), funf(x => 12)));

        [Fact]
        public void reverse_works_as_expected()
        {
            Assert.Equal(nilf, reverse(nilf));
            Assert.Equal(fist(1), reverse(fist(1)));
            Assert.Equal(fist(1, 2, 3, 4, 5), reverse(fist(5, 4, 3, 2, 1)));
        }

        [Fact]
        public void can_create_fist_from_head_and_tail()
        {
            var head = 15;
            var tail = fist(1, 2, 3, 4, 5);

            var headAndTail = fist(head, tail);
            var headAndEmpty = fist(head, nilf);

            Assert.Equal(fist(15, 1, 2, 3, 4, 5), headAndTail);
            Assert.Equal(fist(15), headAndEmpty);
        }

        [Fact]
        public void can_enumerate_nilf()
        {
            var touched = false;

            foreach(var item in nilf)
            {
                touched = true;
            }

            Assert.False(touched);
        }

        [Fact]
        public void can_enumerate_fist()
        {
            var items = new[] { 1, 2, 3, 4, 5 };
            var list = fist(1, 2, 3, 4, 5);

            var i = 0;
            foreach(var item in list)
            {
                Assert.Equal(items[i], item);
                ++i;
            }
            Assert.Equal(5, i);
        }
    }
}
