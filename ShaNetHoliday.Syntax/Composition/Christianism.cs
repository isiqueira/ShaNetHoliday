using ShaNetHoliday.Core.Models;
using ShaNetHoliday.Syntax.Parsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShaNetHoliday.Core.Parsers;

namespace ShaNetHoliday.Syntax.Composition
{
    /// <summary>
    /// Elément d'expression <see cref="Christianism"/>.
    /// </summary>
    public class Christianism : ExpressionElement
    {
        /// <summary>
        /// Expression pour <see cref="CarnivalMonday"/> 48 jours avant le dimanche de Pâques.
        /// </summary>
        /// <returns>Le <see cref="EasterDay"/> correspondant.</returns>
        public EasterDay CarnivalMonday => new EasterDay( this, "EASTER -48" );

        /// <summary>
        /// Expression pour <see cref="CarnivalTuesday"/> 47 jours avant le dimanche de Pâques.
        /// </summary>
        /// <returns>Le <see cref="EasterDay"/> correspondant.</returns>
        public EasterDay CarnivalTuesday => new EasterDay( this, "EASTER -47" );

        /// <summary>
        /// Expression pour <see cref="AshWednesday"/> 46 jours avant le dimanche de Pâques.
        /// </summary>
        /// <returns>Le <see cref="EasterDay"/> correspondant.</returns>
        public EasterDay AshWednesday => new EasterDay( this, "EASTER -46" );

        /// <summary>
        /// Expression pour <see cref="PalmSunday"/> 7 jours avant le dimanche de Pâques.
        /// </summary>
        /// <returns>Le <see cref="EasterDay"/> correspondant.</returns>
        public EasterDay PalmSunday => new EasterDay( this, "EASTER -7" );

        /// <summary>
        /// Expression pour <see cref="MaundyThursday"/> 3 jours avant le dimanche de Pâques.
        /// </summary>
        /// <returns>Le <see cref="EasterDay"/> correspondant.</returns>
        public EasterDay MaundyThursday => new EasterDay( this, "EASTER -3" );

        /// <summary>
        /// Expression pour <see cref="GoodFriday"/> 2 jours avant le dimanche de Pâques.
        /// </summary>
        /// <returns>Le <see cref="EasterDay"/> correspondant.</returns>
        public EasterDay GoodFriday => new EasterDay( this, "EASTER -2" );

        /// <summary>
        /// Expression pour <see cref="HolySaturday"/> 1 jour avant le dimanche de Pâques.
        /// </summary>
        /// <returns>Le <see cref="EasterDay"/> correspondant.</returns>
        public EasterDay HolySaturday => new EasterDay( this, "EASTER -1" );

        /// <summary>
        /// Expression pour <see cref="Easter"/> le dimanche de Pâques.
        /// </summary>
        /// <returns>Le <see cref="EasterDay"/> correspondant.</returns>
        public EasterDay Easter => new EasterDay( this, "EASTER" );

        /// <summary>
        /// Expression pour <see cref="EasterMonday"/> 1 jour après le dimanche de Pâques.
        /// </summary>
        /// <returns>Le <see cref="EasterDay"/> correspondant.</returns>
        public EasterDay EasterMonday => new EasterDay( this, "EASTER +1" );

        /// <summary>
        /// Expression pour <see cref="AscensionDay"/> 39 jours après le dimanche de Pâques.
        /// </summary>
        /// <returns>Le <see cref="EasterDay"/> correspondant.</returns>
        public EasterDay AscensionDay => new EasterDay( this, "EASTER +39" );

        /// <summary>
        /// Expression pour <see cref="Pentecost"/> 49 jours après le dimanche de Pâques.
        /// </summary>
        /// <returns>Le <see cref="EasterDay"/> correspondant.</returns>
        public EasterDay Pentecost => new EasterDay( this, "EASTER +49" );

        /// <summary>
        /// Expression pour <see cref="WhitMonday"/> 50 jours après le dimanche de Pâques.
        /// </summary>
        /// <returns>Le <see cref="EasterDay"/> correspondant.</returns>
        public EasterDay WhitMonday => new EasterDay( this, "EASTER +50" );

        /// <summary>
        /// Expression pour <see cref="CorpusChristi"/> 60 jours après le dimanche de Pâques.
        /// </summary>
        /// <returns>Le <see cref="EasterDay"/> correspondant.</returns>
        public EasterDay CorpusChristi => new EasterDay( this, "EASTER +60" );

        /// <summary>
        /// Expression pour un <see cref="EasterDay"/> personalisé par rapport au dimanche de Pâques..
        /// </summary>
        /// <param name="value">Expression du jour particulier.</param>
        /// <returns>Le <see cref="EasterDay"/> correspondant.</returns>
        public EasterDay CustomDay( string value ) => new EasterDay( this, value );

        /// <summary>
        /// <see cref="ParserEaster"/> associé à l'élément.
        /// </summary>
        protected override ParserBase Parser => new ParserEaster();

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="Christianism"/>.
        /// </summary>
        /// <param name="parent">Elément parent.</param>
        public Christianism( ExpressionElement parent ) : base( parent ) { }
    }
}
