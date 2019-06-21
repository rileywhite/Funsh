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
using System.Linq;
using static Funship.Fist;                                    // Get access to functional magic.

namespace Sandbox
{
    class Program
    {
        static void Main(string[] _)
        {
            var list = fist(1, 2, 3, 4);                      // New functional list [1, 2, 3, 4]

            var result = reduce(list, (x, acc) => x * acc);   // Functional reduce call to multiply list items
            Console.WriteLine(result);                        // Prints 24

            var mappedList = map(list, x => 2 * x);           // Map to a new list with each element doubled
            println(mappedList);                              // Prints 2, 4, 6, 8

            var bigList = to_fist(Enumerable.Range(0, 10000)); // List with ten thousand items. Will be lazy-created.
            var max = reduce(bigList, (x, acc) => x > acc ? x : acc);
            Console.WriteLine(max);                            // Prints 9999
        }
    }
}
