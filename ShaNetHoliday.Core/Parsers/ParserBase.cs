using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShaNetHoliday.Core.Parsers
{
    /// <summary>
    /// Classe de base pour un parser d'expression.
    /// </summary>
    public abstract class ParserBase
    {
        /// <summary>
        /// Méthode qui permet de parser une expression.
        /// </summary>
        /// <param name="expression">Expression à parser.</param>
        /// <param name="year">Année souhaitée.</param>
        /// <returns>Le <see cref="ParserResult"/> correspondant.</returns>
        public abstract ParserResult Parse( string expression, int year );

        /// <summary>
        /// Méthode qui permet de déterminer si une expression peut être interpréter par le parser.
        /// </summary>
        /// <param name="expression">Expression à tester.</param>
        /// <returns>
        /// <see langword="true"/> si l'expression match le pattern, <see langword="false"/> sinon.
        /// </returns>
        public abstract bool IsMatch( string expression );
    }
}
