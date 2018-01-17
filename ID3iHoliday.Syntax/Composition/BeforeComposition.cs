using ID3iHoliday.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ID3iHoliday.Syntax
{
    /// <summary>
    /// Elément de syntax pour indiquer que c'est avant une date précise.
    /// </summary>
    public class BeforeComposition : ExpressionElement
    {
        /// <summary>
        /// Token de l'élément.
        /// </summary>
        protected override string Token => $"BEFORE {Value}";
        internal string Value { get; set; }
        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="BeforeComposition"/>.
        /// </summary>
        /// <param name="parent">Elément de syntax parent.</param>
        /// <param name="value">Date.</param>
        public BeforeComposition(ExpressionElement parent, string value) : base(parent) => Value = value;
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
    }
}
