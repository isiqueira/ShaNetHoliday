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
    ///// <summary>
    ///// Elément racine pour la création d'une expression d'un jour.
    ///// </summary>
    //public class Date : ExpressionElement
    //{
    //    /// <summary>
    //    /// Token de l'élément.
    //    /// </summary>
    //    protected override string Token => "DATE";
    //    /// <summary>
    //    /// Initialise une nouvelle instance de la classe <see cref="Date"/>.
    //    /// </summary>
    //    public Date() : base(null) { }
    //    /// <summary>
    //    /// Elément de syntax pour créer une expression sur un jour fixe.
    //    /// </summary>
    //    /// <param name="value">Date.</param>
    //    /// <returns>
    //    /// L'élément <see cref="FixDay"/>.
    //    /// </returns>
    //    public FixDay Fix(DateTime value) => new FixDay(this, value);
    //    /// <summary>
    //    /// Elément de syntax pour créer une expression sur un jour fixe d'une année en particulier.
    //    /// </summary>
    //    /// <param name="value">Date.</param>
    //    /// <returns>
    //    /// L'élément <see cref="SpecificDay"/>.
    //    /// </returns>
    //    public SpecificDay Specific(DateTime value) => new SpecificDay(this, value);
    //    /// <summary>
    //    /// Elément de syntax pour créer une expression sur un jour en rapport avec le dimanche de Pâques catholique.
    //    /// </summary>
    //    /// <returns>
    //    /// L'élément <see cref="Catholic"/>.
    //    /// </returns>
    //    public Catholic Catholic => new Catholic(this);
    //    /// <summary>
    //    /// Elément de syntax pour créer une expression sur un jour en rapport avec le dimanche de Pâques orthodoxe.
    //    /// </summary>
    //    /// <returns>
    //    /// L'élément <see cref="Orthodox"/>.
    //    /// </returns>
    //    public Orthodox Orthodox => new Orthodox(this);

    //    /// <summary>
    //    /// Elément de syntax pour créer une expression d'un jour non fixe basé sur un nombre d'occurrence.
    //    /// </summary>
    //    /// <param name="count">Adjectif numéral de <paramref name="day"/>.</param>
    //    /// <param name="day">Jour particulier.</param>
    //    /// <returns>
    //    /// L'élément <see cref="Movable"/>.
    //    /// </returns>
    //    public Movable Movable(Count count, DayOfWeek day) => new Movable(this, count, day);
    //    /// <summary>
    //    /// Elément de syntax pour créer une expression d'un jour non fixe basé sur un autre jour non fixe tous deux basés sur un nombre d'occurrence.
    //    /// </summary>
    //    /// <param name="count">Adjectif numéral de <paramref name="day"/>.</param>
    //    /// <param name="day">Jour particulier.</param>
    //    /// <returns>
    //    /// L'élément <see cref="MovableFromMovable"/>.
    //    /// </returns>
    //    public MovableFromMovable MovableFromMovable(Count count, DayOfWeek day) => new MovableFromMovable(this, count, day);

    //    /// <summary>
    //    /// Elément de syntax pour créer une expression basé sur un jour fixe.
    //    /// </summary>
    //    public class FixDay : FixDayBase
    //    {
    //        /// <summary>
    //        /// <see cref="ParserDate"/> associé à l'élément.
    //        /// </summary>
    //        protected override ParserBase Parser => new ParserDate();
    //        /// <summary>
    //        /// Initialise une nouvelle instance de la classe <see cref="FixDay"/>.
    //        /// </summary>
    //        /// <param name="parent">Elément parent.</param>
    //        /// <param name="value">Date.</param>
    //        public FixDay(ExpressionElement parent, DateTime value) : base(parent, value) { }
    //        /// <summary>
    //        /// Elément de syntax pour indiquer l'heure de début.
    //        /// </summary>
    //        /// <param name="value">Heure de début.</param>
    //        /// <returns>L'élément <see cref="StartDay"/> correspondant.</returns>
    //        public StartDay Start(string value) => new StartDay(this, value);
    //        /// <summary>
    //        /// Elément de syntax pour indiquer la durée.
    //        /// </summary>
    //        /// <param name="value">Durée.</param>
    //        /// <returns>L'élément <see cref="Syntax.Duration"/> correspondant.</returns>
    //        public Duration Duration(string value) => new Duration(this, value);
    //        /// <summary>
    //        /// Elément de syntax pour indiquer le type d'année.
    //        /// </summary>
    //        /// <param name="type">Type de l'année.</param>
    //        /// <returns>L'élément <see cref="InYear"/> correspondant.</returns>
    //        public InYear In(Year type) => new InYear(this, type);
    //        /// <summary>
    //        /// Elément de syntax pour indiquer la récurrence par rapport à un nombre d'année.
    //        /// </summary>
    //        /// <param name="number">Nombre d'années.</param>
    //        /// <returns>L'élément <see cref="Syntax.Every"/> correspondant.</returns>
    //        public Every Every(int number) => new Every(this, number);

    //        /// <summary>
    //        /// Elément de syntax pour indiquer l'heure de début.
    //        /// </summary>
    //        public class StartDay : Start
    //        {
    //            /// <summary>
    //            /// Initialise une nouvelle instance de la classe <see cref="StartDay"/>.
    //            /// </summary>
    //            /// <param name="parent">Elément parent.</param>
    //            /// <param name="value">Heure de début.</param>
    //            public StartDay(ExpressionElement parent, string value) : base(parent, value) { }
    //            /// <summary>
    //            /// Elément de syntax pour indiquer la durée.
    //            /// </summary>
    //            /// <param name="value">Durée.</param>
    //            /// <returns>L'élément <see cref="Syntax.Duration"/> correspondant.</returns>
    //            public Duration Duration(string value) => new Duration(this, value);
    //            /// <summary>
    //            /// Elément de syntax de test de jour particulier.
    //            /// </summary>
    //            /// <param name="day">Jour particulier.</param>
    //            /// <returns>L'élément <see cref="IfDay"/> correspondant.</returns>
    //            public IfDay If(DayOfWeek day) => new IfDay(this, day);
    //        }
    //        /// <summary>
    //        /// Elément de syntax de test de jour particulier.
    //        /// </summary>
    //        public class IfDay : If
    //        {
    //            /// <summary>
    //            /// Initialise une nouvelle instance de la classe <see cref="IfDay"/>.
    //            /// </summary>
    //            /// <param name="parent">Elément parent.</param>
    //            /// <param name="day">Jour particulier.</param>
    //            public IfDay(ExpressionElement parent, DayOfWeek day) : base(parent, day) { }
    //            /// <summary>
    //            /// Elément de syntax de date alternative en cas de réussite du test.
    //            /// </summary>
    //            /// <param name="value">Date.</param>
    //            /// <returns>L'élément <see cref="ThenDay"/> correspondant.</returns>
    //            public ThenDay Then(string value) => new ThenDay(this, value);
    //        }
    //        /// <summary>
    //        /// Elément de syntax de date alternative en cas de réussite du test.
    //        /// </summary>
    //        public class ThenDay : Then
    //        {
    //            /// <summary>
    //            /// Token de l'élément.
    //            /// </summary>
    //            protected override string Token => Value;
    //            internal string Value { get; set; }
    //            /// <summary>
    //            /// Initialise une nouvelle instance de la classe <see cref="ThenDay"/>.
    //            /// </summary>
    //            /// <param name="parent">Elément parent.</param>
    //            /// <param name="value">Date alternative.</param>
    //            public ThenDay(ExpressionElement parent, string value) : base(parent) { Value = value; }
    //        }
    //    }
    //    /// <summary>
    //    /// Elément de syntax pour créer une expression sur un jour fixe d'une année en particulier.
    //    /// </summary>
    //    public class SpecificDay : SpecificDayBase
    //    {
    //        /// <summary>
    //        /// <see cref="ParserDate"/> associé à l'élément.
    //        /// </summary>
    //        protected override ParserBase Parser => new ParserDate();
    //        /// <summary>
    //        /// Initialise une nouvelle instance de la classe <see cref="SpecificDay"/>.
    //        /// </summary>
    //        /// <param name="parent">Elément parent.</param>
    //        /// <param name="value">Date.</param>
    //        public SpecificDay(ExpressionElement parent, DateTime value) : base(parent, value) { }
    //    }
    //}
}
