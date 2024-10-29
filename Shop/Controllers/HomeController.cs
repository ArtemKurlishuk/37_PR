using Microsoft.AspNetCore.Mvc;

namespace Shop.Controllers
{
    public class HomeController : Controller
    {
        public RedirectResult Index()
        {
            // Перенаправление пользователя
            return Redirect("/Items/List");
        }
    }
}
