using ID3iHoliday.Core.Models;
using System;
using System.Collections.Generic;

using static ID3iHoliday.Models.RuleType;

namespace ID3iHoliday.Models
{
    /// <summary>
    /// Représentation d'une règle dans le calendrier <see cref="System.Globalization.GregorianCalendar"/>.
    /// </summary>
    public class GregorianRule : Rule
    {
        /// <summary>
        /// Initialise une nouvelle instance pour la classe <see cref="GregorianRule"/>.
        /// </summary>
        public GregorianRule() : base() => Calendar = Calendar.Gregorian;
    }

    /// <summary>
    /// Représentation d'une règle dans le calendrier <see cref="System.Globalization.JulianCalendar"/>.
    /// </summary>
    public class JulianRule : Rule
    {
        /// <summary>
        /// Initialise une nouvelle instance pour la classe <see cref="JulianRule"/>.
        /// </summary>
        public JulianRule() : base() => Calendar = Calendar.Julian;
    }

    /// <summary>
    /// Représentation d'une règle dans le calendrier <see cref="System.Globalization.HijriCalendar"/>.
    /// </summary>
    public class HijriRule : Rule
    {
        /// <summary>
        /// Initialise une nouvelle instance pour la classe <see cref="HijriRule"/>.
        /// </summary>
        public HijriRule() : base() => Calendar = Calendar.Hijri;
    }

    /// <summary>
    /// Représentation d'une règle dans le calendrier <see cref="System.Globalization.HebrewCalendar"/>.
    /// </summary>
    public class HebrewRule : Rule
    {
        /// <summary>
        /// Initialise une nouvelle instance pour la classe <see cref="HebrewRule"/>.
        /// </summary>
        public HebrewRule() : base() => Calendar = Calendar.Hijri;
    }

    /// <summary>
    /// Représentation d'une règle.
    /// </summary>
    public abstract class Rule : ICloneable
    {
        /// <summary>
        /// Eléments à surcharger.
        /// </summary>
        public Overrides Overrides { get; set; } = Overrides.None;

        /// <summary>
        /// Clef de la règle.
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Expression de la règle.
        /// </summary>
        public ExpressionElement Expression { get; set; }

        /// <summary>
        /// Nom du jour particulier.
        /// </summary>
        public Dictionary<Langue, string> Names { get; set; } = new Dictionary<Langue, string>();

        /// <summary>
        /// Type de la règle.
        /// </summary>
        public RuleType Type { get; set; } = Public;

        /// <summary>
        /// Note de la règle.
        /// </summary>
        public string Note { get; set; }

        /// <summary>
        /// Indication si la règle est une règle de substitution.
        /// </summary>
        public bool Substitute { get; set; }

        /// <summary>
        /// Indication sur l'état de la règle.
        /// </summary>
        public bool IsEnable { get; set; } = true;

        /// <summary>
        /// Retourne une chaîne qui représente l'objet actuel.
        /// </summary>
        /// <returns>Chaîne qui représente l'objet actuel.</returns>
        public override string ToString() => Expression.Expression;

        /// <summary>
        /// Type de calendrier de la règle.
        /// </summary>
        public Calendar Calendar { get; set; } = Calendar.Gregorian;

        /// <summary>
        /// Méthode qui permet de parser l'expression de cette règle pour une année..
        /// </summary>
        /// <param name="year">Année.</param>
        /// <param name="specificDays">Liste des jours déjà trouvés.</param>
        public void Parse( int year, List<SpecificDay> specificDays )
        {
            var result = Expression.Parse( year );
            result.DatesToAdd.ForEach( x => specificDays.Add( new SpecificDay( Type, x, Names ) ) );
            if ( result.DateToRemove != null )
            {
                specificDays.RemoveAll( x => x.Date == result.DateToRemove );
            }
        }

        /// <summary>
        /// Crée une copie superficielle du <see cref="Rule"/> actuel.
        /// </summary>
        /// <returns>Copie superficielle du <see cref="Rule"/> actuel.</returns>
        public object Clone() => MemberwiseClone() as Rule;
    }
}
