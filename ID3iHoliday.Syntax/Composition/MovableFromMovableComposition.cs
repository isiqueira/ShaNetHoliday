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
    /// <summary>
    /// Elément de syntax pour changer au jour de la semaine spécifié à partir d'une date fixe déjà changée.
    /// </summary>
    public class MovableFromMovableComposition : ExpressionElement
    {
        /// <summary>
        /// Token de l'élément.
        /// </summary>
        protected override string Token => $"MOVABLE² {Count.ToString().ToUpper()} {Day.ToString().ToUpper()}";
        /// <summary>
        /// <see cref="ParserMovableFromMovable"/> associé à l'élément.
        /// </summary>
        protected override ParserBase Parser => new ParserMovableFromMovable();
        internal Count Count { get; set; }
        internal DayOfWeek Day { get; set; }
        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="MovableFromMovableComposition"/>.
        /// </summary>
        /// <param name="parent">Elément de syntax parent.</param>
        /// <param name="count">Adjectif numéral pour la position du jour.</param>
        /// <param name="dayOfWeek">Jour particulier.</param>
        public MovableFromMovableComposition(ExpressionElement parent, Count count, DayOfWeek dayOfWeek) : base(parent)
        {
            Count = count;
            Day = dayOfWeek;
        }
        /// <summary>
        /// Elément de syntax pour définir la date avant laquelle le jour sera trouvé.
        /// </summary>
        /// <param name="count">Adjectif numéral pour la position du jour.</param>
        /// <param name="dayOfWeek">Jour particulier.</param>
        /// <returns>L'élément de syntax <see cref="BeforeMovableComposition"/> pour ajouter d'autres comportements.</returns>
        public BeforeMovableComposition Before(Count count, DayOfWeek dayOfWeek) => new BeforeMovableComposition(this, count, dayOfWeek);
        /// <summary>
        /// Elément de syntax pour définir la date après laquelle le jour sera trouvé.
        /// </summary>
        /// <param name="count">Adjectif numéral pour la position du jour.</param>
        /// <param name="dayOfWeek">Jour particulier.</param>
        /// <returns>L'élément de syntax <see cref="BeforeMovableComposition"/> pour ajouter d'autres comportements.</returns>
        public AfterMovableComposition After(Count count, DayOfWeek dayOfWeek) => new AfterMovableComposition(this, count, dayOfWeek);
    }
}
