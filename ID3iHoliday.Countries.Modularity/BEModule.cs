using ID3iHoliday.Models;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ID3iHoliday.Countries.Modularity
{
    public class BEModule : IModule
    {
        [Dependency]
        public IUnityContainer Container { get; set; }

        public void Initialize()
        {
            Container.Resolve<IHolidaySystem>().CountriesAvailable.Add(new BE());
        }
    }
}
