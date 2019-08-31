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

namespace Funship
{
    public partial interface Fist
    {
        public static Fist map(Fist list, Func<dynamic, dynamic> fun) => new MFist(list, fun);

        public static dynamic reduce(Fist list, Func<dynamic, dynamic, dynamic> fun) => list switch
        {
            Nilf _ => throw new ArgumentException("Fist must not be empty", nameof(list)),
            (var head, var tail) => reduce(tail, head, fun),
        };

        public static dynamic reduce(Fist list, dynamic acc, Func<dynamic, dynamic, dynamic> fun)
        {
            switch (list)
            {
                case Nilf _: return acc;
                case (var head, var tail): return reduce(tail, fun(head, acc), fun);
                default:
                    throw new ArgumentException("No match for value", nameof(list));
            }
        }

        //public static dynamic reduce(Fist list, dynamic acc, Func<dynamic, dynamic, dynamic> fun) => list switch
        //{
        //    Nilf _ => acc,
        //    (var head, var tail) => reduce(tail, fun(head, acc), fun),
        //};

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
                    return print(tail, tw, ret);

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
                    return println(tail, tw, ret);

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
    }
}
