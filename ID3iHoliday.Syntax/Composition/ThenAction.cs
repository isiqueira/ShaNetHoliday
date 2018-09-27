using ID3iHoliday.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ID3iHoliday.Syntax.Composition
{
    /// <summary>
    /// Elément de syntax qui permet de choisir l'action à réaliser.
    /// </summary>
    public class ThenAction : ExpressionElement
    {
        /// <summary>
        /// Token de l'élément.
        /// </summary>
        protected override string Token => "THEN";

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="ThenAction"/>.
        /// </summary>
        /// <param name="parent">Elément de syntax parent.</param>
        public ThenAction(ExpressionElement parent) : base(parent) { }

        /// <summary>
        /// Elément de syntax qui permet de déplacer la date au jour particulier juste avant.
        /// </summary>
        /// <param name="dayOfWeek">Jour particulier à retourner.</param>
        /// <returns>L'élément de syntax <see cref="Composition.Previous"/> pour ajouter d'autres comportements.</returns>
        public Previous Previous(DayOfWeek dayOfWeek) => new Previous(this, dayOfWeek);

        /// <summary>
        /// Elément de syntax qui permet de déplacer la date au jour particulier juste après.
        /// </summary>
        /// <param name="dayOfWeek">Jour particulier à retourner.</param>
        /// <returns>L'élément de syntax <see cref="Composition.Next"/> pour ajouter d'autres comportements.</returns>
        public Next Next(DayOfWeek dayOfWeek) => new Next(this, dayOfWeek);
    }
}
