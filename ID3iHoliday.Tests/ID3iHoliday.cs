using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using iD3iCore;
using iD3iHoliday.Core.Models;
using iD3iHoliday.Core.Parsers;
using iD3iHoliday.Models;
using iD3iHoliday.Syntax.Parsers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace iD3iHoliday.Tests
{
    [TestClass]
    public class iD3iHoliday
    {
        [TestMethod, TestCategory( "Ok" ), TestCategory( "iD3iHoliday.WebService.Client" )]
        public void Countries()
        {
            var client = new WebService.Client.HolidayWrapper();
            var result = client.Countries();
            Assert.AreEqual( true, result.IsRight );
        }

        [TestMethod, TestCategory( "Ok" ), TestCategory( "iD3iHoliday.WebService.Client" )]
        public void Country()
        {
            var client = new WebService.Client.HolidayWrapper();
            var result = client.Country( "DE" );
            Assert.AreEqual( true, result.IsRight );
        }

        [TestMethod, TestCategory( "Ok" ), TestCategory( "iD3iHoliday.WebService.Client" )]
        public void CountryDays()
        {
            var client = new WebService.Client.HolidayWrapper();
            var result = client.CountryDays( "DE", 2018, "All", "All" );
            Assert.AreEqual( true, result.IsRight );
        }

        [TestMethod, TestCategory( "Ok" ), TestCategory( "iD3iHoliday.WebService.Client" )]
        public void States()
        {
            var client = new WebService.Client.HolidayWrapper();
            var result = client.States( "DE" );
            Assert.AreEqual( true, result.IsRight );
        }

        [TestMethod, TestCategory( "Ok" ), TestCategory( "iD3iHoliday.WebService.Client" )]
        public void State()
        {
            var client = new WebService.Client.HolidayWrapper();
            var result = client.State( "DE-BY" );
            Assert.AreEqual( true, result.IsRight );
        }

        [TestMethod, TestCategory( "Ok" ), TestCategory( "iD3iHoliday.WebService.Client" )]
        public void Regions()
        {
            var client = new WebService.Client.HolidayWrapper();
            var result = client.Regions( "DE-BY" );
            Assert.AreEqual( true, result.IsRight );
        }

        [TestMethod, TestCategory( "Ok" ), TestCategory( "iD3iHoliday.WebService.Client" )]
        public void StateDays()
        {
            var client = new WebService.Client.HolidayWrapper();
            var result = client.StateDays( "DE-BY", 2018, "All", "All" );
            Assert.AreEqual( true, result.IsRight );
        }

        [TestMethod, TestCategory( "Ok" ), TestCategory( "iD3iHoliday.WebService.Client" )]
        public void Region()
        {
            var client = new WebService.Client.HolidayWrapper();
            var result = client.Region( "DE-BY-A" );
            Assert.AreEqual( true, result.IsRight );
        }

        [TestMethod, TestCategory( "Ok" ), TestCategory( "iD3iHoliday.WebService.Client" )]
        public void RegionDays()
        {
            var client = new WebService.Client.HolidayWrapper();
            var result = client.RegionDays( "DE-BY-A", 2018, "All", "All" );
            Assert.AreEqual( true, result.IsRight );
        }

        [TestMethod, TestCategory( "Ok" ), TestCategory( "iD3iHoliday.WebService.Client" )]
        public void Days()
        {
            var client = new WebService.Client.HolidayWrapper();
            var result = client.Days( 2018, "DE", "DE-BY", "DE-BY-A", "All", "All" );
            Assert.AreEqual( true, result.IsRight );
        }

        [TestMethod, TestCategory( "Ok" ), TestCategory( "iD3iHoliday.WebService.Client" )]
        public void LongWeekEnds()
        {
            var client = new WebService.Client.HolidayWrapper();
            var result = client.LongWeekEnds( 2018, "DE", "DE-BY", "DE-BY-A", "All", "All" );
            Assert.AreEqual( true, result.IsRight );
        }

        [TestMethod, TestCategory( "Ok" ), TestCategory( "iD3iHoliday.WebService.Client" )]
        public void Rules()
        {
            var client = new WebService.Client.HolidayWrapper();
            var result = client.Rules;
            Assert.AreEqual( true, result.IsRight );
        }

        [TestMethod, TestCategory( "Ok" ), TestCategory( "iD3iHoliday.WebService.Client" )]
        public void CountryRule()
        {
            var client = new WebService.Client.HolidayWrapper();
            var result = client.CountryRules( "DE" );
            Assert.AreEqual( true, result.IsRight );
        }

        [TestMethod, TestCategory( "Ok" ), TestCategory( "iD3iHoliday.Engine.Standard" )]
        public void CheckAllRulesForAll()
        {
            var year = DateTime.Today.Year;
            Engine.Standard.HolidaySystem.Instance.CountriesAvailable.Where( x => x.Code != null ).ForEach( x =>
            {
                Debug.WriteLine( x.DefaultName );
                x.Rules.ForEach( y =>
                {
                    Debug.WriteLine( $"\t{y.Expression.IsMatch}\t{y.Expression.Expression}\t{string.Join( ", ", y.Expression.Parse( year ).DatesToAdd.Select( ab => ab.ToString() ) )}" );
                    Assert.AreEqual( true, y.Expression.IsMatch, y.Expression.Expression );
                } );
                x.States?.ForEach( y =>
                {
                    Debug.WriteLine( $"\t\t{y.DefaultName}" );
                    y.Rules.ForEach( z =>
                    {
                        if ( z.Expression != null && !string.IsNullOrEmpty( z.Expression.Expression ) )
                        {
                            Debug.WriteLine( $"\t\t\t{z.Expression.IsMatch}\t{z.Expression.Expression}\t{string.Join( ", ", z.Expression.Parse( year ).DatesToAdd.Select( ab => ab.ToString() ) )}" );
                            Assert.AreEqual( true, z.Expression.IsMatch, z.Expression.Expression );
                            Assert.IsTrue( y.Langues != null );
                        }
                    } );
                    y.Regions?.ForEach( z =>
                    {
                        Debug.WriteLine( $"\t\t\t{z.DefaultName}" );
                        z.Rules.ForEach( aa =>
                        {
                            if ( aa.Expression != null && !string.IsNullOrEmpty( aa.Expression.Expression ) )
                            {
                                Debug.WriteLine( $"\t\t\t\t{aa.Expression.IsMatch}\t{aa.Expression.Expression}\t{string.Join( ", ", aa.Expression.Parse( year ).DatesToAdd.Select( ab => ab.ToString() ) )}" );
                                Assert.AreEqual( true, aa.Expression.IsMatch, aa.Expression.Expression );
                                Assert.IsTrue( z.Langues != null );
                            }
                        } );
                    } );
                } );
            } );
        }

        [TestMethod, TestCategory( "Ok" ), TestCategory( "iD3iHoliday.Engine.Standard" )]
        public void GetAllRulesForAll()
        {
            void ShowRule( ExpressionElement expression, Dictionary<Langue, string> names, RuleType type, string tab = "\t" )
            {
                Debug.WriteLine( $"{tab}{expression.Expression}\t({type.ToString()})\t{string.Join( " | ", names.Select( x => $"{x.Key.Description()} : {x.Value}" ) )}" );
            }
            void ShowStateRule( Country country, Rule rule, RuleType ruleType, string tab = "\t\t\t" )
            {
                ExpressionElement expression = null;
                Dictionary<Langue, string> names = null;
                var type = RuleType.All;
                if ( string.IsNullOrEmpty( rule.Key ) )
                {
                    expression = rule.Expression;
                    names = rule.Names;
                    type = rule.Type;
                }
                else
                {
                    expression = ( rule.Overrides & Overrides.Expression ) != 0 || !country.Rules.Any( x => x.Key == rule.Key ) ? rule.Expression : country.Rules.FirstOrDefault( x => x.Key == rule.Key )?.Expression;
                    names = ( rule.Overrides & Overrides.Name ) != 0 || !country.Rules.Any( x => x.Key == rule.Key ) ? rule.Names : country.Rules.FirstOrDefault( x => x.Key == rule.Key )?.Names;
                    type = ( rule.Overrides & Overrides.Type ) != 0 || !country.Rules.Any( x => x.Key == rule.Key ) ? ruleType : country.Rules.FirstOrDefault( x => x.Key == rule.Key )?.Type ?? RuleType.All;
                }

                if ( rule.Overrides == Overrides.None )
                {
                    ShowRule( rule.Expression, rule.Names, type, tab );
                }
                else
                {
                    ShowRule( expression, names, type, tab );
                }
            }
            void ShowRegionRule( Country country, State state, Rule rule, string tab = "\t\t\t\t" )
            {
                if ( rule.Overrides == Overrides.None )
                {
                    ShowRule( rule.Expression, rule.Names, rule.Type, tab );
                }
                else if ( ( rule.Overrides & Overrides.Expression ) != 0 )
                {
                    ShowStateRule( country, rule, rule.Type, tab );
                }
                else
                {
                    ShowStateRule( country, state.Rules.FirstOrDefault( x => x.Key == rule.Key ), rule.Type, tab );
                }
            }

            Engine.Standard.HolidaySystem.Instance.CountriesAvailable.Where( x => x.Code != null ).ForEach( x =>
            {
                Debug.WriteLine( x.DefaultName );
                x.Rules.ForEach( y => ShowRule( y.Expression, y.Names, y.Type ) );
                x.States?.ForEach( y =>
                {
                    Debug.WriteLine( $"\t\t{y.DefaultName}" );
                    y.Rules.ForEach( z => ShowStateRule( x, z, z.Type ) );
                    y.Regions?.ForEach( z =>
                    {
                        Debug.WriteLine( $"\t\t\t{z.DefaultName}" );
                        z.Rules.ForEach( aa => ShowRegionRule( x, y, aa ) );
                    } );
                } );
            } );
        }

        [TestMethod, TestCategory( "Ok" ), TestCategory( "iD3iHoliday.Engine.Standard" )]
        public void ParserDate()
        {
            string str = "DATE MOVABLE² FIRST MONDAY AFTER FIRST SATURDAY AFTER 08-01";
            ParserBase parser = new ParserDate();
            Assert.AreEqual( false, parser.IsMatch( str ) );
        }

        [TestMethod, TestCategory( "Ok" ), TestCategory( "iD3iHoliday.Engine.Standard" )]
        public void ParserEaster()
        {
            string str = "DATE MOVABLE² FIRST MONDAY AFTER FIRST SATURDAY AFTER 08-01";
            ParserBase parser = new ParserEaster();
            Assert.AreEqual( false, parser.IsMatch( str ) );
        }

        [TestMethod, TestCategory( "Ok" ), TestCategory( "iD3iHoliday.Engine.Standard" )]
        public void ParserMovable()
        {
            string str = "DATE MOVABLE² FIRST MONDAY AFTER FIRST SATURDAY AFTER 08-01";
            ParserBase parser = new ParserMovable();
            Assert.AreEqual( false, parser.IsMatch( str ) );
        }

        [TestMethod, TestCategory( "Ok" ), TestCategory( "iD3iHoliday.Engine.Standard" )]
        public void ParserMovableFromMovable()
        {
            string str = "DATE MOVABLE² FIRST MONDAY AFTER FIRST SATURDAY AFTER 08-01";
            ParserBase parser = new ParserMovableFromMovable();
            Assert.AreEqual( true, parser.IsMatch( str ) );
            var result = parser.Parse( str, 2018 );
        }

        [TestMethod, TestCategory( "Ok" ), TestCategory( "iD3iHoliday.Engine.Standard" )]
        public void ParserMove()
        {
            string str = "DATE MOVABLE² FIRST MONDAY AFTER FIRST SATURDAY AFTER 08-01";
            ParserBase parser = new ParserMove();
            Assert.AreEqual( false, parser.IsMatch( str ) );
        }

        [TestMethod, TestCategory( "Ok" ), TestCategory( "iD3iHoliday.Engine.Standard" )]
        public void ParserObserve()
        {
            string str = "DATE MOVABLE² FIRST MONDAY AFTER FIRST SATURDAY AFTER 08-01";
            ParserBase parser = new ParserObserve();
            Assert.AreEqual( false, parser.IsMatch( str ) );
        }

        [TestMethod, TestCategory( "Ok" ), TestCategory( "iD3iHoliday.Engine.Standard" )]
        public void ParserSubstitute()
        {
            string str = "DATE MOVABLE² FIRST MONDAY AFTER FIRST SATURDAY AFTER 08-01";
            ParserBase parser = new ParserSubstitute();
            Assert.AreEqual( false, parser.IsMatch( str ) );
        }
    }
}
