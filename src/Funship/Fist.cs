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
using System.Collections.Generic;
using System.Linq;

namespace Funship
{
    public partial interface Fist
    {
        public void Deconstruct(out dynamic head, out Fist tail);
        public dynamic Head { get; }
        public Fist Tail { get; }
        public bool IsNil { get; }

        public static readonly Fist nilf = new Nilf();

        public static Fist fist(params dynamic[] vals)
        {
            var newf = nilf;
            for (var i = vals.Length - 1; i >= 0; i--)
            {
                newf = new SFist(vals[i], newf);
            }
            return newf;
        }

        public static Fist to_fist<T>(IEnumerable<T> vals) => vals.Any() ? new DFist<T>(vals.First(), vals.Skip(1)) : nilf;


        #region Fist types

        /// <summary>
        /// Nil list
        /// </summary>
        public readonly struct Nilf : Fist
        {
            public void Deconstruct(out dynamic head, out Fist tail)
            {
                head = null;
                tail = null;
            }

            public dynamic Head => null;
            public Fist Tail => null;
            public bool IsNil => true;
        }

        /// <summary>
        /// Static list
        /// </summary>
        private readonly struct SFist : Fist
        {
            internal SFist(dynamic head)
            {
                this.Head = head;
                this.Tail = nilf;
            }

            internal SFist(dynamic head, Fist tail)
            {
                this.Head = head;
                this.Tail = tail;
            }

            public void Deconstruct(out dynamic head, out Fist tail)
            {
                head = this.Head;
                tail = this.Tail;
            }

            public dynamic Head { get; }
            public Fist Tail { get; }
            public bool IsNil => false;
        }

        /// <summary>
        /// Dynamic list
        /// </summary>
        private readonly struct DFist<T> : Fist
        {
            internal DFist(dynamic head, IEnumerable<T> tail)
            {
                this.Head = head;
                this.Tail = new Lazy<Fist>(() => tail.Any() ? new DFist<T>(tail.First(), tail.Skip(1)) : nilf);
            }

            public void Deconstruct(out dynamic head, out Fist tail)
            {
                head = this.Head;
                tail = this.Tail.Value;
            }

            public dynamic Head { get; }

            private Lazy<Fist> Tail { get; }
            Fist Fist.Tail => this.Tail.Value;

            public bool IsNil => false;
        }

        /// <summary>
        /// Mapped list
        /// </summary>
        private readonly struct MFist : Fist
        {
            internal MFist(Fist src, Func<dynamic, dynamic> fun)
            {
                switch (src)
                {
                    case (var head, Nilf _):
                        this.Head = new Lazy<dynamic>(() => fun(head));
                        this.Tail = new Lazy<Fist>(() => nilf);
                        break;

                    case var _:
                        this.Head = new Lazy<dynamic>(() => fun(src.Head));
                        this.Tail = new Lazy<Fist>(() => new MFist(src.Tail, fun));
                        break;
                }
            }

            public void Deconstruct(out dynamic head, out Fist tail)
            {
                head = this.Head.Value;
                tail = this.Tail.Value;
            }

            private Lazy<dynamic> Head { get; }
            dynamic Fist.Head => this.Head.Value;

            private Lazy<Fist> Tail { get; }
            Fist Fist.Tail => this.Tail.Value;

            public bool IsNil => false;
        }

        #endregion
    }
}
