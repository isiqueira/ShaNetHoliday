using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ID3iHoliday.Models
{
    /// <summary>
    /// Classe de base pour les listes.
    /// </summary>
    /// <typeparam name="T">Type des éléments de la liste.</typeparam>
    public class BaseList<T> : List<T>
    {
        /// <summary>
        /// Liste des langues.
        /// </summary>
        public List<Langue> Langues { get; set; }

        /// <summary>
        /// Elle-même.
        /// </summary>
        public BaseList<T> Container => this;

        /// <summary>
        /// Se produit à l'ajout d'un élément.
        /// </summary>
        /// <param name="item">Elément ajouté.</param>
        protected virtual void OnAddedItem(T item) => base.Add(item);

        /// <summary>
        /// Méthode d'ajout d'un élément.
        /// </summary>
        /// <param name="item">Elément à ajouter.</param>
        public new void Add(T item) => OnAddedItem(item);
    }
}
