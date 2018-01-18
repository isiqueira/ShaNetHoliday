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
    /// Elément de syntax pour définir la date avant laquelle le jour sera trouvé.
    /// </summary>
    public class BeforeMovable : Movable
    {
        /// <summary>
        /// Token de l'élément.
        /// </summary>
        protected override string Token => $"BEFORE {Count.ToString().ToUpper()} {Day.ToString().ToUpper()}";
        /// <summary>
        /// <see cref="ParserMovableFromMovable"/> associé à l'élément.
        /// </summary>
        protected override ParserBase Parser => new ParserMovableFromMovable();
        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="BeforeMovable"/>.
        /// </summary>
        /// <param name="parent">Elément de syntax parent.</param>
        /// <param name="count">Adjectif numéral pour la position du jour.</param>
        /// <param name="dayOfWeek">Jour particulier.</param>
        public BeforeMovable(ExpressionElement parent, Count count, DayOfWeek dayOfWeek) : base(parent, count, dayOfWeek) { }
    }
}
