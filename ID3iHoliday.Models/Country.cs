using ID3iCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static ID3iHoliday.Models.RuleType;

namespace ID3iHoliday.Models
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
        public IEnumerable<SpecificDay> Get(int year, RuleType type, Calendar calendar)
            => Get(year, null, null, type, calendar);
        /// <summary>
        /// Méthode qui permet de récupérer les jours pour une année en particulier par rapport à un type de règle.
        /// </summary>
        /// <param name="year">Année souhaitée.</param>
        /// <param name="state">Etat particulier</param>
        /// <param name="type">Type de règle.</param>
        /// <param name="calendar">Type de calendrier des règles.</param>
        /// <returns>Une liste de tous les jours particulier.</returns>
        public IEnumerable<SpecificDay> Get(int year, string state, RuleType type, Calendar calendar)
            => Get(year, state, null, type, calendar);
        /// <summary>
        /// Méthode qui permet de récupérer les jours pour une année en particulier par rapport à un type de règle.
        /// </summary>
        /// <param name="year">Année souhaitée.</param>
        /// <param name="stateCode">Etat particulier.</param>
        /// <param name="regionCode">Région particulière.</param>
        /// <param name="type">Type de règle.</param>
        /// <param name="calendar">Type de calendrier des règles.</param>
        /// <returns>Une liste de tous les jours particulier.</returns>
        public IEnumerable<SpecificDay> Get(int year, string stateCode, string regionCode, RuleType type, Calendar calendar)
        {
            List<Rule> rules = new List<Rule>(Rules.Where(x => x.Calendar == calendar).Select(x => x.Clone() as Rule));

            void CheckRule(Rule rule)
            {
                if (rule.Key.IsNotNullOrEmpty() && !rule.IsEnable)
                    rules.RemoveAll(x => x.Key == rule.Key);
                else if (rule.Key.IsNotNullOrEmpty() && !rule.Overrides.HasFlag(Overrides.None))
                {
                    var baseRule = rules.FirstOrDefault(x => x.Key == rule.Key);
                    if (rule.Overrides.HasFlag(Overrides.Expression))
                        baseRule.Expression = rule.Expression;
                    if (rule.Overrides.HasFlag(Overrides.Type))
                        baseRule.Type = rule.Type;
                    if (rule.Overrides.HasFlag(Overrides.Note))
                        baseRule.Note = rule.Note;
                }
                else
                    rules.Add(rule);
            };

            States.FirstOrDefault(x => x.Code == stateCode)?.IfNotNull(x =>
            {
                x.Rules.Where(y => y.Calendar == calendar).ForEach(y => CheckRule(y));
                x.Regions.FirstOrDefault(y => y.Code == regionCode)?.Rules.Where(y => y.Calendar == calendar).ForEach(y => CheckRule(y));
            });

            List<SpecificDay> lst = new List<SpecificDay>();
            rules.ConditionnalWhere(() => type == All, x => true, x => x.Type == type).ForEach(x => x.Parse(year, lst));

            return lst.OrderBy(x => x.Date);
        }
    }
}
