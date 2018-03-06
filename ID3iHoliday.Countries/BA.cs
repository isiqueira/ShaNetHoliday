using ID3iHoliday.Syntax;
using ID3iCore;
using ID3iDate;
using ID3iHoliday.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static System.DayOfWeek;
using static ID3iHoliday.Models.Calendar;

namespace ID3iHoliday.Countries
{
    /// <summary>
    /// Définition pour Bosnia and Herzegovina.
    /// </summary>
    public class BA : Country
    {
        /// <summary>
        /// Initialise une nouvelle instance pour la classe <see cref="BA"/>.
        /// </summary>
        public BA()
        {
            Code = "BA";
            Alpha3Code = "BIH";
            Names = NamesBuilder.Make.Add(Langue.EN, "Bosnia and Herzegovina").Add(Langue.BS, "Bosna i Hercegovina").Add(Langue.SR, "Боснa и Херцеговина").Add(Langue.HR, "Bosna i Hercegovina").AsDictionary();
            DaysOff.Add(Sunday);
            Langues = new List<Langue>() { Langue.BS, Langue.HR, Langue.SR };
            SupportedCalendar = new List<Calendar>() { Gregorian, Julian, Hijri };
            Rules = new ListRule()
            {
                new HijriRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.Muharram.The1st).Over.Hijri(),
                    Names = NamesBuilder.Make.Add(Langue.BS, "Nova hidžretska godina").AsDictionary()
                },
                new HijriRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.RabiAlAwwal.The12th).Over.Hijri(),
                    Names = NamesBuilder.Make.Add(Langue.BS, "Mevlud").AsDictionary()
                },
                new HijriRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.DhuAlHijjah.The10th).StartAtMidnight.Duration.P4D().Over.Hijri(),
                    Names = NamesBuilder.Make.Add(Langue.BS, "Kurbanski bajram").AsDictionary()
                },
                new HijriRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.Shawwal.The1st).StartAtMidnight.Duration.P3D().Over.Hijri(),
                    Names = NamesBuilder.Make.Add(Langue.BS, "Ramazanski bajram").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Observe.Fix(On.January.The1st).If(Sunday).Then.Next(Tuesday),
                    Names = NamesBuilder.Make
                                .Add(Langue.BS, "Novogodisnji dan")
                                .Add(Langue.HR, "Nova godina")
                                .Add(Langue.SR, "Нова година").AsDictionary(),
                    Substitute = true
                },
                new JulianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.January.The1st).Over.Julian(),
                    Names = NamesBuilder.Make
                                .Add(Langue.BS, "Pravoslavni novogodišnji dan")
                                .Add(Langue.HR, "Pravoslavna Nova Godina")
                                .Add(Langue.SR, "Православна Нова година").AsDictionary(),
                    Note = "Orthodox"
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Observe.Fix(On.January.The2nd).If(Sunday).Then.Next(Monday),
                    Names = NamesBuilder.Make.Add(Langue.BS, "Drugi dan Nove Godine").AsDictionary(),
                    Substitute = true,
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Observe.Fix(On.May.The1st).If(Sunday).Then.Next(Tuesday),
                    Names = NamesBuilder.Make
                                .Add(Langue.BS, "Radni dan")
                                .Add(Langue.HR, "Praznik rada")
                                .Add(Langue.SR, "Празник рада").AsDictionary(),
                    Substitute = true
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Observe.Fix(On.May.The2nd).If(Sunday).Then.Next(Monday),
                    Names = NamesBuilder.Make.Add(Langue.BS, "Drugi dan Dana rada").AsDictionary(),
                    Substitute = true
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.January.The6th),
                    Names = NamesBuilder.Make.Add(Langue.HR, "Bogojavljenje, Sveta tri kralja").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Catholic.Easter,
                    Names = NamesBuilder.Make
                                .Add(Langue.BS, "Vaskrs")
                                .Add(Langue.HR, "Uskrs")
                                .Add(Langue.SR, "Католички Васкрс").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Catholic.EasterMonday,
                    Names = NamesBuilder.Make
                                .Add(Langue.BS, "Uskrsni ponedjeljak")
                                .Add(Langue.HR, "Drugi dan Uskrsa")
                                .Add(Langue.SR, "Католички Васкрсни понедељак").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Catholic.CorpusChristi,
                    Names = NamesBuilder.Make.Add(Langue.HR, "Tijelovo").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.August.The15th),
                    Names = NamesBuilder.Make.Add(Langue.HR, "Velika Gospa").AsDictionary()
                },
                new JulianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.August.The15th).Over.Julian(),
                    Names = NamesBuilder.Make.Add(Langue.HR, "Velika Gospa").AsDictionary(),
                    Note = "Orthodox"
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.November.The1st),
                    Names = NamesBuilder.Make
                                .Add(Langue.BS, "Dita e të gjithë Shenjtorëve")
                                .Add(Langue.HR, "Svi sveti")
                                .Add(Langue.SR, "Сви Свети").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.November.The2nd),
                    Names = NamesBuilder.Make.Add(Langue.HR, "Dušni dan").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.December.The25th),
                    Names = NamesBuilder.Make
                                .Add(Langue.BS, "Božić")
                                .Add(Langue.HR, "Božić")
                                .Add(Langue.SR, "Католички Божић").AsDictionary()
                },
                new JulianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.December.The25th).Over.Julian(),
                    Names = NamesBuilder.Make
                                .Add(Langue.BS, "Božić")
                                .Add(Langue.HR, "Božić")
                                .Add(Langue.SR, "Католички Божић").AsDictionary(),
                    Note = "Orthodox"
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Fix(On.December.The26th),
                    Names = NamesBuilder.Make.Add(Langue.HR, "Svetog Stjepana").AsDictionary()
                },
                new GregorianRule()
                {
                    Expression = ExpressionTree.Date.Orthodox.Easter,
                    Names = NamesBuilder.Make
                                .Add(Langue.BS, "Pravoslavni Vaskrs")
                                .Add(Langue.HR, "Pravoslavni Uskrs")
                                .Add(Langue.SR, "Васкрс").AsDictionary()
                }
            };
            States = new ListState()
            {
                Langues = Langues,
                Container = { new BA_BIH(), new BA_BRC(), new BA_SRP() }
            }.Initialize(x => x.Init());
        }

        internal class BA_BIH : State
        {
            public BA_BIH()
            {
                Code = "BIH";
                Names = NamesBuilder.Make.Add(Langue.EN, "Federation of Bosnia and Herzegovina").AsDictionary();
                Rules = new ListRule()
                {
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.March.The1st),
                            Names = NamesBuilder.Make
                                .Add(Langue.BS, "Dan nezavisnosti")
                                .Add(Langue.HR, "Dan neovisnosti")
                                .Add(Langue.SR, "Дан независности").AsDictionary()
                    },
                    new GregorianRule()
                    {
                        Key = "NOV25",
                        Expression = ExpressionTree.Date.Fix(On.November.The25th),
                            Names = NamesBuilder.Make.Add(Langue.BS, "Dan državnosti").AsDictionary()
                    }
                };
                Regions = new ListRegion()
                {
                    Langues = Langues,
                    Container = { new BA_BIH_W() }
                }.Initialize(x => x.Init());
            }
            internal class BA_BIH_W : Region
            {
                public BA_BIH_W()
                {
                    Code = "W";
                    Names = NamesBuilder.Make.Add(Langue.EN, "Western Herzegovina").AsDictionary();
                    Rules = new ListRule()
                    {
                        new GregorianRule()
                        {
                            Key = "NOV25",
                            IsEnable = false,
                            Overrides = Overrides.IsEnable
                        }
                    };
                }
            }
        }
        internal class BA_BRC : State
        {
            public BA_BRC()
            {
                Code = "BRC";
                Names = NamesBuilder.Make.Add(Langue.EN, "Brčko District").AsDictionary();
                Rules = new ListRule()
                {
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.March.The8th),
                        Names = NamesBuilder.Make.Add(Langue.EN, "Day of the Establishment of the District").AsDictionary()
                    }
                };
            }
        }
        internal class BA_SRP : State
        {
            public BA_SRP()
            {
                Code = "SRP";
                Names = NamesBuilder.Make.Add(Langue.BS, "Republika Srpska").AsDictionary();
                Rules = new ListRule()
                {
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.January.The9th),
                            Names = NamesBuilder.Make.Add(Langue.BS, "Dan Republike").AsDictionary()
                    },
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.May.The9th),
                            Names = NamesBuilder.Make.Add(Langue.BS, "Dan pobjede").AsDictionary()
                    },
                    new GregorianRule()
                    {
                        Expression = ExpressionTree.Date.Fix(On.November.The21st),
                            Names = NamesBuilder.Make.Add(Langue.BS, "Dan uspostave Opšteg okvirnog sporazuma za mir u Bosni i Hercegovini").AsDictionary()
                    }
                };
            }
        }
    }
}
