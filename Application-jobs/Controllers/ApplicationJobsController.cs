using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Application_jobs.Controllers
{
    public class ApplicationJobsController : Controller
    {
        // GET: ApplicationJobsController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ApplicationJobsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ApplicationJobsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ApplicationJobsController/Create
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

        // GET: ApplicationJobsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ApplicationJobsController/Edit/5
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

        // GET: ApplicationJobsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ApplicationJobsController/Delete/5
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
