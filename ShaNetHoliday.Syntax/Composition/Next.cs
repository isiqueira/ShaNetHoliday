using ShaNetHoliday.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShaNetHoliday.Syntax.Composition
{
    /// <summary>
    /// Elément de syntax qui permet de déplacer la date au jour particulier juste après.
    /// </summary>
    public class Next : ExpressionElement
    {
        /// <summary>
        /// Token de l'élément.
        /// </summary>
        protected override string Token => $"NEXT {Day.ToString().ToUpper()}";
        internal DayOfWeek Day { get; set; }

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="Next"/>.
        /// </summary>
        /// <param name="parent">Elément de syntax parent.</param>
        /// <param name="dayOfWeek">Jour particulier.</param>
        public Next( ExpressionElement parent, DayOfWeek dayOfWeek ) : base( parent ) => Day = dayOfWeek;

        /// <summary>
        /// Elément de syntax <see cref="Composition.Or"/> qui permet de chaîner les tests de jours.
        /// </summary>
        public Or Or => new Or( this );

        /// <summary>
        /// Elément de syntax pour gérer la récurrence selon un nombre de période.
        /// </summary>
        /// <param name="number">Nombre de période.</param>
        /// <returns>L'élément de syntax <see cref="Composition.Every"/> pour ajouter d'autres comportements.</returns>
        public Every Every( int number ) => new Every( this, number );

        /// <summary>
        /// Elément de syntax pour gérer le début d'application de l'expression.
        /// </summary>
        /// <param name="year">Année de départ.</param>
        /// <returns>L'élément de syntax <see cref="Composition.Since"/> pour ajouter d'autres comportements.</returns>
        public Since Since( int year ) => Every( 1 ).Year.Since( year );

        /// <summary>
        /// Elément de syntax pour gérer le calendrier à utiliser pour interpréter la date.
        /// </summary>
        /// <returns>L'élément de syntax <see cref="Composition.Over"/> pour ajouter d'autres comportements.</returns>
        public Over Over => new Over( this );
    }
}
