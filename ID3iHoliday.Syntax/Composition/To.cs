using ID3iHoliday.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ID3iHoliday.Syntax.Composition
{
    /// <summary>
    /// Elément de syntax pour gérer la fin d'application de l'expression.
    /// </summary>
    public class To : ExpressionElement
    {
        /// <summary>
        /// Token de l'élément.
        /// </summary>
        protected override string Token => $"TO {Year}";
        internal int Year { get; set; }
        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="Since"/>.
        /// </summary>
        /// <param name="parent">Elément de syntax parent.</param>
        /// <param name="year">Année de fin.</param>
        public To(ExpressionElement parent, int year) : base(parent) => Year = year;
    }
}
