using ID3iHoliday.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ID3iHoliday.Syntax
{
    /// <summary>
    /// Elément de syntax pour gérer la récurrence selon un nombre de périodes.
    /// </summary>
    public class EveryComposition : ExpressionElement
    {
        /// <summary>
        /// Token de l'élément.
        /// </summary>
        protected override string Token => $"EVERY {Number}";
        internal int Number { get; set; }
        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="EveryComposition"/>.
        /// </summary>
        /// <param name="parent">Elément de syntax parent.</param>
        /// <param name="number">Nombre de périodes.</param>
        public EveryComposition(ExpressionElement parent, int number) : base(parent) => Number = number;
        /// <summary>
        /// Elément de syntax pour le récurrence par nombre d'années.
        /// </summary>
        public YearComposition Year => new YearComposition(this);
    }
}
