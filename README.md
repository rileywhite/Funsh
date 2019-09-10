![Funship Logo](./Icons/Funship_0128px.png)

# Funship: Functional C# the Fun Way

![Build Status](https://ci.appveyor.com/api/projects/status/github/rileywhite/funship?svg=true)

# Funship
Functional Programming in C# with partial calling, function composition, and (head, tail) style lists
that work with C# 8.0 `switch` statement pattern matching!

I know you're excited to get started, so install it [via NuGet](https://www.nuget.org/packages/Funship/). Don't foget: you won't find it in your NuGet search through Visual Studio unless you _**check the box that allows pre-release packages**_ in your search results.

If your IDE of choice supports it, then you'll find fully populated interactive documentation.

One teensy additional note: This project depends on a lot of C# 8.0 stuff, so you'll need an environment with the [latest preview of DotNet Core 3.0](https://dotnet.microsoft.com/download/dotnet-core/3.0) installed. Okaythxbye!

# Usage Primer
All examples below use `int`s for argument and list member types. This is only for ease of understanding,
however, as `dynamic` is the underlying type in use for any value that is not specifically a function or
a list.

## Functions
Funship functions, called `Funf`s provide a level of abstraction on top of standard C# delegates. They provide
the ability to call, partially call, and even overflow (i.e. send too many arguments) a function, and they
allow powerful function composition.

Under the hood, `Funf` is a C# `interface`. A given `Funf` instance will be one of a number of possible
implementations, depending on the need at the time. The one thing they all have in common is that every
implementation is a `readonly struct`. They are immutable, stack-allocated, low-memory-overhead data structures.

### Get Access to Functions
Put this statement at the top of a file with your other `using` statements.

```c#
using static Funship.Funf;
```

### Create and call
Call a function by sending the function and its arguments to `call()`.
If you send the expected number of arguments to a function, then a call works exactly as you would expect.

```c#
var f = funf((x, y) => x * y);  // f is a function that expects two arguments
var x = call(f, 5, 10);         // x == 50
```

### Partial call
A partial call results in a function that doesn't actually execute. Instead it captures the passed arguments
and returns a new function that expects the remainder of the arguments.

```c#
var f = funf((x, y) => x - y);  // f is a function that expects two arguments
var g = call(f, 12);            // g is a partially called version of f that expects one additional argument
var x = call(g, 4);             // x == 8, which is the result of f(12, 4)
```

### Overflow call
Sending too many arguments to a function call results in an `IEnumerable<dynamic>` with the function result
followed by the unused arguments.

```c#
var f = funf(x => 2 * x);
var x = call(f, 5, 6, 7);       // x == IEnumerable<dynamic> containing 10, 6, and 7
```

### Compose two functions
Function composition generalizes the mathematical rule of g ∘ f : X → Z, defined by (g ∘ f )(x) = g(f(x)).
Another way to think about this is that the function on the right is called first using as many arguments as it
needs. Its result combines with any unused arguments similar to an overflow call, and that collection of arguments
is available to the function on the left.

```c#
var f = funf(x => 2 * x);
var g = funf((x, y) => x - y);
var h = compose(f, g);
var x = call(h, 2, 1);          // x == 3, which is the result of g(f(2), 1)
```

### Inferred composition
If a function is included in the list of arguments to call another function, the call infers functional composition
from left to right.

```c#
var f = funf(x => 2 * x);
var g = funf((x, y) => x - y);
var x = call(g, f, 2, 1);       // x == 3, which is the result of g(f(2), 1)
```

### Capture
A `capture()` is similar to a `call()` in the way that it handles arguments and composition. The difference is
that `capture()` never executes any of the functions. The result is always another function which can then be called.

When the resulting function is called, the result will be identical to what a call to the original function
with the arguments that were captured would produce.

A partial function call (i.e. one with too few arguments), is semantically equivalent to a capture; however, in
a capture, no function is ever called, while in a call, some functions in the argument list may execute.

```c#
var f = funf(x => 2 * x);
var g = funf((x, y) => x - y);
var h = capture(g, f, 2, 1);    // h is a new function that takes zero arguments
var x = call(h);                // x == 3, which is the result of g(f(2), 1)
```

## Functional Lists
Functional lists are a core feature of many functional languages. They are basically a form of
[singly linked list](https://en.wikipedia.org/wiki/Linked_list#Singly_linked_list) that can be nicely pattern matched.
Base cases for recursive calls will often rely on matching against `Nilf`, the empty list type.

Under the hood, `Fist` is a C# `interface`. A given `Fist` instance will be one of a number of different
implementations, depending on the need at the time. The one thing they all have in common is that every
implementation is a `readonly struct`. They are immutable, stack-allocated, low-memory-overhead data structures.

The one special case for implementations being hidden is the aforementioned `Nilf`, which represents an empty list.
You can create your own `new Nilf()`, but there is a provided `nilf` value that works just as well as all `Nilf`
instances are interchangeable.


### Get Access to Lists
Put this statement at the top of a file with your other `using` statements.

```c#
using static Funship.Fist;
```

### Create
You can create a 

#### From a list of numbers

```c#
var list = fist(1, 2, 3, 4);
```

#### From a head value and an existing tail list
```c#
var list2 = fist(5, list);
```

#### From a Linq range
```c#
var list2 = fist(System.Linq.Enumerable.Range(1, 1000));
```

### Built-in List Library
There are several list functions provided by Funship. Here is a sampling that should look familiar to those
who have used functional languages.

```c#
x = reduce(list, funf((x, acc) => x * acc));
x = map(list, funf(x => 2 * x));
x = all(list, funf(x => x > 100));
x = any(list, funf(x => x > 100));
x = filter(list, funf(x => x % 2 == 0));
x = reverse(list);
println(list);
```

### Switch Expressions and Lists
Use pattern matching and switch expressions to write code that looks classically functional.

```c#
{
...

    var x = skip_through(fist(1, 2, 3, 4), funf(n => n >= 2));  // X = Fist(3, 4)
    var y = skip_through(x, x > 10);                            // x = nilf, the empty list

...

}

private static Fist skip_through(Fist list, Funf pred) => list switch
{
    Nilf _ => nilf,
    (var head, Fist tail) when call(pred, head) => tail,
    (var _, Fist tail) => skip_until(tail, pred),
};
```

# A Note on Tail Call Optimization
The CLR supports [tail call](https://docs.microsoft.com/en-us/dotnet/api/system.reflection.emit.opcodes.tailcall) optimization. The C# compiler [does not generate tail instructions](https://stackoverflow.com/a/15865150). There's some indication that the 64-bit JITter [may generate tail instructions](https://stackoverflow.com/a/491463) on the fly when it makes sense.

In short, you have to expect a stack overflow if you [inception](https://en.wikipedia.org/wiki/Inception) your code with deep recursion.

And this is sad.

At least [one attempt to make it better](https://github.com/hazzik/Tail.Fody) exists, but it seems to be outdated. And when I made the minor modifications to get it compiling in dotnet 3.0, it didn't detect most of the tail recursion calls. In particuler, the IL emitted by the compiler for tail recursive calls in the C# 8.0 [`switch` expressions](https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-8#switch-expressions) weren't detected.

I decided to stop traveling down that rabbit hole for now, but I may return someday.

# Dear SM, why does this thing exist?!
Well, you see, this is more of a why not situation...

It's fun for me, and that's what matters for me with my free time.

And I am aware of F#. I like F#. And I still find this project fun.
