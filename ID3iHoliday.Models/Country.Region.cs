using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ID3iHoliday.Models
{
    public class Region : GeographicElementBase { }
    public class ListRegion : BaseList<Region>
    {
        protected override void OnAddedItem(Region item)
        {
            item.Langues = Langues;
            base.OnAddedItem(item);
        }
        public void Init()
        {
            ForEach(x => { x.Rules.Langues = Langues; });
        }
    }
}
