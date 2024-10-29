using Shop.Data.Interfaces;

namespace Shop.Data.Models
{
    public class Items
    {
        /// <summary>
        /// Id товара
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Наименование товара
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Короткое описание
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Изображение товара
        /// </summary>
        public string Img { get; set; }
        /// <summary>
        /// Цена товара
        /// </summary>
        public int Price { get; set; }
        /// <summary>
        /// Категория товара
        /// </summary>
        public Categories Category { get; set; }

        public Items() { }

        public Items(Items item = null)
        {
            if (item != null)
            {
                this.Id = item.Id;
                this.Name = item.Name;
                this.Description = item.Description;
                this.Img = item.Img;
                this.Price = item.Price;
                this.Category = item.Category;
            }
        }
    }
}
