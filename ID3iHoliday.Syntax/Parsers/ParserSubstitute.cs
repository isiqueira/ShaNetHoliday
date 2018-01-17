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
                .Literal("SUBSTITUTE").Whitespace
                .Include(Parser.PatternMonths)
                .Whitespace.Literal("IF").Whitespace
                    .NamedGroup("Expected", Parser.PatternDay)
                    .Whitespace.Literal("THEN").Whitespace
                    .NamedGroup("Action", Parser.PatternActionNextPrevious)
                    .Whitespace
                    .NamedGroup("NewValue", Parser.PatternDay)
                .EndOfLine;
        /// <summary>
        /// Méthode de parsing d'une expression.
        /// </summary>
        /// <param name="expression">Expression à parser.</param>
        /// <param name="year">Année.</param>
        /// <returns>Un <see cref="ParserResult"/> correspondant.</returns>
        public override ParserResult Parse(string expression, int year)
        {
            ParserResult result = new ParserResult();
            var regex = new Regex(Pattern.ToString());
            var match = regex.Match(expression);
            if (match.Success)
            {
                var realDate = new DateTime(year, Int32.Parse(match.Groups["month"].Value), Int32.Parse(match.Groups["day"].Value));
                if (realDate.DayOfWeek.ToString().ToUpper() == match.Groups["Expected"].Value)
                {
                    if (match.Groups["Action"].Value == "NEXT")
                        result.DatesToAdd.Add(realDate.Next((DayOfWeek)Enum.Parse(typeof(DayOfWeek), match.Groups["NewValue"].Value, true)));
                    else if (match.Groups["Action"].Value == "PREVIOUS")
                        result.DatesToAdd.Add(realDate.Previous((DayOfWeek)Enum.Parse(typeof(DayOfWeek), match.Groups["NewValue"].Value, true)));
                }
                result.DateToRemove = realDate;
            }
            return result;
        }
    }
}
