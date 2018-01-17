using ID3iHoliday.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ID3iHoliday.Syntax
{
    /// <summary>
    /// Elément de syntax pour le récurrence par nombre d'années.
    /// </summary>
    public class YearComposition : ExpressionElement
    {
        /// <summary>
        /// Token de l'élément.
        /// </summary>
        protected override string Token => "YEAR";
        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="YearComposition"/>.
        /// </summary>
        /// <param name="parent">Elément de syntax parent.</param>
        public YearComposition(ExpressionElement parent) : base(parent) { }
        /// <summary>
        /// Elément de syntax pour gérer le début d'application de l'expression.
        /// </summary>
        /// <param name="year">Année de départ.</param>
        /// <returns>L'élément de syntax <see cref="SinceComposition"/> pour ajouter d'autres comportements.</returns>
        public SinceComposition Since(int year) => new SinceComposition(this, year);
    }
}
