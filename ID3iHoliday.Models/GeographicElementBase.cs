using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ID3iHoliday.Models
{
    /// <summary>
    /// Représentation d'un élément géographique.
    /// </summary>
    public abstract class GeographicElementBase
    {
        /// <summary>
        /// Code.
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// Nom par défaut.
        /// </summary>
        public string DefaultName => Names.FirstOrDefault().Value;
        /// <summary>
        /// Liste des noms de l'élément.
        /// </summary>
        public Dictionary<Langue, string> Names { get; set; } = new Dictionary<Langue, string>();
        /// <summary>
        /// Liste des langues de l'élément.
        /// </summary>
        public List<Langue> Langues { get; set; } = new List<Langue>();
        /// <summary>
        /// Liste des règles de l'élément.
        /// </summary>
        public ListRule Rules { get; set; } = new ListRule();
    }   
    
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
