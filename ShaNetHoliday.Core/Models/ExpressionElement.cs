using ShaNetHoliday.Core.Parsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShaNetHoliday.Core.Models
{
    /// <summary>
    /// Classe de base pour un élément.
    /// </summary>
    public abstract class ExpressionElement
    {
        /// <summary>
        /// Token de l'élément.
        /// </summary>
        protected virtual string Token { get; set; }

        /// <summary>
        /// Expression de l'élément.
        /// </summary>
        public virtual string Expression => $@"{( Parent != null ?
                                                ( string.IsNullOrEmpty( Token ) ?
                                                        Parent.Expression
                                                        : $"{Parent.Expression} " )
                                                : "" )}{Token}";

        /// <summary>
        /// Elément parent.
        /// </summary>
        protected virtual ExpressionElement Parent { get; }

        /// <summary>
        /// Parser associé à l'élément.
        /// </summary>
        protected virtual ParserBase Parser => Parent.Parser;

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="ExpressionElement"/>.
        /// </summary>
        /// <param name="parent">Elément parent.</param>
        protected ExpressionElement( ExpressionElement parent ) => Parent = parent;

        /// <summary>
        /// Méthode qui permet de parser l'élément.
        /// </summary>
        /// <param name="year">Année souhaitée.</param>
        /// <returns>Le <see cref="ParserResult"/> correspondant.</returns>
        public ParserResult Parse( int year ) => Parser.Parse( Expression, year );

        /// <summary>
        /// Méthode qui permet de déterminer si l'expression peut être interpréter par le parser.
        /// </summary>
        /// <returns>
        /// <see langword="true"/> si l'expression match le pattern, <see langword="false"/> sinon.
        /// </returns>
        public bool IsMatch => Parser.IsMatch( Expression );
    }
}
