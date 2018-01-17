using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ID3iHoliday.Models
{
    /// <summary>
    /// Langues.
    /// </summary>
    /// <remarks>https://fr.wikipedia.org/wiki/Liste_des_codes_ISO_639-1</remarks>
    public enum Langue
    {
        /// <summary>
        /// French.
        /// </summary>
        FR,
        /// <summary>
        /// English.
        /// </summary>
        EN,
        /// <summary>
        /// Belarusian.
        /// </summary>
        BE,
        /// <summary>
        /// Bulgarian.
        /// </summary>
        BG,
        /// <summary>
        /// Bosnian.
        /// </summary>
        BS,
        /// <summary>
        /// Catalan.
        /// </summary>
        CA,
        /// <summary>
        /// Czech.
        /// </summary>
        CZ,
        /// <summary>
        /// Greek.
        /// </summary>
        EL,
        /// <summary>
        /// Spanish.
        /// </summary>
        ES,
        /// <summary>
        /// Estonian.
        /// </summary>
        ET,
        /// <summary>
        /// Danish.
        /// </summary>
        DA,
        /// <summary>
        /// German.
        /// </summary>
        DE,
        /// <summary>
        /// German - Austria.
        /// </summary>
        DE_AT,
        /// <summary>
        /// Finnish.
        /// </summary>
        FI,
        /// <summary>
        /// Croatian.
        /// </summary>
        HR,
        /// <summary>
        /// Dutch.
        /// </summary>
        NL,
        /// <summary>
        /// Russian.
        /// </summary>
        RU,
        /// <summary>
        /// Albanian.
        /// </summary>
        SQ,
        /// <summary>
        /// Serbian.
        /// </summary>
        SR,
        /// <summary>
        /// Swedish.
        /// </summary>
        SV
    }
    /// <summary>
    /// Enumération des type de règles.
    /// </summary>
    public enum RuleType
    {
        /// <summary>
        /// Tout type.
        /// </summary>
        All,
        /// <summary>
        /// Jour férié pour tout le monde.
        /// </summary>
        Public,
        /// <summary>
        /// Jour férié applicable aux banques.
        /// </summary>
        Bank,
        /// <summary>
        /// Jour férié applicable aux écoles.
        /// </summary>
        School,
        /// <summary>
        /// Jour férié non imposé.
        /// </summary>
        Optional,
        /// <summary>
        /// Jour non férié.
        /// </summary>
        Observance
    }
}
