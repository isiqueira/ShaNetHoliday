using Microsoft.Practices.Unity;
using Prism.Modularity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ID3iHoliday.Models;

namespace ID3iHoliday.Engine.Modularity
{
    public class HolidayEngineModule : IModule
    {
        [Dependency]
        public IUnityContainer Container { get; set; }
        public void Initialize()
        {
            Container.RegisterInstance<IHolidaySystem>(Container.Resolve<HolidaySystem>(), new ContainerControlledLifetimeManager());
        }
    }
}
