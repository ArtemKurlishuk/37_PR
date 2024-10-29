using Shop.Data.Models;
using System.Collections.Generic;

namespace Shop.Data.Interfaces
{
    public interface IItems
    {
        /// <summary>
        /// Получаем все товары
        /// </summary>
        public IEnumerable<Items> AllItems { get; }

        /// <summary>
        /// Метод добавления предмета
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public int Add(Items Item);

        /// <summary>
        /// Метод изменения
        /// </summary>
        /// <param name="Item"></param>
		public void Update(Items Item);

        /// <summary>
        /// Метод удаления
        /// </summary>
        /// <param name="id"></param>
		public void Delete(int id);
    }
}
