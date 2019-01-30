using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using iD3iCore;
using iD3iDate;
using iD3iHoliday.Core.Parsers;
using iD3iRegex;

namespace iD3iHoliday.Syntax.Parsers
{
    /// <summary>
    /// Parser pour une expression solaire.
    /// </summary>
    public class ParserChineseSolar : ParserBase
    {
        /// <summary>
        /// Pattern complet de ce parser.
        /// </summary>
        public Pattern Pattern =>
            Pattern.With
                .StartOfLine
                .Literal( "CHINESE" ).Whitespace
                .Include( Parser.PatternCHS )
                .Include( Parser.PatternCycleElementAnimal ).Repeat.Optional;

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
                var solarTerm = OnSolarTerm.The( int.Parse( match.Groups[ "Degrees" ].Value ) );
                var calculatedYear = year;
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
                var date = solarTerm.ToDateTime( calculatedYear );

                if(match.Groups["Day"].Value.IsNotNullOrEmpty())
                {
                    date = date + int.Parse( match.Groups[ "Day" ].Value ).Days() - 1.Days();
                }

                result.DatesToAdd.Add( date );
            }
            return result;
        }
    }
}
