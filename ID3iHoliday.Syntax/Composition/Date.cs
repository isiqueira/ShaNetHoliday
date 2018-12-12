using iD3iHoliday.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iD3iHoliday.Syntax.Composition
{
    /// <summary>
    /// Syntax pour la création d'une expression de date.
    /// </summary>
    public class Date : ExpressionElement
    {
        /// <summary>
        /// Token de l'élément.
        /// </summary>
        protected override string Token { get; set; } = "DATE";

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="Date"/>.
        /// </summary>
        public Date() : base( null ) { }

        /// <summary>
        /// Elément de syntax pour mettre en place une date fixe dans n'importe quelle année.
        /// </summary>
        /// <param name="dateTime">Date.</param>
        /// <returns>L'élément de syntax <see cref="Day"/> pour ajouter d'autres comportements.</returns>
        public Day Fix( DateTime dateTime ) => new Day( this, dateTime );

        /// <summary>
        /// Elément de syntax pour mettre en place une date fixe dans une année en particulier.
        /// </summary>
        /// <param name="dateTime">Date.</param>
        /// <returns>L'élément de syntax <see cref="SpecificDay"/> pour ajouter d'autres comportements.</returns>
        public SpecificDay Specific( DateTime dateTime ) => new SpecificDay( this, dateTime );

        /// <summary>
        /// Elément de syntax pour les dates calculées par rapport au dimanche de Pâques dans la religion catholique.
        /// </summary>
        /// <returns>L'élément de syntax <see cref="Composition.Catholic"/>.</returns>
        public Catholic Catholic => new Catholic( this );

        /// <summary>
        /// Elément de syntax pour les dates calculées par rapport au dimanche de Pâques dans la religion othodoxe.
        /// </summary>
        /// <returns>L'élément de syntax <see cref="Composition.Orthodox"/>.</returns>
        public Orthodox Orthodox => new Orthodox( this );

        /// <summary>
        /// Elément de syntax pour changer au jour de la semaine spécifié.
        /// </summary>
        /// <param name="count">Nombre d'apparition.</param>
        /// <param name="dayOfWeek">Jour particulier.</param>
        /// <returns>L'élément de syntax <see cref="Move"/> pour ajouter d'autres comportements.</returns>
        public Movable Movable( Count count, DayOfWeek dayOfWeek ) => new Movable( this, count, dayOfWeek );

        /// <summary>
        /// Elément de syntax pour changer au jour de la semaine spécifié à partir d'une date fixe déjà changée.
        /// </summary>
        /// <param name="count">Nombre d'apparition.</param>
        /// <param name="dayOfWeek">Jour particulier.</param>
        /// <returns>L'élément de syntax <see cref="Move"/> pour ajouter d'autres comportements.</returns>
        public MovableFromMovable MovableFromMovable( Count count, DayOfWeek dayOfWeek ) => new MovableFromMovable( this, count, dayOfWeek );
    }
}
