using ID3iHoliday.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ID3iHoliday.Syntax.Composition
{
    /// <summary>
    /// Elément de syntax pour gérer le type d'année pris en charge.
    /// </summary>
    public class InYear : ExpressionElement
    {
        /// <summary>
        /// Token de l'élément.
        /// </summary>
        protected override string Token => $"IN {Year.ToString().ToUpper()} YEARS";
        internal YearType Year { get; set; }
        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="InYear"/>.
        /// </summary>
        /// <param name="parent">Elément de syntax parent.</param>
        /// <param name="year">Type de l'année.</param>
        public InYear(ExpressionElement parent, YearType year) : base(parent) => Year = year;
        /// <summary>
        /// Elément de syntax pour gérer la récurrence selon un nombre de période.
        /// </summary>
        /// <param name="number">Nombre de périodes.</param>
        /// <returns>L'élément de syntax <see cref="Composition.Every"/> pour ajouter d'autres comportements.</returns>
        public Every Every(int number) => new Every(this, number);
    }
}
