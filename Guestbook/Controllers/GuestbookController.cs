using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

//слишком много писать
using GuestbookContext = Guestbook.Models.GuestbookContext;
using GuestbookEntry = Guestbook.Models.GuestbookEntry;

namespace Guestbook.Controllers
{
    public class GuestbookController : Controller
    {
        public GuestbookContext _db = new GuestbookContext();
        // GET: Guestbook
        public ActionResult Index()
        {
            var mostRecentEntries = (from entry in _db.Entries
                                     orderby entry.DateAdd descending
                                     select entry).Take(20);
            ViewBag.Entries = mostRecentEntries.ToList();
            //var model = mostRecentEntries.ToList();
            //return View(model);
            return View();
        }
        
        public ActionResult Create()
        {
            return View();
        }

        public ViewResult Show(int id)
        {
            var entry = _db.Entries.Find(id);
            bool hasPerm = User.Identity.Name == entry.Name;
            ViewData["hasPerm"] = hasPerm;
            return View(entry);
        }

        //следующее действие будет вызываться только в ответ на отправку формы
        [HttpPost]
        public ActionResult Create(GuestbookEntry entry)//так как названия полей в форме совпадают с названиями свойств в классе, заполняться они будут автоматически
        {
            entry.DateAdd = DateTime.Now;
            _db.Entries.Add(entry);//оповещение Entity о создании новой записи
            _db.SaveChanges();//отправка записи в базу
            return RedirectToAction("Index");
            //return Content("Новое сообщение успешно добавлено!");
        }
    }
}