using Microsoft.Practices.Unity;
using Prism.Modularity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iD3iHoliday.Models;

namespace iD3iHoliday.Engine.Modularity
{
    /// <summary>
    /// Module Prism pour l'enregistrement du wrapper de récupération des données.
    /// </summary>
    public class HolidayEngineModule : IModule
    {
        /// <summary>
        /// <see cref="IUnityContainer"/>.
        /// </summary>
        [Dependency]
        public IUnityContainer Container { get; set; }

        /// <summary>
        /// Initialise le module.
        /// </summary>
        public void Initialize() => Container.RegisterInstance<IHolidaySystem>( Container.Resolve<HolidaySystem>(), new ContainerControlledLifetimeManager() );
    }
}
