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
    public class Every : ExpressionElement
    {
        /// <summary>
        /// Token de l'élément.
        /// </summary>
        protected override string Token => $"EVERY {Number}";
        internal int Number { get; set; }
        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="Every"/>.
        /// </summary>
        /// <param name="parent">Elément de syntax parent.</param>
        /// <param name="number">Nombre de périodes.</param>
        public Every(ExpressionElement parent, int number) : base(parent) => Number = number;
        /// <summary>
        /// Elément de syntax pour le récurrence par nombre d'années.
        /// </summary>
        public Year Year => new Year(this);
    }
}
