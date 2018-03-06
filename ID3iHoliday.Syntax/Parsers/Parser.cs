using ID3iRegex;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ID3iHoliday.Syntax.Parsers
{
    /// <summary>
    /// Classe de définition des patterns.
    /// </summary>
    public static class Parser
    {
        /// <summary>
        /// Méthode qui permet de récupérer un <see cref="System.Globalization.Calendar"/> par rapport au type spécifié.
        /// </summary>
        /// <param name="calendar">Type du calendrier souhaité.</param>
        /// <returns>Le <see cref="System.Globalization.Calendar"/> correspondant.</returns>
        public static System.Globalization.Calendar GetCalendar(string calendar)
        {
            switch (calendar?.ToUpper())
            {
                case "GREGORIAN":
                    return new GregorianCalendar();
                case "JULIAN":
                    return new JulianCalendar();
                case "HIJRI":
                    return new HijriCalendar();
                default:
                    return new GregorianCalendar();
            }
        }

        /// <summary>
        /// Pattern pour l'heure de début et la durée.
        /// </summary>
        public static Pattern PatternStartAndDuration =>
            Pattern.With
                .AtomicGroup(
                    Pattern.With.Whitespace
                    .Include(PatternStartHours)).Repeat.Optional
                .Whitespace.Repeat.Optional
                .AtomicGroup(
                    Pattern.With.Literal("P")
                    .NamedGroup("DurationDays", Pattern.With.Digit.Repeat.OneOrMore).Literal("D")).Repeat.Optional;
        /// <summary>
        /// Pattern pour l'heure de début.
        /// </summary>
        public static Pattern PatternStartHours =>
            Pattern.With
                .NamedGroup("StartHours",
                    Pattern.With.Choice(
                        Pattern.With.Literal("0").Set(Pattern.With.Literal("0-9")),
                        Pattern.With.Literal("1").Set(Pattern.With.Literal("0-9")),
                        Pattern.With.Literal("2").Set(Pattern.With.Literal("0-3")))).Literal(":")
                .NamedGroup("StartMinutes", Pattern.With.Set(Pattern.With.Literal("0-5")).Set(Pattern.With.Literal("0-9")));
        /// <summary>
        /// Pattern Si jour particulier alors autre heure de début.
        /// </summary>
        public static Pattern PatternIfDayThenStartAt =>
            Pattern.With
                .AtomicGroup(
                    Pattern.With.Whitespace
                    .Literal("IF").Whitespace
                    .NamedGroup("Expected", PatternDay).Whitespace
                    .Literal("THEN").Whitespace
                    .Include(PatternNewHours)
                ).Repeat.Optional;
        /// <summary>
        /// Pattern pour la nouvelle heure de début.
        /// </summary>
        public static Pattern PatternNewHours =>
              Pattern.With
                .NamedGroup("NewHours",
                    Pattern.With.Choice(
                        Pattern.With.Literal("0").Set(Pattern.With.Literal("0-9")),
                        Pattern.With.Literal("1").Set(Pattern.With.Literal("0-9")),
                        Pattern.With.Literal("2").Set(Pattern.With.Literal("0-3")))).Literal(":")
                .NamedGroup("NewMinutes", Pattern.With.Set(Pattern.With.Literal("0-5")).Set(Pattern.With.Literal("0-9")));

        /// <summary>
        /// Pattern pour le type d'année.
        /// </summary>
        public static Pattern PatternYearType =>
            Pattern.With
                .AtomicGroup(
                    Pattern.With.Whitespace.Literal("IN").Whitespace
                    .NamedGroup("YearType",
                        Pattern.With.Choice(Pattern.With.Literal("EVEN"), Pattern.With.Literal("ODD"), Pattern.With.Literal("LEAP"), Pattern.With.Literal("NONLEAP")))
                    .Whitespace.Literal("YEARS")).Repeat.Optional;

        /// <summary>
        /// Pattern pour le type de calendrier.
        /// </summary>
        public static Pattern PatternCalendar =>
            Pattern.With
                .AtomicGroup(
                    Pattern.With.Whitespace.Literal("OVER").Whitespace
                    .NamedGroup("Calendar",
                        Pattern.With.Choice(
                            Pattern.With.Literal("JULIAN"), Pattern.With.Literal("HIJRI"), Pattern.With.Literal("")
                        )
                    )
                ).Repeat.Optional;

        /// <summary>
        /// Pattern pour la récurrence.
        /// </summary>
        public static Pattern PatternYearRecurs =>
            Pattern.With
                .AtomicGroup(
                    Pattern.With.Whitespace.Literal("EVERY").Whitespace
                    .NamedGroup("RepeatYear", Pattern.With.Digit)
                    .Whitespace.Literal("YEAR").Whitespace.Literal("SINCE").Whitespace
                    .NamedGroup("RepeatStartYear", Pattern.With.Set(Pattern.With.Literal("0-9")).Repeat.Exactly(4))).Repeat.Optional;
        /// <summary>
        /// Pattern pour une date dans un mois.
        /// </summary>
        public static Pattern PatternMonths =>
            Pattern.With
                .AtomicGroup(
                    Pattern.With.Choice(
                        Pattern.With.NamedGroup("month",
                            Pattern.With.Choice(
                                Pattern.With.Literal("0").Set(Pattern.With.Literal("13578")),
                                Pattern.With.Literal("10"),
                                Pattern.With.Literal("12"))).Literal("-")
                            .NamedGroup("day",
                                Pattern.With.Choice(
                                    Pattern.With.Literal("0").Set(Pattern.With.Literal("1-9")),
                                    Pattern.With.Set(Pattern.With.Literal("1-2")).Set(Pattern.With.Literal("0-9")),
                                    Pattern.With.Literal("3").Set(Pattern.With.Literal("0-1")))),
                        Pattern.With
                            .NamedGroup("month", Pattern.With.Literal("02")).Literal("-")
                            .NamedGroup("day",
                                Pattern.With.Choice(
                                Pattern.With.Literal("0").Set(Pattern.With.Literal("1-9")),
                                Pattern.With.Set(Pattern.With.Literal("1-2")).Set(Pattern.With.Literal("0-9")))),
                        Pattern.With
                            .NamedGroup("month",
                                Pattern.With.Choice(
                                    Pattern.With.Literal("0").Set(Pattern.With.Literal("469")),
                                    Pattern.With.Literal("11"))).Literal("-")
                            .NamedGroup("day",
                                Pattern.With.Choice(
                                    Pattern.With.Literal("0").Set(Pattern.With.Literal("1-9")),
                                    Pattern.With.Set(Pattern.With.Literal("1-2")).Set(Pattern.With.Literal("0-9")),
                                    Pattern.With.Literal("30")))
                        ));
        /// <summary>
        /// Pattern pour l'adjectif numéral.
        /// </summary>
        public static Pattern PatternNumber =>
            Pattern.With.Choice(
                Pattern.With.Literal("FIRST"), Pattern.With.Literal("SECOND"), Pattern.With.Literal("THIRD"),
                Pattern.With.Literal("FOURTH"), Pattern.With.Literal("FIFTH"), Pattern.With.Literal("SIXTH"));
        /// <summary>
        /// Pattern pour le jour particulier.
        /// </summary>
        public static Pattern PatternDay =>
            Pattern.With.Choice(
                Pattern.With.Literal("MONDAY"), Pattern.With.Literal("TUESDAY"), Pattern.With.Literal("WEDNESDAY"),
                 Pattern.With.Literal("THURSDAY"), Pattern.With.Literal("FRIDAY"), Pattern.With.Literal("SATURDAY"), Pattern.With.Literal("SUNDAY"));
        /// <summary>
        /// Pattern pour le type d'action Before/After.
        /// </summary>
        public static Pattern PatternActionBeforeAfter =>
            Pattern.With.Choice(Pattern.With.Literal("BEFORE"), Pattern.With.Literal("AFTER"));
        /// <summary>
        /// Pattern pour le type d'action Previous/Next.
        /// </summary>
        public static Pattern PatternActionNextPrevious =>
            Pattern.With.Choice(Pattern.With.Literal("NEXT"), Pattern.With.Literal("PREVIOUS"));
    }
}
