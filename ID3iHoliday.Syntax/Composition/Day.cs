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
    /// Elément de syntax pour mettre en place une date fixe dans n'importe quelle année.
    /// </summary>
    public class Day : ExpressionElement
    {
        /// <summary>
        /// Token de l'élément.
        /// </summary>
        protected override string Token => DateTime.ToString("MM-dd");
        /// <summary>
        /// <see cref="ParserDate"/> associé à l'élément.
        /// </summary>
        protected override ParserBase Parser => new ParserDate();
        internal DateTime DateTime { get; }
        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="Day"/>.
        /// </summary>
        /// <param name="parent">Elément de syntax parent.</param>
        /// <param name="dateTime">Date.</param>
        public Day(ExpressionElement parent, DateTime dateTime) : base(parent) => DateTime = dateTime;
        /// <summary>
        /// Elément de syntax pour indiquer l'heure de début.
        /// </summary>
        /// <param name="value">L'heure de début au format HH:mm</param>
        /// <returns>L'élément de syntax <see cref="Start"/> pour ajouter d'autres comportements.</returns>
        public Start StartAt(string value) => new Start(this, value);

        /// <summary>
        /// Elément de syntax pour gérer le début d'application de l'expression.
        /// </summary>
        /// <param name="year">Année de départ.</param>
        /// <returns>L'élément de syntax <see cref="Syntax.Since"/> pour ajouter d'autres comportements.</returns>
        public Since Since(int year) => StartAt("00:00").UntilMidnight.Every(1).Year.Since(year);
    }
}
