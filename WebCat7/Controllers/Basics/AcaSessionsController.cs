using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SchMod.Models.Basics;
using Syncfusion.EJ2.Base;
using Syncfusion.EJ2.Grids;
using Syncfusion.EJ2;
using Syncfusion.EJ2.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using WebCat7.Data;
using WebCat7.GenFunction;
using static WebCat7.GenFunction.GloVar;

namespace WebCat7.Controllers
{
    public class AcaSessionsController : Controller
    {
        private readonly SchContext _context;

        public AcaSessionsController(SchContext context)
        {
            _context = context;
        }

        // GET: AcaSessions
        public IActionResult Index()
        {
            //using (HttpClient client = new HttpClient())
            //{
            //    client.BaseAddress = new Uri(GloVar.iBaseURI);
            //    MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
            //    client.DefaultRequestHeaders.Accept.Add(contentType);
            //    HttpResponseMessage response = client.GetAsync("/api/AcaSessions/?mdBID = " + mdBId).Result;
            //    //ViewBag.DataSource = response.Content.ReadAsStringAsync().Result;
            //    string stringData = response.Content.ReadAsStringAsync().Result;
            //    List<AcaSession> acaSession = JsonConvert.DeserializeObject<List<AcaSession>>(stringData);
            //    ViewBag.DataSource = acaSession;
            //    return View();
            //}
            return View();
        }

        // GET: AcaSessions/Details/5
        public IActionResult Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(GloVar.iBaseURI);
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                HttpResponseMessage response = client.GetAsync("/api/AcaSessions/" + id).Result;
                string stringData = response.Content.ReadAsStringAsync().Result;
                AcaSession acaSession = JsonConvert.DeserializeObject<AcaSession>(stringData);
                return View(acaSession);
            }


            //var acaSession = await _context.AcaSession
            //    .SingleOrDefaultAsync(m => m.AutoId == id);
            //if (acaSession == null)
            //{
            //    return NotFound();
            //}

