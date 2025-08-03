using Microsoft.AspNetCore.Mvc;
using MyApp.Models;

namespace MyApp.Controllers
{
    public class ItemsController : Controller
    {
        public IActionResult Overview()
        {
            var item = new Item()
            {
                Name = "Sample Item"
            };
            return View(item);
        }

        public IActionResult Edit(int id)
        {
            return Content($"Edit Item with ID: {id}");
        }
    }
}
