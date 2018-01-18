﻿using ID3iHoliday.Core.Models;
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
    public class DayComposition : ExpressionElement
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
        /// Initialise une nouvelle instance de la classe <see cref="DayComposition"/>.
        /// </summary>
        /// <param name="parent">Elément de syntax parent.</param>
        /// <param name="dateTime">Date.</param>
        public DayComposition(ExpressionElement parent, DateTime dateTime) : base(parent) => DateTime = dateTime;
        /// <summary>
        /// Elément de syntax pour indiquer l'heure de début.
        /// </summary>
        /// <param name="value">L'heure de début au format HH:mm</param>
        /// <returns>L'élément de syntax <see cref="StartComposition"/> pour ajouter d'autres comportements.</returns>
        public StartComposition StartAt(string value) => new StartComposition(this, value);
    }
}
