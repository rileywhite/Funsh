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

using static Funship.Fist;

namespace Funship
{
    public partial interface Funf
    {
        public static Funf compose(Funf f, Funf g) => new CFunf(f, g, g.arity + f.arity - 1, nilf);

        public static (Funf, IEnumerable<dynamic> args) capture_and_compose(Funf g, params dynamic[] args) => capture_and_compose(g, args.AsEnumerable());
        public static (Funf, IEnumerable<dynamic> args) capture_and_compose(Funf g, IEnumerable<dynamic> args) =>
            args.SkipWhile(arg => !(arg is Funf)) switch
            {
                var empty when !empty.Any() => (g, args),
                var f_and_args => (compose(capture(f_and_args.First(), f_and_args.Skip(1)), g), args.TakeWhile(arg => !(arg is Funf))),
            };

        public static dynamic call(Funf f, params dynamic[] args) => call(f, args.AsEnumerable());
        public static dynamic call(Funf f, IEnumerable<dynamic> args) => capture_and_compose(f, args) switch
        {
            (WFunf fun, var final_args) => fun.invoke_func(final_args),
            (PFunf fun, var final_args) => fun.collect_args_and_call(final_args),
            (CFunf fun, var final_args) => fun.collect_args_and_call(final_args),
            _ => throw new NotSupportedException(),
        };

        public static Funf capture(Funf f, params dynamic[] args) => capture(f, to_fist(args));
        public static Funf capture(Funf f, IEnumerable<dynamic> args) => capture_and_compose(f, args) switch
        {
            (var fun, var empty) when !empty.Any() => fun,
            (var fun, var final_args) => capture(new PFunf(fun, final_args, fun.arity - final_args.Count())),
        };
    }
}
