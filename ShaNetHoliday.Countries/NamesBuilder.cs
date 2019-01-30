using ShaNetCore;
using ShaNetHoliday.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShaNetHoliday.Countries
{
    internal class NamesBuilder
    {
        internal Dictionary<Langue, string> Names { get; set; } = new Dictionary<Langue, string>();
        public static NamesBuilder Make => new NamesBuilder();
        public NamesBuilder Add(Langue langue, string name)
        {
            Names.AddIfNotContainsKey(langue, name);
            return this;
        }
        public Dictionary<Langue, string> AsDictionary() => Names;
    }
}
