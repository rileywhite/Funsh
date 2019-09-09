![Funship Logo](./Icons/Funship_0128px.png)

# Funship: The Fun way to C# Functionality

![Build Status](https://ci.appveyor.com/api/projects/status/github/rileywhite/funship?svg=true)

# Funship
Functional Programming in C# with partial calling, function composition, and (head, tail) style lists
that work with C# 8.0 `switch` statement pattern matching!

I know you're excited to get started, so install it [via NuGet](https://www.nuget.org/packages/Funship/). Don't foget: you won't find it in your NuGet search through Visual Studio unless you _**check the box that allows pre-release packages**_ in your search results.

If your IDE of choice supports it, then you'll find fully populated interactive documentation.

One teensy additional note: This project depends on a lot of C# 8.0 stuff, so you'll need an environment with the [latest preview of DotNet Core 3.0](https://dotnet.microsoft.com/download/dotnet-core/3.0) installed. Okaythxbye!

# Usage Primer
```c#
using System;
using System.Linq;

// Get access to functional magic
using static Funship.Fist;  // Functional lists
using static Funship.Funf;  // Functional functions

namespace Sandbox
{
    class Program
    {
        static void Main(string[] _)
        {
            // Create and call a functional function
            var f = funf(x => 2 * x);
            Console.WriteLine(call(f, 5));          // Prints 10

            var nums = call(f, 5, 6, 7);            // nums = IEnumerable<dynamic> containing 10, 6, and 7

            // New functional function
            var g = funf((x, y) => x - y);
            Console.WriteLine(call(g, 5, 3));       // Prints 2

            // Compose two functions
            var h = compose(f, g);
            Console.WriteLine(call(h, 2, 1));       // prints 3, which is the result of g(f(2), 1)

            // Inferred composition
            Console.WriteLine(call(g, f, 2, 1));    // prints 3, which is the result of g(f(2), 1)

            // Partially calling functions
            var i = capture(g, 10);
            Console.WriteLine(call(i, 4));          // prints 6, which is the result of g(10, 4)

            // New functional list [1, 2, 3, 4] by specifying members
            var list = fist(1, 2, 3, 4);

            // New functional list [5, 1, 2, 3, 4] by specifying a head and tail
            var list2 = fist(5, list);

            // Functional reduce call to multiply list items
            var result = reduce(list, funf((x, acc) => x * acc));
            Console.WriteLine(result);  // Prints 24

            // Map to a new list with each element doubled
            var mappedList = map(list, funf(x => 2 * x));
            println(mappedList);        // Prints 2, 4, 6, 8

            // List with ten thousand items created from an Enumerable.Range. Will be lazy-created.
            var bigList = fist(Enumerable.Range(0, 10000)); 

            var max = reduce(bigList, funf((x, acc) => x > acc ? x : acc));
            Console.WriteLine(max);     // Prints 9999

            // Functional list traversal
            var x = skip_through(fist(1, 2, 3, 4), funf(n => n >= 2));
            println(x);     // will print 3, 4

            var y = skip_through(x, x > 10);          // x = nilf, the empty list
        }

        // Returns the list after the first item matching the predicate
        private static Fist skip_through(Fist list, Funf pred) => list switch
        {
            Nilf _ => nilf,
            (var head, Fist tail) when call(pred, head) => tail,
            (var _, Fist tail) => skip_until(tail, pred),
        };
    }
}
```

# A Note on Tail Call Optimization
The CLR supports [tail call](https://docs.microsoft.com/en-us/dotnet/api/system.reflection.emit.opcodes.tailcall) optimization. The C# compiler [does not generate tail instructions](https://stackoverflow.com/a/15865150). There's some indication that the 64-bit JITter [may generate tail instructions](https://stackoverflow.com/a/491463) on the fly when it makes sense.

In short, you have to expect a stack overflow if you [inception](https://en.wikipedia.org/wiki/Inception) your code with deep recursion.

And this is sad.

At least [one attempt to make it better](https://github.com/hazzik/Tail.Fody) exists, but it seems to be outdated. And when I made the minor modifications to get it compiling in dotnet 3.0, it didn't detect most of the tail recursion calls. In particuler, the IL emitted by the compiler for tail recursive calls in the C# 8.0 [`switch` expressions](https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-8#switch-expressions) weren't detected.

I decided to stop traveling down that rabbit hole for now, but I may return someday.

# Dear SM, why does this thing exist!!! Doesn't F# do everything you need?!
Well, you see, this is more of a why not situation...

It's fun for me, and that's what matters for me with my free time.
