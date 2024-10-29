using MySql.Data.MySqlClient;
using Shop.Data.Common;
using Shop.Data.Interfaces;
using Shop.Data.Models;
using System.Collections.Generic;
using System.Linq;


namespace Shop.Data.DataBase
{
    public class DBItems : IItems
    {
        public IEnumerable<Categories> Categorys = new DBCategory().AllCategorys;

        public IEnumerable<Items> AllItems
        {
            get
            {
                //Обявляем список предметов
                List<Items> items = new List<Items>();
                //Открываем подключений к базе данных
                MySqlConnection MySqlConnection = Connection.MySqlOpen();
                // Получаем данные из таблицы категорий
                MySqlDataReader ItemsData = Connection.MySqlQuery("SELECT * FROM shop2.Items ORDER BY `Name`;", MySqlConnection);
                // Читаем данные
                while (ItemsData.Read())
                {
                    // Добавляем в список категорий,
                    // проверяем, что они не равны нулю
                    items.Add(new Items()
                    {
                        Id = ItemsData.IsDBNull(0) ? -1 : ItemsData.GetInt32(0),
                        Name = ItemsData.IsDBNull(1) ? "" : ItemsData.GetString(1),
                        Description = ItemsData.IsDBNull(2) ? "" : ItemsData.GetString(2),
                        Img = ItemsData.IsDBNull(3) ? "" : ItemsData.GetString(3),
                        Price = ItemsData.IsDBNull(4) ? -1 : ItemsData.GetInt32(4),
                        Category = ItemsData.IsDBNull(5) ? null : Categorys.Where(x => x.Id == ItemsData.GetInt32(5)).First()
                    });
                }
                // Закрываем соединение
                MySqlConnection.Close();

                // Возращаем список
                return items;
            }
        }

        public IEnumerable<Items> FindItems(string searchString)
        {
            List<Items> foundItems = new List<Items>();
            MySqlConnection MySqlConnection = Connection.MySqlOpen();
            string query = "SELECT * FROM shop2.Items WHERE Name LIKE @search OR Description LIKE @search;";
            MySqlCommand command = new MySqlCommand(query, MySqlConnection);
            command.Parameters.AddWithValue("@search", "%" + searchString + "%");

            MySqlDataReader ItemsData = command.ExecuteReader();

            while (ItemsData.Read())
            {
                foundItems.Add(new Items()
                {
                    Id = ItemsData.IsDBNull(0) ? -1 : ItemsData.GetInt32(0),
                    Name = ItemsData.IsDBNull(1) ? "" : ItemsData.GetString(1),
                    Description = ItemsData.IsDBNull(2) ? "" : ItemsData.GetString(2),
                    Img = ItemsData.IsDBNull(3) ? "" : ItemsData.GetString(3),
                    Price = ItemsData.IsDBNull(4) ? -1 : ItemsData.GetInt32(4),
                    Category = ItemsData.IsDBNull(5) ? null : Categorys.FirstOrDefault(x => x.Id == ItemsData.GetInt32(5))
                });
            }

            MySqlConnection.Close();
            return foundItems;
        }

        public int Add(Items Item)
        {
            // Открываем подключение к базе данных
            MySqlConnection MySqlConnection = Connection.MySqlOpen();
            // Вставляем запись
            Connection.MySqlQuery(
                $"INSERT INTO shop2.Items (Name, Description, Img, Price, IdCategory) VALUES ('{Item.Name}', '{Item.Description}', '{Item.Img}', {Item.Price}, {Item.Category.Id})",
                MySqlConnection);
            MySqlConnection.Close();

            int IdItem = -1;
            // Выполняем второй запрос, чтобы получить ID
            MySqlConnection = Connection.MySqlOpen();
            // Вставляем запись
            MySqlDataReader mySqlDataReaderItem = Connection.MySqlQuery(
                $"SELECT Id FROM shop2.Items WHERE Name = '{Item.Name}' AND Description = '{Item.Description}' AND Price = {Item.Price} AND IdCategory = {Item.Category.Id}",
                MySqlConnection);
            MySqlConnection.Close();
            // Если есть что читать
            if (mySqlDataReaderItem.HasRows)
            {
                // Читаем
                mySqlDataReaderItem.Read();
                IdItem = mySqlDataReaderItem.GetInt32(0);
            }
            // Закрываем соединение
            MySqlConnection.Close();
            // Возвращаем результат
            return IdItem;
        }

        public void Update(Items Item)
        {
            MySqlConnection mySqlConnection = Connection.MySqlOpen();
            MySqlDataReader readCategoryId = Connection.MySqlQuery(
                $"SELECT * FROM shop2.Items WHERE Id = {Item.Id}", mySqlConnection);
            int CategoryId = 0;
            if (readCategoryId.HasRows)
            {
                readCategoryId.Read();
                CategoryId = readCategoryId.GetInt32(5);
            }
            mySqlConnection.Close();
            mySqlConnection.Open();
            Connection.MySqlQuery(
                $"UPDATE shop2.Items SET Name = '{Item.Name}', Description = '{Item.Description}', Img = '{Item.Img}', Price = '{Item.Price}', IdCategory = '{CategoryId}' WHERE Id = {Item.Id}", mySqlConnection);

            mySqlConnection.Close();
        }

        public void Delete(int id)
        {
            MySqlConnection mySqlConnection = Connection.MySqlOpen();
            Connection.MySqlQuery(
                $"DELETE FROM shop2.Items WHERE Id = {id}", mySqlConnection);
            mySqlConnection.Close();
        }
    }
}
