using ID3iHoliday.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ID3iHoliday.Syntax
{
    /// <summary>
    /// Elément de syntax qui permet de choisir l'action à réaliser.
    /// </summary>
    public class ThenActionComposition : ExpressionElement
    {
        /// <summary>
        /// Token de l'élément.
        /// </summary>
        protected override string Token => "THEN";
        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="ThenActionComposition"/>.
        /// </summary>
        /// <param name="parent">Elément de syntax parent.</param>
        public ThenActionComposition(ExpressionElement parent) : base(parent) { }
        /// <summary>
        /// Elément de syntax qui permet de déplacer la date au jour particulier juste avant.
        /// </summary>
        /// <param name="dayOfWeek">Jour particulier à retourner.</param>
        /// <returns>L'élément de syntax <see cref="PreviousComposition"/> pour ajouter d'autres comportements.</returns>
        public PreviousComposition Previous(DayOfWeek dayOfWeek) => new PreviousComposition(this, dayOfWeek);
        /// <summary>
        /// Elément de syntax qui permet de déplacer la date au jour particulier juste après.
        /// </summary>
        /// <param name="dayOfWeek">Jour particulier à retourner.</param>
        /// <returns>L'élément de syntax <see cref="NextComposition"/> pour ajouter d'autres comportements.</returns>
        public NextComposition Next(DayOfWeek dayOfWeek) => new NextComposition(this, dayOfWeek);
    }
}
