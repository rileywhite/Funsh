using System;
using static Funship.Fist;

namespace Sandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = fist(1, 2, 3, 4);
            var result = reduce(list, (x, acc) => x * acc);
            Console.WriteLine(result); // outputs 24
        }
    }
}
