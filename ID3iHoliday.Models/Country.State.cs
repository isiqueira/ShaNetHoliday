using ID3iCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ID3iHoliday.Models
{
    /// <summary>
    /// Réprésentation d'un état.
    /// </summary>
    public class State : GeographicElementBase
    {
        /// <summary>
        /// Liste des régions de l'état.
        /// </summary>
        public ListRegion Regions { get; set; } = new ListRegion();
    }
}
