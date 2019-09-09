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
using static Funship.Fist;                                    // Get access to functional lists.
using static Funship.Funf;                                    // Get access to function functions.  


namespace Sandbox
{
    class Program
    {
        static void Main(string[] _)
        {
            var list = fist(1, 2, 3, 4);                            // New functional list [1, 2, 3, 4]

            var result = reduce(list, funf((x, acc) => x * acc));   // Functional reduce call to multiply list items
            Console.WriteLine(result);                        // Prints 24

            var mappedList = map(list, funf(x => 2 * x));           // Map to a new list with each element doubled
            println(mappedList);                              // Prints 2, 4, 6, 8

            var bigList = fist(Enumerable.Range(0, 1000)); // List with 10 thousand items. Will be lazy-created. (Tail.Fody doesn't currently catch this call in Debug compiles.)

            var max = reduce(bigList, funf((x, acc) => x > acc ? x : acc));
            Console.WriteLine(max);                            // Prints 999

            var fun = funf(x => x + 1);
            Console.WriteLine(call(fun, 10));

            var twoparam = funf((x, y) => x - y);
            Funship.Funf oneparam = call(twoparam, 6);
            Console.WriteLine(call(oneparam, 2));

            var partialCallOneParam = capture(twoparam, 6);
            var partialCallZeroParam = capture(partialCallOneParam, 1);
            Console.WriteLine(call(partialCallZeroParam));

            Console.WriteLine($"Everything greater than 5? {all(fist(6, 7, 8, 9), funf(x => x > 5))}");
            Console.WriteLine($"Is this other stuff greater than 5? {all(fist(6, 4, 8, 9), funf(x => x > 5))}");
        }
    }
}
