using ID3iHoliday.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ID3iHoliday.Syntax
{
    /// <summary>
    /// Elément de syntax pour indiquer l'heure de début.
    /// </summary>
    public class StartComposition : ExpressionElement
    {
        /// <summary>
        /// Token de l'élément.
        /// </summary>
        protected override string Token => $"{Value}";
        internal string Value { get; set; }
        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="StartComposition"/>.
        /// </summary>
        /// <param name="parent">Elément de syntax parent.</param>
        /// <param name="value">Heure de début au format HH:mm</param>
        public StartComposition(ExpressionElement parent, string value) : base(parent) => Value = value;
        /// <summary>
        /// Elément de syntax pour gérer la récurrence selon un nombre de période.
        /// </summary>
        /// <param name="number">Nombre de période.</param>
        /// <returns>L'élément de syntax <see cref="EveryComposition"/> pour ajouter d'autres comportements.</returns>
        public EveryComposition Every(int number) => new EveryComposition(this, number);
        /// <summary>
        /// Elément de syntax pour gérer le type d'année pris en charge.
        /// </summary>
        /// <param name="year">Type de l'année.</param>
        /// <returns>L'élément de syntax <see cref="InYearComposition"/> pour ajouter d'autres comportements.</returns>
        public InYearComposition In(Year year) => new InYearComposition(this, year);
        /// <summary>
        /// Elément de syntax pour gérer la durée.
        /// </summary>
        /// <param name="value">Durée.</param>
        /// <returns>L'élément de syntax <see cref="DurationComposition"/> pour ajouter d'autres comportements.</returns>
        public DurationComposition Duration(string value) => new DurationComposition(this, value);
    }
}
