using iD3iCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iD3iHoliday.Models
{
    /// <summary>
    /// Liste des états.
    /// </summary>
    public class ListState : BaseList<State>
    {
        /// <summary>
        /// Elément parent.
        /// </summary>
        public GeographicElementBase Parent { get; set; }

        /// <summary>
        /// Se produit à l'ajout d'un état.
        /// </summary>
        /// <param name="item">Etat ajouté.</param>
        protected override void OnAddedItem( State item )
        {
            item.Langues = Langues;
            base.OnAddedItem( item );
        }

        /// <summary>
        /// Initialisation de la liste.
        /// </summary>
        public void Init()
            => ForEach( x =>
             {
                 x.Parent = Parent;
                 x.Rules.Langues = Langues;
                 x.Regions.IfNotNull( y =>
                 {
                     y.Langues = Langues;
                     y.Init();
                 } );
             } );
    }
}
