using ID3iHoliday.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ID3iHoliday.Syntax.Composition
{
    /// <summary>
    /// Elément de syntax pour les jours en rapport avec le dimanche de Pâques dans la religion orthodoxe.
    /// </summary>
    public class Orthodox : Christianism
    {
        /// <summary>
        /// Token de l'élément.
        /// </summary>
        protected override string Token => "ORTHODOX";

        /// <summary>
        /// Initilialise une nouvelle instance de la classe <see cref="Orthodox"/>.
        /// </summary>
        /// <param name="parent">Elément de syntax parent.</param>
        public Orthodox(ExpressionElement parent) : base(parent) { }
    }
}
