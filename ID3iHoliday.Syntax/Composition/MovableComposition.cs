using ID3iHoliday.Core.Models;
using ID3iHoliday.Core.Parsers;
using ID3iHoliday.Syntax.Parsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static ID3iHoliday.Syntax.Month;

namespace ID3iHoliday.Syntax
{
    /// <summary>
    /// Elément de syntax pour changer au jour de la semaine spécifié.
    /// </summary>
    public class MovableComposition : ExpressionElement
    {
        /// <summary>
        /// Token de l'élément.
        /// </summary>
        protected override string Token => $"MOVABLE {Count.ToString().ToUpper()} {Day.ToString().ToUpper()}";
        /// <summary>
        /// <see cref="ParserMovable"/> associé à l'élément.
        /// </summary>
        protected override ParserBase Parser => new ParserMovable();
        internal Count Count { get; set; }
        internal DayOfWeek Day { get; set; }
        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="MovableComposition"/>.
        /// </summary>
        /// <param name="parent">Elément de syntax parent.</param>
        /// <param name="count">Adjectif numéral pour la position du jour.</param>
        /// <param name="dayOfWeek">Jour particulier.</param>
        public MovableComposition(ExpressionElement parent, Count count, DayOfWeek dayOfWeek) : base(parent)
        {
            Count = count;
            Day = Day;
        }
        /// <summary>
        /// Elément de syntax pour indiquer que c'est avant une date précise.
        /// </summary>
        /// <param name="value">Date avant laquelle le jour doit se trouver.</param>
        /// <returns>L'élément de syntax <see cref="BeforeComposition"/> pour ajouter d'autres comportements.</returns>
        public BeforeComposition Before(string value) => new BeforeComposition(this, value);
        /// <summary>
        /// Elément de syntax pour indiquer que c'est avant le début du mois.
        /// </summary>
        /// <param name="month">Mois avant lequel le jour doit se trouver.</param>
        /// <returns>L'élément de syntax <see cref="BeforeComposition"/> pour ajouter d'autres comportements.</returns>
        public BeforeComposition Before(Month month)
        {
            switch (month)
            {
                case January:
                    return new BeforeComposition(this, "01-01");
                case February:
                    return new BeforeComposition(this, "02-01");
                case March:
                    return new BeforeComposition(this, "03-01");
                case April:
                    return new BeforeComposition(this, "04-01");
                case May:
                    return new BeforeComposition(this, "05-01");
                case June:
                    return new BeforeComposition(this, "06-01");
                case July:
                    return new BeforeComposition(this, "07-01");
                case August:
                    return new BeforeComposition(this, "08-01");
                case September:
                    return new BeforeComposition(this, "09-01");
                case October:
                    return new BeforeComposition(this, "10-01");
                case November:
                    return new BeforeComposition(this, "11-01");
                case December:
                    return new BeforeComposition(this, "12-01");
                default:
                    return new BeforeComposition(this, "01-01");
            }
        }
        /// <summary>
        /// Elément de syntax pour indiquer que c'est après une date précise.
        /// </summary>
        /// <param name="value">Date après laquelle le jour doit se trouver.</param>
        /// <returns>L'élément de syntax <see cref="AfterComposition"/> pour ajouter d'autres comportements.</returns>
        public AfterComposition After(string value) => new AfterComposition(this, value);
        /// <summary>
        /// Elément de syntax pour indiquer que c'est ap^rès le début du mois.
        /// </summary>
        /// <param name="month">Mois à partir duquel le jour doit se trouver.</param>
        /// <returns>L'élément de syntax <see cref="AfterComposition"/> pour ajouter d'autres comportements.</returns>
        public AfterComposition In(Month month)
        {
            switch (month)
            {
                case January:
                    return new AfterComposition(this, "01-01");
                case February:
                    return new AfterComposition(this, "02-01");
                case March:
                    return new AfterComposition(this, "03-01");
                case April:
                    return new AfterComposition(this, "04-01");
                case May:
                    return new AfterComposition(this, "05-01");
                case June:
                    return new AfterComposition(this, "06-01");
                case July:
                    return new AfterComposition(this, "07-01");
                case August:
                    return new AfterComposition(this, "08-01");
                case September:
                    return new AfterComposition(this, "09-01");
                case October:
                    return new AfterComposition(this, "10-01");
                case November:
                    return new AfterComposition(this, "11-01");
                case December:
                    return new AfterComposition(this, "12-01");
                default:
                    return new AfterComposition(this, "01-01");
            }
        }
    }
}
