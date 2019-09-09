<a name='assembly'></a>
# Funship

## Contents

- [CapFunf](#T-Funship-Funf-CapFunf 'Funship.Funf.CapFunf')
- [CompFunf](#T-Funship-Funf-CompFunf 'Funship.Funf.CompFunf')
- [DFist\`1](#T-Funship-Fist-DFist`1 'Funship.Fist.DFist`1')
- [Fist](#T-Funship-Fist 'Funship.Fist')
  - [nilf](#F-Funship-Fist-nilf 'Funship.Fist.nilf')
  - [Head](#P-Funship-Fist-Head 'Funship.Fist.Head')
  - [IsNil](#P-Funship-Fist-IsNil 'Funship.Fist.IsNil')
  - [Tail](#P-Funship-Fist-Tail 'Funship.Fist.Tail')
  - [Deconstruct(head,tail)](#M-Funship-Fist-Deconstruct-System-Object@,Funship-Fist@- 'Funship.Fist.Deconstruct(System.Object@,Funship.Fist@)')
  - [all(list,fun)](#M-Funship-Fist-all-Funship-Fist,Funship-Funf- 'Funship.Fist.all(Funship.Fist,Funship.Funf)')
  - [any(list,fun)](#M-Funship-Fist-any-Funship-Fist,Funship-Funf- 'Funship.Fist.any(Funship.Fist,Funship.Funf)')
  - [equals(left,right)](#M-Funship-Fist-equals-Funship-Fist,Funship-Fist- 'Funship.Fist.equals(Funship.Fist,Funship.Fist)')
  - [fist(head,tail)](#M-Funship-Fist-fist-System-Object,Funship-Fist- 'Funship.Fist.fist(System.Object,Funship.Fist)')
  - [fist(vals)](#M-Funship-Fist-fist-System-Object[]- 'Funship.Fist.fist(System.Object[])')
  - [hash_code(list)](#M-Funship-Fist-hash_code-Funship-Fist- 'Funship.Fist.hash_code(Funship.Fist)')
  - [map(list,fun)](#M-Funship-Fist-map-Funship-Fist,System-Func{System-Object,System-Object}- 'Funship.Fist.map(Funship.Fist,System.Func{System.Object,System.Object})')
  - [print(list,delimiter)](#M-Funship-Fist-print-Funship-Fist,System-String- 'Funship.Fist.print(Funship.Fist,System.String)')
  - [print(list,tw,delimiter)](#M-Funship-Fist-print-Funship-Fist,System-IO-TextWriter,System-String- 'Funship.Fist.print(Funship.Fist,System.IO.TextWriter,System.String)')
  - [println(list,delimiter)](#M-Funship-Fist-println-Funship-Fist,System-String- 'Funship.Fist.println(Funship.Fist,System.String)')
  - [println(list,tw,delimiter)](#M-Funship-Fist-println-Funship-Fist,System-IO-TextWriter,System-String- 'Funship.Fist.println(Funship.Fist,System.IO.TextWriter,System.String)')
  - [reduce(list,fun)](#M-Funship-Fist-reduce-Funship-Fist,System-Func{System-Object,System-Object,System-Object}- 'Funship.Fist.reduce(Funship.Fist,System.Func{System.Object,System.Object,System.Object})')
  - [reduce(list,acc,fun)](#M-Funship-Fist-reduce-Funship-Fist,System-Object,System-Func{System-Object,System-Object,System-Object}- 'Funship.Fist.reduce(Funship.Fist,System.Object,System.Func{System.Object,System.Object,System.Object})')
  - [reverse(list)](#M-Funship-Fist-reverse-Funship-Fist- 'Funship.Fist.reverse(Funship.Fist)')
  - [to_fist\`\`1(vals)](#M-Funship-Fist-to_fist``1-System-Collections-Generic-IEnumerable{``0}- 'Funship.Fist.to_fist``1(System.Collections.Generic.IEnumerable{``0})')
- [Funf](#T-Funship-Funf 'Funship.Funf')
  - [arity](#P-Funship-Funf-arity 'Funship.Funf.arity')
  - [call(f,args)](#M-Funship-Funf-call-Funship-Funf,System-Object[]- 'Funship.Funf.call(Funship.Funf,System.Object[])')
  - [capture(f,args)](#M-Funship-Funf-capture-Funship-Funf,System-Object[]- 'Funship.Funf.capture(Funship.Funf,System.Object[])')
  - [compose(f,g)](#M-Funship-Funf-compose-Funship-Funf,Funship-Funf- 'Funship.Funf.compose(Funship.Funf,Funship.Funf)')
  - [funf(func)](#M-Funship-Funf-funf-System-Func{System-Object}- 'Funship.Funf.funf(System.Func{System.Object})')
  - [funf(func)](#M-Funship-Funf-funf-System-Func{System-Object,System-Object}- 'Funship.Funf.funf(System.Func{System.Object,System.Object})')
  - [funf(func)](#M-Funship-Funf-funf-System-Func{System-Object,System-Object,System-Object}- 'Funship.Funf.funf(System.Func{System.Object,System.Object,System.Object})')
  - [funf(func)](#M-Funship-Funf-funf-System-Func{System-Object,System-Object,System-Object,System-Object}- 'Funship.Funf.funf(System.Func{System.Object,System.Object,System.Object,System.Object})')
  - [funf(func)](#M-Funship-Funf-funf-System-Func{System-Object,System-Object,System-Object,System-Object,System-Object}- 'Funship.Funf.funf(System.Func{System.Object,System.Object,System.Object,System.Object,System.Object})')
  - [funf(func)](#M-Funship-Funf-funf-System-Func{System-Object,System-Object,System-Object,System-Object,System-Object,System-Object}- 'Funship.Funf.funf(System.Func{System.Object,System.Object,System.Object,System.Object,System.Object,System.Object})')
  - [funf(func)](#M-Funship-Funf-funf-System-Func{System-Object,System-Object,System-Object,System-Object,System-Object,System-Object,System-Object}- 'Funship.Funf.funf(System.Func{System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object})')
  - [funf(func)](#M-Funship-Funf-funf-System-Func{System-Object,System-Object,System-Object,System-Object,System-Object,System-Object,System-Object,System-Object}- 'Funship.Funf.funf(System.Func{System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object})')
  - [funf(func)](#M-Funship-Funf-funf-System-Func{System-Object,System-Object,System-Object,System-Object,System-Object,System-Object,System-Object,System-Object,System-Object}- 'Funship.Funf.funf(System.Func{System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object})')
  - [funf(func)](#M-Funship-Funf-funf-System-Func{System-Object,System-Object,System-Object,System-Object,System-Object,System-Object,System-Object,System-Object,System-Object,System-Object}- 'Funship.Funf.funf(System.Func{System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object})')
  - [funf(func)](#M-Funship-Funf-funf-System-Func{System-Object,System-Object,System-Object,System-Object,System-Object,System-Object,System-Object,System-Object,System-Object,System-Object,System-Object}- 'Funship.Funf.funf(System.Func{System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object})')
  - [funf(func)](#M-Funship-Funf-funf-System-Func{System-Object,System-Object,System-Object,System-Object,System-Object,System-Object,System-Object,System-Object,System-Object,System-Object,System-Object,System-Object}- 'Funship.Funf.funf(System.Func{System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object})')
  - [funf(func)](#M-Funship-Funf-funf-System-Func{System-Object,System-Object,System-Object,System-Object,System-Object,System-Object,System-Object,System-Object,System-Object,System-Object,System-Object,System-Object,System-Object}- 'Funship.Funf.funf(System.Func{System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object})')
  - [funf(func)](#M-Funship-Funf-funf-System-Func{System-Object,System-Object,System-Object,System-Object,System-Object,System-Object,System-Object,System-Object,System-Object,System-Object,System-Object,System-Object,System-Object,System-Object}- 'Funship.Funf.funf(System.Func{System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object})')
  - [funf(func)](#M-Funship-Funf-funf-System-Func{System-Object,System-Object,System-Object,System-Object,System-Object,System-Object,System-Object,System-Object,System-Object,System-Object,System-Object,System-Object,System-Object,System-Object,System-Object}- 'Funship.Funf.funf(System.Func{System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object})')
  - [funf(func)](#M-Funship-Funf-funf-System-Func{System-Object,System-Object,System-Object,System-Object,System-Object,System-Object,System-Object,System-Object,System-Object,System-Object,System-Object,System-Object,System-Object,System-Object,System-Object,System-Object}- 'Funship.Funf.funf(System.Func{System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object})')
  - [funf(func)](#M-Funship-Funf-funf-System-Func{System-Object,System-Object,System-Object,System-Object,System-Object,System-Object,System-Object,System-Object,System-Object,System-Object,System-Object,System-Object,System-Object,System-Object,System-Object,System-Object,System-Object}- 'Funship.Funf.funf(System.Func{System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object})')
- [MFist](#T-Funship-Fist-MFist 'Funship.Fist.MFist')
- [Nilf](#T-Funship-Fist-Nilf 'Funship.Fist.Nilf')
  - [Head](#P-Funship-Fist-Nilf-Head 'Funship.Fist.Nilf.Head')
  - [IsNil](#P-Funship-Fist-Nilf-IsNil 'Funship.Fist.Nilf.IsNil')
  - [Tail](#P-Funship-Fist-Nilf-Tail 'Funship.Fist.Nilf.Tail')
  - [Deconstruct(head,tail)](#M-Funship-Fist-Nilf-Deconstruct-System-Object@,Funship-Fist@- 'Funship.Fist.Nilf.Deconstruct(System.Object@,Funship.Fist@)')
  - [Equals(obj)](#M-Funship-Fist-Nilf-Equals-System-Object- 'Funship.Fist.Nilf.Equals(System.Object)')
  - [GetHashCode()](#M-Funship-Fist-Nilf-GetHashCode 'Funship.Fist.Nilf.GetHashCode')
- [SFist](#T-Funship-Fist-SFist 'Funship.Fist.SFist')
- [WFunf](#T-Funship-Funf-WFunf 'Funship.Funf.WFunf')

<a name='T-Funship-Funf-CapFunf'></a>
## CapFunf `type`

##### Namespace

Funship.Funf

##### Summary

A function that encloses some captured args

<a name='T-Funship-Funf-CompFunf'></a>
## CompFunf `type`

##### Namespace

Funship.Funf

##### Summary

Composed function that, when executed, will pass its outcome to another function

<a name='T-Funship-Fist-DFist`1'></a>
## DFist\`1 `type`

##### Namespace

Funship.Fist

##### Summary

Dynamic list

<a name='T-Funship-Fist'></a>
## Fist `type`

##### Namespace

Funship

##### Summary

Represents a functional list that is constructed with a [Head](#P-Funship-Fist-Head 'Funship.Fist.Head'),
 which is the first element in the functional list, and a [Tail](#P-Funship-Fist-Tail 'Funship.Fist.Tail')
 which reprents the remainder of the functional list without the tail.

##### Example

using static Funship.Fist;
 
 static int Main(string[] args)
 {
     var list = fist(args);
     
     return list switch
     {
         Nilf _ => 0,    // return 0 if no args were passed
         (var head, Nilf _) => 1,    // returns 1 if exactly one arg was passed
         (var head, Fist _) => 2,    // returns 2 two or more args were passed
     };
 }

##### Remarks

Create a fist using [fist](#M-Funship-Fist-fist-System-Object[]- 'Funship.Fist.fist(System.Object[])') or [to_fist\`\`1](#M-Funship-Fist-to_fist``1-System-Collections-Generic-IEnumerable{``0}- 'Funship.Fist.to_fist``1(System.Collections.Generic.IEnumerable{``0})').
 
 A [Fist](#T-Funship-Fist 'Funship.Fist') can be matched as a [ValueTuple\`2](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ValueTuple`2 'System.ValueTuple`2')
 in a `switch` statement.

 An empty list, which as a [Tail](#P-Funship-Fist-Tail 'Funship.Fist.Tail') value also indicates the end of a non-empty list,
 is represented by [nilf](#F-Funship-Fist-nilf 'Funship.Fist.nilf'), which can be matched by type [Nilf](#T-Funship-Fist-Nilf 'Funship.Fist.Nilf').

 All [Fist](#T-Funship-Fist 'Funship.Fist') implementations must be immutable and should be internal or private
 within the assemblies that define them.

<a name='F-Funship-Fist-nilf'></a>
### nilf `constants`

##### Summary

Singleton [Nilf](#T-Funship-Fist-Nilf 'Funship.Fist.Nilf') that is used to represent an empty [Fist](#T-Funship-Fist 'Funship.Fist').

<a name='P-Funship-Fist-Head'></a>
### Head `property`

##### Summary

Gets the first element in the [Fist](#T-Funship-Fist 'Funship.Fist')

<a name='P-Funship-Fist-IsNil'></a>
### IsNil `property`

##### Summary

Gets whether the [Fist](#T-Funship-Fist 'Funship.Fist') is an empty/nil list. Only the [Nilf](#T-Funship-Fist-Nilf 'Funship.Fist.Nilf') type's
[nilf](#F-Funship-Fist-nilf 'Funship.Fist.nilf') instance will return `true`.

<a name='P-Funship-Fist-Tail'></a>
### Tail `property`

##### Summary

Gets the part of the list remaining in the [Fist](#T-Funship-Fist 'Funship.Fist') after the [Head](#P-Funship-Fist-Head 'Funship.Fist.Head')

<a name='M-Funship-Fist-Deconstruct-System-Object@,Funship-Fist@-'></a>
### Deconstruct(head,tail) `method`

##### Summary

Provides a [ValueTuple\`2](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ValueTuple`2 'System.ValueTuple`2') deconstruction of the [Fist](#T-Funship-Fist 'Funship.Fist')

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| head | [System.Object@](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object@ 'System.Object@') | First item of the deconstruction is the [Head](#P-Funship-Fist-Head 'Funship.Fist.Head') |
| tail | [Funship.Fist@](#T-Funship-Fist@ 'Funship.Fist@') | Second item of the deconstruction is the [Tail](#P-Funship-Fist-Tail 'Funship.Fist.Tail') |

<a name='M-Funship-Fist-all-Funship-Fist,Funship-Funf-'></a>
### all(list,fun) `method`

##### Summary

Determines whether a given predicate [Funf](#T-Funship-Funf 'Funship.Funf') is `true`
for all elements in a [Fist](#T-Funship-Fist 'Funship.Fist').

##### Returns

`true` if `fun` returns `true` for all elements in the list, else `false`

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| list | [Funship.Fist](#T-Funship-Fist 'Funship.Fist') | [Fist](#T-Funship-Fist 'Funship.Fist') whose elements will be tested against the predicate |
| fun | [Funship.Funf](#T-Funship-Funf 'Funship.Funf') | [Funf](#T-Funship-Funf 'Funship.Funf') that should accept a value and return a [Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') |

##### Example

var val = all(fist(1, 2, 3, 4), x => x < 5)     // val = true

##### Remarks

Testing elements of a [Fist](#T-Funship-Fist 'Funship.Fist') against a predicate causes it to be traversed, meaning that any delayed lazy traversal
costs will be incurred at the time of this call. However, traversal will stop as soon as the first
`false` predicate return value is encounted.

<a name='M-Funship-Fist-any-Funship-Fist,Funship-Funf-'></a>
### any(list,fun) `method`

##### Summary

Determines whether a given predicate [Funf](#T-Funship-Funf 'Funship.Funf') is `true`
for any element in a [Fist](#T-Funship-Fist 'Funship.Fist').

##### Returns

`true` if `fun` returns `true` for at least one element in the list, else `false`

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| list | [Funship.Fist](#T-Funship-Fist 'Funship.Fist') | [Fist](#T-Funship-Fist 'Funship.Fist') whose elements will be tested against the predicate |
| fun | [Funship.Funf](#T-Funship-Funf 'Funship.Funf') | [Funf](#T-Funship-Funf 'Funship.Funf') that should accept a value and return a [Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') |

##### Example

var val = any(fist(1, 2, 3, 4), x => x > 5)     // val = false

##### Remarks

Testing elements of a [Fist](#T-Funship-Fist 'Funship.Fist') against a predicate causes it to be traversed, meaning that any delayed lazy traversal
costs will be incurred at the time of this call. However, traversal will stop as soon as the first
`true` predicate return value is encounted.

<a name='M-Funship-Fist-equals-Funship-Fist,Funship-Fist-'></a>
### equals(left,right) `method`

##### Summary

Tests equality between two [Fist](#T-Funship-Fist 'Funship.Fist') instances.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| left | [Funship.Fist](#T-Funship-Fist 'Funship.Fist') |  |
| right | [Funship.Fist](#T-Funship-Fist 'Funship.Fist') |  |

##### Remarks

Testing equality of two [Fist](#T-Funship-Fist 'Funship.Fist') instances causes them to be traversed in parallel,
 meaning that any delayed lazy traversal costs will be incurred at the time of this call. However,
 traversal stops at the first pair of [Head](#P-Funship-Fist-Head 'Funship.Fist.Head') elements that are not equal.

 Two fists are considered equal if their items, traversed in parallel, are each equal as
 determined by a call to [Equals](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object.Equals 'System.Object.Equals(System.Object,System.Object)').

<a name='M-Funship-Fist-fist-System-Object,Funship-Fist-'></a>
### fist(head,tail) `method`

##### Summary

Creates a new [Fist](#T-Funship-Fist 'Funship.Fist') by appending a head to an existing tail.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| head | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') |  |
| tail | [Funship.Fist](#T-Funship-Fist 'Funship.Fist') |  |

<a name='M-Funship-Fist-fist-System-Object[]-'></a>
### fist(vals) `method`

##### Summary

Creates a new [Fist](#T-Funship-Fist 'Funship.Fist') from a given set of values

##### Returns

A new [Fist](#T-Funship-Fist 'Funship.Fist') containing the passed values in the order in which they were passed

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| vals | [System.Object[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object[] 'System.Object[]') | Values to add to a list |

##### Example

var list = fist(1, 2, 3, 4);    // list = Fist with head 1 and tail of fist(2, 3, 4)
var empty_list = fist();        // empty_list = [nilf](#F-Funship-Fist-nilf 'Funship.Fist.nilf')

##### Remarks

There are two scenarios when this will return [nilf](#F-Funship-Fist-nilf 'Funship.Fist.nilf'):
1. When `vals` is empty, i.e. no values are passed in the call.
2. When a single `null` is passed.

<a name='M-Funship-Fist-hash_code-Funship-Fist-'></a>
### hash_code(list) `method`

##### Summary

Generates a hash code for a [Fist](#T-Funship-Fist 'Funship.Fist')

##### Returns

Generated hash code

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| list | [Funship.Fist](#T-Funship-Fist 'Funship.Fist') | [Fist](#T-Funship-Fist 'Funship.Fist') to generate hash code for |

##### Remarks

Calculating a hash code for a [Fist](#T-Funship-Fist 'Funship.Fist') causes it to be traversed, meaning that any
delayed lazy traversal costs will be incurred at the time of this call.

<a name='M-Funship-Fist-map-Funship-Fist,System-Func{System-Object,System-Object}-'></a>
### map(list,fun) `method`

##### Summary

Map a [Fist](#T-Funship-Fist 'Funship.Fist') using a given [Funf](#T-Funship-Funf 'Funship.Funf')

##### Returns

Mapped version of `list`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| list | [Funship.Fist](#T-Funship-Fist 'Funship.Fist') | [Fist](#T-Funship-Fist 'Funship.Fist') to map |
| fun | [System.Func{System.Object,System.Object}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{System.Object,System.Object}') | [Funf](#T-Funship-Funf 'Funship.Funf') to map `list` to |

##### Example

var mapped = map(fist(1, 2, 3, 4), x => 2 * x); // mapped = fist(2, 4, 6, 8)

##### Remarks

Mapping is done in a lazy manner. `fun` is called on an
element of `list` as it is traversed.

<a name='M-Funship-Fist-print-Funship-Fist,System-String-'></a>
### print(list,delimiter) `method`

##### Summary

Writes a [Fist](#T-Funship-Fist 'Funship.Fist') to [Out](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Console.Out 'System.Console.Out') with no newline appended

##### Returns

`list`

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| list | [Funship.Fist](#T-Funship-Fist 'Funship.Fist') | [Fist](#T-Funship-Fist 'Funship.Fist') to print |
| delimiter | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Optional [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') to join printed values. Defaults to a single space. |

##### Example

print(fist(1, 2, 3, 4), "; "); // prints "1; 2; 3; 4" to stdout

##### Remarks

Printing a [Fist](#T-Funship-Fist 'Funship.Fist') causes it to be traversed, meaning that any delayed lazy traversal
costs will be incurred at the time of this call.

<a name='M-Funship-Fist-print-Funship-Fist,System-IO-TextWriter,System-String-'></a>
### print(list,tw,delimiter) `method`

##### Summary

Writes a [Fist](#T-Funship-Fist 'Funship.Fist') to a specified [TextWriter](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.TextWriter 'System.IO.TextWriter') no newline appended

##### Returns

`list`

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| list | [Funship.Fist](#T-Funship-Fist 'Funship.Fist') | [Fist](#T-Funship-Fist 'Funship.Fist') to print |
| tw | [System.IO.TextWriter](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.TextWriter 'System.IO.TextWriter') | [TextWriter](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.TextWriter 'System.IO.TextWriter') to print `list` to |
| delimiter | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Optional [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') to join printed values. Defaults to a single space. |

##### Example

using var tw = new StringWriter();
print(fist(1, 2, 3, 4), "; ");
var val = tw.ToString();        // val = "1; 2; 3; 4"

##### Remarks

Printing a [Fist](#T-Funship-Fist 'Funship.Fist') causes it to be traversed, meaning that any delayed lazy traversal
costs will be incurred at the time of this call.

<a name='M-Funship-Fist-println-Funship-Fist,System-String-'></a>
### println(list,delimiter) `method`

##### Summary

Writes a [Fist](#T-Funship-Fist 'Funship.Fist') to [Out](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Console.Out 'System.Console.Out') with a newline appended

##### Returns

`list`

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| list | [Funship.Fist](#T-Funship-Fist 'Funship.Fist') | [Fist](#T-Funship-Fist 'Funship.Fist') to print |
| delimiter | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Optional [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') to join printed values. Defaults to a single space. |

##### Example

println(fist(1, 2, 3, 4), "; "); // write "1; 2; 3; 4\n" to stdout

##### Remarks

Printing a [Fist](#T-Funship-Fist 'Funship.Fist') causes it to be traversed, meaning that any delayed lazy traversal
costs will be incurred at the time of this call.

<a name='M-Funship-Fist-println-Funship-Fist,System-IO-TextWriter,System-String-'></a>
### println(list,tw,delimiter) `method`

##### Summary

Writes a [Fist](#T-Funship-Fist 'Funship.Fist') to a specified [TextWriter](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.TextWriter 'System.IO.TextWriter') a newline appended

##### Returns

`list`

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| list | [Funship.Fist](#T-Funship-Fist 'Funship.Fist') | [Fist](#T-Funship-Fist 'Funship.Fist') to print |
| tw | [System.IO.TextWriter](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.TextWriter 'System.IO.TextWriter') | [TextWriter](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.TextWriter 'System.IO.TextWriter') to print `list` to |
| delimiter | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Optional [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') to join printed values. Defaults to a single space. |

##### Example

using var tw = new StringWriter();
println(fist(1, 2, 3, 4), "; ");
var val = tw.ToString();        // val = "1; 2; 3; 4\n"

##### Remarks

Printing a [Fist](#T-Funship-Fist 'Funship.Fist') causes it to be traversed, meaning that any delayed lazy traversal
costs will be incurred at the time of this call.

<a name='M-Funship-Fist-reduce-Funship-Fist,System-Func{System-Object,System-Object,System-Object}-'></a>
### reduce(list,fun) `method`

##### Summary

Reduces a [Fist](#T-Funship-Fist 'Funship.Fist') using a [Funf](#T-Funship-Funf 'Funship.Funf') that accepts an element
 and an accumulator.

##### Returns

Reduced value

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| list | [Funship.Fist](#T-Funship-Fist 'Funship.Fist') | [Fist](#T-Funship-Fist 'Funship.Fist') to reduce |
| fun | [System.Func{System.Object,System.Object,System.Object}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{System.Object,System.Object,System.Object}') | A [Funf](#T-Funship-Funf 'Funship.Funf') that should accept an element and an accumulator and return an updated value |

##### Example

var val = reduce(fist(1, 2, 3, 4), (el, acc) => el + acc; // val = 10

##### Remarks

Reducing a [Fist](#T-Funship-Fist 'Funship.Fist') causes it to be traversed, meaning that any delayed lazy traversal
 costs will be incurred at the time of this call.

 The initial call to `fun` will send the [Head](#P-Funship-Fist-Head 'Funship.Fist.Head') of `list`
 as the first accumulator value. The actual traversal runs over [Tail](#P-Funship-Fist-Tail 'Funship.Fist.Tail') of `list`.

 Any attempt to reduce [nilf](#F-Funship-Fist-nilf 'Funship.Fist.nilf') in this overload of [reduce](#M-Funship-Fist-reduce-Funship-Fist,System-Func{System-Object,System-Object,System-Object}- 'Funship.Fist.reduce(Funship.Fist,System.Func{System.Object,System.Object,System.Object})')
 will result in [nilf](#F-Funship-Fist-nilf 'Funship.Fist.nilf').

<a name='M-Funship-Fist-reduce-Funship-Fist,System-Object,System-Func{System-Object,System-Object,System-Object}-'></a>
### reduce(list,acc,fun) `method`

##### Summary

Reduces a [Fist](#T-Funship-Fist 'Funship.Fist') using a [Funf](#T-Funship-Funf 'Funship.Funf') that accepts an element
 and an accumulator.

##### Returns

Reduced value

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| list | [Funship.Fist](#T-Funship-Fist 'Funship.Fist') | [Fist](#T-Funship-Fist 'Funship.Fist') to reduce |
| acc | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | Initial accumulator value |
| fun | [System.Func{System.Object,System.Object,System.Object}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{System.Object,System.Object,System.Object}') | A [Funf](#T-Funship-Funf 'Funship.Funf') that should accept an element and an accumulator and return an updated value |

##### Example

var val = reduce(fist(1, 2, 3, 4), true, (el, acc) => acc && (el < 5); // val = true

##### Remarks

Reducing a [Fist](#T-Funship-Fist 'Funship.Fist') causes it to be traversed, meaning that any delayed lazy traversal
 costs will be incurred at the time of this call.

 Any attempt to reduce [nilf](#F-Funship-Fist-nilf 'Funship.Fist.nilf') in this overload of [reduce](#M-Funship-Fist-reduce-Funship-Fist,System-Object,System-Func{System-Object,System-Object,System-Object}- 'Funship.Fist.reduce(Funship.Fist,System.Object,System.Func{System.Object,System.Object,System.Object})')
 will result in returning `acc`.

<a name='M-Funship-Fist-reverse-Funship-Fist-'></a>
### reverse(list) `method`

##### Summary

Creates a [Fist](#T-Funship-Fist 'Funship.Fist') with the elements from `list` in
reversed order.

##### Returns

New [Fist](#T-Funship-Fist 'Funship.Fist') with elements from `list` in reversed order

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| list | [Funship.Fist](#T-Funship-Fist 'Funship.Fist') | [Fist](#T-Funship-Fist 'Funship.Fist') to get reversed elements from |

##### Example

var val = reverse(fist(1, 2, 3, 4))     // val = fist(4, 3, 2, 1)

##### Remarks

Reversing a [Fist](#T-Funship-Fist 'Funship.Fist') causes it to be traversed, meaning that any delayed lazy traversal
costs will be incurred at the time of this call.

<a name='M-Funship-Fist-to_fist``1-System-Collections-Generic-IEnumerable{``0}-'></a>
### to_fist\`\`1(vals) `method`

##### Summary

Converts a given [IEnumerable\`1](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable`1 'System.Collections.Generic.IEnumerable`1') to a [Fist](#T-Funship-Fist 'Funship.Fist').

##### Returns

[Fist](#T-Funship-Fist 'Funship.Fist') containing the items in `vals`

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| vals | [System.Collections.Generic.IEnumerable{\`\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{``0}') | Collection of items that the new [Fist](#T-Funship-Fist 'Funship.Fist') should contain in order |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | Type contained in the [IEnumerable\`1](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable`1 'System.Collections.Generic.IEnumerable`1') |

##### Example

var list = to_fist(new [] { 1, 2, 3, 4 });    // list = Fist with head 1 and tail of fist(2, 3, 4)
var empty_list = to_fist(new object[0]);      // empty_list = [nilf](#F-Funship-Fist-nilf 'Funship.Fist.nilf')

##### Remarks

The [Fist](#T-Funship-Fist 'Funship.Fist') creation is done in a lazy manner. Each item in `vals`
is enumerated over only as the [Fist](#T-Funship-Fist 'Funship.Fist') is traversed.

<a name='T-Funship-Funf'></a>
## Funf `type`

##### Namespace

Funship

##### Summary

Represents a functional-style function.

##### Remarks

A basic [Funf](#T-Funship-Funf 'Funship.Funf') is a container for one of the various [Func\`1](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func`1 'System.Func`1')
 types, of which there are 17 variants (0 to 16 arguments). See the overloads of [funf](#M-Funship-Funf-funf-System-Func{System-Object}- 'Funship.Funf.funf(System.Func{System.Object})')
 for a full list of functional delegate types that can be wrapped.

 They can get more advanced.

 For example, when a [Funf](#T-Funship-Funf 'Funship.Funf') is called via [call](#M-Funship-Funf-call-Funship-Funf,System-Object[]- 'Funship.Funf.call(Funship.Funf,System.Object[])'),
 depending on the number of arguments passed and the [arity](#P-Funship-Funf-arity 'Funship.Funf.arity'), it may be partially called,
 fully called, or even overflowed, returning its own return value along with the extra arguments.
 See documentation for [call](#M-Funship-Funf-call-Funship-Funf,System-Object[]- 'Funship.Funf.call(Funship.Funf,System.Object[])') for more information.

 A [Funf](#T-Funship-Funf 'Funship.Funf') may also capture arguments without attempting to execute via a call to
 [capture](#M-Funship-Funf-capture-Funship-Funf,System-Object[]- 'Funship.Funf.capture(Funship.Funf,System.Object[])'). This creates a new [Funf](#T-Funship-Funf 'Funship.Funf')
 that encloses the passed arguments such that they will be used at the time the [Funf](#T-Funship-Funf 'Funship.Funf')
 is called.

 Additionally, calling [compose](#M-Funship-Funf-compose-Funship-Funf,Funship-Funf- 'Funship.Funf.compose(Funship.Funf,Funship.Funf)') allows you to create a new
 function `h` that composes given functions `f` and `g` such that
 upon being called, `h` applies arguments to `f` until `f` can be executed,
 at which time any results from `f` are applied to `g` along with any remaining
 arguments that were not used by `f`.

 Any time a [Funf](#T-Funship-Funf 'Funship.Funf') is passed as an argument to [call](#M-Funship-Funf-call-Funship-Funf,System-Object[]- 'Funship.Funf.call(Funship.Funf,System.Object[])')
 or [capture](#M-Funship-Funf-capture-Funship-Funf,System-Object[]- 'Funship.Funf.capture(Funship.Funf,System.Object[])'), the returned [Funf](#T-Funship-Funf 'Funship.Funf') will compose the
 argument Funf together with the original.

##### See Also

- [Funship.Funf.call](#M-Funship-Funf-call-Funship-Funf,System-Object[]- 'Funship.Funf.call(Funship.Funf,System.Object[])')
- [Funship.Funf.capture](#M-Funship-Funf-capture-Funship-Funf,System-Object[]- 'Funship.Funf.capture(Funship.Funf,System.Object[])')
- [Funship.Funf.compose](#M-Funship-Funf-compose-Funship-Funf,Funship-Funf- 'Funship.Funf.compose(Funship.Funf,Funship.Funf)')

<a name='P-Funship-Funf-arity'></a>
### arity `property`

##### Summary

Gets the number of arguments the [Funf](#T-Funship-Funf 'Funship.Funf') needs before it can be fully called.

##### Remarks

This may be a negative number indicating that the arguments are overflowing. If such a
[Funf](#T-Funship-Funf 'Funship.Funf') is called, then the return value will be an [IEnumerable\`1](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable`1 'System.Collections.Generic.IEnumerable`1')
with the return value as the first item followed by the unneeded arguments.

<a name='M-Funship-Funf-call-Funship-Funf,System-Object[]-'></a>
### call(f,args) `method`

##### Summary

Attempts to fully execute a `f` using a combination of any enclosed args, which
 are applied first, and the passed `args`.

##### Returns

If the number of arguments passed is fewer than [arity](#P-Funship-Funf-arity 'Funship.Funf.arity'), then a [Funf](#T-Funship-Funf 'Funship.Funf')
 is returned with the passed args captured.

 If the number of arguments passed is equal to [arity](#P-Funship-Funf-arity 'Funship.Funf.arity'), then the result of the execution
 is returned.

 If the number of arguments passes is greater than [arity](#P-Funship-Funf-arity 'Funship.Funf.arity'), then an [IEnumerable\`1](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable`1 'System.Collections.Generic.IEnumerable`1')
 is returned comprised of the result of executing `f` followed by the unused values
 from `args`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| f | [Funship.Funf](#T-Funship-Funf 'Funship.Funf') | [Funf](#T-Funship-Funf 'Funship.Funf') to call |
| args | [System.Object[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object[] 'System.Object[]') | Arguments to apply in the call |

##### Example

var f = funf((x, y, z) => x + y - z);
 var g = capture(f, 2);
 var h = capture(g, 3);
 var i = capture(g, f, 10);

 var v = call(f, 5, 4, 18);  // v = -9
 var w = call(g, 4, 18);     // w = -12
 var x = call(h, 18);        // x = -13
 var y = call(i);// y = -13
 var z = call(h, 18, 24, 30) // z = [IEnumerable\`1](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable`1 'System.Collections.Generic.IEnumerable`1') of [-13, 24, 30]

##### Remarks

If any passed item in `args` is a [Funf](#T-Funship-Funf 'Funship.Funf'), then it will be composed
 with the `f` such that arguments following the new [Funf](#T-Funship-Funf 'Funship.Funf') will be
 applied to it first, and the result from the passed [Funf](#T-Funship-Funf 'Funship.Funf') will become an argument
 that is sent to `f`, replacing the passed [Funf](#T-Funship-Funf 'Funship.Funf') and any args that
 it may have consumed.

<a name='M-Funship-Funf-capture-Funship-Funf,System-Object[]-'></a>
### capture(f,args) `method`

##### Summary

Creates a new [Funf](#T-Funship-Funf 'Funship.Funf') with passed args enclosed.

##### Returns

New [Funf](#T-Funship-Funf 'Funship.Funf') enclosing `f` and the captured `args`

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| f | [Funship.Funf](#T-Funship-Funf 'Funship.Funf') | [Funf](#T-Funship-Funf 'Funship.Funf') which will be enclosed with the given arguments |
| args | [System.Object[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object[] 'System.Object[]') | Arguments |

##### Example

var f = funf((x, y, z) => x + y - z);
 var g = capture(f, 2);
 var h = capture(g, 3);
 var i = capture(g, f, 10);

 var v = call(f, 5, 4, 18);  // v = -9
 var w = call(g, 4, 18);     // w = -12
 var x = call(h, 18);        // x = -13
 var y = call(i);// y = -13
 var z = call(h, 18, 24, 30) // z = [IEnumerable\`1](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable`1 'System.Collections.Generic.IEnumerable`1') of [-13, 24, 30]

##### Remarks

The [arity](#P-Funship-Funf-arity 'Funship.Funf.arity') of the new [Funf](#T-Funship-Funf 'Funship.Funf') will be reduced by the number of passed
 arguments. This may cause it to become negative, and that's okay.

 If any passed item in `args` is a [Funf](#T-Funship-Funf 'Funship.Funf'), then it will be composed
 with the `f` such that arguments following the new [Funf](#T-Funship-Funf 'Funship.Funf') will be
 applied to it first, and upon calling the returned [Funf](#T-Funship-Funf 'Funship.Funf'), the result from the passed
 [Funf](#T-Funship-Funf 'Funship.Funf') will become an argument that is sent to `f`, replacing the
 passed [Funf](#T-Funship-Funf 'Funship.Funf') and any args that it may have consumed.

<a name='M-Funship-Funf-compose-Funship-Funf,Funship-Funf-'></a>
### compose(f,g) `method`

##### Summary

Composes `f` and `g` to create a new
 [Funf](#T-Funship-Funf 'Funship.Funf') that applies its arguments first to `f` and
 then to `g`. The result of `f` becomes one of the
 arguments passed to `g`.

##### Returns

New composed [Funf](#T-Funship-Funf 'Funship.Funf')

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| f | [Funship.Funf](#T-Funship-Funf 'Funship.Funf') | [Funf](#T-Funship-Funf 'Funship.Funf') to which arguments will be applied first and whose result will become an argument to `g` |
| g | [Funship.Funf](#T-Funship-Funf 'Funship.Funf') | [Funf](#T-Funship-Funf 'Funship.Funf') to which arguments will be applied second, including the result from `f` |

##### Example

var f = funf(x => x - 2);
 var g = funf(y => y * 2);

 var h = compose(f, g);      // h(x) -> g(f(x))
 var x = call(h, 10);        // x = 16
 
 var i = compose(h, f);      // i(x) -> f(h(x)) -> f(g(f(x)))
 var y = call(i, 10);        // y = 14

##### Remarks

The mathematical description of composed functions is: `h(x) -> g(f(x))`.
 If `f` and `g` each take one argument, then that
 is exactly what you will get upon calling the composed [Funf](#T-Funship-Funf 'Funship.Funf').

<a name='M-Funship-Funf-funf-System-Func{System-Object}-'></a>
### funf(func) `method`

##### Summary

Creates a new [Funf](#T-Funship-Funf 'Funship.Funf') from a given
[Func\`1](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func`1 'System.Func`1')

##### Returns

New [Funf](#T-Funship-Funf 'Funship.Funf')

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| func | [System.Func{System.Object}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{System.Object}') | Function that will be executed upon successful call |

##### Example

var f = Funf(() => 0);
var x = call(f);        // x = 0

<a name='M-Funship-Funf-funf-System-Func{System-Object,System-Object}-'></a>
### funf(func) `method`

##### Summary

Creates a new [Funf](#T-Funship-Funf 'Funship.Funf') from a given
[Func\`2](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func`2 'System.Func`2')

##### Returns

New [Funf](#T-Funship-Funf 'Funship.Funf')

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| func | [System.Func{System.Object,System.Object}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{System.Object,System.Object}') | Function that will be executed upon successful call |

##### Example

var f = Funf((arg) => arg);
var x = call(f, 1);        // x = 1

<a name='M-Funship-Funf-funf-System-Func{System-Object,System-Object,System-Object}-'></a>
### funf(func) `method`

##### Summary

Creates a new [Funf](#T-Funship-Funf 'Funship.Funf') from a given
[Func\`3](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func`3 'System.Func`3')

##### Returns

New [Funf](#T-Funship-Funf 'Funship.Funf')

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| func | [System.Func{System.Object,System.Object,System.Object}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{System.Object,System.Object,System.Object}') | Function that will be executed upon successful call |

##### Example

var f = Funf((a1, a2) => a1 + a2);
var x = call(f, 1, 1);        // x = 2

<a name='M-Funship-Funf-funf-System-Func{System-Object,System-Object,System-Object,System-Object}-'></a>
### funf(func) `method`

##### Summary

Creates a new [Funf](#T-Funship-Funf 'Funship.Funf') from a given
[Func\`4](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func`4 'System.Func`4')

##### Returns

New [Funf](#T-Funship-Funf 'Funship.Funf')

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| func | [System.Func{System.Object,System.Object,System.Object,System.Object}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{System.Object,System.Object,System.Object,System.Object}') | Function that will be executed upon successful call |

##### Example

var f = Funf((a1, a2, a3) => a1 + a2 + a3);
var x = call(f, 1, 1, 1);        // x = 3

<a name='M-Funship-Funf-funf-System-Func{System-Object,System-Object,System-Object,System-Object,System-Object}-'></a>
### funf(func) `method`

##### Summary

Creates a new [Funf](#T-Funship-Funf 'Funship.Funf') from a given
[Func\`5](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func`5 'System.Func`5')

##### Returns

New [Funf](#T-Funship-Funf 'Funship.Funf')

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| func | [System.Func{System.Object,System.Object,System.Object,System.Object,System.Object}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{System.Object,System.Object,System.Object,System.Object,System.Object}') | Function that will be executed upon successful call |

##### Example

var f = Funf((a1, a2, a3, a4) => a1 + a2 + a3 + a4);
var x = call(f, 1, 1, 1, 1);        // x = 4

<a name='M-Funship-Funf-funf-System-Func{System-Object,System-Object,System-Object,System-Object,System-Object,System-Object}-'></a>
### funf(func) `method`

##### Summary

Creates a new [Funf](#T-Funship-Funf 'Funship.Funf') from a given
[Func\`6](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func`6 'System.Func`6')

##### Returns

New [Funf](#T-Funship-Funf 'Funship.Funf')

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| func | [System.Func{System.Object,System.Object,System.Object,System.Object,System.Object,System.Object}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{System.Object,System.Object,System.Object,System.Object,System.Object,System.Object}') | Function that will be executed upon successful call |

##### Example

var f = Funf((a1, a2, a3, a4, a5) => a1 + a2 + a3 + a4 + a5);
var x = call(f, 1, 1, 1, 1, 1);        // x = 5

<a name='M-Funship-Funf-funf-System-Func{System-Object,System-Object,System-Object,System-Object,System-Object,System-Object,System-Object}-'></a>
### funf(func) `method`

##### Summary

Creates a new [Funf](#T-Funship-Funf 'Funship.Funf') from a given
[Func\`7](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func`7 'System.Func`7')

##### Returns

New [Funf](#T-Funship-Funf 'Funship.Funf')

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| func | [System.Func{System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object}') | Function that will be executed upon successful call |

##### Example

var f = Funf((a1, a2, a3, a4, a5, a6) => a1 + a2 + a3 + a4 + a5 + a6);
var x = call(f, 1, 1, 1, 1, 1, 1);        // x = 6

<a name='M-Funship-Funf-funf-System-Func{System-Object,System-Object,System-Object,System-Object,System-Object,System-Object,System-Object,System-Object}-'></a>
### funf(func) `method`

##### Summary

Creates a new [Funf](#T-Funship-Funf 'Funship.Funf') from a given
[Func\`8](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func`8 'System.Func`8')

##### Returns

New [Funf](#T-Funship-Funf 'Funship.Funf')

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| func | [System.Func{System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object}') | Function that will be executed upon successful call |

##### Example

var f = Funf((a1, a2, a3, a4, a5, a6, a7) => a1 + a2 + a3 + a4 + a5 + a6 + a7);
var x = call(f, 1, 1, 1, 1, 1, 1, 1);        // x = 7

<a name='M-Funship-Funf-funf-System-Func{System-Object,System-Object,System-Object,System-Object,System-Object,System-Object,System-Object,System-Object,System-Object}-'></a>
### funf(func) `method`

##### Summary

Creates a new [Funf](#T-Funship-Funf 'Funship.Funf') from a given
[Func\`9](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func`9 'System.Func`9')

##### Returns

New [Funf](#T-Funship-Funf 'Funship.Funf')

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| func | [System.Func{System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object}') | Function that will be executed upon successful call |

##### Example

var f = Funf((a1, a2, a3, a4, a5, a6, a7, a8) => a1 + a2 + a3 + a4 + a5 + a6 + a7 + a8);
var x = call(f, 1, 1, 1, 1, 1, 1, 1, 1);        // x = 8

<a name='M-Funship-Funf-funf-System-Func{System-Object,System-Object,System-Object,System-Object,System-Object,System-Object,System-Object,System-Object,System-Object,System-Object}-'></a>
### funf(func) `method`

##### Summary

Creates a new [Funf](#T-Funship-Funf 'Funship.Funf') from a given
[Func\`10](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func`10 'System.Func`10')

##### Returns

New [Funf](#T-Funship-Funf 'Funship.Funf')

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| func | [System.Func{System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object}') | Function that will be executed upon successful call |

##### Example

var f = Funf((a1, a2, a3, a4, a5, a6, a7, a8, a9) => a1 + a2 + a3 + a4 + a5 + a6 + a7 + a8 + a9);
var x = call(f, 1, 1, 1, 1, 1, 1, 1, 1, 1);        // x = 9

<a name='M-Funship-Funf-funf-System-Func{System-Object,System-Object,System-Object,System-Object,System-Object,System-Object,System-Object,System-Object,System-Object,System-Object,System-Object}-'></a>
### funf(func) `method`

##### Summary

Creates a new [Funf](#T-Funship-Funf 'Funship.Funf') from a given
[Func\`11](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func`11 'System.Func`11')

##### Returns

New [Funf](#T-Funship-Funf 'Funship.Funf')

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| func | [System.Func{System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object}') | Function that will be executed upon successful call |

##### Example

var f = Funf((a1, a2, a3, a4, a5, a6, a7, a8, a9, a10) => a1 + a2 + a3 + a4 + a5 + a6 + a7 + a8 + a9 + a10);
var x = call(f, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1);        // x = 10

<a name='M-Funship-Funf-funf-System-Func{System-Object,System-Object,System-Object,System-Object,System-Object,System-Object,System-Object,System-Object,System-Object,System-Object,System-Object,System-Object}-'></a>
### funf(func) `method`

##### Summary

Creates a new [Funf](#T-Funship-Funf 'Funship.Funf') from a given
[Func\`12](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func`12 'System.Func`12')

##### Returns

New [Funf](#T-Funship-Funf 'Funship.Funf')

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| func | [System.Func{System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object}') | Function that will be executed upon successful call |

##### Example

var f = Funf((a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11) => a1 + a2 + a3 + a4 + a5 + a6 + a7 + a8 + a9 + a10 + a11);
var x = call(f, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1);        // x = 11

<a name='M-Funship-Funf-funf-System-Func{System-Object,System-Object,System-Object,System-Object,System-Object,System-Object,System-Object,System-Object,System-Object,System-Object,System-Object,System-Object,System-Object}-'></a>
### funf(func) `method`

##### Summary

Creates a new [Funf](#T-Funship-Funf 'Funship.Funf') from a given
[Func\`13](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func`13 'System.Func`13')

##### Returns

New [Funf](#T-Funship-Funf 'Funship.Funf')

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| func | [System.Func{System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object}') | Function that will be executed upon successful call |

##### Example

var f = Funf((a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12) => a1 + a2 + a3 + a4 + a5 + a6 + a7 + a8 + a9 + a10 + a11 + a12);
var x = call(f, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1);        // x = 12

<a name='M-Funship-Funf-funf-System-Func{System-Object,System-Object,System-Object,System-Object,System-Object,System-Object,System-Object,System-Object,System-Object,System-Object,System-Object,System-Object,System-Object,System-Object}-'></a>
### funf(func) `method`

##### Summary

Creates a new [Funf](#T-Funship-Funf 'Funship.Funf') from a given
[Func\`14](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func`14 'System.Func`14')

##### Returns

New [Funf](#T-Funship-Funf 'Funship.Funf')

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| func | [System.Func{System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object}') | Function that will be executed upon successful call |

##### Example

var f = Funf((a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13) => a1 + a2 + a3 + a4 + a5 + a6 + a7 + a8 + a9 + a10 + a11 + a12 + a13);
var x = call(f, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1);        // x = 13

<a name='M-Funship-Funf-funf-System-Func{System-Object,System-Object,System-Object,System-Object,System-Object,System-Object,System-Object,System-Object,System-Object,System-Object,System-Object,System-Object,System-Object,System-Object,System-Object}-'></a>
### funf(func) `method`

##### Summary

Creates a new [Funf](#T-Funship-Funf 'Funship.Funf') from a given
[Func\`15](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func`15 'System.Func`15')

##### Returns

New [Funf](#T-Funship-Funf 'Funship.Funf')

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| func | [System.Func{System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object}') | Function that will be executed upon successful call |

##### Example

var f = Funf((a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13, a14) => a1 + a2 + a3 + a4 + a5 + a6 + a7 + a8 + a9 + a10 + a11 + a12 + a13 + a14);
var x = call(f, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1);        // x = 14

<a name='M-Funship-Funf-funf-System-Func{System-Object,System-Object,System-Object,System-Object,System-Object,System-Object,System-Object,System-Object,System-Object,System-Object,System-Object,System-Object,System-Object,System-Object,System-Object,System-Object}-'></a>
### funf(func) `method`

##### Summary

Creates a new [Funf](#T-Funship-Funf 'Funship.Funf') from a given
[Func\`16](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func`16 'System.Func`16')

##### Returns

New [Funf](#T-Funship-Funf 'Funship.Funf')

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| func | [System.Func{System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object}') | Function that will be executed upon successful call |

##### Example

var f = Funf((a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13, a14, a15) => a1 + a2 + a3 + a4 + a5 + a6 + a7 + a8 + a9 + a10 + a11 + a12 + a13 + a14 + a15);
var x = call(f, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1);        // x = 15

<a name='M-Funship-Funf-funf-System-Func{System-Object,System-Object,System-Object,System-Object,System-Object,System-Object,System-Object,System-Object,System-Object,System-Object,System-Object,System-Object,System-Object,System-Object,System-Object,System-Object,System-Object}-'></a>
### funf(func) `method`

##### Summary

Creates a new [Funf](#T-Funship-Funf 'Funship.Funf') from a given
[Func\`17](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func`17 'System.Func`17')

##### Returns

New [Funf](#T-Funship-Funf 'Funship.Funf')

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| func | [System.Func{System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object,System.Object}') | Function that will be executed upon successful call |

##### Example

var f = Funf((a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13, a14, a15, a16) => a1 + a2 + a3 + a4 + a5 + a6 + a7 + a8 + a9 + a10 + a11 + a12 + a13 + a14 + a15 + a16);
var x = call(f, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1);        // x = 16

<a name='T-Funship-Fist-MFist'></a>
## MFist `type`

##### Namespace

Funship.Fist

##### Summary

Mapped list

<a name='T-Funship-Fist-Nilf'></a>
## Nilf `type`

##### Namespace

Funship.Fist

##### Summary

Nil list. Use [nilf](#F-Funship-Fist-nilf 'Funship.Fist.nilf') to get an instance.

<a name='P-Funship-Fist-Nilf-Head'></a>
### Head `property`

##### Summary

Gets [nilf](#F-Funship-Fist-nilf 'Funship.Fist.nilf')

<a name='P-Funship-Fist-Nilf-IsNil'></a>
### IsNil `property`

##### Summary

Always `true`

<a name='P-Funship-Fist-Nilf-Tail'></a>
### Tail `property`

##### Summary

Gets [nilf](#F-Funship-Fist-nilf 'Funship.Fist.nilf')

<a name='M-Funship-Fist-Nilf-Deconstruct-System-Object@,Funship-Fist@-'></a>
### Deconstruct(head,tail) `method`

##### Summary

[Nilf](#T-Funship-Fist-Nilf 'Funship.Fist.Nilf') deconstructs into ([nilf](#F-Funship-Fist-nilf 'Funship.Fist.nilf'), [nilf](#F-Funship-Fist-nilf 'Funship.Fist.nilf')).

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| head | [System.Object@](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object@ 'System.Object@') | Will be [nilf](#F-Funship-Fist-nilf 'Funship.Fist.nilf') |
| tail | [Funship.Fist@](#T-Funship-Fist@ 'Funship.Fist@') | Will be [nilf](#F-Funship-Fist-nilf 'Funship.Fist.nilf') |

<a name='M-Funship-Fist-Nilf-Equals-System-Object-'></a>
### Equals(obj) `method`

##### Summary

Tests equality

##### Returns

`true` for any other [Nilf](#T-Funship-Fist-Nilf 'Funship.Fist.Nilf'), else `false`

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| obj | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | Object to test against |

<a name='M-Funship-Fist-Nilf-GetHashCode'></a>
### GetHashCode() `method`

##### Summary

Hash code for [Nilf](#T-Funship-Fist-Nilf 'Funship.Fist.Nilf') is always 0;

##### Returns



##### Parameters

This method has no parameters.

<a name='T-Funship-Fist-SFist'></a>
## SFist `type`

##### Namespace

Funship.Fist

##### Summary

Static list

<a name='T-Funship-Funf-WFunf'></a>
## WFunf `type`

##### Namespace

Funship.Funf

##### Summary

Simple wrapped dotnet function
