using ID3iCore;
using ID3iHoliday.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ID3iHoliday.Countries
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
