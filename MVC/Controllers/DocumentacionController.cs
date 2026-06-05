using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class DocumentacionController : Controller
    {
        // GET: DocumentacionController
        public ActionResult Index()
        {
            return View();
        }

        // GET: DocumentacionController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DocumentacionController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DocumentacionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DocumentacionController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DocumentacionController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DocumentacionController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DocumentacionController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
