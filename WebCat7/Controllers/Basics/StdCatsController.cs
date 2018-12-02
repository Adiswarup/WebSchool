using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SchMod.Models.Basics;
using Syncfusion.EJ2.Base;
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

namespace WebCat7.Controllers.Basics
{
    public class StdCatsController : Controller
    {
        private readonly SchContext _context;

        public StdCatsController(SchContext context)
        {
            _context = context;
        }

        // GET: StdCats
        public async Task<IActionResult> Index()
        {
            return View();
        }

        // GET: StdCats/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stdCat = await _context.StdCat
                .SingleOrDefaultAsync(m => m.StdCatId == id);
            if (stdCat == null)
            {
                return NotFound();
            }

            return View(stdCat);
        }

        // GET: StdCats/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StdCats/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StdCatId,StdCategory,LoginName")] StdCat stdCat)
        {
            if (ModelState.IsValid)
            {
                if (!StdCatExists(stdCat.StdCategory))
                {
                    using (HttpClient client = new HttpClient())
                    {
                        client.BaseAddress = new Uri(GloVar.iBaseURI);
                        MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                        client.DefaultRequestHeaders.Accept.Add(contentType);
                        string stringData = JsonConvert.SerializeObject(stdCat);
                        var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");
                        HttpResponseMessage response = client.PostAsync("/api/StdCats", contentData).Result;
                        ViewBag.Message = response.Content.ReadAsStringAsync().Result;
                        if (response.IsSuccessStatusCode)
                        {
                            ViewBag.Remark = "Creation of Students Category '" + stdCat.StdCategory + "' Successful";
                            return View();
                        }
                        else
                        {
                            ViewBag.Remark = "Creation of Students Category '" + stdCat.StdCategory + "' Failed!. Please Try Again";
                            return View(stdCat);
                        }
                    }
                }
                else
                {
                    ViewBag.Remark = "Failed Students Category '" + stdCat.StdCategory + "' Already Exists.";
                    return View(stdCat);
                }
            }
            else
            {
                ViewBag.Remark = "Failed! Students Category '" + stdCat.StdCategory + "' Unable To create. PleaseTry Again.";
                return View(stdCat);
            }
        }

        // GET: StdCats/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stdCat = await _context.StdCat.SingleOrDefaultAsync(m => m.StdCatId == id);
            if (stdCat == null)
            {
                return NotFound();
            }
            return View(stdCat);
        }

        // POST: StdCats/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AutoId,StdCatId,StdCategory,LoginName")] StdCat stdCat)
        {
            if (id != stdCat.StdCatId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stdCat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StdCatExists(stdCat.StdCatId))
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
            return View(stdCat);
        }

        // GET: StdCats/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stdCat = await _context.StdCat
                .SingleOrDefaultAsync(m => m.StdCatId == id);
            if (stdCat == null)
            {
                return NotFound();
            }

            return View(stdCat);
        }

        // POST: StdCats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var stdCat = await _context.StdCat.SingleOrDefaultAsync(m => m.StdCatId == id);
            _context.StdCat.Remove(stdCat);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Update([FromBody] StdCatEdit stdCatVal)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(GloVar.iBaseURI);
                    MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                    client.DefaultRequestHeaders.Accept.Add(contentType);
                    string stringData = JsonConvert.SerializeObject(stdCatVal.Value);
                    var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");
                    HttpResponseMessage response = client.PutAsync("/api/StdCats/" + stdCatVal.Key, contentData).Result;
                    ViewBag.Message = response.Content.ReadAsStringAsync().Result;
                    //return View(acaSession);
                }

                //_context.Update(acaSession);
                //await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StdCatExists(stdCatVal.Value.StdCatId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            //AcaSession acsess = JsonConvert.DeserializeObject<AcaSession>(value);
            return Json(stdCatVal.Value);
        }

        public ActionResult DataSource([FromBody] DataManagerRequest dm)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(GloVar.iBaseURI);
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                HttpResponseMessage response = client.GetAsync("/api/StdCats/?mdBID=" + mdBId).Result;
                var stringData = response.Content.ReadAsStringAsync().Result;
                List<StdCat> stdCat = JsonConvert.DeserializeObject<List<StdCat>>(stringData);
                DataOperations operation = new DataOperations();
                IEnumerable data = stdCat;
                var count = data.AsQueryable().Count();
                if (dm.Skip > 0)
                {
                    data = operation.PerformSkip(data, dm.Skip);
                }

                if (dm.Take > 0)
                {
                    data = operation.PerformTake(data, dm.Take);
                }

                return Json(new { result = data, count = count });
            }
        }

        private bool StdCatExists(int id)
        {
            return _context.StdCat.Any(e => e.StdCatId == id);
        }
        private bool StdCatExists(String StCat)
        {
            return _context.StdCat.Any(e => e.StdCategory == StCat);
        }
    }
}
