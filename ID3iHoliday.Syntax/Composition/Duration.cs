using ID3iHoliday.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ID3iHoliday.Syntax.Composition
{
    /// <summary>
    /// Elément de syntax pour gérer la durée.
    /// </summary>
    public class Duration : ExpressionElement
    {
        /// <summary>
        /// Token de l'élément.
        /// </summary>
        protected override string Token => $"{Value}";
        internal string Value { get; set; }
        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="Duration"/>.
        /// </summary>
        /// <param name="parent">Elément de syntax parent.</param>
        /// <param name="value">Durée.</param>
        public Duration(ExpressionElement parent, string value) : base(parent) => Value = value;
        /// <summary>
        /// Elément de syntax pour gérer la récurrence selon un nombre de période.
        /// </summary>
        /// <param name="number">Nombre de période.</param>
        /// <returns>L'élément de syntax <see cref="Composition.Every"/> pour ajouter d'autres comportements.</returns>
        public Every Every(int number) => new Every(this, number);
        /// <summary>
        /// Elément de syntax pour gérer le type d'année pris en charge.
        /// </summary>
        /// <param name="year">Type de l'année.</param>
        /// <returns>L'élément de syntax <see cref="InYear"/> pour ajouter d'autres comportements.</returns>
        public InYear In(YearType year) => new InYear(this, year);
        /// <summary>
        /// Elément de syntax pour changer l'heure de début selon le jour.
        /// </summary>
        /// <param name="dayOfWeek">Jour particulier.</param>
        /// <returns>L'élément de syntax <see cref="Composition.If"/> pour ajouter d'autres comportements.</returns>
        public If If(DayOfWeek dayOfWeek) => new If(this, dayOfWeek);
    }
}
