using ID3iHoliday.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ID3iHoliday.Syntax.Composition
{
    /// <summary>
    /// Elément de syntax pour gérer le calendrier à utiliser pour interpréter la date.
    /// </summary>
    public class Over : ExpressionElement
    {
        /// <summary>
        /// Token de l'élément.
        /// </summary>
        protected override string Token => $"OVER {Calendar.ToString().ToUpper()}";
        internal Calendar Calendar { get; set; }
        /// <summary>
        /// Initialise une nouvelle instance pour la classe <see cref="Over"/>.
        /// </summary>
        /// <param name="parent">Elément de syntax parent.</param>
        /// <param name="calendar">Calendrier à utiliser pour interpréter la règle.</param>
        public Over(ExpressionElement parent, Calendar calendar) : base(parent)
        {
            Calendar = calendar;
        }
    }
}
