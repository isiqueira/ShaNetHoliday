using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using ShaNetCore;
using ShaNetDate;
using ShaNetHoliday.Core.Models;
using ShaNetHoliday.Core.Parsers;
using ShaNetHoliday.Models;
using ShaNetHoliday.Syntax;
using ShaNetHoliday.Syntax.Parsers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace ShaNetHoliday.Tests
{
    [TestClass]
    public class ShaNetHoliday
    {
        [TestMethod, TestCategory( "Ok" ), TestCategory( "ShaNetHoliday.WebService.Client" )]
        public void Countries()
        {
            var client = new WebService.Client.HolidayWrapper();
            var result = client.Countries();
            Assert.AreEqual( true, result.IsRight );
        }

        [TestMethod, TestCategory( "Ok" ), TestCategory( "ShaNetHoliday.WebService.Client" )]
        public void Country()
        {
            var client = new WebService.Client.HolidayWrapper();
            var result = client.Country( "DE" );
            Assert.AreEqual( true, result.IsRight );
        }

        [TestMethod, TestCategory( "Ok" ), TestCategory( "ShaNetHoliday.WebService.Client" )]
        public void CountryDays()
        {
            var client = new WebService.Client.HolidayWrapper();
            var result = client.CountryDays( "DE", 2018, "All", "All" );
            Assert.AreEqual( true, result.IsRight );
        }

        [TestMethod, TestCategory( "Ok" ), TestCategory( "ShaNetHoliday.WebService.Client" )]
        public void States()
        {
            var client = new WebService.Client.HolidayWrapper();
            var result = client.States( "DE" );
            Assert.AreEqual( true, result.IsRight );
        }

        [TestMethod, TestCategory( "Ok" ), TestCategory( "ShaNetHoliday.WebService.Client" )]
        public void State()
        {
            var client = new WebService.Client.HolidayWrapper();
            var result = client.State( "DE-BY" );
            Assert.AreEqual( true, result.IsRight );
        }

        [TestMethod, TestCategory( "Ok" ), TestCategory( "ShaNetHoliday.WebService.Client" )]
        public void Regions()
        {
            var client = new WebService.Client.HolidayWrapper();
            var result = client.Regions( "DE-BY" );
            Assert.AreEqual( true, result.IsRight );
        }

        [TestMethod, TestCategory( "Ok" ), TestCategory( "ShaNetHoliday.WebService.Client" )]
        public void StateDays()
        {
            var client = new WebService.Client.HolidayWrapper();
            var result = client.StateDays( "DE-BY", 2018, "All", "All" );
            Assert.AreEqual( true, result.IsRight );
        }

        [TestMethod, TestCategory( "Ok" ), TestCategory( "ShaNetHoliday.WebService.Client" )]
        public void Region()
        {
            var client = new WebService.Client.HolidayWrapper();
            var result = client.Region( "DE-BY-A" );
            Assert.AreEqual( true, result.IsRight );
        }

        [TestMethod, TestCategory( "Ok" ), TestCategory( "ShaNetHoliday.WebService.Client" )]
        public void RegionDays()
        {
            var client = new WebService.Client.HolidayWrapper();
            var result = client.RegionDays( "DE-BY-A", 2018, "All", "All" );
            Assert.AreEqual( true, result.IsRight );
        }

        [TestMethod, TestCategory( "Ok" ), TestCategory( "ShaNetHoliday.WebService.Client" )]
        public void Days()
        {
            var client = new WebService.Client.HolidayWrapper();
            var result = client.Days( 2018, "DE", "DE-BY", "DE-BY-A", "All", "All" );
            Assert.AreEqual( true, result.IsRight );
        }

        [TestMethod, TestCategory( "Ok" ), TestCategory( "ShaNetHoliday.WebService.Client" )]
        public void LongWeekEnds()
        {
            var client = new WebService.Client.HolidayWrapper();
            var result = client.LongWeekEnds( 2018, "DE", "DE-BY", "DE-BY-A", "All", "All" );
            Assert.AreEqual( true, result.IsRight );
        }

        [TestMethod, TestCategory( "Ok" ), TestCategory( "ShaNetHoliday.WebService.Client" )]
        public void Rules()
        {
            var client = new WebService.Client.HolidayWrapper();
            var result = client.Rules;
            Assert.AreEqual( true, result.IsRight );
        }

        [TestMethod, TestCategory( "Ok" ), TestCategory( "ShaNetHoliday.WebService.Client" )]
        public void CountryRule()
        {
            var client = new WebService.Client.HolidayWrapper();
            var result = client.CountryRules( "DE" );
            Assert.AreEqual( true, result.IsRight );
        }

        [TestMethod, TestCategory( "Ok" ), TestCategory( "ShaNetHoliday.Engine.Standard" )]
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

        [TestMethod, TestCategory( "Ok" ), TestCategory( "ShaNetHoliday.Engine.Standard" )]
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

        [TestMethod, TestCategory( "Ok" ), TestCategory( "ShaNetHoliday.Engine.Standard" )]
        public void ParserDate()
        {
            var str = "DATE MOVABLE² FIRST MONDAY AFTER FIRST SATURDAY AFTER 08-01";
            ParserBase parser = new ParserDate();
            Assert.AreEqual( false, parser.IsMatch( str ) );
        }

        [TestMethod, TestCategory( "Ok" ), TestCategory( "ShaNetHoliday.Engine.Standard" )]
        public void ParserEaster()
        {
            var str = "DATE MOVABLE² FIRST MONDAY AFTER FIRST SATURDAY AFTER 08-01";
            ParserBase parser = new ParserEaster();
            Assert.AreEqual( false, parser.IsMatch( str ) );
        }

        [TestMethod, TestCategory( "Ok" ), TestCategory( "ShaNetHoliday.Engine.Standard" )]
        public void ParserMovable()
        {
            var str = "DATE MOVABLE² FIRST MONDAY AFTER FIRST SATURDAY AFTER 08-01";
            ParserBase parser = new ParserMovable();
            Assert.AreEqual( false, parser.IsMatch( str ) );
        }

        [TestMethod, TestCategory( "Ok" ), TestCategory( "ShaNetHoliday.Engine.Standard" )]
        public void ParserMovableFromMovable()
        {
            var str = "DATE MOVABLE² FIRST MONDAY AFTER FIRST SATURDAY AFTER 08-01";
            ParserBase parser = new ParserMovableFromMovable();
            Assert.AreEqual( true, parser.IsMatch( str ) );
            var result = parser.Parse( str, 2018 );
        }

        [TestMethod, TestCategory( "Ok" ), TestCategory( "ShaNetHoliday.Engine.Standard" )]
        public void ParserMove()
        {
            var str = "DATE MOVABLE² FIRST MONDAY AFTER FIRST SATURDAY AFTER 08-01";
            ParserBase parser = new ParserMove();
            Assert.AreEqual( false, parser.IsMatch( str ) );
        }

        [TestMethod, TestCategory( "Ok" ), TestCategory( "ShaNetHoliday.Engine.Standard" )]
        public void ParserObserve()
        {
            var str = "DATE MOVABLE² FIRST MONDAY AFTER FIRST SATURDAY AFTER 08-01";
            ParserBase parser = new ParserObserve();
            Assert.AreEqual( false, parser.IsMatch( str ) );
        }

        [TestMethod, TestCategory( "Ok" ), TestCategory( "ShaNetHoliday.Engine.Standard" )]
        public void ParserSubstitute()
        {
            var str = "DATE MOVABLE² FIRST MONDAY AFTER FIRST SATURDAY AFTER 08-01";
            ParserBase parser = new ParserSubstitute();
            Assert.AreEqual( false, parser.IsMatch( str ) );
        }

        [TestMethod, TestCategory( "Ok" ), TestCategory( "ShaNetHoliday.Try" )]
        public void ChineseLunarToDateTime()
        {
            var currentCycle = 0;
            var currentElement = 0;
            var currentAnimal = 0;
            var month = 0;
            var day = 0;
            var leapCorrection = 0;
            var year = 0;
            DateTime result;

            /*
             * Date précise dans une année en particulier. 
             * Cycle-Element-Animal-Month-Day.
             * 78-2-11-01-01.
             * 
             * L'année qu'on demanderait (par ex 2019) ne servirait pas, vu qu'avec le cycle, l'élément et l'animal elle est calculée.
             * */
            currentCycle = 78;
            currentElement = 2;
            currentAnimal = 11;
            month = 1;
            day = 1;
            leapCorrection =
                currentAnimal.IsEven() ?
                    currentAnimal <= 2 * currentElement ?
                        1
                        : 61
                    : currentAnimal <= ( 2 * currentElement ) + 1 ?
                        7
                        : 67;
            year = ( 12 * currentElement ) - ( 5 * currentAnimal ) + leapCorrection + ( 60 * currentCycle ) - 2757;
            result = new ChineseLunisolarCalendar().ToDateTime( year, month, day, 0, 0, 0, 0 );

            /*
             * Dans précise pour une année souhaitée.
             * Month-Day.
             * 01-01
             * 
             * L'année qu'on demanderait (par ex 2019) servirait à calculer le cycle, l'élément et l'animal.
             * */
            currentCycle = (int)Math.Truncate( (decimal)( DateTime.Today.Year + 2756 ) / 60 );
            currentElement = ( DateTime.Today.Year.IsEven() ? ( ( DateTime.Today.Year + 6 ) % 10 ) : ( ( DateTime.Today.Year + 6 ) % 10 ) - 1 ) / 2;
            currentAnimal = ( DateTime.Today.Year + 8 ) % 12;
            month = 1;
            day = 1;
            leapCorrection =
                currentAnimal.IsEven() ?
                    currentAnimal <= 2 * currentElement ?
                        1
                        : 61
                    : currentAnimal <= ( 2 * currentElement ) + 1 ?
                        7
                        : 67;
            year = ( 12 * currentElement ) - ( 5 * currentAnimal ) + leapCorrection + ( 60 * currentCycle ) - 2757;
            result = new ChineseLunisolarCalendar().ToDateTime( year, month, day, 0, 0, 0, 0 );
        }

        [TestMethod, TestCategory( "Ok" ), TestCategory( "ShaNetHoliday.Try" )]
        public void ChineseSolarTermToDateTime()
        {
            for ( var i = 285; i < 360; i += 15 )
            {
                Debug.WriteLine( OnSolarTerm.The( i ).ToDateTime( 2018 ).ToString( "dd MM yyyy - HH:00:00" ) );
            }
            for ( var i = 0; i < 285; i += 15 )
            {
                Debug.WriteLine( OnSolarTerm.The( i ).ToDateTime( 2018 ).ToString( "dd MM yyyy - HH:00:00" ) );
            }
        }

        /// <summary>
        /// 2000-2099 values from https://www.timeanddate.com/holidays/china/qing-ming-jie
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<object[]> QingMingData()
        {
            yield return new object[] { 2000, 4 };
            yield return new object[] { 2001, 5 };
            yield return new object[] { 2002, 5 };
            yield return new object[] { 2003, 5 };
            yield return new object[] { 2004, 4 };
            yield return new object[] { 2005, 5 };
            yield return new object[] { 2006, 5 };
            yield return new object[] { 2007, 5 };
            yield return new object[] { 2008, 4 };
            yield return new object[] { 2009, 5 };
            yield return new object[] { 2010, 5 };
            yield return new object[] { 2011, 5 };
            yield return new object[] { 2012, 4 };
            yield return new object[] { 2013, 4 };
            yield return new object[] { 2014, 5 };
            yield return new object[] { 2015, 5 };
            yield return new object[] { 2016, 4 };
            yield return new object[] { 2017, 4 };
            yield return new object[] { 2018, 5 };
            yield return new object[] { 2019, 5 };
            yield return new object[] { 2020, 4 };
            yield return new object[] { 2021, 5 };
            yield return new object[] { 2022, 5 };
            yield return new object[] { 2023, 5 };
            yield return new object[] { 2024, 4 };
            yield return new object[] { 2025, 5 };
            yield return new object[] { 2026, 5 };
            yield return new object[] { 2027, 5 };
            yield return new object[] { 2028, 4 };
            yield return new object[] { 2029, 5 };
            yield return new object[] { 2030, 5 };
            yield return new object[] { 2031, 5 };
            yield return new object[] { 2032, 4 };
            yield return new object[] { 2033, 5 };
            yield return new object[] { 2034, 5 };
            yield return new object[] { 2035, 5 };
            yield return new object[] { 2036, 4 };
            yield return new object[] { 2037, 5 };
            yield return new object[] { 2038, 5 };
            yield return new object[] { 2039, 5 };
            yield return new object[] { 2040, 4 };
            yield return new object[] { 2041, 5 };
            yield return new object[] { 2042, 5 };
            yield return new object[] { 2043, 5 };
            yield return new object[] { 2044, 4 };
            yield return new object[] { 2045, 5 };
            yield return new object[] { 2046, 5 };
            yield return new object[] { 2047, 5 };
            yield return new object[] { 2048, 4 };
            yield return new object[] { 2049, 5 };
            yield return new object[] { 2050, 5 };
            yield return new object[] { 2051, 5 };
            yield return new object[] { 2052, 4 };
            yield return new object[] { 2053, 5 };
            yield return new object[] { 2054, 5 };
            yield return new object[] { 2055, 5 };
            yield return new object[] { 2056, 4 };
            yield return new object[] { 2057, 5 };
            yield return new object[] { 2058, 5 };
            yield return new object[] { 2059, 5 };
            yield return new object[] { 2060, 4 };
            yield return new object[] { 2061, 5 };
            yield return new object[] { 2062, 5 };
            yield return new object[] { 2063, 5 };
            yield return new object[] { 2064, 4 };
            yield return new object[] { 2065, 5 };
            yield return new object[] { 2066, 5 };
            yield return new object[] { 2067, 5 };
            yield return new object[] { 2068, 4 };
            yield return new object[] { 2069, 5 };
            yield return new object[] { 2070, 5 };
            yield return new object[] { 2071, 5 };
            yield return new object[] { 2072, 4 };
            yield return new object[] { 2073, 5 };
            yield return new object[] { 2074, 5 };
            yield return new object[] { 2075, 5 };
            yield return new object[] { 2076, 4 };
            yield return new object[] { 2077, 5 };
            yield return new object[] { 2078, 5 };
            yield return new object[] { 2079, 5 };
            yield return new object[] { 2080, 4 };
            yield return new object[] { 2081, 5 };
            yield return new object[] { 2082, 5 };
            yield return new object[] { 2083, 5 };
            yield return new object[] { 2084, 4 };
            yield return new object[] { 2085, 5 };
            yield return new object[] { 2086, 5 };
            yield return new object[] { 2087, 5 };
            yield return new object[] { 2088, 4 };
            yield return new object[] { 2089, 5 };
            yield return new object[] { 2090, 5 };
            yield return new object[] { 2091, 5 };
            yield return new object[] { 2092, 4 };
            yield return new object[] { 2093, 5 };
            yield return new object[] { 2094, 5 };
            yield return new object[] { 2095, 5 };
            yield return new object[] { 2096, 4 };
            yield return new object[] { 2097, 5 };
            yield return new object[] { 2098, 5 };
            yield return new object[] { 2099, 5 };
        }

        [DynamicData( nameof( QingMingData ), DynamicDataSourceType.Method )]
        [DataTestMethod, TestCategory( "Ok" ), TestCategory( "ShaNetHoliday.Try" )]
        public void ChineseQingMing( int year, int day )
        {
            var calculatedDay = OnSolarTerm.The5th.ToDateTime( year ).Day;
            /*
             * Ok si c'est le même jour,
             * Ok si c'est pas le même jour, mais qu'il y a que 1 jour de décalage.
             * */
            Assert.IsTrue(
                day == calculatedDay
                || ( day != calculatedDay && Math.Abs( day - calculatedDay ) <= 1 )
            );
        }

        [TestMethod, TestCategory( "Ok" ), TestCategory( "ShaNetHoliday.Engine.Standard" )]
        public void ParserChineseLunar()
        {
            var r = ExpressionTree
              .Chinese.LunarDate( "01-0-01" ).OnCycle( 78 ).Of( ChineseElement.Earth ).And( ChineseZodiac.Pig )
              .If( DayOfWeek.Sunday ).Then.Next( DayOfWeek.Tuesday )
              .Or.If( DayOfWeek.Saturday ).Then.Next( DayOfWeek.Monday );

            var result = r.Parse( 2019 );
            Assert.AreEqual( On.February.The8th.Of( 1959 ), result.DatesToAdd.First() );

            r = ExpressionTree
                    .Chinese.LunarDate( "01-0-01" )
                    .If( DayOfWeek.Sunday ).Then.Next( DayOfWeek.Tuesday )
                    .Or.If( DayOfWeek.Saturday ).Then.Next( DayOfWeek.Monday );

            result = r.Parse( 2019 );
            Assert.AreEqual( On.February.The5th.Of( 2019 ), result.DatesToAdd.First() );

            result = r.Parse( 1959 );
            Assert.AreEqual( On.February.The8th.Of( 1959 ), result.DatesToAdd.First() );
        }

        [TestMethod, TestCategory( "Ok" ), TestCategory( "ShaNetHoliday.Engine.Standard" )]
        public void ParserChineseSolar()
        {
            ExpressionElement r = ExpressionTree.Chinese.SolarDate( OnSolarTerm.The5th ).OnCycle( 78 ).Of( ChineseElement.Earth ).And( ChineseZodiac.Pig );
            var result = r.Parse( 2019 );
            Assert.AreEqual( On.April.The4th.Of( 1959 ), result.DatesToAdd.First() );

            r = ExpressionTree.Chinese.SolarDate( OnSolarTerm.The5th );
            result = r.Parse( 2019 );
            Assert.AreEqual( On.April.The5th, result.DatesToAdd.First() );

            result = r.Parse( 1959 );
            Assert.AreEqual( On.April.The4th.Of( 1959 ), result.DatesToAdd.First() );

            r = ExpressionTree.Chinese.SolarDate( OnSolarTerm.The5th ).The( 2 );
            result = r.Parse( 2019 );
            Assert.AreEqual( On.April.The6th, result.DatesToAdd.First() );
        }
    }
}
