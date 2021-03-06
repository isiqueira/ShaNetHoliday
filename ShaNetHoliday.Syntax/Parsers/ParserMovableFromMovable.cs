﻿using ShaNetRegex;
using System;
using System.Text.RegularExpressions;
using ShaNetHoliday.Core.Parsers;
using ShaNetCore;
using ShaNetDate;
using static ShaNetHoliday.Syntax.YearType;

namespace ShaNetHoliday.Syntax.Parsers
{
    /// <summary>
    /// Parser pour une expression de type movable from movable.
    /// </summary>
    public class ParserMovableFromMovable : ParserBase
    {
        /// <summary>
        /// Pattern complet de ce parser.
        /// </summary>
        public Pattern Pattern =>
            Pattern.With
                .StartOfLine
                .Literal( "DATE" ).Whitespace.Literal( "MOVABLE²" ).Whitespace
                .NamedGroup( "ExpectedNumber", Parser.PatternNumber )
                .Whitespace
                .NamedGroup( "Expected", Parser.PatternDay )
                .Whitespace
                .NamedGroup( "ExpectedAction", Parser.PatternActionBeforeAfter )
                .Whitespace
                .NamedGroup( "BaseNumber", Parser.PatternNumber )
                .Whitespace
                .NamedGroup( "Base", Parser.PatternDay )
                .Whitespace
                .NamedGroup( "BaseAction", Parser.PatternActionBeforeAfter )
                .Whitespace
                .Include( Parser.PatternMonths )
                .AtomicGroup( Pattern.With.Whitespace.Literal( "THEN" ) ).Repeat.Optional
                .Include( Parser.PatternStartAndDuration )
                .Include( Parser.PatternYearType )
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
                var date = new DateTime( year, int.Parse( match.Groups[ "month" ].Value ), int.Parse( match.Groups[ "day" ].Value ) );
                if ( match.Groups[ "BaseAction" ].Value == "BEFORE" )
                {
                    date = date.Previous( (DayOfWeek)Enum.Parse( typeof( DayOfWeek ), match.Groups[ "Base" ].Value, true ) ).WeekEarlier( (int)(Count)Enum.Parse( typeof( Count ), match.Groups[ "BaseNumber" ].Value, true ) );
                }
                else if ( match.Groups[ "BaseAction" ].Value == "AFTER" )
                {
                    date = date.NextOrThis( (DayOfWeek)Enum.Parse( typeof( DayOfWeek ), match.Groups[ "Base" ].Value, true ) ).WeekAfter( (int)(Count)Enum.Parse( typeof( Count ), match.Groups[ "BaseNumber" ].Value, true ) );
                }

                if ( match.Groups[ "ExpectedAction" ].Value == "BEFORE" )
                {
                    date = date.Previous( (DayOfWeek)Enum.Parse( typeof( DayOfWeek ), match.Groups[ "Expected" ].Value, true ) ).WeekEarlier( (int)(Count)Enum.Parse( typeof( Count ), match.Groups[ "ExpectedNumber" ].Value, true ) );
                }
                else if ( match.Groups[ "ExpectedAction" ].Value == "AFTER" )
                {
                    date = date.NextOrThis( (DayOfWeek)Enum.Parse( typeof( DayOfWeek ), match.Groups[ "Expected" ].Value, true ) ).WeekAfter( (int)(Count)Enum.Parse( typeof( Count ), match.Groups[ "ExpectedNumber" ].Value, true ) );
                }

                if ( match.Groups[ "StartHours" ].Value.IsNotNullOrEmpty() && match.Groups[ "StartMinutes" ].Value.IsNotNullOrEmpty() )
                {
                    date = date.SetTime( int.Parse( match.Groups[ "StartHours" ].Value ), int.Parse( match.Groups[ "StartMinutes" ].Value ) );
                }

                if ( match.Groups[ "RepeatEndYear" ].Value.IsNotNullOrEmpty() )
                {
                    if ( date.Year > int.Parse( match.Groups[ "RepeatEndYear" ].Value ) )
                    {
                        return result;
                    }
                }

                var isYearTypeOk = false;
                if ( match.Groups[ "YearType" ].Value.IsNotNullOrEmpty() )
                {
                    switch ( (YearType)Enum.Parse( typeof( YearType ), match.Groups[ "YearType" ].Value, true ) )
                    {
                        case Even:
                            if ( date.Year % 2 == 0 )
                            {
                                isYearTypeOk = true;
                            }

                            break;
                        case Odd:
                            if ( date.Year % 2 != 0 )
                            {
                                isYearTypeOk = true;
                            }

                            break;
                        case Leap:
                            if ( DateTime.IsLeapYear( date.Year ) )
                            {
                                isYearTypeOk = true;
                            }

                            break;
                        case NonLeap:
                            if ( !DateTime.IsLeapYear( date.Year ) )
                            {
                                isYearTypeOk = true;
                            }

                            break;
                        default:
                            isYearTypeOk = false;
                            break;
                    }
                }
                else
                {
                    isYearTypeOk = true;
                }

                var isYearRecursOk = false;
                if ( match.Groups[ "RepeatYear" ].Value.IsNotNullOrEmpty() && match.Groups[ "RepeatStartYear" ].Value.IsNotNullOrEmpty() )
                {
                    var numberYear = int.Parse( match.Groups[ "RepeatYear" ].Value );
                    var startYear = int.Parse( match.Groups[ "RepeatStartYear" ].Value );
                    if ( date.Year >= startYear && ( ( date.Year - startYear ) % numberYear ) == 0 )
                    {
                        isYearRecursOk = true;
                    }
                }
                else
                {
                    isYearRecursOk = true;
                }

                if ( isYearTypeOk && isYearRecursOk )
                {
                    result.DatesToAdd.Add( date );
                }
            }
            return result;
        }
    }
}
