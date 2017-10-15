using ID3iRegex;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ID3iHoliday.Syntax.Parsers
{
    public static class Parser
    {
        public static Pattern PatternDuration =>
            Pattern.With
                .AtomicGroup(
                    Pattern.With.Whitespace
                        .NamedGroup("StartHours",
                            Pattern.With.Choice(
                                Pattern.With.Literal("0").Set(Pattern.With.Literal("0-9")),
                                Pattern.With.Literal("1").Set(Pattern.With.Literal("0-9")),
                                Pattern.With.Literal("2").Set(Pattern.With.Literal("0-3")))).Literal(":")
                    .NamedGroup("StartMinutes", Pattern.With.Set(Pattern.With.Literal("0-5")).Set(Pattern.With.Literal("0-9")))).Repeat.Optional
                .Whitespace.Repeat.Optional
                .AtomicGroup(
                    Pattern.With.Literal("P")
                    .NamedGroup("DurationDays", Pattern.With.Digit.Repeat.OneOrMore).Literal("D")).Repeat.Optional;

        public static Pattern PatternYearType =>
            Pattern.With
                .AtomicGroup(
                    Pattern.With.Whitespace.Literal("IN").Whitespace
                    .NamedGroup("YearType",
                        Pattern.With.Choice(Pattern.With.Literal("EVEN"), Pattern.With.Literal("ODD"), Pattern.With.Literal("LEAP"), Pattern.With.Literal("NONLEAP")))
                    .Whitespace.Literal("YEARS")).Repeat.Optional;

        public static Pattern PatternYearRecurs =>
            Pattern.With
                .AtomicGroup(
                    Pattern.With.Whitespace.Literal("EVERY").Whitespace
                    .NamedGroup("RepeatYear", Pattern.With.Digit)
                    .Whitespace.Literal("YEARS").Whitespace.Literal("SINCE").Whitespace
                    .NamedGroup("RepeatStartYear", Pattern.With.Set(Pattern.With.Literal("0-9")).Repeat.Exactly(4))).Repeat.Optional;

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

        public static Pattern PatternNumber =>
            Pattern.With.Choice(
                Pattern.With.Literal("FIRST"), Pattern.With.Literal("SECOND"), Pattern.With.Literal("THIRD"),
                Pattern.With.Literal("FOURTH"), Pattern.With.Literal("FIFTH"), Pattern.With.Literal("SIXTH"));

        public static Pattern PatternDay =>
            Pattern.With.Choice(
                Pattern.With.Literal("MONDAY"), Pattern.With.Literal("TUESDAY"), Pattern.With.Literal("WEDNESDAY"),
                 Pattern.With.Literal("THURSDAY"), Pattern.With.Literal("FRIDAY"), Pattern.With.Literal("SATURDAY"), Pattern.With.Literal("SUNDAY"));

        public static Pattern PatternActionBeforeAfter =>
            Pattern.With.Choice(Pattern.With.Literal("BEFORE"), Pattern.With.Literal("AFTER"));

        public static Pattern PatternActionNextPrevious =>
            Pattern.With.Choice(Pattern.With.Literal("NEXT"), Pattern.With.Literal("PREVIOUS"));
    }
}
