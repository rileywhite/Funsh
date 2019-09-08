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

        public static dynamic call(Funf f, params dynamic[] args) => call(f, args.AsEnumerable());
        public static dynamic call(Funf f, IEnumerable<dynamic> args) => f switch
        {
            WFunf fun => fun.invoke_func(args),
            PFunf fun => fun.call(args),
            _ => args switch
            {
                Nilf _ => f.call(),
                Fist _ => call(capture(f, args)),
                _ => true,
            },
        };

        public static Funf capture(Funf f, params dynamic[] args) => capture(f, to_fist(args));
        public static Funf capture(Funf f, IEnumerable<dynamic> args) => args switch
        {
            Nilf _ => f,
            _ => capture(new PFunf(f, args, f.arity - args.Count())),
        };
    }
}
