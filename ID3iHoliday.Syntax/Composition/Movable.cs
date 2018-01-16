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
    ///// <summary>
    ///// Elément de syntax pour créer une expression d'un jour non fixe basé sur un nombre d'occurrence.
    ///// </summary>
    //public class Movable : ExpressionElement
    //{
    //    /// <summary>
    //    /// Token de l'élément.
    //    /// </summary>
    //    protected override string Token => $"MOVABLE {Count.ToString().ToUpper()} {Day.ToString().ToUpper()}";
    //    /// <summary>
    //    /// <see cref="ParserMovable"/> associé à l'élément.
    //    /// </summary>
    //    protected override ParserBase Parser => new ParserMovable();
    //    internal Count Count { get; set; }
    //    internal DayOfWeek Day { get; set; }
    //    /// <summary>
    //    /// Initialise une nouvelle instance de la classe <see cref="Movable"/>.
    //    /// </summary>
    //    /// <param name="parent">Elément parent.</param>
    //    /// <param name="count">Adjectif numéral de <paramref name="day"/>.</param>
    //    /// <param name="day">Jour particulier.</param>
    //    public Movable(ExpressionElement parent, Count count, DayOfWeek day) : base(parent)
    //    {
    //        Count = count;
    //        Day = day;
    //    }
    //    /// <summary>
    //    /// Elément de syntax pour indiquer que c'est avant une date particulière.
    //    /// </summary>
    //    /// <param name="value">Date particulière.</param>
    //    /// <returns>Le <see cref="BeforeDay"/> correspondant.</returns>
    //    public BeforeDay Before(string value) => new BeforeDay(this, value);
    //    /// <summary>
    //    /// Elément de syntax pour indiquer que c'est avant le début d'un mois.
    //    /// </summary>
    //    /// <param name="month">Mois.</param>
    //    /// <returns>Le <see cref="BeforeDay"/> correspondant.</returns>
    //    public BeforeDay Before(Month month)
    //    {
    //        switch (month)
    //        {
    //            case January:
    //                return new BeforeDay(this, "01-01");
    //            case February:
    //                return new BeforeDay(this, "02-01");
    //            case March:
    //                return new BeforeDay(this, "03-01");
    //            case April:
    //                return new BeforeDay(this, "04-01");
    //            case May:
    //                return new BeforeDay(this, "05-01");
    //            case June:
    //                return new BeforeDay(this, "06-01");
    //            case July:
    //                return new BeforeDay(this, "07-01");
    //            case August:
    //                return new BeforeDay(this, "08-01");
    //            case September:
    //                return new BeforeDay(this, "09-01");
    //            case October:
    //                return new BeforeDay(this, "10-01");
    //            case November:
    //                return new BeforeDay(this, "11-01");
    //            case December:
    //                return new BeforeDay(this, "12-01");
    //            default:
    //                return new BeforeDay(this, "01-01");
    //        }
    //    }
    //    /// <summary>
    //    /// Elément de syntax pour indiquer que c'est après une date particulière.
    //    /// </summary>
    //    /// <param name="value">Date particulière.</param>
    //    /// <returns>Le <see cref="AfterDay"/> correspondant.</returns>
    //    public AfterDay After(string value) => new AfterDay(this, value);
    //    /// <summary>
    //    /// Elément de syntax pour indiquer que c'est après le début d'un mois.
    //    /// </summary>
    //    /// <param name="month">Mois.</param>
    //    /// <returns>Le <see cref="AfterDay"/> correspondant.</returns>
    //    public AfterDay In(Month month)
    //    {
    //        switch (month)
    //        {
    //            case January:
    //                return new AfterDay(this, "01-01");
    //            case February:
    //                return new AfterDay(this, "02-01");
    //            case March:
    //                return new AfterDay(this, "03-01");
    //            case April:
    //                return new AfterDay(this, "04-01");
    //            case May:
    //                return new AfterDay(this, "05-01");
    //            case June:
    //                return new AfterDay(this, "06-01");
    //            case July:
    //                return new AfterDay(this, "07-01");
    //            case August:
    //                return new AfterDay(this, "08-01");
    //            case September:
    //                return new AfterDay(this, "09-01");
    //            case October:
    //                return new AfterDay(this, "10-01");
    //            case November:
    //                return new AfterDay(this, "11-01");
    //            case December:
    //                return new AfterDay(this, "12-01");
    //            default:
    //                return new AfterDay(this, "01-01");
    //        }
    //    }

    //    /// <summary>
    //    /// Elément de syntax pour l'expression avant.
    //    /// </summary>
    //    public class BeforeDay : Before
    //    {
    //        /// <summary>
    //        /// Token de l'élément.
    //        /// </summary>
    //        protected override string Token => $"BEFORE {Value}";
    //        internal string Value { get; set; }
    //        /// <summary>
    //        /// Intialise une nouvelle instance de la classe <see cref="BeforeDay"/>.
    //        /// </summary>
    //        /// <param name="parent">Elément parent.</param>
    //        /// <param name="value">Date particulière.</param>
    //        public BeforeDay(ExpressionElement parent, string value) : base(parent) { Value = value; }
    //        /// <summary>
    //        /// Elément de syntax pour indiquer le type d'année.
    //        /// </summary>
    //        /// <param name="type">Type de l'année.</param>
    //        /// <returns>L'élément <see cref="InYear"/> correspondant.</returns>
    //        public InYear In(Year type) => new InYear(this, type);
    //        /// <summary>
    //        /// Elément de syntax pour indiquer la récurrence par rapport à un nombre d'année.
    //        /// </summary>
    //        /// <param name="year">Nombre d'années.</param>
    //        /// <returns>L'élément <see cref="Syntax.Every"/> correspondant.</returns>
    //        public Every Every(int year) => new Every(this, year);
    //    }
    //    /// <summary>
    //    /// Elément de syntax pour l'expression après.
    //    /// </summary>
    //    public class AfterDay : After
    //    {
    //        /// <summary>
    //        /// Token de l'élément.
    //        /// </summary>
    //        protected override string Token => $"AFTER {Value}";
    //        internal string Value { get; set; }
    //        /// <summary>
    //        /// Intialise une nouvelle instance de la classe <see cref="AfterDay"/>.
    //        /// </summary>
    //        /// <param name="parent">Elément parent.</param>
    //        /// <param name="value">Date particulière.</param>
    //        public AfterDay(ExpressionElement parent, string value) : base(parent) { Value = value; }
    //        /// <summary>
    //        /// Elément de syntax pour indiquer le type d'année.
    //        /// </summary>
    //        /// <param name="type">Type de l'année.</param>
    //        /// <returns>L'élément <see cref="InYear"/> correspondant.</returns>
    //        public InYear In(Year type) => new InYear(this, type);
    //        /// <summary>
    //        /// Elément de syntax pour indiquer la récurrence par rapport à un nombre d'année.
    //        /// </summary>
    //        /// <param name="year">Nombre d'années.</param>
    //        /// <returns>L'élément <see cref="Syntax.Every"/> correspondant.</returns>
    //        public Every Every(int year) => new Every(this, year);
    //    }
    //}
}
