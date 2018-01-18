using ID3iHoliday.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ID3iHoliday.Syntax
{
    /// <summary>
    /// Syntax pour la création d'une expression de date.
    /// </summary>
    public class DateComposition : ExpressionElement
    {
        /// <summary>
        /// Token de l'élément.
        /// </summary>
        protected override string Token { get; set; } = "DATE";
        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="DateComposition"/>.
        /// </summary>
        public DateComposition() : base(null) { }
        /// <summary>
        /// Elément de syntax pour mettre en place une date fixe dans n'importe quelle année.
        /// </summary>
        /// <param name="dateTime">Date.</param>
        /// <returns>L'élément de syntax <see cref="DayComposition"/> pour ajouter d'autres comportements.</returns>
        public DayComposition Fix(DateTime dateTime) => new DayComposition(this, dateTime);
        /// <summary>
        /// Elément de syntax pour mettre en place une date fixe dans une année en particulier.
        /// </summary>
        /// <param name="dateTime">Date.</param>
        /// <returns>L'élément de syntax <see cref="SpecificDayComposition"/> pour ajouter d'autres comportements.</returns>
        public SpecificDayComposition Specific(DateTime dateTime) => new SpecificDayComposition(this, dateTime);
        /// <summary>
        /// Elément de syntax pour les dates calculées par rapport au dimanche de Pâques dans la religion catholique.
        /// </summary>
        /// <returns>L'élément de syntax <see cref="Syntax.Catholic"/>.</returns>
        public Catholic Catholic => new Catholic(this);
        /// <summary>
        /// Elément de syntax pour les dates calculées par rapport au dimanche de Pâques dans la religion othodoxe.
        /// </summary>
        /// <returns>L'élément de syntax <see cref="Syntax.Orthodox"/>.</returns>
        public Orthodox Orthodox => new Orthodox(this);
        /// <summary>
        /// Elément de syntax pour changer au jour de la semaine spécifié.
        /// </summary>
        /// <param name="count">Nombre d'apparition.</param>
        /// <param name="dayOfWeek">Jour particulier.</param>
        /// <returns>L'élément de syntax <see cref="MoveComposition"/> pour ajouter d'autres comportements.</returns>
        public MovableComposition Movable(Count count, DayOfWeek dayOfWeek) => new MovableComposition(this, count, dayOfWeek);
        /// <summary>
        /// Elément de syntax pour changer au jour de la semaine spécifié à partir d'une date fixe déjà changée.
        /// </summary>
        /// <param name="count">Nombre d'apparition.</param>
        /// <param name="dayOfWeek">Jour particulier.</param>
        /// <returns>L'élément de syntax <see cref="MoveComposition"/> pour ajouter d'autres comportements.</returns>
        public MovableFromMovableComposition MovableFromMovable(Count count, DayOfWeek dayOfWeek) => new MovableFromMovableComposition(this, count, dayOfWeek);
    }
}
