using ID3iHoliday.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ID3iHoliday.Syntax
{
    /// <summary>
    /// Elément de syntax pour la définition d'un jour en rapport avec le dimanche de Pâques.
    /// </summary>
    public class EasterDayComposition : ExpressionElement
    {
        /// <summary>
        /// Token de l'élément.
        /// </summary>
        protected override string Token => Value;
        internal string Value { get; set; }
        /// <summary>
        /// Initialise une nouvelle classe de <see cref="EasterDayComposition"/>.
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="value"></param>
        public EasterDayComposition(ExpressionElement parent, string value) : base(parent) => Value = value;
        /// <summary>
        /// Elément de syntax pour indiquer l'heure de début.
        /// </summary>
        /// <param name="value">L'heure de début au format HH:mm</param>
        /// <returns>L'élément de syntax <see cref="StartComposition"/> pour ajouter d'autres comportements.</returns>
        public StartComposition StartAt(string value) => new StartComposition(this, value);
        /// <summary>
        /// Elément de syntax pour indiquer que l'heure de début est à minuit.
        /// </summary>
        /// <returns>L'élément de syntax <see cref="StartComposition"/> pour ajouter d'autres comportements.</returns>
        public StartComposition StartAtMidnight => new StartComposition(this, "00:00");
    }
}
