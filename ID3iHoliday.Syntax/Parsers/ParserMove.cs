using ID3iRegex;
using System;
using System.Text.RegularExpressions;
using ID3iHoliday.Core.Parsers;
using ID3iDate;

namespace ID3iHoliday.Syntax.Parsers
{
    /// <summary>
    /// Parser pour une expression de type déplacement.
    /// </summary>
    public class ParserMove : ParserBase
    {
        /// <summary>
        /// Pattern complet de ce parser.
        /// </summary>
        public Pattern Pattern =>
            Pattern.With
                .StartOfLine
                .Literal("MOVE").Whitespace
                .Include(Parser.PatternMonths)
                .NamedGroup("Or",
                    Pattern.With.Whitespace.Literal("IF").Whitespace
                    .NamedGroup("Expected", Parser.PatternDay)
                    .Whitespace.Literal("THEN").Whitespace
                    .NamedGroup("Action", Parser.PatternActionNextPrevious)
                    .Whitespace
                    .NamedGroup("NewValue", Parser.PatternDay)).Repeat.OneOrMore
                .EndOfLine;

        /// <summary>
        /// Méthode qui permet de déterminer si une expression peut être interpréter par le parser.
        /// </summary>
        /// <param name="expression">Expression à tester.</param>
        /// <returns>
        /// <see langword="true"/> si l'expression match le pattern, <see langword="false"/> sinon.
        /// </returns>
        public override bool IsMatch(string expression) => new Regex(Pattern.ToString()).IsMatch(expression);

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
                for (int i = 0; i < match.Groups["Or"].Captures.Count; i++)
                {
                    if (realDate.DayOfWeek.ToString().ToUpper() == match.Groups["Expected"].Captures[i].Value)
                    {
                        if (match.Groups["Action"].Value == "NEXT")
                            result.DatesToAdd.Add(realDate.Next((DayOfWeek)Enum.Parse(typeof(DayOfWeek), match.Groups["NewValue"].Captures[i].Value, true)));
                        else if (match.Groups["Action"].Value == "PREVIOUS")
                            result.DatesToAdd.Add(realDate.Previous((DayOfWeek)Enum.Parse(typeof(DayOfWeek), match.Groups["NewValue"].Captures[i].Value, true)));
                    }
                }
                result.DateToRemove = realDate;
            }
            return result;
        }
    }
}
