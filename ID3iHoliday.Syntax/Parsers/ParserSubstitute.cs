using ID3iCore;
using ID3iDate;
using ID3iHoliday.Core.Parsers;
using ID3iRegex;
using System;
using System.Text.RegularExpressions;

namespace ID3iHoliday.Syntax.Parsers
{
    /// <summary>
    /// Parser pour une expression de type substitution.
    /// </summary>
    public class ParserSubstitute : ParserBase
    {
        /// <summary>
        /// Pattern complet de ce parser.
        /// </summary>
        public Pattern Pattern =>
            Pattern.With
                .StartOfLine
                .Literal( "SUBSTITUTE" ).Whitespace
                .Include( Parser.PatternMonths )
                .NamedGroup( "Or",
                    Pattern.With.Whitespace.Literal( "IF" ).Whitespace
                    .NamedGroup( "Expected", Parser.PatternDay )
                    .Whitespace.Literal( "THEN" ).Whitespace
                    .NamedGroup( "Action", Parser.PatternActionNextPrevious )
                    .Whitespace
                    .NamedGroup( "NewValue", Parser.PatternDay ) ).Repeat.OneOrMore
                .Include( Parser.PatternYearRecurs )
                .EndOfLine;

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
            var result = new ParserResult();
            var regex = new Regex( Pattern.ToString() );
            var match = regex.Match( expression );
            if ( match.Success )
            {
                var substituteDate = new DateTime( year, int.Parse( match.Groups[ "month" ].Value ), int.Parse( match.Groups[ "day" ].Value ) );
                var newDate = new DateTime( year, int.Parse( match.Groups[ "month" ].Value ), int.Parse( match.Groups[ "day" ].Value ) );
                for ( var i = 0; i < match.Groups[ "Or" ].Captures.Count; i++ )
                {
                    if ( substituteDate.DayOfWeek.ToString().ToUpper() == match.Groups[ "Expected" ].Captures[ i ].Value )
                    {
                        if ( match.Groups[ "Action" ].Value == "NEXT" )
                        {
                            newDate = substituteDate.Next( (DayOfWeek)Enum.Parse( typeof( DayOfWeek ), match.Groups[ "NewValue" ].Captures[ i ].Value, true ) );
                        }
                        else if ( match.Groups[ "Action" ].Value == "PREVIOUS" )
                        {
                            newDate = substituteDate.Previous( (DayOfWeek)Enum.Parse( typeof( DayOfWeek ), match.Groups[ "NewValue" ].Captures[ i ].Value, true ) );
                        }
                    }
                }

                if ( match.Groups[ "RepeatEndYear" ].Value.IsNotNullOrEmpty() )
                {
                    if ( newDate.Year > int.Parse( match.Groups[ "RepeatEndYear" ].Value ) )
                    {
                        return result;
                    }
                }

                var isYearRecursOk = false;
                if ( match.Groups[ "RepeatYear" ].Value.IsNotNullOrEmpty() && match.Groups[ "RepeatStartYear" ].Value.IsNotNullOrEmpty() )
                {
                    var numberYear = int.Parse( match.Groups[ "RepeatYear" ].Value );
                    var startYear = int.Parse( match.Groups[ "RepeatStartYear" ].Value );
                    if ( newDate.Year >= startYear && ( ( newDate.Year - startYear ) % numberYear ) == 0 )
                    {
                        isYearRecursOk = true;
                    }
                }
                else
                {
                    isYearRecursOk = true;
                }

                if ( isYearRecursOk )
                {
                    if ( substituteDate != newDate )
                    {
                        result.DateToRemove = substituteDate;
                    }

                    result.DatesToAdd.Add( newDate );
                }
            }
            return result;
        }
    }
}
