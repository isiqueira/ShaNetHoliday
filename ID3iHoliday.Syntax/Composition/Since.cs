using ID3iHoliday.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ID3iHoliday.Syntax.Composition
{
    /// <summary>
    /// Elément de syntax pour gérer le début d'application de l'expression.
    /// </summary>
    public class Since : ExpressionElement
    {
        /// <summary>
        /// Token de l'élément.
        /// </summary>
        protected override string Token => $"SINCE {Year}";
        internal int Year { get; set; }

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="Since"/>.
        /// </summary>
        /// <param name="parent">Elément de syntax parent.</param>
        /// <param name="year">Année de départ.</param>
        public Since(ExpressionElement parent, int year) : base(parent) => Year = year;

        /// <summary>
        /// Elément de syntax pour gérer la fin d'application de l'expression.
        /// </summary>
        /// <param name="year">Année de fin.</param>
        /// <returns>L'élément de syntax <see cref="Composition.To"/> pour ajouter d'autres comportements.</returns>
        public To To(int year) => new To(this, year);
    }
}
