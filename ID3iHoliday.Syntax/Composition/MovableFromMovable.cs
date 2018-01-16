using ID3iHoliday.Core.Models;
using ID3iHoliday.Core.Parsers;
using ID3iHoliday.Syntax.Parsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ID3iHoliday.Syntax
{
    ///// <summary>
    ///// Elément de syntax pour créer une expression d'un jour non fixe basé sur un autre jour non fixe tous deux basés sur un nombre d'occurrence.
    ///// </summary>
    //public class MovableFromMovable : ExpressionElement
    //{
    //    /// <summary>
    //    /// Token de l'élément.
    //    /// </summary>
    //    protected override string Token => $"MOVABLE² {Count.ToString().ToUpper()} {Day.ToString().ToUpper()}";
    //    /// <summary>
    //    /// <see cref="ParserMovableFromMovable"/> associé à l'élément.
    //    /// </summary>
    //    protected override ParserBase Parser => new ParserMovableFromMovable();
    //    internal Count Count { get; set; }
    //    internal DayOfWeek Day { get; set; }
    //    /// <summary>
    //    /// Initialise une nouvelle instance de la classe <see cref="MovableFromMovable"/>.
    //    /// </summary>
    //    /// <param name="parent">Elément parent.</param>
    //    /// <param name="count">Adjectif numéral de <paramref name="day"/>.</param>
    //    /// <param name="day">Jour particulier.</param>
    //    public MovableFromMovable(ExpressionElement parent, Count count, DayOfWeek day) : base(parent)
    //    {
    //        Count = count;
    //        Day = day;
    //    }
    //    /// <summary>
    //    /// Elément de syntax pour indiquer que c'est avant un jour non fixe.
    //    /// </summary>
    //    /// <param name="count">Adjectif numéral de <paramref name="day"/>.</param>
    //    /// <param name="day">Jour particulier.</param>
    //    /// <returns>Le <see cref="BeforeMovable"/> correspondant.</returns>
    //    public BeforeMovable Before(Count count, DayOfWeek day) => new BeforeMovable(this, count, day);
    //    /// <summary>
    //    /// Elément de syntax pour indiquer que c'est après un jour non fixe.
    //    /// </summary>
    //    /// <param name="count">Adjectif numéral de <paramref name="day"/>.</param>
    //    /// <param name="day">Jour particulier.</param>
    //    /// <returns>Le <see cref="AfterMovable"/> correspondant.</returns>
    //    public AfterMovable After(Count count, DayOfWeek day) => new AfterMovable(this, count, day);

    //    /// <summary>
    //    /// Elément de syntax pour l'expression avant.
    //    /// </summary>
    //    public class BeforeMovable : Movable
    //    {
    //        /// <summary>
    //        /// Token de l'élément.
    //        /// </summary>
    //        protected override string Token => $"BEFORE {Count.ToString().ToUpper()} {Day.ToString().ToUpper()}";
    //        /// <summary>
    //        /// <see cref="ParserBase"/> associé à l'élément.
    //        /// </summary>
    //        protected override ParserBase Parser => ((MovableFromMovable)Parent).Parser;
    //        /// <summary>
    //        /// Initialise une nouvelle instance de la classe <see cref="BeforeMovable"/>   
    //        /// </summary>
    //        /// <param name="parent">Elément parent.</param>
    //        /// <param name="count">Adjectif numéral de <paramref name="day"/>.</param>
    //        /// <param name="day">Jour particulier.</param>
    //        public BeforeMovable(ExpressionElement parent, Count count, DayOfWeek day) : base(parent, count, day) { }
    //    }
    //    /// <summary>
    //    /// Elément de syntax pour l'expression après.
    //    /// </summary>
    //    public class AfterMovable : Movable
    //    {
    //        /// <summary>
    //        /// Token de l'élément.
    //        /// </summary>
    //        protected override string Token => $"AFTER {Count.ToString().ToUpper()} {Day.ToString().ToUpper()}";
    //        /// <summary>
    //        /// <see cref="ParserBase"/> associé à l'élément.
    //        /// </summary>
    //        protected override ParserBase Parser => ((MovableFromMovable)Parent).Parser;
    //        /// <summary>
    //        /// Initialise une nouvelle instance de la classe <see cref="AfterMovable"/>   
    //        /// </summary>
    //        /// <param name="parent">Elément parent.</param>
    //        /// <param name="count">Adjectif numéral de <paramref name="day"/>.</param>
    //        /// <param name="day">Jour particulier.</param>
    //        public AfterMovable(ExpressionElement parent, Count count, DayOfWeek day) : base(parent, count, day) { }
    //    }
    //}
}
