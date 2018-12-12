using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Modularity;
using Microsoft.Practices.Unity;
using iD3iHoliday.Models;

namespace iD3iHoliday.Countries.Modularity
{
    /// <summary>
    /// Module Prism pour <see cref="FR"/>.
    /// </summary>
    public class FRModule : IModule
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
            Container.Resolve<IHolidaySystem>().CountriesAvailable.Add(new FR());
        }
    }    
}
