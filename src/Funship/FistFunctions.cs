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

using static Funship.Funf;

namespace Funship
{
    public partial interface Fist
    {
        /// <summary>
        /// Map a <see cref="Fist"/> using a given <see cref="Funf"/>
        /// </summary>
        /// <param name="list"><see cref="Fist"/> to map</param>
        /// <param name="fun">
        /// <see cref="Funf"/> to map <paramref name="list"/> to. Should be f(x) -> y where
        /// x is a list element and y is a mapped list element.
        /// </param>
        /// <returns>Mapped version of <paramref name="list"/>.</returns>
        /// <remarks>
        /// Mapping is done in a lazy manner. <paramref name="fun"/> is called on an
        /// element of <paramref name="list"/> as it is traversed.
        /// </remarks>
        /// <example>
        /// var mapped = map(fist(1, 2, 3, 4), funf(x => 2 * x)); // mapped = fist(2, 4, 6, 8)
        /// </example>
        public static Fist map(Fist list, Funf fun) => new MFist(list, fun);

        /// <summary>
        /// Reduces a <see cref="Fist"/> using a <see cref="Funf"/> that accepts an element
        /// and an accumulator.
        /// </summary>
        /// <param name="list"><see cref="Fist"/> to reduce</param>
        /// <param name="fun">
        /// A <see cref="Funf"/> that should accept an element and an accumulator and return an updated value.
        /// Should be in the form f(x, acc) -> new_acc, where x and acc are an element and the accumulator, and
        /// new_acc is the accumulator value having taken x into account.
        /// </param>
        /// <returns>Reduced value</returns>
        /// <remarks>
        /// Reducing a <see cref="Fist"/> causes it to be traversed, meaning that any delayed lazy traversal
        /// costs will be incurred at the time of this call.
        ///
        /// The initial call to <paramref name="fun"/> will send the <see cref="Fist.head"/> of <paramref name="list"/>
        /// as the first accumulator value. The actual traversal runs over <see cref="Fist.tail"/> of <paramref name="list"/>.
        ///
        /// Any attempt to reduce <see cref="nilf"/> in this overload of <see cref="reduce(Fist, Funf)"/>
        /// will result in <see cref="nilf"/>.
        /// </remarks>
        /// <example>
        /// var val = reduce(fist(1, 2, 3, 4), funf((el, acc) => el + acc)); // val = 10
        /// </example>
        public static dynamic reduce(Fist list, Funf fun) => list switch
        {
            Nilf _ => nilf,
            (var head, Fist tail) => reduce(tail, head, fun),
        };

        /// <summary>
        /// Reduces a <see cref="Fist"/> using a <see cref="Funf"/> that accepts an element
        /// and an accumulator.
        /// </summary>
        /// <param name="list"><see cref="Fist"/> to reduce</param>
        /// <param name="acc">Initial accumulator value</param>
        /// <param name="fun">
        /// A <see cref="Funf"/> that should accept an element and an accumulator and return an updated value.
        /// Should be in the form f(x, acc) -> new_acc, where x and acc are an element and the accumulator, and
        /// new_acc is the accumulator value having taken x into account.
        /// </param>
        /// <returns>Reduced value</returns>
        /// <remarks>
        /// Reducing a <see cref="Fist"/> causes it to be traversed, meaning that any delayed lazy traversal
        /// costs will be incurred at the time of this call.
        ///
        /// Any attempt to reduce <see cref="nilf"/> in this overload of <see cref="reduce(Fist, dynamic, Funf)"/>
        /// will result in returning <paramref name="acc"/>.
        /// </remarks>
        /// <example>
        /// var val = reduce(fist(1, 2, 3, 4), true, funf((el, acc) => acc &amp;&amp; (el &lt; 5))); // val = true
        /// </example>
        public static dynamic reduce(Fist list, dynamic acc, Funf fun) => list switch
        {
            Nilf _ => acc,
            (var head, Fist tail) => reduce(tail, call(fun, head, acc), fun),
        };

        /// <summary>
        /// Drops items from the front of the list until the current head matches a predicate
        /// </summary>
        /// <param name="list"><see cref="Fist"/> to drop items from</param>
        /// <param name="predicate"><see cref="Funf"/> to match against. Should be of the form f(x) -> bool</param>
        /// <returns><see cref="Fist"/> with a first item matching <paramref name="predicate"/> or <see cref="nilf"/> if no items match</returns>
        /// <example>
        /// var list = drop_until(
        ///             fist(1, 2, 3, 4, 5, 6, 5, 4, 3, 2, 1),
        ///             funf(x => x > 5))
        /// // list will be fist(6, 5, 4, 3, 2, 1)
        /// </example>
        public static Fist drop_until(Fist list, Funf predicate) => list switch
        {
            Nilf _ => nilf,
            Fist _ when call(predicate, list.head) => list,
            (var _, Fist tail) => drop_until(tail, predicate),
        };

