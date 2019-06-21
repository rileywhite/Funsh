# Funship
Functional Programming in C#

# To Use
```c#
using System;
using static Funship.Fist;                                  // Get access to functional magic.

namespace Sandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = fist(1, 2, 3, 4);                    // New functional list [1, 2, 3, 4]
            var result = reduce(list, (x, acc) => x * acc); // Functional reduce call to multiply list items
            Console.WriteLine(result);                      // outputs 24
        }
    }
}

```