            //return View(acaSession);
        }

        // GET: AcaSessions/Create
        public IActionResult Create()
        {
            return View();
        }
        //public ActionResult NormalUpdate([FromBody]CRUDModel<AcaSession> myObject)
        //{
        //    var ord = myObject.Value;
        //    //AcaSession val = order.Where(or => or.OrderID == ord.OrderID).FirstOrDefault();
        //    //val.OrderID = ord.OrderID;
        //    //val.EmployeeID = ord.EmployeeID;
        //    //val.CustomerID = ord.CustomerID;
        //    //val.Freight = ord.Freight;
        //    //val.ShipCity = ord.ShipCity;
        //    return Json(myObject.Value);
        //}

        // POST: AcaSessions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("AutoId,Ssdid,SessionName,SessionStartDate,SessionEndDate,Dormant,LoginName,ModTime,CTerminal,DBid")] AcaSession acaSession)
        {
            if (ModelState.IsValid)
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(GloVar.iBaseURI);
                    MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                    client.DefaultRequestHeaders.Accept.Add(contentType);
                    string stringData = JsonConvert.SerializeObject(acaSession);
                    var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");
                    HttpResponseMessage response = client.PostAsync("/api/AcaSessions", contentData).Result;
                    ViewBag.Message = response.Content.ReadAsStringAsync().Result;
                    return View(acaSession);
                }

                //_context.Add(acaSession);
                //await _context.SaveChangesAsync();
                //return RedirectToAction("Index");
            }
            return View(acaSession);
        }

        // GET: AcaSessions/Edit/5
        public IActionResult Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(GloVar.iBaseURI);
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                HttpResponseMessage response = client.GetAsync("/api/AcaSessions/" + id).Result;
                string stringData = response.Content.ReadAsStringAsync().Result;
                AcaSession acaSession = JsonConvert.DeserializeObject<AcaSession>(stringData);
                //var acaSession = await _context.AcaSession.SingleOrDefaultAsync(m => m.AutoId == id);
                if (acaSession == null)
                {
                    return NotFound();
                }
                return View(acaSession);
            }
        }
        // POST: AcaSessions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("AutoId,Ssdid,SessionName,SessionStartDate,SessionEndDate,Dormant,LoginName,ModTime,CTerminal,DBid")] AcaSession acaSession)
        {
            //if (id != acaSession.AutoId)
            //{
            //    return NotFound();
            //}

            if (ModelState.IsValid)
            {
                try
                {
                    using (HttpClient client = new HttpClient())
                    {
                        client.BaseAddress = new Uri(GloVar.iBaseURI);
                        MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                        client.DefaultRequestHeaders.Accept.Add(contentType);
                        string stringData = JsonConvert.SerializeObject(acaSession);
                        var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");
                        HttpResponseMessage response = client.PutAsync("/api/AcaSessions/" + acaSession.AutoId, contentData).Result;
                        ViewBag.Message = response.Content.ReadAsStringAsync().Result;
                        //return View(acaSession);
                    }

                    //_context.Update(acaSession);
                    //await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AcaSessionExists(acaSession.AutoId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(acaSession);
        }

        // GET: AcaSessions/Delete/5
        public IActionResult Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(GloVar.iBaseURI);
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);

                HttpResponseMessage response = client.GetAsync("/api/AcaSessions/" + id).Result;
                string stringData = response.Content.ReadAsStringAsync().Result;
                AcaSession acaSession = JsonConvert.DeserializeObject<AcaSession>(stringData);
                return View(acaSession);
            }
            //var acaSession = await _context.AcaSession
            //    .SingleOrDefaultAsync(m => m.AutoId == id);
            //if (acaSession == null)
            //{
            //    return NotFound();
            //}

            //return View(acaSession);
        }

        // POST: AcaSessions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(GloVar.iBaseURI);
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                HttpResponseMessage response = client.DeleteAsync("/api/AcaSessions/Index/" + id).Result;
                TempData["Message"] = response.Content.ReadAsStringAsync().Result;
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public ActionResult Update([FromBody] Object AcsVal)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    //client.BaseAddress = new Uri(GloVar.iBaseURI);
                    //MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                    //client.DefaultRequestHeaders.Accept.Add(contentType);
                    //string stringData = JsonConvert.SerializeObject(AcsVal);
                    //var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");
                    //HttpResponseMessage response = client.PutAsync("/api/AcaSessions/" + AcsVal.Ssdid, contentData).Result;
                    //ViewBag.Message = response.Content.ReadAsStringAsync().Result;
                    ////return View(acaSession);
                }

                //_context.Update(acaSession);
                //await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!AcaSessionExists(AcsVal.Ssdid ))
                //{
                //    return NotFound();
                //}
                //else
                //{
                //    throw;
                //}
            }
            //AcaSession acsess = JsonConvert.DeserializeObject<AcaSession>(value);
            return Json(AcsVal);
        }

        public ActionResult DataSource([FromBody] DataManagerRequest dm)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(GloVar.iBaseURI);
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                HttpResponseMessage response = client.GetAsync("/api/AcaSessions/?mdBID=" + mdBId).Result;
                var  stringData = response.Content.ReadAsStringAsync().Result;
                List<AcaSession> acaSession = JsonConvert.DeserializeObject<List<AcaSession>>(stringData);
                DataOperations operation = new DataOperations();
                IEnumerable data = acaSession;
                var count = data.AsQueryable().Count();
                if (dm.Skip > 0)
                    data = operation.PerformSkip(data, dm.Skip);
                if (dm.Take > 0)
                    data = operation.PerformTake(data, dm.Take);
                return Json(new { result = data, count = count });
            }
        }

        public class DataResult
        {
            public IEnumerable result { get; set; }
            public int count { get; set; }
        }

        private bool AcaSessionExists(int id)
        {
            return _context.AcaSession.Any(e => e.AutoId == id);
        }
    }
}