        /// <summary>
        /// Drops items from the front of the list until the current head does not match a predicate
        /// </summary>
        /// <param name="list"><see cref="Fist"/> to drop items from</param>
        /// <param name="predicate"><see cref="Funf"/> to match against. Should be of the form f(x) -> bool</param>
        /// <returns><see cref="Fist"/> with a first item not matching <paramref name="predicate"/> or <see cref="nilf"/> if all items match</returns>
        /// <example>
        /// var list = drop_while(
        ///             fist(1, 2, 3, 4, 5, 6, 5, 4, 3, 2, 1),
        ///             funf(x => x &lt;= 5));
        /// // list will be fist(6, 5, 4, 3, 2, 1)
        /// </example>
        public static Fist drop_while(Fist list, Funf predicate) => list switch
        {
            Nilf _ => nilf,
            Fist _ when !call(predicate, list.head) => list,
            (var _, Fist tail) => drop_while(tail, predicate),
        };

        /// <summary>
        /// Filters a <see cref="Fist"/> to only items matching a predicate
        /// </summary>
        /// <param name="list"><see cref="Fist"/> to filter</param>
        /// <param name="predicate"><see cref="Funf"/> to match against. Should be of the form f(x) -> bool</param>
        /// <returns>New <see cref="Fist"/> containing only items that match <paramref name="predicate"/></returns>
        /// <example>
        /// var list = filter(fist(1, 2, 3, 4, 5, 6, 5, 4, 3, 2, 1), funf(x => x > 5));
        /// // list will be fist(6)
        /// </example>
        public static dynamic filter(Fist list, Funf predicate) => FFist.create(list, predicate);

        /// <summary>
        /// Filters a <see cref="Fist"/> to only items not matching a predicate
        /// </summary>
        /// <param name="list"><see cref="Fist"/> to filter</param>
        /// <param name="predicate"><see cref="Funf"/> to match against. Should be of the form f(x) -> bool</param>
        /// <returns>New <see cref="Fist"/> containing only items that do not match <paramref name="predicate"/></returns>
        /// <example>
        /// var list = filter(fist(1, 2, 3, 4, 5, 6, 5, 4, 3, 2, 1), funf(x => x &lt;= 5));
        /// // list will be fist(6)
        /// </example>
        public static dynamic reject(Fist list, Funf predicate) => FFist.create(list, compose(predicate, funf(x => !x)));

        /// <summary>
        /// Writes a <see cref="Fist"/> to <see cref="Console.Out"/> with no newline appended
        /// </summary>
        /// <param name="list"><see cref="Fist"/> to print</param>
        /// <param name="delimiter">Optional <see cref="string"/> to join printed values. Defaults to a single space.</param>
        /// <returns><paramref name="list"/></returns>
        /// <remarks>
        /// Printing a <see cref="Fist"/> causes it to be traversed, meaning that any delayed lazy traversal
        /// costs will be incurred at the time of this call.
        /// </remarks>
        /// <example>
        /// print(fist(1, 2, 3, 4), "; "); // prints "1; 2; 3; 4" to stdout
        /// </example>
        public static Fist print(Fist list, string delimiter = " ") => print(list, Console.Out, delimiter, list);

        /// <summary>
        /// Writes a <see cref="Fist"/> to a specified <see cref="TextWriter"/> no newline appended
        /// </summary>
        /// <param name="list"><see cref="Fist"/> to print</param>
        /// <param name="tw"><see cref="TextWriter"/> to print <paramref name="list"/> to</param>
        /// <param name="delimiter">Optional <see cref="string"/> to join printed values. Defaults to a single space.</param>
        /// <returns><paramref name="list"/></returns>
        /// <remarks>
        /// Printing a <see cref="Fist"/> causes it to be traversed, meaning that any delayed lazy traversal
        /// costs will be incurred at the time of this call.
        /// </remarks>
        /// <example>
        /// using var tw = new StringWriter();
        /// print(fist(1, 2, 3, 4), "; ");
        /// var val = tw.ToString();        // val = "1; 2; 3; 4"
        /// </example>
        public static Fist print(Fist list, TextWriter tw, string delimiter = " ") => print(list, tw, delimiter, list);
        private static Fist print(Fist list, TextWriter tw, string delimiter, Fist ret)
        {
            switch (list)
            {

                case (var head, Nilf _):
                    tw.Write(head);
                    return ret;

                case (var head, var tail):
                    tw.Write($"{head}{delimiter}");
                    return print(tail, tw, delimiter, ret);

                case var _:
                    return ret;
            }
        }

        /// <summary>
        /// Writes a <see cref="Fist"/> to <see cref="Console.Out"/> with a newline appended
        /// </summary>
        /// <param name="list"><see cref="Fist"/> to print</param>
        /// <param name="delimiter">Optional <see cref="string"/> to join printed values. Defaults to a single space.</param>
        /// <returns><paramref name="list"/></returns>
        /// <remarks>
        /// Printing a <see cref="Fist"/> causes it to be traversed, meaning that any delayed lazy traversal
        /// costs will be incurred at the time of this call.
        /// </remarks>
        /// <example>
        /// println(fist(1, 2, 3, 4), "; "); // write "1; 2; 3; 4\n" to stdout
        /// </example>
        public static Fist println(Fist list, string delimiter = " ") => println(list, Console.Out, delimiter, list);

