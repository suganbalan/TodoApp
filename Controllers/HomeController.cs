using Microsoft.AspNetCore.Mvc;
using TodoApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace TodoApp.Controllers
{
    public class HomeController : Controller
    {
        static List<TodoItem> tasks = new List<TodoItem>();

        public IActionResult Index()
        {
            return View(tasks);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(string task)
        {
            tasks.Add(new TodoItem { Id = tasks.Count + 1, Task = task, IsDone = false });
            return RedirectToAction("Index");
        }

        public IActionResult Done(int id)
        {
            var item = tasks.FirstOrDefault(x => x.Id == id);
            if (item != null)
                item.IsDone = true;
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var item = tasks.FirstOrDefault(x => x.Id == id);
            if (item != null)
                tasks.Remove(item);
            return RedirectToAction("Index");
        }

        public IActionResult Resume()
        {
            return View();
        }
    }
}
