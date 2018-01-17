using ID3iHoliday.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ID3iHoliday.Syntax
{
    /// <summary>
    /// Elément de syntax pour gérer le type d'année pris en charge.
    /// </summary>
    public class InYearComposition : ExpressionElement
    {
        /// <summary>
        /// Token de l'élément.
        /// </summary>
        protected override string Token => $"IN {Year.ToString().ToUpper()} YEARS";
        internal Year Year { get; set; }
        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="InYearComposition"/>.
        /// </summary>
        /// <param name="parent">Elément de syntax parent.</param>
        /// <param name="year">Type de l'année.</param>
        public InYearComposition(ExpressionElement parent, Year year) : base(parent) => Year = year;
        /// <summary>
        /// Elément de syntax pour gérer la récurrence selon un nombre de période.
        /// </summary>
        /// <param name="number">Nombre de périodes.</param>
        /// <returns>L'élément de syntax <see cref="EveryComposition"/> pour ajouter d'autres comportements.</returns>
        public EveryComposition Every(int number) => new EveryComposition(this, number);
    }
}
