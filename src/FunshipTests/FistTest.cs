using System;
using Xunit;

using static Funship.Fist;

namespace FunshipTests
{
    public class FistTest
    {
        [Fact]
        public void reduce_ints_with_multiplication_works()
        {
            var list = fist(1, 2, 3, 4);
            var result = reduce(list, (x, acc) => x * acc);
            Assert.Equal(24, result);
        }
    }
}
