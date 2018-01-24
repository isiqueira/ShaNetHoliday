using ID3iHoliday.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ID3iHoliday.Syntax.Composition
{
    /// <summary>
    /// Elément de syntax qui permet de chaîner les tests de jours.
    /// </summary>
    public class Or : ExpressionElement
    {
        /// <summary>
        /// Token de l'élément.
        /// </summary>
        protected override string Token => "";
        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="Or"/>.
        /// </summary>
        /// <param name="parent">Elément de syntax parent.</param>
        public Or(ExpressionElement parent) : base(parent) { }
        /// <summary>
        /// Elément de syntax pour déplacer le jour à un autre si il tombe un certain jour.
        /// </summary>
        /// <param name="dayOfWeek">Jour particulier.</param>
        /// <returns>L'élément de syntax <see cref="IfDay"/> pour ajouter d'autres comportements.</returns>
        public IfDay If(DayOfWeek dayOfWeek) => new IfDay(this, dayOfWeek);
    }
}
