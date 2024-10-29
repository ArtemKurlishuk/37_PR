using Shop.Data.Models;
using System.Collections.Generic;

namespace Shop.Data.ViewModell
{
    public class VMItems
    {
        /// <summary>
        /// Предметы
        /// </summary>
        public IEnumerable<Items> Items { get; set; }
        /// <summary>
        /// Категории
        /// </summary>
        public IEnumerable<Categories> Categorys { get; set; }
        /// <summary>
        /// Корзина
        /// </summary>
        public List<ItemsBasket> ItemsBaskets { get; set; }
        /// <summary>
        /// Выбранная категория
        /// </summary>
        public int SelectCategory = 0;
    }
}
