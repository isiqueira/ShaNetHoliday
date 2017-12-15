using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Modularity;
using Microsoft.Practices.Unity;
using ID3iHoliday.Models;

namespace ID3iHoliday.Countries.Modularity
{
    public class FIModule : IModule
    {
        [Dependency]
        public IUnityContainer Container { get; set; }
        public void Initialize()
        {
            Container.Resolve<IHolidaySystem>().CountriesAvailable.Add(new FI());
        }
    }    
}
