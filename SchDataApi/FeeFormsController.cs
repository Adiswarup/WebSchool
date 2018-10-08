using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SchDataApi
{
    public class FeeFormsController : Controller
    {
        // GET: FeeForms
        public ActionResult Index()
        {
            return View();
        }

        // GET: FeeForms/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FeeForms/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FeeForms/Create
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

        // GET: FeeForms/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FeeForms/Edit/5
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

        // GET: FeeForms/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FeeForms/Delete/5
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