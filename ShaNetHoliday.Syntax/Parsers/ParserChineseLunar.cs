using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ShaNetCore;
using ShaNetDate;
using ShaNetHoliday.Core.Parsers;
using ShaNetRegex;

namespace ShaNetHoliday.Syntax.Parsers
{
    /// <summary>
    /// Parser pour une expression lunaire.
    /// </summary>
    public class ParserChineseLunar : ParserBase
    {
        /// <summary>
        /// Pattern complet de ce parser.
        /// </summary>
        public Pattern Pattern =>
            Pattern.With
                .StartOfLine
                .Literal( "CHINESE" ).Whitespace
                .Include( Parser.PatternCHL )
                .Include( Parser.PatternCycleElementAnimal ).Repeat.Optional
                .NamedGroup( "Or",
                    Pattern.With.Whitespace.Literal( "IF" ).Whitespace
                    .NamedGroup( "Expected", Parser.PatternDay )
                    .Whitespace.Literal( "THEN" ).Whitespace
                    .NamedGroup( "Action", Parser.PatternActionNextPrevious )
                    .Whitespace
                    .NamedGroup( "NewValue", Parser.PatternDay ) ).Repeat.ZeroOrMore;

        /// <summary>
        /// Méthode qui permet de déterminer si une expression peut être interpréter par le parser.
        /// </summary>
        /// <param name="expression">Expression à tester.</param>
        /// <returns>
        /// <see langword="true"/> si l'expression match le pattern, <see langword="false"/> sinon.
        /// </returns>
        public override bool IsMatch( string expression ) => new Regex( Pattern.ToString() ).IsMatch( expression );

        /// <summary>
        /// Méthode de parsing d'une expression.
        /// </summary>
        /// <param name="expression">Expression à parser.</param>
        /// <param name="year">Année.</param>
        /// <returns>Un <see cref="ParserResult"/> correspondant.</returns>
        public override ParserResult Parse( string expression, int year )
        {
            int GetLeapCorrection( int element, int animal )
            {
                return animal.IsEven() ?
                        animal <= ( 2 * element ) ?
                            1
                            : 61
                        : animal <= ( 2 * element ) + 1 ?
                            7
                            : 67;
            }
            var result = new ParserResult();
            var regex = new Regex( Pattern.ToString() );
            var match = regex.Match( expression );
            if ( match.Success )
            {
                var day = int.Parse( match.Groups[ "Day" ].Value );
                var month = int.Parse( match.Groups[ "Month" ].Value );
                var calculatedYear = year;
                DateTime observedDate;
                DateTime newDate;
                if ( match.Groups[ "Cycle" ].Value.IsNotNullOrEmpty() && match.Groups[ "Element" ].Value.IsNotNullOrEmpty() && match.Groups[ "Animal" ].Value.IsNotNullOrEmpty() )
                {
                    /*
                     * Cas d'une date particulière. l'année passée en paramètre ne nous sert pas, on la calcule avec le cycle, l'élément et l'animal.
                     * */
                    var cycle = int.Parse( match.Groups[ "Cycle" ].Value );
                    var element = (ChineseElement)Enum.Parse( typeof( ChineseElement ), match.Groups[ "Element" ].Value, true );
                    var animal = (ChineseZodiac)Enum.Parse( typeof( ChineseZodiac ), match.Groups[ "Animal" ].Value, true );

                    var leapCorrection = GetLeapCorrection( (int)element, (int)animal );

                    calculatedYear = ( 12 * (int)element ) - ( 5 * (int)animal ) + leapCorrection + ( 60 * cycle ) - 2757;
                }
                else
                {
                    /*
                     * Cas d'une date sans année particulière.
                     * */
                    var cycle = (int)Math.Truncate( (decimal)( year + 2756 ) / 60 );
                    var element = ( year.IsEven() ? ( ( year + 6 ) % 10 ) : ( ( year + 6 ) % 10 ) - 1 ) / 2;
                    var animal = ( year + 8 ) % 12;

                    var leapCorrection = GetLeapCorrection( (int)element, (int)animal );

                    calculatedYear = ( 12 * (int)element ) - ( 5 * (int)animal ) + leapCorrection + ( 60 * cycle ) - 2757;
                }
                observedDate = new ChineseLunisolarCalendar().ToDateTime( calculatedYear, month, day, 0, 0, 0, 0 );
                newDate = new ChineseLunisolarCalendar().ToDateTime( calculatedYear, month, day, 0, 0, 0, 0 );

                for ( var i = 0; i < match.Groups[ "Or" ].Captures.Count; i++ )
                {
                    if ( observedDate.DayOfWeek.ToString().ToUpper() == match.Groups[ "Expected" ].Captures[ i ].Value )
                    {
                        if ( match.Groups[ "Action" ].Captures[ i ].Value == "NEXT" )
                        {
                            newDate = observedDate.Next( (DayOfWeek)Enum.Parse( typeof( DayOfWeek ), match.Groups[ "NewValue" ].Captures[ i ].Value, true ) );
                        }
                        else if ( match.Groups[ "Action" ].Captures[ i ].Value == "PREVIOUS" )
                        {
                            newDate = observedDate.Previous( (DayOfWeek)Enum.Parse( typeof( DayOfWeek ), match.Groups[ "NewValue" ].Captures[ i ].Value, true ) );
                        }
                    }
                }

                result.DatesToAdd.Add( observedDate );
                if ( observedDate != newDate )
                {
                    result.DatesToAdd.Add( newDate );
                }
            }
            return result;
        }
    }
}
