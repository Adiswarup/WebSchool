using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchMod.Models.Convey;
using WebCat7.Data;
using static WebCat7.GenFunction.AcaFunctions;
using System.Net.Http;
using static WebCat7.GenFunction.GloVar;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Collections;
using Syncfusion.EJ2.Base;
using Syncfusion.EJ2.Grids;
using Syncfusion.EJ2.Inputs;
using Syncfusion.EJ2.Linq;
using static WebCat7.GenFunction.GloFunc;


namespace WebCat7.Controllers.Convey
{
    public class StopsController : Controller
    {
        private readonly SchContext _context;

        public StopsController(SchContext context)
        {
            _context = context;
        }

        // GET: Stops
        public async Task<IActionResult> Index()
        {
            GetVehTypLst(_context);
            ViewBag.vehTyp = drpVehTypLst;
            return View( );
        }

        // GET: Stops/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stops = await _context.Stops
                .SingleOrDefaultAsync(m => m.stopId == id);
            if (stops == null)
            {
                return NotFound();
            }

            return View(stops);
        }

        // GET: Stops/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Stops/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StopId,ConveyanceMode,Stops1,Circuit,MonthlyFare,FareFromMonth")] Stops stops)
        {
            if (ModelState.IsValid)
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(iBaseURI);
                    MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                    client.DefaultRequestHeaders.Accept.Add(contentType);
                    string stringData = JsonConvert.SerializeObject(stops);
                    var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");
                    HttpResponseMessage response = client.PostAsync("/api/stops", contentData).Result;
                    ViewBag.Message = response.Content.ReadAsStringAsync().Result;
            //return View(stops);
                }
            }
            return View(stops);
        }

        // GET: Stops/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stops = await _context.Stops.SingleOrDefaultAsync(m => m.stopId == id);
            if (stops == null)
            {
                return NotFound();
            }
            return View(stops);
        }

        // POST: Stops/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AutoId,StopId,ConveyanceMode,Stops1,Circuit,MonthlyFare,FareFromMonth")] Stops stops)
        {
            if (id != stops.stopId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stops);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StopsExists(stops.stopId))
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
            return View(stops);
        }

        // GET: Stops/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stops = await _context.Stops
                .SingleOrDefaultAsync(m => m.stopId == id);
            if (stops == null)
            {
                return NotFound();
            }

            return View(stops);
        }

        // POST: Stops/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var stops = await _context.Stops.SingleOrDefaultAsync(m => m.stopId == id);
            _context.Stops.Remove(stops);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        public ActionResult Update([FromBody] StopsEdit stopsVal)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    stopsVal.Value.DBid = mdBId;
                    client.BaseAddress = new Uri(iBaseURI);
                    MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                    client.DefaultRequestHeaders.Accept.Add(contentType);
                    string stringData = JsonConvert.SerializeObject(stopsVal.Value);
                    var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");
                    HttpResponseMessage response = client.PutAsync("/api/stops/" + stopsVal.Key, contentData).Result;
                    ViewBag.Message = response.Content.ReadAsStringAsync().Result;
                    //return View(acaSession);
                }

                //_context.Update(acaSession);
                //await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StopsExists(stopsVal.Value.stopId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            //AcaSession acsess = JsonConvert.DeserializeObject<AcaSession>(value);
            return Json(stopsVal.Value);
        }


        public ActionResult DataSource(string clss, [FromBody] DataManagerRequest dm)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(iBaseURI);
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                HttpResponseMessage response = client.GetAsync("/api/stops?mdBID=" + mdBId).Result;
                var stringData = response.Content.ReadAsStringAsync().Result;
                List<Stops> stops = JsonConvert.DeserializeObject<List<Stops>>(stringData);
                DataOperations operation = new DataOperations();
                IEnumerable data = stops;
                var count = data.AsQueryable().Count();
                if (dm.Skip > 0)
                    data = operation.PerformSkip(data, dm.Skip);
                if (dm.Take > 0)
                    data = operation.PerformTake(data, dm.Take);
                return Json(new { result = data, count = count });
            }
        }

        private bool StopsExists(int id)
        {
            return _context.Stops.Any(e => e.stopId == id);
        }
    }
}
