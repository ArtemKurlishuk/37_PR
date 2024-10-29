using MySql.Data.MySqlClient;
using Shop.Data.Common;
using Shop.Data.Interfaces;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Mocks
{
    public class MockItems : IItems
    {
        /// <summary>
        /// Интерфес категорий
        /// </summary>
        public ICategorys _category = new MockCategorys();

        public IEnumerable<Items> AllItems
        {
            // Метод возвращения
            get
            {
                // возвращаем список вещей
                return new List<Items>()
                {
                    new Items()
                    {
                        Id = 0,
                        Name = "DEXP MS-70",
                        Description = "Благодаря черному корпусу с лаконичным дизайном микроволновая печь DEXP MS-70 отлично впишется в кухню с любым интерьером. Камера вмещает 20 л и дополняется удобным поворотным столом со стеклянным блюдом диаметром 25.5 см. С эмалированных стенок легко удаляются засохшие частички пищи. Для простоты ухода перед очисткой камеры можно поставить на 1-2 минуты стакан с водой и лимонной кислотой.\r\nПрибор DEXP MS-70 не имеет уникальных автопрограмм, но простые поворотные рычаги позволят легко подобрать нужное время и мощность работы. 35 минут таймера вполне хватает для разморозки мяса и прочих продуктов или разогрева готового блюда. Классическая навесная дверца легко открывается с помощью ручки.",
                        Img = "https://c.dns-shop.ru/thumb/st1/fit/500/500/59a87f71c12f41fa3c6ad251a93b7811/b1a761fddbd2197e22bdcf5ee0cd1cfd773ce824ab6ef6eba7411b9a626c50a7.jpg.webp",
                        Price = 3699,
                        Category = _category.AllCategorys.Where(x=>x.Id == 1).First()
                    },
                    new Items()
                    {
                        Id = 1,
                        Name = "DEXP MC-OR",
                        Description = "Микроволновая печь DEXP MC-OR выделяется среди прочих устройств необычной оранжевой расцветкой дверцы. Основной корпус модели выполнен в белом цвете. Такое дизайнерское решение, несомненно, привлекает внимание при входе на кухню. Мощность микроволн прибора достигает показателя в 700 Вт, что позволяет ему отлично справляться с поставленными задачами. Внутренний объем камеры составляет 20 л, что является стандартной характеристикой для такого типа устройств. Модель имеет 5 уровней мощности для разогревания пищи.\r\nУправление микроволновой печи представлено 2 механизмами и настолько просто в обращении, что справиться с ним может даже ребенок. В конфигурации прибора имеется опция разморозки по весу и по времени. Для осуществления последнего модель получила от производителя таймер на 35 минут. Он позволяет размораживать продукты питания, не отвлекаясь от других дел. Открывается DEXP MC-OR при помощи широкой удобной ручки. Энергопотребление микроволновой печи не превышает 1050 Вт, что делает ее весьма практичным приобретением.",
                        Img = "https://c.dns-shop.ru/thumb/st4/fit/500/500/fffeefb6eb920f6fa7d97ddba3de20ee/e71db2bc143c2273fae5fb4c530c876f1e5951868b48bf25a9446607467a4f5b.jpg.webp",
                        Price = 1899,
                        Category = _category.AllCategorys.Where(x=>x.Id == 1).First()
                    },
                    new Items()
                    {
                        Id = 2,
                        Name = "Kitfort КТ-205",
                        Description = "Медленноварка Kitfort КТ-205 станет незаменимой помощницей истинных приверженцев полезной пищи, поскольку исключает необходимость в добавлении масла – а все благодаря керамическому покрытию 1.5-литровой основной чаши. Воспользовавшись поворотным переключателем, вам не составит труда подобрать желаемый режим последующей работы устройства.\r\nЧтобы добавить еще больше удобства при эксплуатации Kitfort КТ-205, на ее корпусе появились прочные ручки. Устойчивое положение прибора обеспечивают незаменимые ножки в основании. Выполненный с использованием металла корпус препятствует быстрому остыванию находящихся внутри медленноварки кулинарных изысков.",
                        Img = "https://c.dns-shop.ru/thumb/st4/fit/500/500/e89d43fa21da1d46843749c7cf098beb/cffea8ac96c6195c8c37262530f0f0d5eb7fbf1cbb8f100a15253ce237ad20ae.jpg.webp",
                        Price = 1899,
                        Category = _category.AllCategorys.Where(x=>x.Id == 2).First()
                    },
                    new Items()
                    {
                        Id = 3,
                        Name = "Kitfort КТ-206",
                        Description = "Медленноварка Kitfort КТ-206 придется как нельзя кстати для приготовления томленых блюд с сохранением максимального количества полезных и питательных свойств. Поворотный переключатель на корпусе прибора незаменим, чтобы осуществить быстрый выбор 1 из 3 режимов.\r\nВнутри 2.5-литрового резервуара Kitfort КТ-206 появилось керамическое покрытие. Именно оно исключает необходимость в использовании масла для приготовления любимых кулинарных шедевров. Производитель позаботился и о максимально комфортной эксплуатации устройства, предусмотрев в нем прочные ручки. Благодаря металлическому корпусу вы избавитесь от необходимости разогревать блюда перед непосредственной подачей к столу.",
                        Img = "https://c.dns-shop.ru/thumb/st4/fit/500/500/2eed03bebef4ef7361cab9c4d88cc40b/8e84476b45c8f002051ab4a73c95caac9e74d1deeba4a84d93fd1b9da2aee2ee.jpg.webp",
                        Price = 1950,
                        Category = _category.AllCategorys.Where(x=>x.Id == 2).First()
                    },
                    new Items()
                    {
                        Id = 4,
                        Name = "GOODHELPER MC-5115",
                        Description = "Мультиварка GOODHELPER MC-5115 позволяет готовить разные блюда, предлагая вам питаться правильно и разнообразно. Она поддерживает 11 программ приготовления, это: быстрое приготовление, варка, выпечка, каша, кипение, нагрев, приготовление на пару, разогрев, рис, суп, тушение. Прибор мощностью 950 Вт использует для отображения стадий приготовления блюда специальный индикатор, что очень удобно. Кроме того, на дисплее отображается оставшееся время.\r\nЧаша, устанавливаемая в GOODHELPER MC-5115, поддерживает объем 5 л, при этом обладает антипригарным покрытием, что позволяет не следить за приготовлением пищи: продукты не будут прилипать к стенкам и дну, а вы получите готовое блюдо по окончанию программы. Когда блюдо приготовилось, мультиварка не отключится совсем, а будет находиться на стадии поддержания температуры, чтобы вы могли в любой момент приступить к трапезе и не подогревать еду снова. Используя отложенный старт, вы можете запрограммировать устройство на начало работы в определенное время.",
                        Img = "https://c.dns-shop.ru/thumb/st4/fit/500/500/fef151235c89b9f901792d7cbba377ad/05de1fb566955b17f3d8898e68173cad54ca93ab986dd866616232291757a3e1.jpg.webp",
                        Price = 2099,
                        Category = _category.AllCategorys.Where(x=>x.Id == 2).First()
                    }
                };
            }
        }

        public int Add(Items item)
        {
            // Открываем подключение к базе данных
            MySqlConnection MySqlConnection = Connection.MySqlOpen();
            // Вставляем запись
            Connection.MySqlQuery(
                $"INSERT INTO shop2.Items (Name, Description, Img, Price, IdCategory) VALUES ('{item.Name}', '{item.Description}', '{item.Img}', {item.Price}, {item.Category.Id})",
                MySqlConnection);
            MySqlConnection.Close();

            int IdItem = -1;
            // Выполняем второй запрос, чтобы получить ID
            MySqlConnection = Connection.MySqlOpen();
            // Вставляем запись
            MySqlDataReader mySqlDataReaderItem = Connection.MySqlQuery(
                $"SELECT Id FROM shop2.Items WHERE Name = '{item.Name}' AND Description = '{item.Description}' AND Price = {item.Price} AND IdCategory = {item.Category.Id}",
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
