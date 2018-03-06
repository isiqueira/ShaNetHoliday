using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ID3iHoliday.Models
{
    /// <summary>
    /// Interface pour la définition d'un wrapper de récupération de données particulières dans l'environnement des jours particuliers.
    /// </summary>
    public interface IHolidaySystem
    {
        /// <summary>
        /// Liste des pays disponible.
        /// </summary>
        List<Country> CountriesAvailable { get; set; }
        /// <summary>
        /// Méthode qui permet d'éxécuter toutes les règles souhaitées pour une année en particulier.
        /// </summary>
        /// <param name="year">Année souhaitée.</param>
        /// <param name="countryCode">Pays.</param>
        /// <param name="type">Type de règle.</param>
        /// <param name="calendar">Type de calendrier des règles.</param>
        /// <returns>Une liste des jours.</returns>
        IEnumerable<SpecificDay> All(int year, string countryCode, RuleType type = RuleType.All, Calendar calendar = Calendar.Gregorian);
        /// <summary>
        /// Méthode qui permet d'éxécuter toutes les règles souhaitées pour une année en particulier.
        /// </summary>
        /// <param name="year">Année souhaitée.</param>
        /// <param name="countryCode">Pays.</param>
        /// <param name="stateCode">Etat.</param>
        /// <param name="type">Type de règle.</param>
        /// <param name="calendar">Type de calendrier des règles.</param>
        /// <returns>Une liste des jours.</returns>
        IEnumerable<SpecificDay> All(int year, string countryCode, string stateCode, RuleType type = RuleType.All, Calendar calendar = Calendar.Gregorian);
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
        IEnumerable<SpecificDay> All(int year, string countryCode, string stateCode, string regionCode, RuleType type = RuleType.All, Calendar calendar = Calendar.Gregorian);

        /// <summary>
        /// Méthode qui permet d'éxécuter toutes les règles souhaitées entre une date de début et une date de fin.
        /// </summary>
        /// <param name="startDate">Date de début.</param>
        /// <param name="endDate">Date de fin.</param>
        /// <param name="countryCode">Pays.</param>
        /// <param name="type">Type de règle.</param>
        /// <returns>Une liste des jours.</returns>
        IEnumerable<SpecificDay> Between(DateTime startDate, DateTime endDate, string countryCode, RuleType type = RuleType.All);
        /// <summary>
        /// Méthode qui permet d'éxécuter toutes les règles souhaitées entre une date de début et une date de fin.
        /// </summary>
        /// <param name="startDate">Date de début.</param>
        /// <param name="endDate">Date de fin.</param>
        /// <param name="countryCode">Pays.</param>
        /// <param name="stateCode">Etat.</param>
        /// <param name="type">Type de règle.</param>
        /// <returns>Une liste des jours.</returns>
        IEnumerable<SpecificDay> Between(DateTime startDate, DateTime endDate, string countryCode, string stateCode, RuleType type = RuleType.All);
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
        IEnumerable<SpecificDay> Between(DateTime startDate, DateTime endDate, string countryCode, string stateCode, string regionCode, RuleType type = RuleType.All);

        /// <summary>
        /// Méthode qui permet pour une date donnée de vérifier si un jour particulier est trouvé à l'éxécution des règles. 
        /// </summary>
        /// <param name="date">Date à trouver.</param>
        /// <param name="countryCode">Pays.</param>
        /// <param name="type">Type de règle.</param>
        /// <returns>Le jour particulier à la date donnée si il est trouvé, sinon <see langword="null"/>.</returns>
        SpecificDay Single(DateTime date, string countryCode, RuleType type = RuleType.Public);
        /// <summary>
        /// Méthode qui permet pour une date donnée de vérifier si un jour particulier est trouvé à l'éxécution des règles. 
        /// </summary>
        /// <param name="date">Date à trouver.</param>
        /// <param name="countryCode">Pays.</param>
        /// <param name="stateCode">Etat.</param>
        /// <param name="type">Type de règle.</param>
        /// <returns>Le jour particulier à la date donnée si il est trouvé, sinon <see langword="null"/>.</returns>
        SpecificDay Single(DateTime date, string countryCode, string stateCode, RuleType type = RuleType.Public);
        /// <summary>
        /// Méthode qui permet pour une date donnée de vérifier si un jour particulier est trouvé à l'éxécution des règles. 
        /// </summary>
        /// <param name="date">Date à trouver.</param>
        /// <param name="countryCode">Pays.</param>
        /// <param name="stateCode">Etat.</param>
        /// <param name="regionCode">Région.</param>
        /// <param name="type">Type de règle.</param>
        /// <returns>Le jour particulier à la date donnée si il est trouvé, sinon <see langword="null"/>.</returns>
        SpecificDay Single(DateTime date, string countryCode, string stateCode, string regionCode, RuleType type = RuleType.Public);

        /// <summary>
        /// Méthode qui permet de trouver tous les longs week-ends pour une année.
        /// </summary>
        /// <param name="year">Année souhaitée.</param>
        /// <param name="countryCode">Pays.</param>
        /// <returns>La liste des longs week-ends, un long week-end est un période d'au moins 3 jours, avec potentiellement un jour ouvrés entre 2 jours non ouvrés.</returns>
        IEnumerable<LongWeekEnd> LongWeekEnds(int year, string countryCode);
        /// <summary>
        /// Méthode qui permet de trouver tous les longs week-ends pour une année.
        /// </summary>
        /// <param name="year">Année souhaitée.</param>
        /// <param name="countryCode">Pays.</param>
        /// <param name="stateCode">Etat.</param>
        /// <returns>La liste des longs week-ends, un long week-end est un période d'au moins 3 jours, avec potentiellement un jour ouvrés entre 2 jours non ouvrés.</returns>
        IEnumerable<LongWeekEnd> LongWeekEnds(int year, string countryCode, string stateCode);
        /// <summary>
        /// Méthode qui permet de trouver tous les longs week-ends pour une année.
        /// </summary>
        /// <param name="year">Année souhaitée.</param>
        /// <param name="countryCode">Pays.</param>
        /// <param name="stateCode">Etat.</param>
        /// <param name="regionCode">Région.</param>
        /// <returns>La liste des longs week-ends, un long week-end est un période d'au moins 3 jours, avec potentiellement un jour ouvrés entre 2 jours non ouvrés.</returns>
        IEnumerable<LongWeekEnd> LongWeekEnds(int year, string countryCode, string stateCode, string regionCode);
    }
}
