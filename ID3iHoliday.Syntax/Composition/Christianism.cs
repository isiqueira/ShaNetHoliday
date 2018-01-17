using ID3iHoliday.Core.Models;
using ID3iHoliday.Syntax.Parsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ID3iHoliday.Core.Parsers;

namespace ID3iHoliday.Syntax
{
    /// <summary>
    /// Elément d'expression <see cref="Christianism"/>.
    /// </summary>
    public class Christianism : ExpressionElement
    {
        /// <summary>
        /// Expression pour <see cref="CarnivalMonday"/> 48 jours avant le dimanche de Pâques.
        /// </summary>
        /// <returns>Le <see cref="EasterDayComposition"/> correspondant.</returns>
        public EasterDayComposition CarnivalMonday => new EasterDayComposition(this, "EASTER -48");
        /// <summary>
        /// Expression pour <see cref="CarnivalTuesday"/> 47 jours avant le dimanche de Pâques.
        /// </summary>
        /// <returns>Le <see cref="EasterDayComposition"/> correspondant.</returns>
        public EasterDayComposition CarnivalTuesday => new EasterDayComposition(this, "EASTER -47");
        /// <summary>
        /// Expression pour <see cref="AshWednesday"/> 46 jours avant le dimanche de Pâques.
        /// </summary>
        /// <returns>Le <see cref="EasterDayComposition"/> correspondant.</returns>
        public EasterDayComposition AshWednesday => new EasterDayComposition(this, "EASTER -46");
        /// <summary>
        /// Expression pour <see cref="PalmSunday"/> 7 jours avant le dimanche de Pâques.
        /// </summary>
        /// <returns>Le <see cref="EasterDayComposition"/> correspondant.</returns>
        public EasterDayComposition PalmSunday => new EasterDayComposition(this, "EASTER -7");
        /// <summary>
        /// Expression pour <see cref="MaundyThursday"/> 3 jours avant le dimanche de Pâques.
        /// </summary>
        /// <returns>Le <see cref="EasterDayComposition"/> correspondant.</returns>
        public EasterDayComposition MaundyThursday => new EasterDayComposition(this, "EASTER -3");
        /// <summary>
        /// Expression pour <see cref="GoodFriday"/> 2 jours avant le dimanche de Pâques.
        /// </summary>
        /// <returns>Le <see cref="EasterDayComposition"/> correspondant.</returns>
        public EasterDayComposition GoodFriday => new EasterDayComposition(this, "EASTER -2");
        /// <summary>
        /// Expression pour <see cref="HolySaturday"/> 1 jour avant le dimanche de Pâques.
        /// </summary>
        /// <returns>Le <see cref="EasterDayComposition"/> correspondant.</returns>
        public EasterDayComposition HolySaturday => new EasterDayComposition(this, "EASTER -1");
        /// <summary>
        /// Expression pour <see cref="Easter"/> le dimanche de Pâques.
        /// </summary>
        /// <returns>Le <see cref="EasterDayComposition"/> correspondant.</returns>
        public EasterDayComposition Easter => new EasterDayComposition(this, "EASTER");
        /// <summary>
        /// Expression pour <see cref="EasterMonday"/> 1 jour après le dimanche de Pâques.
        /// </summary>
        /// <returns>Le <see cref="EasterDayComposition"/> correspondant.</returns>
        public EasterDayComposition EasterMonday => new EasterDayComposition(this, "EASTER +1");
        /// <summary>
        /// Expression pour <see cref="AscensionDay"/> 39 jours après le dimanche de Pâques.
        /// </summary>
        /// <returns>Le <see cref="EasterDayComposition"/> correspondant.</returns>
        public EasterDayComposition AscensionDay => new EasterDayComposition(this, "EASTER +39");
        /// <summary>
        /// Expression pour <see cref="Pentecost"/> 49 jours après le dimanche de Pâques.
        /// </summary>
        /// <returns>Le <see cref="EasterDayComposition"/> correspondant.</returns>
        public EasterDayComposition Pentecost => new EasterDayComposition(this, "EASTER +49");
        /// <summary>
        /// Expression pour <see cref="WhitMonday"/> 50 jours après le dimanche de Pâques.
        /// </summary>
        /// <returns>Le <see cref="EasterDayComposition"/> correspondant.</returns>
        public EasterDayComposition WhitMonday => new EasterDayComposition(this, "EASTER +50");
        /// <summary>
        /// Expression pour <see cref="CorpusChristi"/> 60 jours après le dimanche de Pâques.
        /// </summary>
        /// <returns>Le <see cref="EasterDayComposition"/> correspondant.</returns>
        public EasterDayComposition CorpusChristi => new EasterDayComposition(this, "EASTER +60");
        /// <summary>
        /// Expression pour un <see cref="EasterDayComposition"/> personalisé par rapport au dimanche de Pâques..
        /// </summary>
        /// <param name="value">Expression du jour particulier.</param>
        /// <returns>Le <see cref="EasterDayComposition"/> correspondant.</returns>
        public EasterDayComposition CustomDay(string value) => new EasterDayComposition(this, value);
        /// <summary>
        /// <see cref="ParserEaster"/> associé à l'élément.
        /// </summary>
        protected override ParserBase Parser => new ParserEaster();
        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="Christianism"/>.
        /// </summary>
        /// <param name="parent">Elément parent.</param>
        public Christianism(ExpressionElement parent) : base(parent) { }
    }
}
