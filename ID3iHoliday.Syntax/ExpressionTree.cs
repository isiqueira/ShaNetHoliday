using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ID3iHoliday.Syntax
{
    /// <summary>
    /// Racine de la syntax pour les expressions.
    /// </summary>
    public static class ExpressionTree
    {
        /// <summary>
        /// Racine pour les expressions de date.
        /// </summary>
        public static DateComposition Date => new DateComposition();
        /// <summary>
        /// Racine pour les expressions de déplacement.
        /// </summary>
        public static MoveComposition Move => new MoveComposition();
        /// <summary>
        /// Racine pour les expressions d'observation.
        /// </summary>
        public static ObserveComposition Observe => new ObserveComposition();
        /// <summary>
        /// Racine pour les expressions de substitution.
        /// </summary>
        public static SubstituteComposition Substitute => new SubstituteComposition();
    }
}
