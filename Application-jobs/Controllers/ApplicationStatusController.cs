using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Application_jobs.Controllers
{
    public class ApplicationStatusController : Controller
    {
        // GET: ApplicationStatusController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ApplicationStatusController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ApplicationStatusController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ApplicationStatusController/Create
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

        // GET: ApplicationStatusController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ApplicationStatusController/Edit/5
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

        // GET: ApplicationStatusController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ApplicationStatusController/Delete/5
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
