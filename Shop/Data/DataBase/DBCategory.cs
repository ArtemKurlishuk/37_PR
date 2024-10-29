using MySql.Data.MySqlClient;
using Shop.Data.Common;
using Shop.Data.Interfaces;
using Shop.Data.Models;
using System.Collections.Generic;


namespace Shop.Data.DataBase
{
    public class DBCategory : ICategorys
    {
        public IEnumerable<Categories> AllCategorys
        {
            get
            {
                //Обявляем список категорий
                List<Categories> categorys = new List<Categories>();
                //Открываем подключений к базе данных
                MySqlConnection MySqlConnection = Connection.MySqlOpen();
                // Получаем данные из таблицы категорий
                MySqlDataReader CategorysData = Connection.MySqlQuery("SELECT * FROM shop2.Categorys ORDER BY `Name`;", MySqlConnection);
                // Читаем данные
                while (CategorysData.Read())
                {
                    // Добавляем в список категорий,
                    // проверяем, что они не равны нулю
                    categorys.Add(new Categories()
                    {
                        Id = CategorysData.IsDBNull(0) ? -1 : CategorysData.GetInt32(0),
                        Name = CategorysData.IsDBNull(1) ? null : CategorysData.GetString(1),
                        Description = CategorysData.IsDBNull(2) ? null : CategorysData.GetString(2)
                    });
                }

                // Возращаем список
                return categorys;
            }
        }
    }
}
