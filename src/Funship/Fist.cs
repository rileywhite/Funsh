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

using static Funship.Funf;

namespace Funship
{
    /// <summary>
    /// Represents a functional list that is constructed with a <see cref="head"/>,
    /// which is the first element in the functional list, and a <see cref="tail"/>
    /// which reprents the remainder of the functional list without the tail.
    /// </summary>
    /// <remarks>
    /// Create a fist using <see cref="fist(dynamic[])"/> or <see cref="fist{T}(IEnumerable{T})"/>.
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
    public partial interface Fist : IEnumerable<object>
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

        /// <summary>
        /// Singleton <see cref="Nilf"/> that is used to represent an empty <see cref="Fist"/>.
        /// </summary>
        public static readonly Fist nilf = new Nilf();

        /// <summary>
        /// Creates a new <see cref="Fist"/> by appending a head to an existing tail.
        /// </summary>
        /// <param name="head"></param>
        /// <param name="tail"></param>
        /// <returns>New fist with the given <paramref name="head"/> and <paramref name="tail"/></returns>
        public static Fist fist(dynamic head, Fist tail) => head switch
        {
            Nilf _ => nilf,
            _ => new SFist(head, tail),
        };

        /// <summary>
        /// Converts a given <see cref="IEnumerable{T}"/> to a <see cref="Fist"/>.
        /// </summary>
        /// <typeparam name="T">Type contained in the <see cref="IEnumerable{T}"/></typeparam>
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
        public static Fist fist<T>(IEnumerable<T> vals) => vals switch
        {
            null => nilf,
            _ when !vals.Any() => nilf,
            _ => new DFist<T>(vals.First(), vals.Skip(1)),
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
        public static Fist fist(params dynamic[] vals) => vals switch
        {
            _ when vals.Length == 1 && vals[0] == null => nilf,
            _ => fist(vals.AsEnumerable()),
        };

        /// <summary>
        /// Tests equality between two <see cref="Fist"/> instances.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        /// <remarks>
        /// Testing equality of two <see cref="Fist"/> instances causes them to be traversed in parallel,
        /// meaning that any delayed lazy traversal costs will be incurred at the time of this call. However,
        /// traversal stops at the first pair of <see cref="head"/> elements that are not equal.
        ///
        /// Two fists are considered equal if their items, traversed in parallel, are each equal as
        /// determined by a call to <see cref="object.Equals(object, object)"/>.
        /// </remarks>
        public static bool equals(Fist left, Fist right) => (left, right) switch
        {
            (Nilf _, Nilf _) => true,
            ((_, _), Nilf _) => false,
            (Nilf _, (_, _)) => false,
            ((var headL, Fist tailL), (var headR, Fist tailR)) when object.Equals(headL, headR) => equals(tailL, tailR),
            _ => false,
        };

        /// <summary>
        /// Generates a hash code for a <see cref="Fist"/>
        /// </summary>
        /// <param name="list"><see cref="Fist"/> to generate hash code for</param>
        /// <returns>Generated hash code</returns>
        /// <remarks>
        /// Calculating a hash code for a <see cref="Fist"/> causes it to be traversed, meaning that any
        /// delayed lazy traversal costs will be incurred at the time of this call.
        /// </remarks>
        public static int hash_code(Fist list) => reduce(list, 0, funf((x, acc) => 486187739 * acc + (x.GetHashCode())));

        private static IEnumerator<object> enumerator(Fist list) => new FistEnumerator(list);

        private class FistEnumerator : IEnumerator<object>
        {
            public FistEnumerator(Fist list)
            {
                // the nullable logic is here because MoveNext is called before the first value is read
                this.InitialList = list;
                this.List = default;
            }

            private Fist InitialList { get; set; }
#nullable enable
            private Fist? List { get; set; }
#nullable disable

            public object Current => this.List.head;

            public void Dispose()
            {
                this.InitialList = nilf;
                this.List = null;
            }

            public bool MoveNext() => !(this.List = this.List == null ? this.InitialList : this.List.tail).is_nil;

            public void Reset() => this.List = null;
        }

        #region Fist types

        /// <summary>
        /// Nil list. Use <see cref="nilf"/> as a shortcut to get an instance.
        /// </summary>
        public readonly struct Nilf : Fist
        {
            /// <summary>
            /// <see cref="Nilf"/> deconstructs into (<see cref="nilf"/>, <see cref="nilf"/>).
            /// </summary>
            /// <param name="head">Will be <see cref="nilf"/></param>
            /// <param name="tail">Will be <see cref="nilf"/></param>
            public void Deconstruct(out dynamic head, out Fist tail)
            {
                head = nilf;
                tail = nilf;
            }

            /// <summary>
            /// Gets <see cref="nilf"/>
            /// </summary>
            public dynamic head => nilf;

            /// <summary>
            /// Gets <see cref="nilf"/>
            /// </summary>
            public Fist tail => nilf;

            /// <summary>
            /// Always <c>true</c>
            /// </summary>
            public bool is_nil => true;

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

            IEnumerator IEnumerable.GetEnumerator() => (this as IEnumerable<object>).GetEnumerator();
            IEnumerator<object> IEnumerable<object>.GetEnumerator() => enumerator(this);
        }

        /// <summary>
        /// Static list
        /// </summary>
        private readonly struct SFist : Fist
        {
            internal SFist(dynamic head)
            {
                if (nilf.Equals(head)) { throw new ArgumentException("DFist head cannot be nilf"); }
                this.head = head;
                this.tail = nilf;
            }

            internal SFist(dynamic head, Fist tail)
            {
                if (nilf.Equals(head)) { throw new ArgumentException("DFist head cannot be nilf"); }
                this.head = head;
                this.tail = tail;
            }

            public void Deconstruct(out dynamic head, out Fist tail)
            {
                head = this.head;
                tail = this.tail;
            }

            public dynamic head { get; }
            public Fist tail { get; }
            public bool is_nil => false;

#nullable enable
            public override bool Equals(object? obj) => obj != null && obj is Fist && equals(this, (Fist)obj);
#nullable disable

            public override int GetHashCode() => hash_code(this);

            IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
            public IEnumerator<object> GetEnumerator() => enumerator(this);
        }

        /// <summary>
        /// Dynamic list
        /// </summary>
        private readonly struct DFist<T> : Fist
        {
            internal DFist(dynamic head, IEnumerable<T> tail)
            {
                if (nilf.Equals(head)) { throw new ArgumentException("DFist head cannot be nilf"); }
                this.head = head;
                this.Tail = new Lazy<Fist>(() => tail.Any() ? new DFist<T>(tail.First(), tail.Skip(1)) : nilf);
            }

            public void Deconstruct(out dynamic head, out Fist tail)
            {
                head = this.head;
                tail = this.Tail.Value;
            }

            public dynamic head { get; }

            private Lazy<Fist> Tail { get; }
            Fist Fist.tail => this.Tail.Value;

            public bool is_nil => false;


#nullable enable
            public override bool Equals(object? obj) => obj != null && obj is Fist && equals(this, (Fist)obj);
#nullable disable

            public override int GetHashCode() => hash_code(this);

            IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
            public IEnumerator<object> GetEnumerator() => enumerator(this);
        }

        /// <summary>
        /// Mapped list
        /// </summary>
        private readonly struct MFist : Fist
        {
            internal MFist(Fist src, Funf fun)
            {
                switch (src)
                {
                    case (var head, Nilf _):
                        this.Head = new Lazy<dynamic>(() =>
                        {
                            var h = call(fun, head);
                            return h;
                        });
                        this.Tail = new Lazy<Fist>(() => nilf);
                        break;

                    case var _:
                        this.Head = new Lazy<dynamic>(() =>
                        {
                            var h = call(fun, src.head);
                            return h;
                        });
                        this.Tail = new Lazy<Fist>(() => new MFist(src.tail, fun));
                        break;
                }
            }

            public void Deconstruct(out dynamic head, out Fist tail)
            {
                head = this.Head.Value;
                tail = this.Tail.Value;
            }

            private Lazy<dynamic> Head { get; }
            dynamic Fist.head => this.Head.Value;

            private Lazy<Fist> Tail { get; }
            Fist Fist.tail => this.Tail.Value;

            public bool is_nil => false;

#nullable enable
            public override bool Equals(object? obj) => obj != null && obj is Fist && equals(this, (Fist)obj);
#nullable disable

            public override int GetHashCode() => hash_code(this);

            IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
            public IEnumerator<object> GetEnumerator() => enumerator(this);
        }

        /// <summary>
        /// A <see cref="Fist"/> that filters items based on
        /// a given predicate
        /// </summary>
        private readonly struct FFist : Fist
        {
            /// <summary>
            /// Creates a new <see cref="FFist"/>
            /// </summary>
            /// <param name="source">Source <see cref="Fist"/> that has a filter applied</param>
            /// <param name="predicate"><see cref="Funf"/> of form f(x) -> bool used to filter the list</param>
            /// <returns>New <see cref="FFist"/> if at least one item gets a <c>true</c> result from <paramref name="predicate"/>, else <see cref="nilf"/></returns>
            public static Fist create(Fist source, Funf predicate) => drop_until(source, predicate) switch
            {
                Nilf _ => nilf,
                (var head, Fist tail) => new FFist(head, tail, predicate),
            };

            private FFist(dynamic head, Fist tail_source, Funf predicate)
            {
                this.head = head;
                this.tail = new Lazy<Fist>(() => create(tail_source, predicate));
            }

            public dynamic head { get; }

            public Lazy<Fist> tail { get; }
            Fist Fist.tail => this.tail.Value;

            public bool is_nil => false;

            public void Deconstruct(out dynamic head, out Fist tail)
            {
                head = this.head;
                tail = this.tail.Value;
            }

#nullable enable
            public override bool Equals(object? obj) => obj != null && obj is Fist && equals(this, (Fist)obj);
#nullable disable

            public override int GetHashCode() => hash_code(this);

            IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
            public IEnumerator<object> GetEnumerator() => enumerator(this);
        }

        #endregion
    }
}
