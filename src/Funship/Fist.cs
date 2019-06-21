using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Funship
{
    public interface Fist
    {
        #region Interface members

        public void Deconstruct(out dynamic head, out Fist tail);
        public dynamic Head { get; }
        public Fist Tail { get; }
        public bool IsNil { get; }

        #endregion

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

        public static Fist fist(ICollection<dynamic> vals) => vals.Any() ? new DFist(vals.First(), vals.Skip(1)) : nilf;


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
        private readonly struct DFist : Fist
        {
            internal DFist(dynamic head, IEnumerable<dynamic> tail)
            {
                this.Head = head;
                this.Tail = new Lazy<Fist>(() => tail.Any() ? new DFist(tail.First(), tail.Skip(1)) : nilf);
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
                this.Source = src;
                this.Head = new Lazy<dynamic>(() => fun(src.Head));
                this.Tail = new Lazy<Fist>(() => new MFist(src.Tail, fun));
            }

            public void Deconstruct(out dynamic head, out Fist tail)
            {
                head = this.Head.Value;
                tail = this.Tail.Value;
            }

            private Fist Source { get; }

            private Lazy<dynamic> Head { get; }
            dynamic Fist.Head => this.Head.Value;

            private Lazy<Fist> Tail { get; }
            Fist Fist.Tail => this.Tail.Value;

            public bool IsNil => false;
        }

        #endregion

        #region Functions

        public static Fist map(Fist list, Func<dynamic, dynamic> fun) => new MFist(list, fun);

        public static dynamic reduce(Fist list, Func<dynamic, dynamic, dynamic> fun) => list switch
        {
            Nilf _ => throw new ArgumentException("Fist must not be empty", nameof(list)),
            (var head, var tail) => reduce(tail, head, fun),
        };

        public static dynamic reduce(Fist list, dynamic acc, Func<dynamic, dynamic, dynamic> fun) => list switch
        {
            Nilf _ => acc,
            (var head, var tail) => reduce(tail, fun(head, acc), fun),
        };

        public static Fist print(Fist list) => print(list, Console.Out);
        public static Fist print(Fist list, TextWriter tw) => print(list, tw, list);
        private static Fist print(Fist list, TextWriter tw, Fist ret)
        {
            switch (list)
            {

                case (var head, Nilf _):
                    tw.Write(head);
                    return ret;

                case (var head, var tail):
                    tw.Write($"{head} ");
                    return print(tail, tw);

                case var _:
                    return ret;
            }
        }

        public static Fist println(Fist list) => println(list, Console.Out);
        public static Fist println(Fist list, TextWriter tw) => println(list, tw, list);
        public static Fist println(Fist list, TextWriter tw, Fist ret)
        {
            switch (list)
            {

                case (var head, Nilf _):
                    tw.WriteLine(head);
                    return ret;

                case (var head, var tail):
                    tw.Write($"{head} ");
                    return println(tail, tw);

                case var _:
                    tw.WriteLine();
                    return list;
            }
        }

        public static Fist reverse(Fist list) => reverse(list, nilf);
        private static Fist reverse(Fist list, Fist acc) => list switch
        {
            Nilf _ => acc,
            (var head, var tail) => reverse(tail, new SFist(head, acc))
        };

        #endregion
    }
}
