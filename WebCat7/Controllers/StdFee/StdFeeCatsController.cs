using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SchMod.Models.StdFees;
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

namespace WebCat7.Controllers.StdFee
{
    public class StdFeeCatsController : Controller
    {
        private readonly SchContext _context;

        public StdFeeCatsController(SchContext context)
        {
            _context = context;
        }

        // GET: StdFeeCats
        public async Task<IActionResult> Index()
        {
            return View();
        }

        // GET: StdFeeCats/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var StdFeeCat = await _context.StdFeeCat
                .SingleOrDefaultAsync(m => m.StdFeeCatId == id);
            if (StdFeeCat == null)
            {
                return NotFound();
            }

            return View(StdFeeCat);
        }

        // GET: StdFeeCats/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StdFeeCats/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StdFeeCatId,StdFeeCategory,LoginName")] StdFeeCat stdFeeCat)
        {
            if (ModelState.IsValid)
            {
                stdFeeCat.DBid = mdBId;
                if (!StdFeeCatExists(stdFeeCat.StdFeeCategory))
                {
                    using (HttpClient client = new HttpClient())
                    {
                        client.BaseAddress = new Uri(GloVar.iBaseURI);
                        MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                        client.DefaultRequestHeaders.Accept.Add(contentType);
                        string stringData = JsonConvert.SerializeObject(stdFeeCat);
                        var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");
                        HttpResponseMessage response = client.PostAsync("/api/StdFeeCats", contentData).Result;
                        ViewBag.Message = response.Content.ReadAsStringAsync().Result;
                        if (response.IsSuccessStatusCode)
                        {
                            ViewBag.Remark = "Creation of Fee Category '" + stdFeeCat.StdFeeCategory + "' Successful";
                            return View();
                        }
                        else
                        {
                            ViewBag.Remark = "Creation of Fee Category '" + stdFeeCat.StdFeeCategory + "' Failed!. Please Try Again";
                            return View(stdFeeCat);
                        }
                    }
                }
                else
                {
                    ViewBag.Remark = "Failed Fee Category '" + stdFeeCat.StdFeeCategory + "' Already Exists.";
                    return View(stdFeeCat);
                }
            }
            else
            {
                ViewBag.Remark = "Failed! Fee Category '" + stdFeeCat.StdFeeCategory + "' Unable To create. PleaseTry Again.";
                return View(stdFeeCat);
            }
        }

        // GET: StdFeeCats/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var StdFeeCat = await _context.StdFeeCat.SingleOrDefaultAsync(m => m.StdFeeCatId == id);
            if (StdFeeCat == null)
            {
                return NotFound();
            }
            return View(StdFeeCat);
        }

        // POST: StdFeeCats/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AutoId,StdFeeCatId,StdFeeCategory,LoginName")] StdFeeCat StdFeeCat)
        {
            if (id != StdFeeCat.StdFeeCatId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(StdFeeCat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StdFeeCatExists(StdFeeCat.StdFeeCatId))
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
            return View(StdFeeCat);
        }

        // GET: StdFeeCats/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var StdFeeCat = await _context.StdFeeCat
                .SingleOrDefaultAsync(m => m.StdFeeCatId == id);
            if (StdFeeCat == null)
            {
                return NotFound();
            }

            return View(StdFeeCat);
        }

        // POST: StdFeeCats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var StdFeeCat = await _context.StdFeeCat.SingleOrDefaultAsync(m => m.StdFeeCatId == id);
            _context.StdFeeCat.Remove(StdFeeCat);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Update([FromBody] StdFeeCatEdit StdFeeCatVal)
        {
            try
            {
                StdFeeCatVal.Value.DBid = mdBId;
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(GloVar.iBaseURI);
                    MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                    client.DefaultRequestHeaders.Accept.Add(contentType);
                    string stringData = JsonConvert.SerializeObject(StdFeeCatVal.Value);
                    var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");
                    HttpResponseMessage response = client.PutAsync("/api/StdFeeCats/" + StdFeeCatVal.Key, contentData).Result;
                    ViewBag.Message = response.Content.ReadAsStringAsync().Result;
                    //return View(acaSession);
                }

                //_context.Update(acaSession);
                //await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StdFeeCatExists(StdFeeCatVal.Value.StdFeeCatId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            //AcaSession acsess = JsonConvert.DeserializeObject<AcaSession>(value);
            return Json(StdFeeCatVal.Value);
        }

        public ActionResult DataSource([FromBody] DataManagerRequest dm)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(GloVar.iBaseURI);
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                HttpResponseMessage response = client.GetAsync("/api/StdFeeCats/?dSess=" + dSess + "&mdBID=" + mdBId).Result;
                var stringData = response.Content.ReadAsStringAsync().Result;
                List<StdFeeCat> StdFeeCat = JsonConvert.DeserializeObject<List<StdFeeCat>>(stringData);
                DataOperations operation = new DataOperations();
                IEnumerable data = StdFeeCat;
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

        private bool StdFeeCatExists(int id)
        {
            return _context.StdFeeCat.Any(e => e.StdFeeCatId == id);
        }
        private bool StdFeeCatExists(String StCat)
        {
            return _context.StdCat.Any(e => e.StdCategory == StCat);
        }
    }
}
