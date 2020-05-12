using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Questionator.Models;

namespace Questionator.Controllers
{
    [Controller]
    public class HomeController : Controller
    {
        IUserRepository _repo = null;

        public HomeController(IUserRepository repo)
        {
            _repo = repo;
        }
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public IActionResult GetSecondUserView()
        {
            return PartialView("_GetSecondUserView", _repo.Get(2));
        }
        public string AddQuestion(string text)
        {
            return $"\"{text}\" добавлен";
        }

        [HttpPost]
        public string Area(int altitude, int height)
        {
            double square = altitude * height / 2;
            return $"Площадь треугольника с основанием {altitude} и высотой {height} равна {square}";
        }

        // GET: Home/Details/5
        public IActionResult Details(int id, int id2)
        {
            User user = _repo.Get(id);
            if (user != null)
            {
                return Content($"id = {id}, id2 = {id2}");
                //return View(user);
            }
            //return NotFound();
            return Content("");
        }

        public JsonResult GetU(User user)
        {

            //return Json($"user name = {user.NickName}, user email = {user.Email}");
            return Json(user);
        }

        // GET: Home/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: Home/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Home/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Home/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}