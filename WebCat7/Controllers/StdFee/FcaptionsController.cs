using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SchMod.Models.Basics;
using SchMod.Models.StdFees;
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
using System.Threading.Tasks;
using WebCat7.Data;
using WebCat7.GenFunction;
using static WebCat7.GenFunction.GloVar;

namespace WebCat7.Controllers.StdFee
{
    public class FcaptionsController : Controller
    {
        private readonly SchContext _context;

        public FcaptionsController(SchContext context)
        {
            _context = context;
        }

        // GET: Fcaptions
        public async  Task<IActionResult> Index()
        {
            List<DropDown> periodList = new List<DropDown>();
            periodList.Add(new DropDown("Monthly" ));
            periodList.Add(new DropDown("Quaterly" ));
            periodList.Add(new DropDown("Half Yearly" ));
            periodList.Add(new DropDown("Annually"));
            ViewBag.dropdownDuration = periodList;
            return View();
        }

        // GET: Fcaptions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fcaption = await _context.Fcaption
                .SingleOrDefaultAsync(m => m.FeeNameId == id);
            if (fcaption == null)
            {
                return NotFound();
            }

            return View(fcaption);
        }

        // GET: Fcaptions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Fcaptions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FeeNameId,FeeCaption,FeeDuration,FeeType,FeeOrder, ShowIt")] Fcaption fcaption)
        {
            if (ModelState.IsValid)
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(GloVar.iBaseURI);
                    MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                    client.DefaultRequestHeaders.Accept.Add(contentType);
                    string stringData = JsonConvert.SerializeObject(fcaption);
                    var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");
                    HttpResponseMessage response = client.PostAsync("/api/fcaptions?mDbid=" + mdBId, contentData).Result;
                    ViewBag.Message = response.Content.ReadAsStringAsync().Result;
                }
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Fcaptions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fcaption = await _context.Fcaption.SingleOrDefaultAsync(m => m.FeeNameId == id);
            if (fcaption == null)
            {
                return NotFound();
            }
            return View(fcaption);
        }

        // POST: Fcaptions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FeeNameId,FeeCaption,FeeDuration,FeeType,FeeOrder,ShowIt")] Fcaption fcaption)
        {
            if (id != fcaption.FeeNameId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fcaption);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FcaptionExists(fcaption.FeeNameId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(fcaption);
        }

        // GET: Fcaptions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fcaption = await _context.Fcaption
                .SingleOrDefaultAsync(m => m.FeeNameId == id);
            if (fcaption == null)
            {
                return NotFound();
            }

            return View(fcaption);
        }

        // POST: Fcaptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fcaption = await _context.Fcaption.SingleOrDefaultAsync(m => m.FeeNameId == id);
            _context.Fcaption.Remove(fcaption);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public ActionResult Update([FromBody] FcaptionEdit fCaptionVal)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    fCaptionVal.Value.DBid = mdBId;
                    client.BaseAddress = new Uri(GloVar.iBaseURI);
                    MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                    client.DefaultRequestHeaders.Accept.Add(contentType);
                    string stringData = JsonConvert.SerializeObject(fCaptionVal.Value);
                    var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");
                    HttpResponseMessage response = client.PutAsync("/api/fcaptions/" + fCaptionVal.Key, contentData).Result;
                    ViewBag.Message = response.Content.ReadAsStringAsync().Result;
                    //return View(acaSession);
                }

                //_context.Update(acaSession);
                //await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FcaptionExists(fCaptionVal.Value.FeeNameId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            //AcaSession acsess = JsonConvert.DeserializeObject<AcaSession>(value);
            return Json(fCaptionVal.Value);
        }


        public ActionResult DataSource( [FromBody] DataManagerRequest dm)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(GloVar.iBaseURI);
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                HttpResponseMessage response = client.GetAsync("/api/fcaptions?dSess=" + dSess + "&mdBID=" + mdBId).Result;
                var stringData = response.Content.ReadAsStringAsync().Result;
                List<Fcaption> fcap = JsonConvert.DeserializeObject<List<Fcaption>>(stringData);
                DataOperations operation = new DataOperations();
                IEnumerable data = fcap;
                var count = data.AsQueryable().Count();
                if (dm.Skip > 0)
                    data = operation.PerformSkip(data, dm.Skip);
                if (dm.Take > 0)
                    data = operation.PerformTake(data, dm.Take);
                return Json(new { result = data, count = count });
            }
        }

        private bool FcaptionExists(int id)
        {
            return _context.Fcaption.Any(e => e.FeeNameId == id);
        }
    }
}
