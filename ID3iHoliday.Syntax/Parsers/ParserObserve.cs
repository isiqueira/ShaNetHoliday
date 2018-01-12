using ID3iRegex;
using System;
using System.Text.RegularExpressions;
using ID3iHoliday.Core.Parsers;
using ID3iDate;

namespace ID3iHoliday.Syntax.Parsers
{
    public class ParserObserve : ParserBase
    {
        public Pattern Pattern =>
            Pattern.With
                .StartOfLine
                .Literal("OBSERVE").Whitespace
                .Include(Parser.PatternMonths)
                .NamedGroup("A",
                    Pattern.With.Whitespace.Literal("IF").Whitespace
                    .NamedGroup("Expected", Parser.PatternDay)
                    .Whitespace.Literal("THEN").Whitespace
                    .NamedGroup("Action", Parser.PatternActionNextPrevious)
                    .Whitespace
                    .NamedGroup("NewValue", Parser.PatternDay)).Repeat.OneOrMore
                .EndOfLine;
        public override ParserResult Parse(string expression, int year)
        {
            ParserResult result = new ParserResult();
            var regex = new Regex(Pattern.ToString());
            var match = regex.Match(expression);
            if (match.Success)
            {
                var realDate = new DateTime(year, Int32.Parse(match.Groups["month"].Value), Int32.Parse(match.Groups["day"].Value));
                result.DatesToAdd.Add(realDate);
                for (int i = 0; i < match.Groups["A"].Captures.Count; i++)
                {
                    if (realDate.DayOfWeek.ToString().ToUpper() == match.Groups["Expected"].Captures[i].Value)
                    {
                        if (match.Groups["Action"].Captures[i].Value == "NEXT")
                            result.DatesToAdd.Add(realDate.Next((DayOfWeek)Enum.Parse(typeof(DayOfWeek), match.Groups["NewValue"].Captures[i].Value, true)));
                        else if (match.Groups["Action"].Captures[i].Value == "PREVIOUS")
                            result.DatesToAdd.Add(realDate.Previous((DayOfWeek)Enum.Parse(typeof(DayOfWeek), match.Groups["NewValue"].Captures[i].Value, true)));
                    }
                }
            }
            return result;
        }
    }
}
