using ID3iHoliday.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ID3iHoliday.Syntax
{
    /// <summary>
    /// Elément de syntax pour changer l'heure de début selon le jour.
    /// </summary>
    public class IfComposition : ExpressionElement
    {
        /// <summary>
        /// Token de l'élément.
        /// </summary>
        protected override string Token => $"IF {DayOfWeek.ToString().ToUpper()}";
        internal DayOfWeek DayOfWeek { get; set; }
        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="IfComposition"/>.
        /// </summary>
        /// <param name="parent">Elément de syntax parent.</param>
        /// <param name="dayOfWeek">Jour particulier.</param>
        public IfComposition(ExpressionElement parent, DayOfWeek dayOfWeek) : base(parent) => DayOfWeek = dayOfWeek;
        /// <summary>
        /// Elément de syntax pour changer l'heure.
        /// </summary>
        /// <param name="value">Nouvelle heure.</param>
        /// <returns>L'élément de syntax <see cref="ThenStartComposition"/> pour ajouter d'autres comportements.</returns>
        public ThenStartComposition ThenStartAt(string value) => new ThenStartComposition(this, value);
    }
}
