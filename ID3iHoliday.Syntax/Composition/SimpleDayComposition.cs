using ID3iHoliday.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ID3iHoliday.Syntax
{
    /// <summary>
    /// Elément de syntax pour mettre en place une date fixe dans n'importe qu'elle année.
    /// </summary>
    public class SimpleDayComposition : ExpressionElement
    {
        /// <summary>
        /// Token de l'élément.
        /// </summary>
        protected override string Token => DateTime.ToString("MM-dd");
        internal DateTime DateTime { get; }
        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="SimpleDayComposition"/>.
        /// </summary>
        /// <param name="parent">Elément de syntax parent.</param>
        /// <param name="dateTime">Date.</param>
        public SimpleDayComposition(ExpressionElement parent, DateTime dateTime) : base(parent) => DateTime = dateTime;
        /// <summary>
        /// Elément de syntax pour déplacer le jour à un autre si il tombe un certain jour.
        /// </summary>
        /// <param name="dayOfWeek">Jour particulier.</param>
        /// <returns>L'élément de syntax <see cref="IfDayComposition"/> pour ajouter d'autres comportements.</returns>
        public IfDayComposition If(DayOfWeek dayOfWeek) => new IfDayComposition(this, dayOfWeek);
    }
}
