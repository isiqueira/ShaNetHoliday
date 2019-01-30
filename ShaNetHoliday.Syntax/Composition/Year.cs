using ShaNetHoliday.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShaNetHoliday.Syntax.Composition
{
    /// <summary>
    /// Elément de syntax pour le récurrence par nombre d'années.
    /// </summary>
    public class Year : ExpressionElement
    {
        /// <summary>
        /// Token de l'élément.
        /// </summary>
        protected override string Token => "YEAR";

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="Year"/>.
        /// </summary>
        /// <param name="parent">Elément de syntax parent.</param>
        public Year( ExpressionElement parent ) : base( parent ) { }

        /// <summary>
        /// Elément de syntax pour gérer le début d'application de l'expression.
        /// </summary>
        /// <param name="year">Année de départ.</param>
        /// <returns>L'élément de syntax <see cref="Composition.Since"/> pour ajouter d'autres comportements.</returns>
        public Since Since( int year ) => new Since( this, year );

        /// <summary>
        /// Elément de syntax pour gérer la fin d'application de l'expression.
        /// </summary>
        /// <param name="year">Année de fin.</param>
        /// <returns>L'élément de syntax <see cref="Composition.To"/> pour ajouter d'autres comportements.</returns>
        public To To( int year ) => new To( this, year );
    }
}
