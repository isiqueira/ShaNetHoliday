using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static ID3iHoliday.Models.Rule.SpecificDayKey;

namespace ID3iHoliday.Models
{
    public partial class Rule
    {
        public enum SpecificDayKey
        {
            Jan01Key, Jan06Key,
            Feb02Key, Feb14Key,
            Mar08Key, Mar19Key,
            Apr01Key,
            May01Key,
            Jun29Key,
            Aug15Key,
            Nov01Key, Nov02Key, Nov11Key,
            Dec06Key, Dec08Key, Dec24Key, Dec25Key, Dec26Key, Dec31Key,

            CarnivalMondayKey, CarnivalTuesdayKey, AshWednesdayKey, PalmSundayKey, MaundyThrusdayKey, GoodFridayKey, HolySaturdayKey, EasterKey, EasterMondayKey, AscensionKey,
            PentecostKey, WhitMondayKey, CorpusChristiKey,

            AbolitionSlaveryKey, ConstitutionDayKey, FatherDayKey, IndependenceDayKey, LiberationDayKey, MotherDayKey,
            NationalDayKey, PublicHolidayKey, ReformationDayKey, RevolutionDayKey
        }

        internal class NamesInfo
        {
            public SpecificDayKey Code { get; set; }
            public Langue Langue { get; set; }
            public string Name { get; set; }
            public NamesInfo(SpecificDayKey code, Langue langue, string name)
            {
                Code = code;
                Langue = langue;
                Name = name;
            }
        }

