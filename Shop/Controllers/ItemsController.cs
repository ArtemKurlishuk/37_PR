using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting.Internal;
using Shop.Data.DataBase;
using Shop.Data.Interfaces;
using Shop.Data.Models;
using Shop.Data.ViewModell;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Controllers
{
    public class ItemsController : Controller
    {
        /// <summary>
        /// Предоставляет сведенья о среде расположения веб-сайтов
        /// </summary>
        private readonly IHostingEnvironment hostingEnvironment;

        /// <summary>
        ///  Интерфейс объектов
        /// </summary>
        private IItems IAllItems;
        /// <summary>
        /// Интерфейс категорий
        /// </summary>
        private ICategorys IAllCategorys;
        /// <summary>
        /// Создаём модель, хранящую в себе данные
        /// </summary>
        VMItems VMItems = new VMItems();
        int countItemsInBasket;

        /// <summary>
        /// Конструктор принимающий параметры
        /// </summary>
        /// <param name="IAllItems"></param>
        /// <param name="IAllCategorys"></param>
        public ItemsController(IItems IAllItems, ICategorys IAllCategorys, IHostingEnvironment environment)
        {
            // Запоминание интерфес вещей
            this.IAllItems = IAllItems;
            // Запоминаем интерфес категорий
            this.IAllCategorys = IAllCategorys;
            // Запоминаем сведенья
            this.hostingEnvironment = environment;
        }

        /// <summary>
        /// Метод реализующий отображение данных
        /// </summary>
        /// <returns></returns>
        public ViewResult List(int id = 0, string sortBy = "0", string searchString = "")
        {
            countItemsInBasket = 0;
            ViewBag.Title = "Страница с товарами";
            var items = IAllItems.AllItems;
            if (id != 0)
            {
                items = items.Where(i => i.Category.Id == id);
            }
            if (!string.IsNullOrEmpty(searchString))
            {
                DBItems temp = new DBItems();
                items = temp.FindItems(searchString);
                ViewBag.Title = "Результаты поиска";
                ViewBag.SearchString = searchString;
            }
            if (sortBy == "desc")
            {
                items = items.OrderByDescending(i => i.Price);
            }
            else if (sortBy == "asc")
            {
                items = items.OrderBy(i => i.Price);
            }
            VMItems.Items = items;
            VMItems.Categorys = IAllCategorys.AllCategorys;
            VMItems.SelectCategory = id;

            return View(VMItems);
        }

        /// <summary>
        /// Метод добавления предмета
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ViewResult Add()
        {
            IEnumerable<Categories> Categorys = IAllCategorys.AllCategorys;

            return View(Categorys);
        }

        /// <summary>
        /// Метод добавления предмета
        /// </summary>
        /// <param name="name">Наименование предмета</param>
        /// <param name="description">Описание предмета</param>
        /// <param name="files">Изображение</param>
        /// <param name="price">Цена</param>
        /// <param name="idCategory">Код категории</param>
        /// <returns></returns>
		[HttpPost]
        public RedirectResult Add(string name, string description, IFormFile files, float price, int idCategory)
        {
            // Если файл присутсвует
            if (files != null)
            {
                // Получаем путь к папке
                var uploads = Path.Combine(hostingEnvironment.WebRootPath, "img");
                // Получаем путь к файлу
                var filePath = Path.Combine(uploads, files.FileName);
                // Копируем файл 
                files.CopyTo(new FileStream(filePath, FileMode.Create));
            }
            // Создаём новый предмет, заполняем данные
            Items newItems = new Items();
            newItems.Name = name;
            newItems.Description = description;
            newItems.Img = files.FileName;
            newItems.Price = Convert.ToInt32(price);
            newItems.Category = new Categories() { Id = idCategory };
            // Вызываем метод домбавления
            int id = IAllItems.Add(newItems);
            // Перенаправляем пользователя на страницу изменения
            return Redirect("/Items/List");
        }

        /// <summary>
        /// Метод изменения предмета
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Categories = IAllCategorys.AllCategorys;
            var EditItem = IAllItems.AllItems.FirstOrDefault(i => i.Id == id);
            if (EditItem == null)
            {
                return NotFound();
            }
            return View(EditItem);
        }

        [HttpPost]
        public IActionResult Edit(Items Item, IFormFile files)
        {
            if (ModelState.IsValid)
            {
                if (files != null)
                {
                    //получаем путь к папке
                    var uploads = Path.Combine(hostingEnvironment.WebRootPath, "img");
                    //получаем путь к файлу
                    var filePath = Path.Combine(uploads, files.FileName);
                    //копируем файл
                    files.CopyTo(new FileStream(filePath, FileMode.Create));
                    Item.Img = filePath;
                }
                IAllItems.Update(Item);
                return RedirectToAction("List", "Items");
            }
            return View(Item);
        }

        /// <summary>
        /// Метод удаления предмета
        /// </summary>
        /// <param name="Item"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Delete(int id)
        {
            IAllItems.Delete(id);
            return RedirectToAction("List", "Items");
        }

        /// <summary>
        /// Добавление в корзину
        /// </summary>
        /// <param name="idItem"></param>
        /// <returns></returns>
        public ActionResult Basket(int idItem = -1)
        {
            // Усли ID предмета указано
            if (idItem != -1)
            {
                // Добавляем в корзину предмет
                Startup.BasketItem.Add(new ItemsBasket(1, IAllItems.AllItems.Where(x => x.Id == idItem).First()));
            }
            // Возращаем список в корзину
            return Json(Startup.BasketItem);
        }

        /// <summary>
        /// Удаление и счёт количества
        /// </summary>
        /// <param name="idItem"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public ActionResult BasketCount(int idItem = -1, int count = -1)
        {
            // Усли ID предмета указано
            if (idItem != -1)
            {
                // Если кол-во = 0
                if (count == 0)
                    // Удаляем из корзины
                    Startup.BasketItem.Remove(Startup.BasketItem.Find(x => x.Id == idItem));
                else
                    // Указываем кол-во
                    Startup.BasketItem.Find(x => x.Id == idItem).Count = count;
            }

            countItemsInBasket = Startup.BasketItem.Sum(x => x.Count);
            // Возращаем Json
            return Json(Startup.BasketItem);
        }

        public ViewResult BasketList()
        {
            ViewBag.Title = "Корзина";
            VMItems VMItem = new VMItems();
            VMItem.ItemsBaskets = Startup.BasketItem;
            return View(VMItem);
        }

    }
}
