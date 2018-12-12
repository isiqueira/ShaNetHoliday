using iD3iCore;
using iD3iDate;
using iD3iHoliday.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iD3iHoliday.Engine
{
    /// <summary>
    /// Wrapper de base pour la récupération de données particulières dans l'environnement des jours particuliers.
    /// </summary>
    public partial class HolidaySystem : IHolidaySystem
    {
        /// <summary>
        /// Liste des pays disponible.
        /// </summary>
        public List<Country> CountriesAvailable { get; set; } = new List<Country>();

        /// <summary>
        /// Méthode qui permet d'éxécuter toutes les règles souhaitées pour une année en particulier.
        /// </summary>
        /// <param name="year">Année souhaitée.</param>
        /// <param name="countryCode">Pays.</param>
        /// <param name="type">Type de règle.</param>
        /// <param name="calendar">Type de calendrier des règles.</param>
        /// <returns>Une liste des jours.</returns>
        public IEnumerable<SpecificDay> All( int year, string countryCode, RuleType type = RuleType.All, Calendar calendar = Calendar.All )
            => All( year, countryCode, null, null, type, calendar );

        /// <summary>
        /// Méthode qui permet d'éxécuter toutes les règles souhaitées pour une année en particulier.
        /// </summary>
        /// <param name="year">Année souhaitée.</param>
        /// <param name="countryCode">Pays.</param>
        /// <param name="stateCode">Etat.</param>
        /// <param name="type">Type de règle.</param>
        /// <param name="calendar">Type de calendrier des règles.</param>
        /// <returns>Une liste des jours.</returns>
        public IEnumerable<SpecificDay> All( int year, string countryCode, string stateCode, RuleType type = RuleType.All, Calendar calendar = Calendar.All )
            => All( year, countryCode, stateCode, null, type, calendar );

        /// <summary>
        /// Méthode qui permet d'éxécuter toutes les règles souhaitées pour une année en particulier.
        /// </summary>
        /// <param name="year">Année souhaitée.</param>
        /// <param name="countryCode">Pays.</param>
        /// <param name="stateCode">Etat.</param>
        /// <param name="regionCode">Région.</param>
        /// <param name="type">Type de règle.</param>
        /// <param name="calendar">Type de calendrier des règles.</param>
        /// <returns>Une liste des jours.</returns>
        public IEnumerable<SpecificDay> All( int year, string countryCode, string stateCode, string regionCode, RuleType type = RuleType.All, Calendar calendar = Calendar.All )
            => countryCode.IsNotNullOrEmpty() && stateCode.IsNotNullOrEmpty() && regionCode.IsNotNullOrEmpty()
                ? CountriesAvailable.FirstOrDefault( x => x.Code == countryCode )?.Get( year, stateCode, regionCode, type, calendar )
                : countryCode.IsNotNullOrEmpty() && stateCode.IsNotNullOrEmpty() && regionCode.IsNullOrEmpty()
                    ? CountriesAvailable.FirstOrDefault( x => x.Code == countryCode )?.Get( year, stateCode, type, calendar )
                    : CountriesAvailable.FirstOrDefault( x => x.Code == countryCode )?.Get( year, type, calendar );

        /// <summary>
        /// Méthode qui permet d'éxécuter toutes les règles souhaitées entre une date de début et une date de fin.
        /// </summary>
        /// <param name="startDate">Date de début.</param>
        /// <param name="endDate">Date de fin.</param>
        /// <param name="countryCode">Pays.</param>
        /// <param name="type">Type de règle.</param>
        /// <returns>Une liste des jours.</returns>
        public IEnumerable<SpecificDay> Between( DateTime startDate, DateTime endDate, string countryCode, RuleType type = RuleType.All )
            => Between( startDate, endDate, countryCode, null, null, type );

        /// <summary>
        /// Méthode qui permet d'éxécuter toutes les règles souhaitées entre une date de début et une date de fin.
        /// </summary>
        /// <param name="startDate">Date de début.</param>
        /// <param name="endDate">Date de fin.</param>
        /// <param name="countryCode">Pays.</param>
        /// <param name="stateCode">Etat.</param>
        /// <param name="type">Type de règle.</param>
        /// <returns>Une liste des jours.</returns>
        public IEnumerable<SpecificDay> Between( DateTime startDate, DateTime endDate, string countryCode, string stateCode, RuleType type = RuleType.All )
            => Between( startDate, endDate, countryCode, stateCode, null, type );

        /// <summary>
        /// Méthode qui permet d'éxécuter toutes les règles souhaitées entre une date de début et une date de fin.
        /// </summary>
        /// <param name="startDate">Date de début.</param>
        /// <param name="endDate">Date de fin.</param>
        /// <param name="countryCode">Pays.</param>
        /// <param name="stateCode">Etat.</param>
        /// <param name="regionCode">Région.</param>
        /// <param name="type">Type de règle.</param>
        /// <returns>Une liste des jours.</returns>
        public IEnumerable<SpecificDay> Between( DateTime startDate, DateTime endDate, string countryCode, string stateCode, string regionCode, RuleType type = RuleType.All )
        {
            if ( startDate.IsAfter( endDate ) )
            {
                throw new ArgumentException( "startDate is after endDate." );
            }

            return BetweenIterator();
            IEnumerable<SpecificDay> BetweenIterator()
            {
                var currentYear = startDate.Year;
                var endYear = endDate.Year;

                while ( currentYear <= endYear )
                {
                    var items = countryCode.IsNotNullOrEmpty() && stateCode.IsNotNullOrEmpty() && regionCode.IsNotNullOrEmpty()
                        ? All( currentYear, countryCode, stateCode, regionCode, type )
                        : countryCode.IsNotNullOrEmpty() && stateCode.IsNotNullOrEmpty() && regionCode.IsNullOrEmpty()
                            ? All( currentYear, countryCode, stateCode, type )
                            : All( currentYear, countryCode, type );

                    foreach ( var item in items )
                    {
                        if ( item.Date >= startDate && item.Date <= endDate )
                        {
                            yield return item;
                        }
                    }

                    currentYear++;
                }
            }
        }

        /// <summary>
        /// Méthode qui permet pour une date donnée de vérifier si un jour particulier est trouvé à l'éxécution des règles. 
        /// </summary>
        /// <param name="date">Date à trouver.</param>
        /// <param name="countryCode">Pays.</param>
        /// <param name="type">Type de règle.</param>
        /// <returns>Le jour particulier à la date donnée si il est trouvé, sinon <see langword="null"/>.</returns>
        public SpecificDay Single( DateTime date, string countryCode, RuleType type = RuleType.Public )
            => Single( date, countryCode, null, null, type );

        /// <summary>
        /// Méthode qui permet pour une date donnée de vérifier si un jour particulier est trouvé à l'éxécution des règles. 
        /// </summary>
        /// <param name="date">Date à trouver.</param>
        /// <param name="countryCode">Pays.</param>
        /// <param name="stateCode">Etat.</param>
        /// <param name="type">Type de règle.</param>
        /// <returns>Le jour particulier à la date donnée si il est trouvé, sinon <see langword="null"/>.</returns>
        public SpecificDay Single( DateTime date, string countryCode, string stateCode, RuleType type = RuleType.Public )
            => Single( date, countryCode, stateCode, null, type );

        /// <summary>
        /// Méthode qui permet pour une date donnée de vérifier si un jour particulier est trouvé à l'éxécution des règles. 
        /// </summary>
        /// <param name="date">Date à trouver.</param>
        /// <param name="countryCode">Pays.</param>
        /// <param name="stateCode">Etat.</param>
        /// <param name="regionCode">Région.</param>
        /// <param name="type">Type de règle.</param>
        /// <returns>Le jour particulier à la date donnée si il est trouvé, sinon <see langword="null"/>.</returns>
        public SpecificDay Single( DateTime date, string countryCode, string stateCode, string regionCode, RuleType type = RuleType.Public )
        {
            var items = All( date.Year, countryCode, stateCode, regionCode, type );
            return items?.Where( x => x.Type == type )?.FirstOrDefault( x => x.Date.Date == date.Date );
        }

        /// <summary>
        /// Méthode qui permet de trouver tous les longs week-ends pour une année.
        /// </summary>
        /// <param name="year">Année souhaitée.</param>
        /// <param name="countryCode">Pays.</param>
        /// <returns>La liste des longs week-ends, un long week-end est un période d'au moins 3 jours, avec potentiellement un jour ouvrés entre 2 jours non ouvrés.</returns>
        public IEnumerable<LongWeekEnd> LongWeekEnds( int year, string countryCode )
            => LongWeekEnds( year, countryCode, null, null );

        /// <summary>
        /// Méthode qui permet de trouver tous les longs week-ends pour une année.
        /// </summary>
        /// <param name="year">Année souhaitée.</param>
        /// <param name="countryCode">Pays.</param>
        /// <param name="stateCode">Etat.</param>
        /// <returns>La liste des longs week-ends, un long week-end est un période d'au moins 3 jours, avec potentiellement un jour ouvrés entre 2 jours non ouvrés.</returns>
        public IEnumerable<LongWeekEnd> LongWeekEnds( int year, string countryCode, string stateCode )
            => LongWeekEnds( year, countryCode, stateCode, null );

        /// <summary>
        /// Méthode qui permet de trouver tous les longs week-ends pour une année.
        /// </summary>
        /// <param name="year">Année souhaitée.</param>
        /// <param name="countryCode">Pays.</param>
        /// <param name="stateCode">Etat.</param>
        /// <param name="regionCode">Région.</param>
        /// <returns>La liste des longs week-ends, un long week-end est un période d'au moins 3 jours, avec potentiellement un jour ouvrés entre 2 jours non ouvrés.</returns>
        public IEnumerable<LongWeekEnd> LongWeekEnds( int year, string countryCode, string stateCode, string regionCode )
        {
            var specificDays = All( year, countryCode, stateCode, regionCode, RuleType.Public );
            var lst = new List<LongWeekEnd>();
            foreach ( var item in specificDays )
            {
                var longWeekEnd = DoSomeThing( specificDays, item, null, SearchType.All );
                if ( longWeekEnd != null )
                {
                    if ( !lst.Any( x => x.StartDate <= longWeekEnd.StartDate && x.EndDate >= longWeekEnd.EndDate ) )
                    {
                        lst.Add( longWeekEnd );
                    }
                }
            }
            return lst;
        }

        internal enum SearchType { All, StartDate, EndDate }

        private LongWeekEnd DoSomeThing( IEnumerable<SpecificDay> specificDays, SpecificDay specificDay, LongWeekEnd longWeekEnd, SearchType searchType = SearchType.All )
        {
            switch ( specificDay.Date.DayOfWeek )
            {
                case DayOfWeek.Sunday:
                    return longWeekEnd;
                case DayOfWeek.Monday:
                    if ( longWeekEnd == null )
                    {
                        longWeekEnd = new LongWeekEnd() { StartDate = 2.Days().Before( specificDay.Date ), EndDate = specificDay.Date };
                    }

                    if ( searchType == SearchType.StartDate || searchType == SearchType.All )
                    {
                        longWeekEnd.StartDate = 2.Days().Before( specificDay.Date );

                        var specFriday = specificDays.FirstOrDefault( x => x.Date == 4.Days().Before( specificDay.Date ) );
                        var specThursday = specificDays.FirstOrDefault( x => x.Date == 5.Days().Before( specificDay.Date ) );

                        if ( specFriday != null )
                        {
                            DoSomeThing( specificDays, specFriday, longWeekEnd, SearchType.StartDate );
                        }

                        if ( specThursday != null )
                        {
                            DoSomeThing( specificDays, specThursday, longWeekEnd, SearchType.StartDate );
                        }
                    }
                    if ( searchType == SearchType.EndDate || searchType == SearchType.All )
                    {
                        longWeekEnd.EndDate = specificDay.Date;

                        var specTuesday = specificDays.FirstOrDefault( x => x.Date == 1.Days().After( specificDay.Date ) );
                        var specWednesday = specificDays.FirstOrDefault( x => x.Date == 2.Days().After( specificDay.Date ) );

                        if ( specTuesday != null )
                        {
                            DoSomeThing( specificDays, specTuesday, longWeekEnd, SearchType.EndDate );
                        }

                        if ( specWednesday != null )
                        {
                            DoSomeThing( specificDays, specWednesday, longWeekEnd, SearchType.EndDate );
                        }
                    }
                    return longWeekEnd;
                case DayOfWeek.Tuesday:
                    if ( longWeekEnd == null )
                    {
                        longWeekEnd = new LongWeekEnd() { StartDate = 3.Days().Before( specificDay.Date ), EndDate = specificDay.Date };
                    }

                    if ( searchType == SearchType.StartDate || searchType == SearchType.All )
                    {
                        longWeekEnd.StartDate = 3.Days().Before( specificDay.Date );
                        longWeekEnd.HasBridge = true;

                        var specFriday = specificDays.FirstOrDefault( x => x.Date == 4.Days().Before( specificDay.Date ) );
                        var specThursday = specificDays.FirstOrDefault( x => x.Date == 5.Days().Before( specificDay.Date ) );

                        if ( specFriday != null )
                        {
                            DoSomeThing( specificDays, specFriday, longWeekEnd, SearchType.StartDate );
                        }

                        if ( specThursday != null )
                        {
                            DoSomeThing( specificDays, specThursday, longWeekEnd, SearchType.StartDate );
                        }
                    }
                    if ( searchType == SearchType.EndDate || searchType == SearchType.All )
                    {
                        longWeekEnd.EndDate = specificDay.Date;

                        var specWednesday = specificDays.FirstOrDefault( x => x.Date == 1.Days().After( specificDay.Date ) );
                        var specThursday = specificDays.FirstOrDefault( x => x.Date == 2.Days().After( specificDay.Date ) );

                        if ( specWednesday != null )
                        {
                            DoSomeThing( specificDays, specWednesday, longWeekEnd, SearchType.EndDate );
                        }

                        if ( specThursday != null )
                        {
                            DoSomeThing( specificDays, specThursday, longWeekEnd, SearchType.EndDate );
                        }
                    }
                    return longWeekEnd;
                case DayOfWeek.Wednesday:
                    if ( longWeekEnd != null && ( searchType == SearchType.StartDate || searchType == SearchType.All ) )
                    {
                        longWeekEnd.StartDate = specificDay.Date;

                        var specTuesday = specificDays.FirstOrDefault( x => x.Date == 1.Days().Before( specificDay.Date ) );
                        var specMonday = specificDays.FirstOrDefault( x => x.Date == 2.Days().Before( specificDay.Date ) );

                        if ( specTuesday != null )
                        {
                            DoSomeThing( specificDays, specTuesday, longWeekEnd, SearchType.StartDate );
                        }

                        if ( specMonday != null )
                        {
                            DoSomeThing( specificDays, specMonday, longWeekEnd, SearchType.StartDate );
                        }
                    }
                    if ( longWeekEnd != null && ( searchType == SearchType.EndDate || searchType == SearchType.All ) )
                    {
                        longWeekEnd.EndDate = specificDay.Date;

                        var specThursday = specificDays.FirstOrDefault( x => x.Date == 1.Days().After( specificDay.Date ) );
                        var specFriday = specificDays.FirstOrDefault( x => x.Date == 2.Days().After( specificDay.Date ) );

                        if ( specThursday != null )
                        {
                            DoSomeThing( specificDays, specThursday, longWeekEnd, SearchType.EndDate );
                        }

                        if ( specFriday != null )
                        {
                            DoSomeThing( specificDays, specFriday, longWeekEnd, SearchType.EndDate );
                        }
                    }
                    return longWeekEnd;
                case DayOfWeek.Thursday:
                    {
                        if ( longWeekEnd == null )
                        {
                            longWeekEnd = new LongWeekEnd() { StartDate = specificDay.Date, EndDate = 3.Days().After( specificDay.Date ) };
                        }

                        if ( searchType == SearchType.StartDate || searchType == SearchType.All )
                        {
                            longWeekEnd.StartDate = specificDay.Date;
                            longWeekEnd.HasBridge = true;

                            var specWednesday = specificDays.FirstOrDefault( x => x.Date == 1.Days().Before( specificDay.Date ) );
                            var specTuesday = specificDays.FirstOrDefault( x => x.Date == 2.Days().Before( specificDay.Date ) );

                            if ( specWednesday != null )
                            {
                                DoSomeThing( specificDays, specWednesday, longWeekEnd, SearchType.StartDate );
                            }

                            if ( specTuesday != null )
                            {
                                DoSomeThing( specificDays, specTuesday, longWeekEnd, SearchType.StartDate );
                            }
                        }
                        if ( searchType == SearchType.EndDate || searchType == SearchType.All )
                        {
                            longWeekEnd.EndDate = 3.Days().After( specificDay.Date );

                            var specMonday = specificDays.FirstOrDefault( x => x.Date == 4.Days().After( specificDay.Date ) );
                            var specTuesday = specificDays.FirstOrDefault( x => x.Date == 5.Days().After( specificDay.Date ) );

                            if ( specMonday != null )
                            {
                                DoSomeThing( specificDays, specMonday, longWeekEnd, SearchType.EndDate );
                            }

                            if ( specTuesday != null )
                            {
                                DoSomeThing( specificDays, specTuesday, longWeekEnd, SearchType.EndDate );
                            }
                        }
                        return longWeekEnd;
                    }
                case DayOfWeek.Friday:
                    {
                        if ( longWeekEnd == null )
                        {
                            longWeekEnd = new LongWeekEnd() { StartDate = specificDay.Date, EndDate = 2.Days().After( specificDay.Date ) };
                        }

                        if ( searchType == SearchType.StartDate || searchType == SearchType.All )
                        {
                            longWeekEnd.StartDate = specificDay.Date;

                            var specThursday = specificDays.FirstOrDefault( x => x.Date == 1.Days().Before( specificDay.Date ) );
                            var specWednesday = specificDays.FirstOrDefault( x => x.Date == 2.Days().Before( specificDay.Date ) );

                            if ( specThursday != null )
                            {
                                DoSomeThing( specificDays, specThursday, longWeekEnd );
                            }

                            if ( specWednesday != null )
                            {
                                DoSomeThing( specificDays, specWednesday, longWeekEnd );
                            }
                        }
                        if ( searchType == SearchType.EndDate || searchType == SearchType.All )
                        {
                            var specMonday = specificDays.FirstOrDefault( x => x.Date == 3.Days().After( specificDay.Date ) );
                            var specTuesday = specificDays.FirstOrDefault( x => x.Date == 4.Days().After( specificDay.Date ) );

                            if ( specMonday != null )
                            {
                                DoSomeThing( specificDays, specMonday, longWeekEnd );
                            }

                            if ( specTuesday != null )
                            {
                                DoSomeThing( specificDays, specTuesday, longWeekEnd );
                            }
                        }
                        return longWeekEnd;
                    }
                case DayOfWeek.Saturday:
                    return longWeekEnd;
                default:
                    return longWeekEnd;
            }
        }
    }
}
