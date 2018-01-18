using ID3iCore;
using ID3iDate;
using ID3iHoliday.Core.Parsers;
using ID3iRegex;
using System;
using System.Text.RegularExpressions;
using static ID3iHoliday.Syntax.Year;

namespace ID3iHoliday.Syntax.Parsers
{
    /// <summary>
    /// Parser pour une expression de type religieuse.
    /// </summary>
    public class ParserEaster : ParserBase
    {
        internal static DateTime CatholicEasterSunday(int year)
        {
            var g = year % 19;
            var c = year / 100;
            var h = (c - c / 4 - (8 * c + 13) / 25 + 19 * g + 15) % 30;
            var i = h - (h / 28) * (1 - (h / 28) * (29 / (h + 1)) * ((21 - g) / 11));

            var day = i - ((year + (int)(year / 4) + i + 2 - c + (int)(c / 4)) % 7) + 28;
            var month = 3;

            if (day > 31)
            {
                month++;
                day -= 31;
            }

            return new DateTime(year, month, day);
        }
        internal static DateTime OrthodoxEasterSunday(int year)
        {
            var a = year % 19;
            var b = year % 7;
            var c = year % 4;

            var d = (19 * a + 16) % 30;
            var e = (2 * c + 4 * b + 6 * d) % 7;
            var f = (19 * a + 16) % 30;
            var key = f + e + 3;

            var month = (key > 30) ? 5 : 4;
            var day = (key > 30) ? key - 30 : key;

            return new DateTime(year, month, day);
        }
        /// <summary>
        /// Pattern complet de ce parser.
        /// </summary>
        public Pattern Pattern =>
            Pattern.With
                .StartOfLine
                .Literal("DATE").Whitespace
                .NamedGroup("Religion",
                    Pattern.With.Choice(Pattern.With.Literal("CATHOLIC"), Pattern.With.Literal("ORTHODOX")))
                .Whitespace.Literal("EASTER")
                .AtomicGroup(Pattern.With.Whitespace.NamedGroup("Symbol", Pattern.With.Choice(Pattern.With.Literal("+"), Pattern.With.Literal("-")))).Repeat.Optional
                .NamedGroup("Number", Pattern.With.Digit.Repeat.Between(0, 2)).Repeat.Optional
                .Include(Parser.PatternStartAndDuration)
                .Include(Parser.PatternIfDayThenStartAt)
                .Include(Parser.PatternYearType)
                .Include(Parser.PatternYearRecurs)
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
                DateTime date = DateTime.MinValue;
                if (match.Groups["Religion"].Value == "CATHOLIC")
                    date = CatholicEasterSunday(year);
                else if (match.Groups["Religion"].Value == "ORTHODOX")
                    date = OrthodoxEasterSunday(year);
                var symbol = match.Groups["Symbol"].Value;
                if (symbol.IsNotNullOrEmpty() && match.Groups["Number"].Value.IsNotNullOrEmpty())
                {
                    int number = Int32.Parse(match.Groups["Number"].Value);
                    if (symbol == "+")
                        date = number.Days().After(date);
                    else if (symbol == "-")
                        date = number.Days().Before(date);
                }

                if (match.Groups["StartHours"].Value.IsNotNullOrEmpty() && match.Groups["StartMinutes"].Value.IsNotNullOrEmpty())
                    date = date.SetTime(Int32.Parse(match.Groups["StartHours"].Value), Int32.Parse(match.Groups["StartMinutes"].Value));

                if (match.Groups["Expected"].Value.IsNotNullOrEmpty())
                    if (date.DayOfWeek.ToString().ToUpper() == match.Groups["Expected"].Value)
                        if (match.Groups["NewHours"].Value.IsNotNullOrEmpty() && match.Groups["NewMinutes"].Value.IsNotNullOrEmpty())
                            date = date.SetTime(Int32.Parse(match.Groups["NewHours"].Value), Int32.Parse(match.Groups["NewMinutes"].Value));

                bool isYearTypeOk = false;
                if (match.Groups["YearType"].Value.IsNotNullOrEmpty())
                {
                    switch ((Year)Enum.Parse(typeof(Year), match.Groups["YearType"].Value, true))
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
                    if (((date.Year - startYear) % numberYear) == 0)
                        isYearRecursOk = true;
                }
                else
                    isYearRecursOk = true;

                if (isYearTypeOk && isYearRecursOk)
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
