using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ID3iHoliday.Models
{
    /// <summary>
    /// Liste de région.
    /// </summary>
    public class ListRegion : BaseList<Region>
    {
        public GeographicElementBase Parent { get; set; }
        /// <summary>
        /// Se produit à l'ajout d'une région.
        /// </summary>
        /// <param name="item">Région ajoutée.</param>
        protected override void OnAddedItem(Region item)
        {
            item.Langues = Langues;
            base.OnAddedItem(item);
        }
        /// <summary>
        /// Initialisation de la liste.
        /// </summary>
        public void Init()
        {
            ForEach(x => 
            {
                x.Parent = Parent;
                x.Rules.Langues = Langues;
            });
        }
    }
}
