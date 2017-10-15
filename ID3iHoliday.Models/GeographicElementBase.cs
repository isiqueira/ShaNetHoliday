using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ID3iHoliday.Models
{
    public abstract class GeographicElementBase
    {
        public string Code { get; set; }
        public string DefaultName => Names.FirstOrDefault().Value;
        public Dictionary<Langue, string> Names { get; set; } = new Dictionary<Langue, string>();
        public List<Langue> Langues { get; set; } = new List<Langue>();
        public ListRule Rules { get; set; } = new ListRule();
    }   
    
    public class BaseList<T> : List<T>
    {
        public List<Langue> Langues { get; set; }
        public BaseList<T> Container => this;
        protected virtual void OnAddedItem(T item) => base.Add(item);
        public new void Add(T item) => OnAddedItem(item);
    }
}
