using ID3iCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ID3iHoliday.Models
{
    public class State : GeographicElementBase
    {
        public ListRegion Regions { get; set; } = new ListRegion();
    }

    public class ListState : BaseList<State>
    {
        protected override void OnAddedItem(State item)
        {
            item.Langues = Langues;
            base.OnAddedItem(item);
        }
        public void Init()
        {
            ForEach(x =>
            {
                x.Rules.Langues = Langues;
                x.Rules.Init();
                x.Regions.IfNotNull(y =>
                {
                    y.Langues = Langues;
                    y.Init();
                });
            });
        }
    }
}