        /// <summary>
        /// Writes a <see cref="Fist"/> to a specified <see cref="TextWriter"/> a newline appended
        /// </summary>
        /// <param name="list"><see cref="Fist"/> to print</param>
        /// <param name="tw"><see cref="TextWriter"/> to print <paramref name="list"/> to</param>
        /// <param name="delimiter">Optional <see cref="string"/> to join printed values. Defaults to a single space.</param>
        /// <returns><paramref name="list"/></returns>
        /// <remarks>
        /// Printing a <see cref="Fist"/> causes it to be traversed, meaning that any delayed lazy traversal
        /// costs will be incurred at the time of this call.
        /// </remarks>
        /// <example>
        /// using var tw = new StringWriter();
        /// println(fist(1, 2, 3, 4), "; ");
        /// var val = tw.ToString();        // val = "1; 2; 3; 4\n"
        /// </example>
        public static Fist println(Fist list, TextWriter tw, string delimiter = " ") => println(list, tw, delimiter, list);
        private static Fist println(Fist list, TextWriter tw, string delimiter, Fist ret)
        {
            switch (list)
            {

                case (var head, Nilf _):
                    tw.WriteLine(head);
                    return ret;

                case (var head, var tail):
                    tw.Write($"{head}{delimiter}");
                    return println(tail, tw, delimiter, ret);

                case var _:
                    tw.WriteLine();
                    return list;
            }
        }

        /// <summary>
        /// Creates a <see cref="Fist"/> with the elements from <paramref name="list"/> in
        /// reversed order.
        /// </summary>
        /// <param name="list"><see cref="Fist"/> to get reversed elements from</param>
        /// <returns>New <see cref="Fist"/> with elements from <paramref name="list"/> in reversed order</returns>
        /// <remarks>
        /// Reversing a <see cref="Fist"/> causes it to be traversed, meaning that any delayed lazy traversal
        /// costs will be incurred at the time of this call.
        /// </remarks>
        /// <example>
        /// var val = reverse(fist(1, 2, 3, 4))     // val = fist(4, 3, 2, 1)
        /// </example>
        public static Fist reverse(Fist list) => reverse(list, nilf);
        private static Fist reverse(Fist list, Fist acc) => list switch
        {
            Nilf _ => acc,
            (var head, var tail) => reverse(tail, new SFist(head, acc))
        };

        /// <summary>
        /// Determines whether a given predicate <see cref="Funf"/> is <c>true</c>
        /// for all elements in a <see cref="Fist"/>.
        /// </summary>
        /// <param name="list"><see cref="Fist"/> whose elements will be tested against the predicate</param>
        /// <param name="fun"><see cref="Funf"/> that should accept a value and return a <see cref="bool"/></param>
        /// <returns><c>true</c> if <paramref name="fun"/> returns <c>true</c> for all elements in the list, else <c>false</c></returns>
        /// <remarks>
        /// Testing elements of a <see cref="Fist"/> against a predicate causes it to be traversed, meaning that any delayed lazy traversal
        /// costs will be incurred at the time of this call. However, traversal will stop as soon as the first
        /// <c>false</c> predicate return value is encounted.
        /// </remarks>
        /// <example>
        /// var val = all(fist(1, 2, 3, 4), funf(x => x &lt; 5))     // val = true
        /// </example>
        public static bool all(Fist list, Funf fun) => list switch
        {
            Nilf _ => true,
            (var head, _) when !call(fun, head) => false,
            (_, Fist tail) => all(tail, fun),
        };

        /// <summary>
        /// Determines whether a given predicate <see cref="Funf"/> is <c>true</c>
        /// for any element in a <see cref="Fist"/>.
        /// </summary>
        /// <param name="list"><see cref="Fist"/> whose elements will be tested against the predicate</param>
        /// <param name="fun"><see cref="Funf"/> that should accept a value and return a <see cref="bool"/></param>
        /// <returns><c>true</c> if <paramref name="fun"/> returns <c>true</c> for at least one element in the list, else <c>false</c></returns>
        /// <remarks>
        /// Testing elements of a <see cref="Fist"/> against a predicate causes it to be traversed, meaning that any delayed lazy traversal
        /// costs will be incurred at the time of this call. However, traversal will stop as soon as the first
        /// <c>true</c> predicate return value is encounted.
        /// </remarks>
        /// <example>
        /// var val = any(fist(1, 2, 3, 4), funf(x => x > 5))     // val = false
        /// </example>
        public static bool any(Fist list, Funf fun) => list switch
        {
            Nilf _ => false,
            (var head, _) when call(fun, head) => true,
            (_, Fist tail) => any(tail, fun),
        };
    }
}
