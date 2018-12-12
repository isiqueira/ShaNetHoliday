using iD3iHoliday.Models;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iD3iHoliday.Countries.Modularity
{
    /// <summary>
    /// Module Prism pour <see cref="IE"/>.
    /// </summary>
    public class IEModule : IModule
    {
        /// <summary>
        /// <see cref="IUnityContainer"/>.
        /// </summary>
        [Dependency]
        public IUnityContainer Container { get; set; }
        /// <summary>
        /// Initialise le module.
        /// </summary>
        public void Initialize()
        {
            Container.Resolve<IHolidaySystem>().CountriesAvailable.Add(new IE());
        }
    }
}
