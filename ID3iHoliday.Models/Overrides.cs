using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ID3iHoliday.Models
{
    /// <summary>
    /// Enumération pour indiquer quelle partie d'une règle est à surcharger.
    /// </summary>
    [Flags]
    public enum Overrides
    {
        /// <summary>
        /// Rien.
        /// </summary>
        None = 1,
        /// <summary>
        /// L'expression.
        /// </summary>
        Expression = 2,
        /// <summary>
        /// Le type.
        /// </summary>
        Type = Expression << 1,
        /// <summary>
        /// La note.
        /// </summary>
        Note = Type << 1,
        /// <summary>
        /// L'état.
        /// </summary>
        IsEnable = Note << 1,
        /// <summary>
        /// Les noms.
        /// </summary>
        Name = IsEnable << 1
    }
}
