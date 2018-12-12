using iD3iHoliday.Core.Models;
using iD3iHoliday.Core.Parsers;
using iD3iHoliday.Syntax.Parsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static iD3iHoliday.Syntax.Month;

namespace iD3iHoliday.Syntax.Composition
{
    /// <summary>
    /// Elément de syntax pour changer au jour de la semaine spécifié.
    /// </summary>
    public class Movable : ExpressionElement
    {
        /// <summary>
        /// Token de l'élément.
        /// </summary>
        protected override string Token => $"MOVABLE {Count.ToString().ToUpper()} {Day.ToString().ToUpper()}";

        /// <summary>
        /// <see cref="ParserMovable"/> associé à l'élément.
        /// </summary>
        protected override ParserBase Parser => new ParserMovable();
        internal Count Count { get; set; }
        internal DayOfWeek Day { get; set; }

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="Movable"/>.
        /// </summary>
        /// <param name="parent">Elément de syntax parent.</param>
        /// <param name="count">Adjectif numéral pour la position du jour.</param>
        /// <param name="dayOfWeek">Jour particulier.</param>
        public Movable( ExpressionElement parent, Count count, DayOfWeek dayOfWeek ) : base( parent )
        {
            Count = count;
            Day = dayOfWeek;
        }

        /// <summary>
        /// Elément de syntax pour indiquer que c'est avant une date précise.
        /// </summary>
        /// <param name="value">Date avant laquelle le jour doit se trouver.</param>
        /// <returns>L'élément de syntax <see cref="Composition.Before"/> pour ajouter d'autres comportements.</returns>
        public Before Before( string value ) => new Before( this, value );

        /// <summary>
        /// Elément de syntax pour indiquer que c'est avant le début du mois.
        /// </summary>
        /// <param name="month">Mois avant lequel le jour doit se trouver.</param>
        /// <returns>L'élément de syntax <see cref="Composition.Before"/> pour ajouter d'autres comportements.</returns>
        public Before Before( Month month )
        {
            switch ( month )
            {
                case January:
                    return new Before( this, "01-01" );
                case February:
                    return new Before( this, "02-01" );
                case March:
                    return new Before( this, "03-01" );
                case April:
                    return new Before( this, "04-01" );
                case May:
                    return new Before( this, "05-01" );
                case June:
                    return new Before( this, "06-01" );
                case July:
                    return new Before( this, "07-01" );
                case August:
                    return new Before( this, "08-01" );
                case September:
                    return new Before( this, "09-01" );
                case October:
                    return new Before( this, "10-01" );
                case November:
                    return new Before( this, "11-01" );
                case December:
                    return new Before( this, "12-01" );
                default:
                    return new Before( this, "01-01" );
            }
        }

        /// <summary>
        /// Elément de syntax pour indiquer que c'est après une date précise.
        /// </summary>
        /// <param name="value">Date après laquelle le jour doit se trouver.</param>
        /// <returns>L'élément de syntax <see cref="Composition.After"/> pour ajouter d'autres comportements.</returns>
        public After After( string value ) => new After( this, value );

        /// <summary>
        /// Elément de syntax pour indiquer que c'est ap^rès le début du mois.
        /// </summary>
        /// <param name="month">Mois à partir duquel le jour doit se trouver.</param>
        /// <returns>L'élément de syntax <see cref="Composition.After"/> pour ajouter d'autres comportements.</returns>
        public After In( Month month )
        {
            switch ( month )
            {
                case January:
                    return new After( this, "01-01" );
                case February:
                    return new After( this, "02-01" );
                case March:
                    return new After( this, "03-01" );
                case April:
                    return new After( this, "04-01" );
                case May:
                    return new After( this, "05-01" );
                case June:
                    return new After( this, "06-01" );
                case July:
                    return new After( this, "07-01" );
                case August:
                    return new After( this, "08-01" );
                case September:
                    return new After( this, "09-01" );
                case October:
                    return new After( this, "10-01" );
                case November:
                    return new After( this, "11-01" );
                case December:
                    return new After( this, "12-01" );
                default:
                    return new After( this, "01-01" );
            }
        }
    }
}
