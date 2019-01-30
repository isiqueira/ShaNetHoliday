using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShaNetHoliday.Models
{
    /// <summary>
    /// Enumération des type de règles.
    /// </summary>
    public enum RuleType
    {
        /// <summary>
        /// Tout type.
        /// </summary>
        All,

        /// <summary>
        /// Jour férié pour tout le monde.
        /// </summary>
        Public,

        /// <summary>
        /// Jour férié applicable aux banques.
        /// </summary>
        Bank,

        /// <summary>
        /// Jour férié applicable aux écoles.
        /// </summary>
        School,

        /// <summary>
        /// Jour férié non imposé.
        /// </summary>
        Optional,

        /// <summary>
        /// Jour non férié.
        /// </summary>
        Observance
    }
}