        internal static List<NamesInfo> AllNames => new List<NamesInfo>()
        {
            new NamesInfo(Jan01Key, Langue.FR, "Jour de l'an"),
            new NamesInfo(Jan01Key, Langue.EN, "New Year's Day"),
            new NamesInfo(Jan01Key, Langue.CA, "Any nou"),
            new NamesInfo(Jan01Key, Langue.ES, "Año Nuevo"),
                         
            new NamesInfo(Jan06Key, Langue.FR, "L'épiphanie"),
            new NamesInfo(Jan06Key, Langue.EN, "Epiphany"),
            new NamesInfo(Jan06Key, Langue.ES, "Día de los Reyes Magos"),
                         
            new NamesInfo(Feb02Key, Langue.EN, "Candlemas"),
                         
            new NamesInfo(Feb14Key, Langue.FR, "Saint-Valentin"),
            new NamesInfo(Feb14Key, Langue.EN, "Valentine's Day"),
                         
            new NamesInfo(Mar08Key, Langue.EN, "International Women's day"),
                         
            new NamesInfo(Mar19Key, Langue.EN, "Saint Joseph"),
            new NamesInfo(Mar19Key, Langue.EN, "San José"),
                         
            new NamesInfo(Apr01Key, Langue.EN, "April Fool's Day"),
                         
            new NamesInfo(May01Key, Langue.FR, "Fête du travail"),
            new NamesInfo(May01Key, Langue.EN, "Labour Day"),
            new NamesInfo(May01Key, Langue.ES, "Fiesta del trabajo"),
                         
            new NamesInfo(Jun29Key, Langue.EN, "Saint Peter and Saint Paul"),
            new NamesInfo(Jun29Key, Langue.ES, "San Pedro y San Pablo"),
                         
            new NamesInfo(Aug15Key, Langue.FR, "Assomption"),
            new NamesInfo(Aug15Key, Langue.EN, "Assumption"),
            new NamesInfo(Aug15Key, Langue.ES, "Asunción"),
                         
            new NamesInfo(Nov01Key, Langue.FR, "Toussaint"),
            new NamesInfo(Nov01Key, Langue.EN, "All Saints' Day"),
            new NamesInfo(Nov01Key, Langue.ES, "Todos los Santos"),
                         
            new NamesInfo(Nov02Key, Langue.FR, "Fête des morts"),
            new NamesInfo(Nov02Key, Langue.EN, "All Souls' Day"),
            new NamesInfo(Nov02Key, Langue.ES, "Día de los Difuntos"),
                         
            new NamesInfo(Nov11Key, Langue.EN, "Saint Martin"),
                         
            new NamesInfo(Dec06Key, Langue.FR, "Saint-Nicolas"),
            new NamesInfo(Dec06Key, Langue.EN, "Saint Nicholas"),
                         
            new NamesInfo(Dec08Key, Langue.FR, "Immaculée Conception"),
            new NamesInfo(Dec08Key, Langue.EN, "Immaculate Conception"),
            new NamesInfo(Dec08Key, Langue.ES, "La inmaculada concepción"),
                         
            new NamesInfo(Dec24Key, Langue.EN, "Christmax Eve"),
            new NamesInfo(Dec24Key, Langue.ES, "Nochebuena"),
                         
            new NamesInfo(Dec25Key, Langue.FR, "Noël"),
            new NamesInfo(Dec25Key, Langue.EN, "Christmas Day"),
            new NamesInfo(Dec25Key, Langue.ES, "Navidad"),
                         
            new NamesInfo(Dec26Key, Langue.FR, "Lendemain de Noël"),
            new NamesInfo(Dec26Key, Langue.EN, "Boxing Day"),
            new NamesInfo(Dec26Key, Langue.ES, "San Esteban"),
                         
            new NamesInfo(Dec31Key, Langue.FR, "Saint-Sylvestre"),
            new NamesInfo(Dec31Key, Langue.EN, "New Year's Eve"),
            new NamesInfo(Dec31Key, Langue.ES, "Fin del Año"),
                         
            new NamesInfo(CarnivalMondayKey, Langue.FR, "Lundi de Carnaval"),
            new NamesInfo(CarnivalMondayKey, Langue.EN, "Shrove Monday"),
            new NamesInfo(CarnivalMondayKey, Langue.ES, "Carnaval"),            
                         
            new NamesInfo(CarnivalTuesdayKey, Langue.EN, "Shrove Tuesday"),
            new NamesInfo(CarnivalTuesdayKey, Langue.ES, "Carnaval"),
                         
            new NamesInfo(AshWednesdayKey, Langue.FR, "Mercredi des Cendres"),
            new NamesInfo(AshWednesdayKey, Langue.EN, "Ash Wednesday"),
            new NamesInfo(AshWednesdayKey, Langue.ES, "Miercoles de Ceniza"),
                         
            new NamesInfo(PalmSundayKey, Langue.EN, "Palm Sunday"),
            new NamesInfo(PalmSundayKey, Langue.ES, "Domingo de Ramos"),
                         
            new NamesInfo(MaundyThrusdayKey, Langue.FR, "Jeudi saint"),
            new NamesInfo(MaundyThrusdayKey, Langue.EN, "Maundy Thursday"),
            new NamesInfo(MaundyThrusdayKey, Langue.ES, "Jueves Santo"),
                         
            new NamesInfo(GoodFridayKey, Langue.FR, "Vendredi saint"),
            new NamesInfo(GoodFridayKey, Langue.EN, "Good Friday"),
            new NamesInfo(GoodFridayKey, Langue.ES, "Viernes Santo"),
                         
            new NamesInfo(HolySaturdayKey, Langue.FR, "Samedi saint"),
            new NamesInfo(HolySaturdayKey, Langue.EN, "Easter Saturday"),
            new NamesInfo(HolySaturdayKey, Langue.ES, "Sabado Santo"),
                         
            new NamesInfo(EasterKey,Langue.FR, "Lundi de pâques"),
            new NamesInfo(EasterKey,Langue.EN, "Easter Sunday"),
            new NamesInfo(EasterKey,Langue.ES, "Pascua"),
                         
            new NamesInfo(EasterMondayKey,Langue.FR, "Lundi de pâques"),
            new NamesInfo(EasterMondayKey,Langue.EN, "Easter Monday"),
            new NamesInfo(EasterMondayKey,Langue.ES, "Lunes de Pascua"),
                         
            new NamesInfo(AscensionKey, Langue.FR, "Ascension"),
            new NamesInfo(AscensionKey, Langue.EN, "Ascension Day"),
            new NamesInfo(AscensionKey, Langue.ES, "La Asunción"),
                         
            new NamesInfo(PentecostKey, Langue.FR, "Pentecôte"),
            new NamesInfo(PentecostKey, Langue.EN, "Pentecost"),
            new NamesInfo(PentecostKey, Langue.ES, "Pentecostés"),
                         
            new NamesInfo(WhitMondayKey, Langue.FR, "Lundi de Pentecôte"),
            new NamesInfo(WhitMondayKey, Langue.EN, "Whit Monday"),
            new NamesInfo(WhitMondayKey, Langue.ES, "Lunes de Pentecostés"),
                         
            new NamesInfo(AbolitionSlaveryKey, Langue.FR, "Abolition de l'esclavage"),
            new NamesInfo(AbolitionSlaveryKey, Langue.EN, "Abolition of Slavery"),
                         
            new NamesInfo(ConstitutionDayKey, Langue.EN, "Constitution day"),
            new NamesInfo(ConstitutionDayKey, Langue.CA, "Dia de la Constitució"),
            new NamesInfo(ConstitutionDayKey, Langue.ES, "Día de la Constitución"),
                         
            new NamesInfo(FatherDayKey, Langue.EN, "Father's Day"),
                         
            new NamesInfo(IndependenceDayKey, Langue.FR, "Jour de l'Indépendance"),
            new NamesInfo(IndependenceDayKey, Langue.EN, "Independence Day"),
            new NamesInfo(IndependenceDayKey, Langue.ES, "Día de la Independencia"),
                         
            new NamesInfo(LiberationDayKey, Langue.EN, "Liberation Day"),
                         
            new NamesInfo(MotherDayKey, Langue.FR, "Fête des mères"),
            new NamesInfo(MotherDayKey, Langue.EN, "Mother's Day"),
            new NamesInfo(MotherDayKey, Langue.ES, "Día de la Madre"),
                         
            new NamesInfo(NationalDayKey, Langue.FR, "Fête nationale"),
            new NamesInfo(NationalDayKey, Langue.EN, "National Holiday"),
            new NamesInfo(NationalDayKey, Langue.ES, "Fiesta Nacional"),
                         
            new NamesInfo(PublicHolidayKey, Langue.FR, "Jour férié légaux"),
            new NamesInfo(PublicHolidayKey, Langue.EN, "Public Holiday"),
                         
            new NamesInfo(PublicHolidayKey, Langue.EN, "Reformation Day"),
            new NamesInfo(PublicHolidayKey, Langue.ES, "Día Nacional de las Iglesias Evangélicas y Protestantes"),
                         
            new NamesInfo(PublicHolidayKey, Langue.EN, "Revolution Day"),
            new NamesInfo(PublicHolidayKey, Langue.ES, "Día de la Revolución"),
        };

        public SpecificDayKey SpecDayKey { get; set; }
        public Dictionary<Langue, string> GetNames() => Langues.ToDictionary(x => x, x => AllNames.FirstOrDefault(y => y.Code == SpecDayKey && y.Langue == x)?.Name);
    }
}
