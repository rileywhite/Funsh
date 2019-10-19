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
using System.Linq;

using static Funship.Fist;                                    // Get access to functional lists.
using static Funship.Funf;                                    // Get access to function functions.  


using Funship;

namespace Sandbox
{
    class Program
    {
        static void Main(string[] _)
        {
            var list = fist(Enumerable.Range(1, 1_000));
            var reducerFunf = funf<int, int, int>((x, acc) => x + acc);

            Console.WriteLine("Starting Linq Sum...");
            var startLinq = DateTimeOffset.Now;
            for (int i = 0; i < 1_000_000; i++)
            {
                StreamWriter.Null.Write(list.Aggregate((x, acc) => x + acc));
            }
            var endLinq = DateTimeOffset.Now;
            Console.WriteLine("Done");
            Console.WriteLine();

            Console.WriteLine("Starting Funship reduce...");
            var startFunship = DateTimeOffset.Now;
            for (int i = 0; i < 1_000_000; i++)
            {
                StreamWriter.Null.Write(reduce(list, reducerFunf));
            }
            var endFunship = DateTimeOffset.Now;
            Console.WriteLine("Done");
            Console.WriteLine();

            Console.WriteLine($"Linq time    :{endLinq - startLinq}");
            Console.WriteLine($"Funship time :{endFunship - startFunship}");
        }
    }
}
