using System;
using System.Text.RegularExpressions;
using ID3iRegex;
using ID3iHoliday.Core.Parsers;
using ID3iCore;
using ID3iDate;
using static ID3iHoliday.Syntax.YearType;

namespace ID3iHoliday.Syntax.Parsers
{
    /// <summary>
    /// Parser pour une expression de type date.
    /// </summary>
    public class ParserDate : ParserBase
    {
        /// <summary>
        /// Pattern complet de ce parser.
        /// </summary>
        public Pattern Pattern =>
            Pattern.With
                .StartOfLine
                .Literal("DATE").Whitespace
                .AtomicGroup(Pattern.With.NamedGroup("year", Pattern.With.Set(Pattern.With.Literal("0-9")).Repeat.Exactly(4)).Literal("-")).Repeat.Optional
                .Include(Parser.PatternMonths)
                .Include(Parser.PatternStartAndDuration)
                .Include(Parser.PatternIfDayThenStartAt)
                .Include(Parser.PatternYearType)
                .Include(Parser.PatternYearRecurs)
                .Include(Parser.PatternCalendar)
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
                var calendar = Parser.GetCalendar(match.Groups["Calendar"].Value);

                var date = new DateTime(calendar.GetYear(DateTime.Today), Int32.Parse(match.Groups["month"].Value), Int32.Parse(match.Groups["day"].Value), calendar);
                if (match.Groups["year"].Value.IsNotNullOrEmpty())
                    date = date.SetYear(Int32.Parse(match.Groups["year"].Value));

                if (match.Groups["StartHours"].Value.IsNotNullOrEmpty() && match.Groups["StartMinutes"].Value.IsNotNullOrEmpty())
                    date = date.SetTime(Int32.Parse(match.Groups["StartHours"].Value), Int32.Parse(match.Groups["StartMinutes"].Value));

                if (match.Groups["Expected"].Value.IsNotNullOrEmpty())
                    if (date.DayOfWeek.ToString().ToUpper() == match.Groups["Expected"].Value)
                        if (match.Groups["NewHours"].Value.IsNotNullOrEmpty() && match.Groups["NewMinutes"].Value.IsNotNullOrEmpty())
                            date = date.SetTime(Int32.Parse(match.Groups["NewHours"].Value), Int32.Parse(match.Groups["NewMinutes"].Value));

                bool isYearTypeOk = false;
                if (match.Groups["YearType"].Value.IsNotNullOrEmpty())
                {
                    switch ((YearType)Enum.Parse(typeof(YearType), match.Groups["YearType"].Value, true))
                    {
                        case Even:
                            if (date.Year % 2 == 0)
                                isYearTypeOk = true;
                            break;
                        case Odd:
                            if (date.Year % 2 != 0)
                                isYearTypeOk = true;
                            break;
                        case Leap:
                            if (DateTime.IsLeapYear(date.Year))
                                isYearTypeOk = true;
                            break;
                        case NonLeap:
                            if (!DateTime.IsLeapYear(date.Year))
                                isYearTypeOk = true;
                            break;
                        default:
                            isYearTypeOk = false;
                            break;
                    }
                }
                else
                    isYearTypeOk = true;

                bool isYearRecursOk = false;
                if (match.Groups["RepeatYear"].Value.IsNotNullOrEmpty() && match.Groups["RepeatStartYear"].Value.IsNotNullOrEmpty())
                {
                    var numberYear = Int32.Parse(match.Groups["RepeatYear"].Value);
                    var startYear = Int32.Parse(match.Groups["RepeatStartYear"].Value);
                    if (date.Year >= startYear && ((date.Year - startYear) % numberYear) == 0)
                        isYearRecursOk = true;
                }
                else
                    isYearRecursOk = true;

                if (isYearTypeOk && isYearRecursOk && (match.Groups["year"].Value.IsNotNullOrEmpty() ? date.Year == year : true))
                {
                    result.DatesToAdd.Add(date);
                    if (match.Groups["DurationDays"].Value.IsNotNullOrEmpty())
                    {
                        int number = Int32.Parse(match.Groups["DurationDays"].Value);
                        for (int i = 1; i < number; i++)
                            result.DatesToAdd.Add(i.Days().After(date.Midnight()));
                    }
                }
            }
            return result;
        }
    }
}
