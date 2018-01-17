using ID3iCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ID3iHoliday.Models
{
    /// <summary>
    /// Réprésentation d'un état.
    /// </summary>
    public class State : GeographicElementBase
    {
        /// <summary>
        /// Liste des régions de l'état.
        /// </summary>
        public ListRegion Regions { get; set; } = new ListRegion();
    }

    /// <summary>
    /// Liste des états.
    /// </summary>
    public class ListState : BaseList<State>
    {
        /// <summary>
        /// Se produit à l'ajout d'un état.
        /// </summary>
        /// <param name="item">Etat ajouté.</param>
        protected override void OnAddedItem(State item)
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
                x.Rules.Langues = Langues;
                x.Regions.IfNotNull(y =>
                {
                    y.Langues = Langues;
                    y.Init();
                });
            });
        }
    }
}
