namespace Shop.Data.Models
{
    public class ItemsBasket : Items
    {
        /// <summary>
        /// Кол-во в корзине
        /// </summary>
        public int Count { get; set; }

        public ItemsBasket(int count, Items item) : base(item)
        {
            Count = count;
        }
    }
}
