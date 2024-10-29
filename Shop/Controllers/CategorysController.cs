using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shop.Data.Interfaces;

namespace Shop.Controllers
{
    public class CategorysController : Controller
    {
        /// <summary>
        ///  Интерфес объектов
        /// </summary>
        private IItems IAllItems;
        /// <summary>
        /// Интерфес категорий
        /// </summary>
        private ICategorys IAllCategorys;

        /// <summary>
        /// Конструктор принимающий параметры
        /// </summary>
        /// <param name="IAllItems"></param>
        /// <param name="IAllCategorys"></param>
        public CategorysController(IItems IAllItems, ICategorys IAllCategorys)
        {
            // Запоминание интерфес вещей
            this.IAllItems = IAllItems;
            // Запоминаем интерфес категорий
            this.IAllCategorys = IAllCategorys;
        }

        /// <summary>
        /// Метод реализующий отображение данных
        /// </summary>
        /// <returns></returns>
        public ViewResult List()
        {
            // Название нашей страницы
            ViewBag.Title = "Страница с категориями";

            // Получаем все вещи
            var cars = IAllCategorys.AllCategorys;
            // Передаём на страницу
            return View(cars);
        }
    }
}
