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
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Funship
{
    public static class Finq
    {
        public static void Deconstruct(this IEnumerable source, out dynamic head, out Fist tail) =>
            Deconstruct(source.Cast<dynamic>(), out head, out tail);

        public static void Deconstruct<TEnumerable, T>(this TEnumerable source, out T head, out Fist tail)
            where TEnumerable : IEnumerable<T>
        {
            if (source.Any())
            {
                head = source.First();
                tail = Fist.fist(source.Skip(1));
            }
            else
            {
                throw new NotSupportedException(
                    "Cannot deconstruct an empty IEnumerable<T>. Maybe you're missing a match against `Nilf _`?");
            }
        }
    }

    /// <summary>
    /// Represents a functional list that is constructed with a <see cref="head"/>,
    /// which is the first element in the functional list, and a <see cref="tail"/>
    /// which reprents the remainder of the functional list without the tail.
    /// </summary>
    /// <remarks>
    /// Create a fist using <see cref="fist{T}(T[])"/> or <see cref="fist{T}(IEnumerable{T})"/>.
    /// 
    /// A <see cref="Fist"/> can be matched as a <see cref="ValueTuple{dynamic, Fist}"/>
    /// in a <c>switch</c> statement.
    ///
    /// An empty list, which as a <see cref="tail"/> value also indicates the end of a non-empty list,
    /// is represented by <see cref="nilf"/>, which can be matched by type <see cref="Nilf"/>.
    ///
    /// All <see cref="Fist"/> implementations must be immutable and should be internal or private
    /// within the assemblies that define them.
    /// </remarks>
    /// <example>
    /// using static Funship.Fist;
    /// 
    /// static int Main(string[] args)
    /// {
    ///     var list = fist(args);
    ///     
    ///     return list switch
    ///     {
    ///         Nilf _ => 0,                // return 0 if no args were passed
    ///         (var head, Nilf _) => 1,    // returns 1 if exactly one arg was passed
    ///         (var head, Fist _) => 2,    // returns 2 two or more args were passed
    ///     };
    /// }
    /// </example>
    public partial interface Fist : IEnumerable
    {
        /// <summary>
        /// Provides a <see cref="ValueTuple{dynamic, Fist}"/> deconstruction of the <see cref="Fist"/>
        /// </summary>
        /// <param name="head">First item of the deconstruction is the <see cref="head"/></param>
        /// <param name="tail">Second item of the deconstruction is the <see cref="tail"/></param>
        public void Deconstruct(out dynamic head, out Fist tail);

        /// <summary>
        /// Gets the first element in the <see cref="Fist"/>
        /// </summary>
        public dynamic head { get; }

        /// <summary>
        /// Gets the part of the list remaining in the <see cref="Fist"/> after the <see cref="head"/>
        /// </summary>
        public Fist tail { get; }

        /// <summary>
        /// Gets whether the <see cref="Fist"/> is an empty/nil list. Only the <see cref="Nilf"/> type's
        /// <see cref="nilf"/> instance will return <c>true</c>.
        /// </summary>
        public bool is_nil { get; }

        public static Fist nilf => new Nilf<dynamic>();

        /// <summary>
        /// Creates a new <see cref="Fist"/> by appending a head to an existing tail.
        /// </summary>
        /// <returns>New <see cref="nilf"/>, the empty functional list</returns>
        public static Fist fist() => Fist<dynamic>.nilf;

        /// <summary>
        /// Creates a new <see cref="Fist"/> by appending a head to an existing tail.
        /// </summary>
        /// <param name="head"></param>
        /// <param name="tail"></param>
        /// <returns>New fist with the given <paramref name="head"/> and <paramref name="tail"/></returns>
        public static Fist<TFist> fist<TValue, TFist>(TValue head, IEnumerable<TFist> tail) where TValue : TFist  => head switch
        {
            Nilf _ => Fist<TFist>.nilf,
            _ => LinqFist<TFist>.__new(Enumerable.Prepend(tail, head)),
        };
        public static Fist<dynamic> fist<T>(T head, IEnumerable tail) =>
            fist(head, tail.Cast<object>());

        /// <summary>
        /// Converts a given <see cref="IEnumerable{T}"/> to a <see cref="Fist"/>.
        /// </summary>
        /// <param name="vals">Collection of items that the new <see cref="Fist"/> should contain in order</param>
        /// <returns><see cref="Fist"/> containing the items in <paramref name="vals"/></returns>
        /// <remarks>
        /// The <see cref="Fist"/> creation is done in a lazy manner. Each item in <paramref name="vals"/>
        /// is enumerated over only as the <see cref="Fist"/> is traversed.
        /// </remarks>
        /// <example>
        /// var list = fist(new [] { 1, 2, 3, 4 });    // list = Fist with head 1 and tail of fist(2, 3, 4)
        /// var empty_list = fist(new object[0]);      // empty_list = <see cref="nilf"/>
        /// </example>
        public static Fist<T> fist<T>(IEnumerable<T> vals) => vals switch
        {
            _ when !vals.Any() => Fist<T>.nilf,
            _ => LinqFist<T>.__new(vals),
        };

        /// <summary>
        /// Creates a new <see cref="Fist"/> from a given set of values
        /// </summary>
        /// <param name="vals">Values to add to a list</param>
        /// <returns>A new <see cref="Fist"/> containing the passed values in the order in which they were passed</returns>
        /// <remarks>
        /// There are two scenarios when this will return <see cref="nilf"/>:
        /// 1. When <paramref name="vals"/> is empty, i.e. no values are passed in the call.
        /// 2. When a single <c>null</c> is passed.
        /// </remarks>
        /// <example>
        /// var list = fist(1, 2, 3, 4);    // list = Fist with head 1 and tail of fist(2, 3, 4)
        /// var empty_list = fist();        // empty_list = <see cref="nilf"/>
        /// </example>
        public static Fist<T> fist<T>(params T[] vals) => vals.Length switch
        {
            0 => Fist<T>.nilf,
            1 => vals[0] switch
            {
                null => Fist<T>.nilf,
                _ => LinqFist<T>.__new(vals),
            },
            _ => LinqFist<T>.__new(vals),
        };

        #region Fist types

        /// <summary>
        /// Nil list. Use <see cref="nilf"/> as a shortcut to get an instance.
        /// </summary>
        public interface Nilf : Fist { }

        private readonly struct LinqFist<T> : Fist<T>
        {
            public static Fist<T> __new(IEnumerable<T> source) => new LinqFist<T>(source);

            private LinqFist(IEnumerable<T> source)
            {
                if (!source.Any()) { throw new ArgumentException("Must have at least one element", nameof(source)); }
                this.source = source;
                this.head = source.First();
                this.tail = new Lazy<Fist<T>>(() =>
                    {
                        var tailSource = source.Skip(1);
                        return tailSource.Any() ? (Fist<T>)new LinqFist<T>(tailSource) : (Fist<T>)Fist<T>.nilf;
                    });
            }

            private IEnumerable<T> source { get; }

            public T head { get; }
            dynamic Fist.head => this.head;

            private Lazy<Fist<T>> tail { get; }
            Fist<T> Fist<T>.tail => this.tail.Value;
            Fist Fist.tail => this.tail.Value;

            public void Deconstruct(out dynamic head, out Fist tail)
            {
                head = this.head;
                tail = this.tail.Value;
            }

            public bool is_nil => false;
#nullable enable
            /// <summary>
            /// Tests equality
            /// </summary>
            /// <param name="obj">Object to test against</param>
            /// <returns><c>true</c> for any other <see cref="Nilf"/>, else <c>false</c></returns>
            public override bool Equals(object? obj) => obj != null && obj is Fist && equals(this, (Fist)obj);
#nullable disable

            /// <summary>
            /// Hash code for <see cref="Nilf"/> is always 0;
            /// </summary>
            /// <returns></returns>
            public override int GetHashCode() => hash_code(this);

            IEnumerator IEnumerable.GetEnumerator() => this.source.GetEnumerator();
            IEnumerator<T> IEnumerable<T>.GetEnumerator() => this.source.GetEnumerator();
        }

        #endregion
    }

    public interface Fist<out T> : Fist, IEnumerable<T>
    {
        new T head { get; }
        new Fist<T> tail { get; }

        public new static Fist<T> nilf => new Nilf<T>();
    }

    internal readonly struct Nilf<T> : Fist.Nilf, Fist<T>
    {
        dynamic Fist.head => throw new NotSupportedException("Cannot get head of nilf");
        T Fist<T>.head => throw new NotImplementedException("Cannot get head of nilf");

        Fist Fist.tail => this;
        Fist<T> Fist<T>.tail => this;

        public bool is_nil => true;

#nullable enable
        /// <summary>
        /// Tests equality
        /// </summary>
        /// <param name="obj">Object to test against</param>
        /// <returns><c>true</c> for any other <see cref="Fist.Nilf"/>, else <c>false</c></returns>
        public override bool Equals(object? obj) => obj == null || obj is Fist.Nilf;
#nullable disable

        /// <summary>
        /// Hash code for <see cref="Fist.Nilf"/> is always 0;
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode() => 0;

        IEnumerator IEnumerable.GetEnumerator() => Enumerable.Empty<object>().GetEnumerator();
        IEnumerator<T> IEnumerable<T>.GetEnumerator() => Enumerable.Empty<T>().GetEnumerator();
        void Fist.Deconstruct(out dynamic head, out Fist tail) => throw new NotImplementedException();
    }
}
