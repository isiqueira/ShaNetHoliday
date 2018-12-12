using iD3iHoliday.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iD3iHoliday.Syntax.Composition
{
    /// <summary>
    /// Elément d'expression <see cref="Catholic"/>.
    /// </summary>
    public class Catholic : Christianism
    {
        /// <summary>
        /// Token de l'élément.
        /// </summary>
        protected override string Token => "CATHOLIC";

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="Catholic"/>.
        /// </summary>
        /// <param name="parent">Elément parent.</param>
        public Catholic( ExpressionElement parent ) : base( parent ) { }
    }
}
