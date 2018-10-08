using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SchMod.ViewModels.StdFees;
using Syncfusion.EJ2.Base;
using Syncfusion.EJ2.Grids;
using Syncfusion.EJ2.Inputs;
using Syncfusion.EJ2.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using WebCat7.GenFunction;
using static WebCat7.GenFunction.GloVar;

namespace WebCat7.Controllers.StdFee
{
    public class FeeSummController : Controller
    {
        // GET: FeeSumm
        public ActionResult Index(FeeForm feeForm)
        {
            return View();
        }

        // GET: FeeSumm/Details/5
        public ActionResult Details(FeeForm feeForm)
        {
            return View(feeForm);
        }

        // GET: FeeSumm/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FeeSumm/Create
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

        // GET: FeeSumm/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FeeSumm/Edit/5
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

        // GET: FeeSumm/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FeeSumm/Delete/5
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

        [HttpPost]
        public ActionResult Update([FromBody] FeeSummEdit FeeSummVal)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(GloVar.iBaseURI);
                    MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                    client.DefaultRequestHeaders.Accept.Add(contentType);
                    string stringData = JsonConvert.SerializeObject(FeeSummVal.Value);
                    var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");
                    HttpResponseMessage response = client.PutAsync("/api/FeeForms/" + FeeSummVal.Key, contentData).Result;
                    ViewBag.Message = response.Content.ReadAsStringAsync().Result;
                    //return View(acaSession);
                }

                //_context.Update(acaSession);
                //await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                //if (!SubjectsExists(subjectsVal.Value.SubId))
                //{
                //    return NotFound();
                //}
                //else
                //{
                //    throw;
                //}
            }
            //AcaSession acsess = JsonConvert.DeserializeObject<AcaSession>(value);
            return Json(FeeSummVal.Value);
        }

        public ActionResult DataSource(int RegNo, [FromBody] DataManagerRequest dm)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(GloVar.iBaseURI);
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                HttpResponseMessage response = client.GetAsync("/api/FeeSumm/" + RegNo + "?dSess=" + dSess + "&mdBID=" + mdBId).Result;
                var stringData = response.Content.ReadAsStringAsync().Result;
                IEnumerable<FeeSumm> stdFeeSumm = JsonConvert.DeserializeObject<IEnumerable<FeeSumm>>(stringData);
                DataOperations operation = new DataOperations();
                IEnumerable data = stdFeeSumm;
                var count = data.AsQueryable().Count();
                //ViewBag.stdFee = stdFee;
                if (dm.Skip > 0)
                    data = operation.PerformSkip(data, dm.Skip);
                if (dm.Take > 0)
                    data = operation.PerformTake(data, dm.Take);
                return Json(new { result = data, count = count });
            }
        }

    }
}