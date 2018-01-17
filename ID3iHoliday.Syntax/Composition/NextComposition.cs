using ID3iHoliday.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ID3iHoliday.Syntax
{
    /// <summary>
    /// Elément de syntax qui permet de déplacer la date au jour particulier juste après.
    /// </summary>
    public class NextComposition : ExpressionElement
    {
        /// <summary>
        /// Token de l'élément.
        /// </summary>
        protected override string Token => $"NEXT {Day.ToString().ToUpper()}";
        internal DayOfWeek Day { get; set; }
        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="NextComposition"/>.
        /// </summary>
        /// <param name="parent">Elément de syntax parent.</param>
        /// <param name="dayOfWeek">Jour particulier.</param>
        public NextComposition(ExpressionElement parent, DayOfWeek dayOfWeek) : base(parent) => Day = dayOfWeek;
        /// <summary>
        /// Elément de syntax <see cref="OrComposition"/> qui permet de chaîner les tests de jours.
        /// </summary>
        public OrComposition Or => new OrComposition(this);
    }
}
