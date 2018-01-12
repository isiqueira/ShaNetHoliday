using System;
using System.Text.RegularExpressions;
using ID3iRegex;
using ID3iHoliday.Core.Parsers;
using ID3iCore;

namespace ID3iHoliday.Syntax.Parsers
{
    internal class ParserDate : ParserBase
    {
        public Pattern Pattern =>
            Pattern.With
                .StartOfLine
                .Literal("DATE").Whitespace
                .AtomicGroup(Pattern.With.NamedGroup("year", Pattern.With.Set(Pattern.With.Literal("0-9")).Repeat.Exactly(4)).Literal("-")).Repeat.Optional
                .Include(Parser.PatternMonths)
                .Include(Parser.PatternDuration)
                .Include(Parser.PatternYearRecurs)
                .EndOfLine;

        public override ParserResult Parse(string expression, int year)
        {
            ParserResult result = new ParserResult();
            var regex = new Regex(Pattern.ToString());
            var match = regex.Match(expression);
            if (match.Success)
            {
                var date = new DateTime(year, Int32.Parse(match.Groups["month"].Value), Int32.Parse(match.Groups["day"].Value));
                if (match.Groups["year"].Value.IsNotNullOrEmpty())
                    date = date.SetYear(Int32.Parse(match.Groups["year"].Value));
                if (date.Year == year)
                {
                    bool isOkEveryYear = true;
                    if (match.Groups["RepeatYear"].Value.IsNotNullOrEmpty() && match.Groups["RepeatStartYear"].Value.IsNotNullOrEmpty())
                    {
                        var numberYear = Int32.Parse(match.Groups["RepeatYear"].Value);
                        var startYear = Int32.Parse(match.Groups["RepeatStartYear"].Value);
                        isOkEveryYear = ((date.Year - startYear) % numberYear) == 0;
                    }

                    if (isOkEveryYear)
                    {
                        if (match.Groups["StartHours"].Value.IsNotNullOrEmpty() && match.Groups["StartMinutes"].Value.IsNotNullOrEmpty())
                            date = date.At(Int32.Parse(match.Groups["StartHours"].Value), Int32.Parse(match.Groups["StartMinutes"].Value));
                        result.DatesToAdd.Add(date);

                        if (match.Groups["DurationDays"].Value.IsNotNullOrEmpty())
                        {
                            int number = Int32.Parse(match.Groups["DurationDays"].Value);
                            for (int i = 1; i < number; i++)
                                result.DatesToAdd.Add(i.Days().After(date.Midnight()));
                        }
                    }
                }
            }
            return result;
        }
    }
}
