using ID3iHoliday.Core.Models;
using ID3iHoliday.Core.Parsers;
using ID3iHoliday.Syntax.Parsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ID3iHoliday.Syntax.Composition
{
    /// <summary>
    /// Syntax pour la création d'une expression d'observation de date supplémentaire.
    /// </summary>
    public class Observe : ExpressionElement
    {
        /// <summary>
        /// Token de l'élément.
        /// </summary>
        protected override string Token => "OBSERVE";

        /// <summary>
        /// <see cref="ParserObserve"/> associé à l'élément.
        /// </summary>
        protected override ParserBase Parser => new ParserObserve();

        /// <summary>
        /// Intialise une nouvelle instance de la classe <see cref="Observe"/>.
        /// </summary>
        public Observe() : base(null) { }

        /// <summary>
        /// Elément de syntax pour mettre en place une date fixe dans n'importe qu'elle année.
        /// </summary>
        /// <param name="dateTime">Date.</param>
        /// <returns>L'élément de syntax <see cref="SimpleDay"/> pour ajouter d'autres comportements.</returns>
        public SimpleDay Fix(DateTime dateTime) => new SimpleDay(this, dateTime);
    }
}
