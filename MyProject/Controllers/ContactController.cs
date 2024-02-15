using DataAccessLayer;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace MyProject.UI.Controllers
{
    public class ContactController : Controller
    {
        private readonly DataContext _db;

        public ContactController(DataContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.menuindex = 4;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(Message message)
        {
            message.RecDate = DateTime.Now;
            _db.Message.Add(message);
            _db.SaveChanges();  
            return RedirectToAction("Index");
        }
    }
}
