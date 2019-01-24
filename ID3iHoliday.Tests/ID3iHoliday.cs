using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using AASharp;
using iD3iCore;
using iD3iDate;
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
            var str = "DATE MOVABLE² FIRST MONDAY AFTER FIRST SATURDAY AFTER 08-01";
            ParserBase parser = new ParserDate();
            Assert.AreEqual( false, parser.IsMatch( str ) );
        }

        [TestMethod, TestCategory( "Ok" ), TestCategory( "iD3iHoliday.Engine.Standard" )]
        public void ParserEaster()
        {
            var str = "DATE MOVABLE² FIRST MONDAY AFTER FIRST SATURDAY AFTER 08-01";
            ParserBase parser = new ParserEaster();
            Assert.AreEqual( false, parser.IsMatch( str ) );
        }

        [TestMethod, TestCategory( "Ok" ), TestCategory( "iD3iHoliday.Engine.Standard" )]
        public void ParserMovable()
        {
            var str = "DATE MOVABLE² FIRST MONDAY AFTER FIRST SATURDAY AFTER 08-01";
            ParserBase parser = new ParserMovable();
            Assert.AreEqual( false, parser.IsMatch( str ) );
        }

        [TestMethod, TestCategory( "Ok" ), TestCategory( "iD3iHoliday.Engine.Standard" )]
        public void ParserMovableFromMovable()
        {
            var str = "DATE MOVABLE² FIRST MONDAY AFTER FIRST SATURDAY AFTER 08-01";
            ParserBase parser = new ParserMovableFromMovable();
            Assert.AreEqual( true, parser.IsMatch( str ) );
            var result = parser.Parse( str, 2018 );
        }

        [TestMethod, TestCategory( "Ok" ), TestCategory( "iD3iHoliday.Engine.Standard" )]
        public void ParserMove()
        {
            var str = "DATE MOVABLE² FIRST MONDAY AFTER FIRST SATURDAY AFTER 08-01";
            ParserBase parser = new ParserMove();
            Assert.AreEqual( false, parser.IsMatch( str ) );
        }

        [TestMethod, TestCategory( "Ok" ), TestCategory( "iD3iHoliday.Engine.Standard" )]
        public void ParserObserve()
        {
            var str = "DATE MOVABLE² FIRST MONDAY AFTER FIRST SATURDAY AFTER 08-01";
            ParserBase parser = new ParserObserve();
            Assert.AreEqual( false, parser.IsMatch( str ) );
        }

        [TestMethod, TestCategory( "Ok" ), TestCategory( "iD3iHoliday.Engine.Standard" )]
        public void ParserSubstitute()
        {
            var str = "DATE MOVABLE² FIRST MONDAY AFTER FIRST SATURDAY AFTER 08-01";
            ParserBase parser = new ParserSubstitute();
            Assert.AreEqual( false, parser.IsMatch( str ) );
        }

        [TestMethod, TestCategory( "Ok" ), TestCategory( "TESTS SUR iD3iHoliday" )]
        public void MyTestMethod()
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

        [DataRow( 2013, 20 )]
        [DataRow( 2014, 21 )]
        [DataRow( 2015, 21 )]
        [DataRow( 2016, 20 )]
        [DataRow( 2017, 20 )]
        [DataRow( 2018, 21 )]
        [DataRow( 2019, 21 )]
        [DataTestMethod, TestCategory( "Ok" ), TestCategory( "TESTS SUR iD3iHoliday" )]
        public void MyTestMethod2( int year, int day )
        {
            var date = new AASharp.AASDate();
            var spring = AASharp.AASEquinoxesAndSolstices.NorthwardEquinox( year, true );
            date.Set( spring, true );
            var dt = new DateTime( (int)date.Year, (int)date.Month, (int)date.Day, (int)date.Hour, (int)date.Minute, (int)date.Second );
            var convertDt = TimeZoneInfo.ConvertTimeFromUtc( dt, TimeZoneInfo.FindSystemTimeZoneById( "China Standard Time" ) );
            Assert.AreEqual( day, convertDt.Day );
        }

        [DataRow( 2013, 23 )]
        [DataRow( 2014, 23 )]
        [DataRow( 2015, 23 )]
        [DataRow( 2016, 22 )]
        [DataRow( 2017, 23 )]
        [DataRow( 2018, 23 )]
        [DataRow( 2019, 23 )]
        [DataTestMethod, TestCategory( "Ok" ), TestCategory( "TESTS SUR iD3iHoliday" )]
        public void MyTestMethod3( int year, int day )
        {
            var date = new AASharp.AASDate();
            var spring = AASharp.AASEquinoxesAndSolstices.SouthwardEquinox( year, true );
            date.Set( spring, true );
            var dt = new DateTime( (int)date.Year, (int)date.Month, (int)date.Day, (int)date.Hour, (int)date.Minute, (int)date.Second );
            var convertDt = TimeZoneInfo.ConvertTimeFromUtc( dt, TimeZoneInfo.FindSystemTimeZoneById( "China Standard Time" ) );
            Assert.AreEqual( day, convertDt.Day );
        }

        [TestMethod]
        public void MyTestMethod4()
        {
            var date = new AASharp.AASDate();
            var spring = AASharp.AASEquinoxesAndSolstices.SouthwardEquinox( 2019, true );
            date.Set( spring, true );
            var dt = new DateTime( (int)date.Year, (int)date.Month, (int)date.Day, (int)date.Hour, (int)date.Minute, (int)date.Second );
            var convertDt = TimeZoneInfo.ConvertTimeFromUtc( dt, TimeZoneInfo.FindSystemTimeZoneById( "China Standard Time" ) );
        }

        [TestMethod]
        public void MyTestMethod5()
        {
            var date = new AASharp.AASDate();
            var spring = AASharp.AASEquinoxesAndSolstices.NorthwardEquinox( 2019, true );
            date.Set( spring, true );
            var dt = new DateTime( (int)date.Year, (int)date.Month, (int)date.Day, (int)date.Hour, (int)date.Minute, (int)date.Second );
            var convertDt = TimeZoneInfo.ConvertTimeFromUtc( dt, TimeZoneInfo.FindSystemTimeZoneById( "China Standard Time" ) );
        }

        [TestMethod]
        public void MyTestMethod6()
        {
            var date = new AASharp.AASDate();
            var spring = AASharp.AASEquinoxesAndSolstices.NorthernSolstice( 2019, true );
            date.Set( spring, true );
            var dt = new DateTime( (int)date.Year, (int)date.Month, (int)date.Day, (int)date.Hour, (int)date.Minute, (int)date.Second );
            var convertDt = TimeZoneInfo.ConvertTimeFromUtc( dt, TimeZoneInfo.FindSystemTimeZoneById( "China Standard Time" ) );
        }

        [TestMethod]
        public void MyTestMethod7()
        {
            var date = new AASharp.AASDate();
            var spring = AASharp.AASEquinoxesAndSolstices.SouthernSolstice( 2019, true );
            var hop = AASharp.AASSun.ApparentEclipticLongitude( spring, true );
            date.Set( spring, true );
            var dt = new DateTime( (int)date.Year, (int)date.Month, (int)date.Day, (int)date.Hour, (int)date.Minute, (int)date.Second );
            var convertDt = TimeZoneInfo.ConvertTimeFromUtc( dt, TimeZoneInfo.FindSystemTimeZoneById( "China Standard Time" ) );

            var test = AASharp.AASPhysicalSun.TimeOfStartOfRotation( 2019 );
            date.Set( test, false );
            var test2 = AASharp.AASPhysicalSun.Calculate( AASharp.AASPhysicalSun.TimeOfStartOfRotation( 2019 ), true );
        }

        //[DataRow( 2007, 5 )]
        //[DataRow( 2008, 4 )]
        //[DataRow( 2009, 4 )]
        //[DataRow( 2010, 5 )]
        //[DataRow( 2011, 5 )]
        //[DataRow( 2012, 4 )]
        //[DataRow( 2013, 4 )]
        //[DataRow( 2014, 5 )]
        //[DataRow( 2015, 5 )]
        //[DataRow( 2016, 4 )]
        //[DataRow( 2017, 4 )]
        //[DataRow( 2018, 5 )]
        [DataRow( 2019, 5 )]
        [DataTestMethod, TestCategory( "Ok" ), TestCategory( "TESTS SUR iD3iHoliday" )]
        public void QingMing( int year, int day )
        {
            var date = new AASharp.AASDate();
            //var spring = AASharp.AASEquinoxesAndSolstices.NorthwardEquinox( year, true );
            var spring = AASharp.AASEquinoxesAndSolstices.NorthwardEquinox( year, true );
            date.Set( spring, true );

            var SunLong = AASSun.GeometricEclipticLongitude( date.Julian, true );
            var SunLat = AASSun.GeometricEclipticLatitude( date.Julian, true );

            double SunLongCorrection = AASFK5.CorrectionInLongitude( SunLong, SunLat, 2448908.5 );
            double SunLatCorrection = AASFK5.CorrectionInLatitude( SunLong, 2448908.5 );

            var tmpJDSun = date.Julian + AASDynamicalTime.DeltaT( date.Julian ) / 86400.0;
            double tmpSunLong = AASSun.ApparentEclipticLongitude( tmpJDSun, false );
            double tmpSunLat = AASSun.ApparentEclipticLatitude( tmpJDSun, false );
            var a = AASNutation.TrueObliquityOfEcliptic( tmpJDSun );

            var dt = new DateTime( (int)date.Year, (int)date.Month, (int)date.Day, (int)date.Hour, (int)date.Minute, (int)date.Second );
            var convertDt = TimeZoneInfo.ConvertTimeFromUtc( dt, TimeZoneInfo.FindSystemTimeZoneById( "China Standard Time" ) );

            convertDt = convertDt + 105.Days();

            //Assert.AreEqual( day, convertDt.Day );

            AASDate dateSunCalc = new AASDate( AASEquinoxesAndSolstices.NorthwardEquinox( year, true ), true );
            double JDSun = dateSunCalc.Julian + AASDynamicalTime.DeltaT( dateSunCalc.Julian ) / 86400.0;
            SunLong = AASSun.ApparentEclipticLongitude( JDSun, false );
            SunLat = AASSun.ApparentEclipticLatitude( JDSun, false );
            AAS2DCoordinate Equatorial = AASCoordinateTransformation.Ecliptic2Equatorial( SunLong, SunLat, AASNutation.TrueObliquityOfEcliptic( JDSun ) );
            double SunRad = AASEarth.RadiusVector( JDSun, false );
            double Longitude = AASCoordinateTransformation.DMSToDegrees( 116, 51, 45 ); //West is considered positive
            double Latitude = AASCoordinateTransformation.DMSToDegrees( 33, 21, 22 );
            double Height = 1706;
            AAS2DCoordinate SunTopo = AASParallax.Equatorial2Topocentric( Equatorial.X, Equatorial.Y, SunRad, Longitude, Latitude, Height, JDSun );
            double AST = AASSidereal.ApparentGreenwichSiderealTime( dateSunCalc.Julian );
            double LongtitudeAsHourAngle = AASCoordinateTransformation.DegreesToHours( Longitude );
            double LocalHourAngle = AST - LongtitudeAsHourAngle - SunTopo.X;
            AAS2DCoordinate SunHorizontal = AASCoordinateTransformation.Equatorial2Horizontal( LocalHourAngle, SunTopo.Y, Latitude );
            SunHorizontal.Y += AASRefraction.RefractionFromTrue( SunHorizontal.Y, 1013, 10 );


            date = new AASharp.AASDate();
            spring = AASharp.AASEquinoxesAndSolstices.NorthwardEquinox( year, true );
            date.Set( spring, true );
            var ast = AASSidereal.ApparentGreenwichSiderealTime( date.Julian );
            LongtitudeAsHourAngle = AASCoordinateTransformation.DegreesToHours( AASCoordinateTransformation.DMSToDegrees( 116, 21, 49 ) );
            double Alpha = AASCoordinateTransformation.DMSToDegrees( 116, 21, 49 );
            LocalHourAngle = AST - LongtitudeAsHourAngle - Alpha;
            AAS2DCoordinate Horizontal = AASCoordinateTransformation.Equatorial2Horizontal( LocalHourAngle, AASCoordinateTransformation.DMSToDegrees( 6, 43, 11.61, false ), AASCoordinateTransformation.DMSToDegrees( 38, 55, 17 ) );
            AAS2DCoordinate Equatorial3 = AASCoordinateTransformation.Horizontal2Equatorial( Horizontal.X, Horizontal.Y, AASCoordinateTransformation.DMSToDegrees( 38, 55, 17 ) );
            double alpha2 = AASCoordinateTransformation.MapTo0To24Range( AST - Equatorial3.X - LongtitudeAsHourAngle );

            var t1 = AASEarth.EclipticLatitudeJ2000( AASEquinoxesAndSolstices.NorthwardEquinox( year, true ), true );
            var t2 = AASEarth.EclipticLongitudeJ2000( AASEquinoxesAndSolstices.NorthwardEquinox( year, true ), true );

            var g = AASEquationOfTime.Calculate( AASEquinoxesAndSolstices.NorthwardEquinox( year, true ), true );
        }

        public double date2jd( double Day, double Month, double Year )
        {
            // Written By Eran O. Ofek (All right reserved)
            //December 1998 
            double A;
            double B;
            double DayFrac;
            double JD;
            double DayOfWeek;


            DayFrac = Day - Math.Floor( Day );
            Day = Math.Floor( Day );
            A = 0;
            B = 0;
            if ( Month < 3 )
            {
                if ( Month == 1 )
                {
                    Month = 13;
                }
                else
                {
                    Month = 14;
                }
                Year = Year - 1;
            }
            if ( ( Year > 1582 ) || ( ( Year == 1582 ) && ( Month > 10 ) ) || ( ( Year == 1582 ) && ( Month == 10 ) && ( Day >= 15 ) ) )
            {
                A = Math.Floor( Year / 100 );
                B = 2 - A + Math.Floor( A / 4 );
            }
            JD = Math.Floor( 365.25f * Year + 365.25f * 4716.0f ) + Math.Floor( 30.6001f * Month + 30.6001f ) + Day + B - 1524.5f + DayFrac;


            //calculate day of week
            DayOfWeek = ( JD - 0.5f ) % 7 + 3;
            if ( DayOfWeek > 7 )
            {
                DayOfWeek = DayOfWeek - 7;
            }
            return JD;
        }
        public DateTime jd2date( double JD )
        {

            double Z;
            double F;
            double Alpha;
            double A;
            double B;
            double C;
            double D;
            double E;
            double YearVal;
            double MonthVal;
            double DayVal;
            double HourVal;


            Z = Math.Floor( JD + 0.5f );
            F = JD + 0.5f - Z;

            if ( Z < 2299161 )
            {
                A = Z;
            }
            else
            {
                Alpha = Math.Floor( ( Z - 1867216.25f ) / 36524.25f );
                A = Z + 1 + Alpha - Math.Floor( 0.25f * Alpha );
            }

            B = A + 1524;
            C = Math.Floor( ( B - 122.1f ) / 365.25f );
            D = Math.Floor( 365.25f * C );
            E = Math.Floor( ( B - D ) / 30.6001f );

            DayVal = B - D - Math.Floor( 30.6001f * E );

            if ( E < 14 )
            {
                MonthVal = E - 1;
            }
            else
            {
                MonthVal = E - 13;
            }

            if ( MonthVal > 2 )
            {
                YearVal = C - 4716;
            }
            else
            {
                YearVal = C - 4715;
            }

            HourVal = Math.Round( F * 24 );
            if ( HourVal == 24 )
            {
                HourVal = 0;
                //DayVal++;
            }
            //document.FindJD.YearText.value = YearVal;
            //document.FindJD.MonthText.value = MonthVal;
            //document.FindJD.DayText.value = DayVal;
            //document.FindJD.HourText.value = HourVal;
            Debug.WriteLine( new DateTime( (int)YearVal, (int)MonthVal, (int)DayVal, (int)HourVal, 0, 0 ).ToString( "dd MM yyyy" ) );

            return new DateTime( (int)YearVal, (int)MonthVal, (int)DayVal, (int)HourVal, 0, 0 );

        }

        public DateTime sollon2jd( double Long, double Month, double Year )
        {
            // Written By Eran O. Ofek (All right reserved)
            //August 2000

            double N;
            double JDM0;
            double Dt;
            double RAD;
            double ApproxJD;
            double JD1;
            double JD;
            double DiffJD;

            RAD = 57.29577951308232f;

            Long = Long / RAD;

            N = Year - 2000;

            //if ( Math.abs( N ) > 100 )
            //{
            //    alert( "Algorithm is not stable for years below 1900 or above 2100" );
            //}


            JDM0 = 2451182.24736f + 365.25963575f * N;

            // calc approximate JD
            ApproxJD = date2jd( (double)4, Month, Year );


            DiffJD = ApproxJD - 2451545;

            Dt = 1.94330f * Math.Sin( Long - 1.798135f ) + 0.01305272f * Math.Sin( 2 * Long + 2.634232f ) + 78.195268f + 58.13165f * Long - 0.0000089408f * DiffJD;



            if ( Math.Abs( ApproxJD - ( JDM0 - Dt ) ) > 50 )
            {
                Dt = Dt + 365.2596f;
            }

            JD1 = JDM0 + Dt;

            var dt = jd2date( JD1 );

            JD = Math.Round( JD1 * 100 );

            //document.FindJD.JD.value = JD / 100

            return dt;
        }

        [TestMethod]
        public void MyTestMethod10()
        {
            sollon2jd( 285, 12, 2018 );
            sollon2jd( 300, 12, 2018 );
            sollon2jd( 315, 12, 2018 );
            sollon2jd( 330, 12, 2018 );
            sollon2jd( 345, 12, 2018 );
            sollon2jd( 0, 12, 2019 );
            sollon2jd( 15, 12, 2019 );
            sollon2jd( 30, 12, 2019 );
            sollon2jd( 45, 12, 2019 );
            sollon2jd( 60, 12, 2019 );
            sollon2jd( 75, 12, 2019 );
            sollon2jd( 90, 12, 2019 );
            sollon2jd( 105, 12, 2019 );
            sollon2jd( 120, 12, 2019 );
            sollon2jd( 135, 12, 2019 );
            sollon2jd( 150, 12, 2019 );
            sollon2jd( 165, 12, 2019 );
            sollon2jd( 180, 12, 2019 );
            sollon2jd( 195, 12, 2019 );
            sollon2jd( 210, 12, 2019 );
            sollon2jd( 225, 12, 2019 );
            sollon2jd( 240, 12, 2019 );
            sollon2jd( 255, 12, 2019 );
            sollon2jd( 270, 12, 2019 );
        }

        [DataRow( 2000, 4 )]
        [DataRow( 2001, 5 )]
        [DataRow( 2002, 5 )]
        [DataRow( 2003, 5 )]
        [DataRow( 2004, 4 )]
        [DataRow( 2005, 5 )]
        [DataRow( 2006, 5 )]
        [DataRow( 2007, 5 )]
        [DataRow( 2008, 4 )]
        [DataRow( 2009, 5 )]
        [DataRow( 2010, 5 )]
        [DataRow( 2011, 5 )]
        [DataRow( 2012, 4 )]
        [DataRow( 2013, 4 )]
        [DataRow( 2014, 5 )]
        [DataRow( 2015, 5 )]
        [DataRow( 2016, 4 )]
        [DataRow( 2017, 4 )]
        [DataRow( 2018, 5 )]
        [DataRow( 2019, 5 )]
        [DataRow( 2020, 4 )]
        [DataRow( 2021, 5 )]
        [DataRow( 2022, 5 )]
        [DataRow( 2023, 5 )]
        [DataRow( 2024, 4 )]
        [DataRow( 2025, 5 )]
        [DataRow( 2026, 5 )]
        [DataRow( 2027, 5 )]
        [DataRow( 2028, 4 )]
        [DataRow( 2029, 5 )]
        [DataRow( 2030, 5 )]
        [DataRow( 2031, 5 )]
        [DataRow( 2032, 4 )]
        [DataRow( 2033, 5 )]
        [DataRow( 2034, 5 )]
        [DataRow( 2035, 5 )]
        [DataRow( 2036, 4 )]
        [DataRow( 2037, 5 )]
        [DataRow( 2038, 5 )]
        [DataRow( 2039, 5 )]
        [DataRow( 2040, 4 )]
        [DataRow( 2041, 5 )]
        [DataRow( 2042, 5 )]
        [DataRow( 2043, 5 )]
        [DataRow( 2044, 4 )]
        [DataRow( 2045, 5 )]
        [DataRow( 2046, 5 )]
        [DataRow( 2047, 5 )]
        [DataRow( 2048, 4 )]
        [DataRow( 2049, 5 )]
        [DataTestMethod]
        public void hop( int year, int day )
        {
            var result = sollon2jd( 15, 4, year );

            Assert.AreEqual( day, result.Day );
        }

        [TestMethod]
        public void Main()
        {
            var successes = 0;

            var yearRange = Enumerable.Range( 2000, 50 );

            Debug.WriteLine( $"Year | Expect | Calc | Fail" );

            foreach ( var year in yearRange )
            {
                var calculatedDay = 1;

                for ( int day = calculatedDay; day < 30; day++ )
                {
                    var zonelessDateTime = DateTime.SpecifyKind( new DateTime( year, 4, day, 04, 00, 00 ), DateTimeKind.Unspecified );

                    var chinaDateTimeAsUtc = TimeZoneInfo.ConvertTimeToUtc( zonelessDateTime, TimeZoneInfo.FindSystemTimeZoneById( "China Standard Time" ) );
                    var dayDurationStart = chinaDateTimeAsUtc;

                    var dayDurationEnd = dayDurationStart.AddDays( 1 );

                    AASDate dateEndSunCalc = new AASDate( dayDurationEnd.Year, dayDurationEnd.Month, dayDurationEnd.Day, dayDurationEnd.Hour, dayDurationEnd.Minute, dayDurationEnd.Second, true );

                    double JDEndSun = dateEndSunCalc.Julian + AASDynamicalTime.DeltaT( dateEndSunCalc.Julian ) / 86400.0;
                    double SunEndLong = AASSun.ApparentEclipticLongitude( JDEndSun, true );
                    SunEndLong = AASSun.GeometricEclipticLongitudeJ2000( JDEndSun, true );

                    if ( SunEndLong >= 15 )
                    {
                        calculatedDay = day;
                        break;
                    }
                }

                string x = ( TestValues[ year ] != calculatedDay ) ? "X" : " ";

                Debug.WriteLine( $"{year} |      {TestValues[ year ]} | {calculatedDay}    | {x} | {TimeZoneInfo.ConvertTimeToUtc( DateTime.SpecifyKind( new DateTime( year, 4, calculatedDay, 0, 0, 0 ), DateTimeKind.Unspecified ), TimeZoneInfo.FindSystemTimeZoneById( "China Standard Time" ) ).AddDays( 1 )}" );

                //Console.WriteLine($"Apr {calculatedDay}, {year}");
                if ( TestValues[ year ] == calculatedDay )
                    successes++;
            }
            Debug.WriteLine( "" );
            Debug.WriteLine( $"Success rate: {(double)successes / TestValues.Count * 100}%" );
            Assert.AreEqual( 100, (double)successes / TestValues.Count * 100 );
        }

        // 2000-2049 values from https://www.timeanddate.com/holidays/china/qing-ming-jie
        public static Dictionary<int, int> TestValues = new Dictionary<int, int>()
        {
            {2000,4},
            {2001,5},
            {2002,5},
            {2003,5},
            {2004,4},
            {2005,5},
            {2006,5},
            {2007,5},
            {2008,4},
            {2009,5},
            {2010,5},
            {2011,5},
            {2012,4},
            {2013,4},
            {2014,5},
            {2015,5},
            {2016,4},
            {2017,4},
            {2018,5},
            {2019,5},
            {2020,4},
            {2021,5},
            {2022,5},
            {2023,5},
            {2024,4},
            {2025,5},
            {2026,5},
            {2027,5},
            {2028,4},
            {2029,5},
            {2030,5},
            {2031,5},
            {2032,4},
            {2033,5},
            {2034,5},
            {2035,5},
            {2036,4},
            {2037,5},
            {2038,5},
            {2039,5},
            {2040,4},
            {2041,5},
            {2042,5},
            {2043,5},
            {2044,4},
            {2045,5},
            {2046,5},
            {2047,5},
            {2048,4},
            {2049,5},
        };
    }
}
