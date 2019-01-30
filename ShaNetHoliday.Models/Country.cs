using ShaNetCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static ShaNetHoliday.Models.RuleType;

namespace ShaNetHoliday.Models
{
    /// <summary>
    /// Représentation d'un pays.
    /// </summary>
    public class Country : GeographicElementBase
    {
        /// <summary>
        /// Code alphanumérique sur 3 caractères
        /// </summary>
        /// <remarks>https://en.wikipedia.org/wiki/ISO_3166-1_alpha-3</remarks>
        public string Alpha3Code { get; set; }

        /// <summary>
        /// Jours non travaillés.
        /// </summary>
        public List<DayOfWeek> DaysOff { get; set; } = new List<DayOfWeek>();

        /// <summary>
        /// Types de calendrier supportés par le pays.
        /// </summary>
        public List<Calendar> SupportedCalendar { get; set; } = new List<Calendar>();

        /// <summary>
        /// Liste des états du pays.
        /// </summary>
        public ListState States { get; set; } = new ListState();

        /// <summary>
        /// Méthode qui permet de récupérer les jours pour une année en particulier par rapport à un type de règle.
        /// </summary>
        /// <param name="year">Année souhaitée.</param>
        /// <param name="type">Type de règle.</param>
        /// <param name="calendar">Type de calendrier des règles.</param>
        /// <returns>Une liste de tous les jours particulier.</returns>
        public IEnumerable<SpecificDay> Get( int year, RuleType type, Calendar calendar )
            => Get( year, null, null, type, calendar );

        /// <summary>
        /// Méthode qui permet de récupérer les jours pour une année en particulier par rapport à un type de règle.
        /// </summary>
        /// <param name="year">Année souhaitée.</param>
        /// <param name="state">Etat particulier</param>
        /// <param name="type">Type de règle.</param>
        /// <param name="calendar">Type de calendrier des règles.</param>
        /// <returns>Une liste de tous les jours particulier.</returns>
        public IEnumerable<SpecificDay> Get( int year, string state, RuleType type, Calendar calendar )
            => Get( year, state, null, type, calendar );

        /// <summary>
        /// Méthode qui permet de récupérer les jours pour une année en particulier par rapport à un type de règle.
        /// </summary>
        /// <param name="year">Année souhaitée.</param>
        /// <param name="stateCode">Etat particulier.</param>
        /// <param name="regionCode">Région particulière.</param>
        /// <param name="type">Type de règle.</param>
        /// <param name="calendar">Type de calendrier des règles.</param>
        /// <returns>Une liste de tous les jours particulier.</returns>
        public IEnumerable<SpecificDay> Get( int year, string stateCode, string regionCode, RuleType type, Calendar calendar )
        {
            var rules = new List<Rule>( Rules.Select( x => x.Clone() as Rule ) );

            void CheckRule( Rule rule )
            {
                if ( rule.Key.IsNotNullOrEmpty() && !rule.IsEnable )
                {
                    rules.RemoveAll( x => x.Key == rule.Key );
                }
                else if ( rule.Key.IsNotNullOrEmpty() && ( rule.Overrides & Overrides.None ) == 0 )
                {
                    var baseRule = rules.FirstOrDefault( x => x.Key == rule.Key );
                    if ( ( rule.Overrides & Overrides.Expression ) != 0 )
                    {
                        baseRule.Expression = rule.Expression;
                    }

                    if ( ( rule.Overrides & Overrides.Type ) != 0 )
                    {
                        baseRule.Type = rule.Type;
                    }

                    if ( ( rule.Overrides & Overrides.Note ) != 0 )
                    {
                        baseRule.Note = rule.Note;
                    }

                    if ( ( rule.Overrides & Overrides.Name ) != 0 )
                    {
                        baseRule.Names = rule.Names;
                    }
                }
                else
                {
                    rules.Add( rule );
                }
            }

            States.FirstOrDefault( x => x.Code == stateCode )?.IfNotNull( x =>
               {
                   x.Rules.ForEach( y => CheckRule( y ) );
                   x.Regions.FirstOrDefault( y => y.Code == regionCode )?.Rules.ForEach( y => CheckRule( y ) );
               } );

            var lst = new List<SpecificDay>();
            rules
                .ConditionnalWhere( () => type == All, _ => true, x => x.Type == type )
                .ConditionnalWhere( () => calendar == Calendar.All, _ => true, x => x.Calendar == calendar )
                .ForEach( x => x.Parse( year, lst ) );

            return lst.OrderBy( x => x.Date );
        }
    }
}
