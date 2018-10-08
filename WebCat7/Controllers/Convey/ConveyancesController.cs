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
using static WebCat7.GenFunction.GloFunc;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Collections;
using Syncfusion.EJ2.Base;
using Syncfusion.EJ2.Grids;
using Syncfusion.EJ2.Inputs;
using Syncfusion.EJ2.Linq;
using WebCat7.GenFunction;

namespace WebCat7.Controllers.Convey
{
    public class ConveyancesController : Controller
    {
        private readonly SchContext _context;

        public ConveyancesController(SchContext context)
        {
            _context = context;
        }

        // GET: Conveyances
        public async Task<IActionResult> Index()
        {
            GetVehTypLst(_context);
            GetStopLst(_context);
            ViewBag.vehTyp = SchVehTypLst;
            GetSchClss(_context);
            ViewBag.clsses = StrClsLst;
            ViewBag.dropdownStops = drpStopLst;
            //ViewBag.dropdownAtType = ls;
            ViewBag.AtDate = DateTime.Now;
            return View();
        }

        // GET: Conveyances/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var conveyance = await _context.Conveyance
                .SingleOrDefaultAsync(m => m.ConId == id);
            if (conveyance == null)
            {
                return NotFound();
            }

            return View(conveyance);
        }

        // GET: Conveyances/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Conveyances/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ConId,RegNum,StdName,Clss,RollNo,Gender,Parents,Address,UniReg,StopId,Stops,RouteId,DateFrom,DateTo")] Conveyance conveyance)
        {
            if (ModelState.IsValid)
            {
                _context.Add(conveyance);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(conveyance);
        }

        // GET: Conveyances/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var conveyance = await _context.Conveyance.SingleOrDefaultAsync(m => m.ConId == id);
            if (conveyance == null)
            {
                return NotFound();
            }
            return View(conveyance);
        }

        // POST: Conveyances/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ConId,RegNum,StdName,Clss,RollNo,Gender,Parents,Address,UniReg,StopId,Stops,RouteId,DateFrom,DateTo")] Conveyance conveyance)
        {
            if (id != conveyance.ConId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(conveyance);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConveyanceExists(conveyance.ConId))
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
            return View(conveyance);
        }

        // GET: Conveyances/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var conveyance = await _context.Conveyance
                .SingleOrDefaultAsync(m => m.ConId == id);
            if (conveyance == null)
            {
                return NotFound();
            }

            return View(conveyance);
        }

        // POST: Conveyances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var conveyance = await _context.Conveyance.SingleOrDefaultAsync(m => m.ConId == id);
            _context.Conveyance.Remove(conveyance);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        //int id,string clss,  float stDate, string dSess, int mdBId,
        [HttpPost]
        public ActionResult Update(string clss, DateTime stDate ,[FromBody] ConveyanceEdit ConveyancesVal)
        {
            double fStDate = GloFunc.ToOADate(stDate);
            if (ConveyancesVal.Value.Commit)
            {
                ConveyancesVal.Value.Clss = clss;
                ConveyancesVal.Value.DateFrom = stDate;
                ConveyancesVal.Value.DBid = mdBId;
                try
                {
                    using (HttpClient client = new HttpClient())
                    {
                        client.BaseAddress = new Uri(iBaseURI);
                        MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                        client.DefaultRequestHeaders.Accept.Add(contentType);
                        string stringData = JsonConvert.SerializeObject(ConveyancesVal.Value);
                        var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");
                        HttpResponseMessage response = client.PutAsync("/api/Conveyances/" + ConveyancesVal.Key + mdBId, contentData).Result;
                        ViewBag.Message = response.Content.ReadAsStringAsync().Result;
                    }

                    //_context.Update(acaSession);
                    //await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConveyanceExists(ConveyancesVal.Value.ConId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
               //AcaSession acsess = JsonConvert.DeserializeObject<AcaSession>(value);
                return Json(ConveyancesVal.Value);
        }

        public ActionResult DataSource(string clss, DateTime stDate, [FromBody] DataManagerRequest dm)
        {
            double fStDate = GloFunc.ToOADate(stDate);
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(iBaseURI);
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                HttpResponseMessage response = client.GetAsync("/api/Conveyances?clss=" + clss + "&stDate=" + fStDate + "&dSess=" + dSess + "&mdBID=" + mdBId).Result;
                var stringData = response.Content.ReadAsStringAsync().Result;
                List<Conveyance> subjects = JsonConvert.DeserializeObject<List<Conveyance>>(stringData);
                DataOperations operation = new DataOperations();
                IEnumerable data = subjects;
                var count = data.AsQueryable().Count();
                if (dm.Skip > 0)
                    data = operation.PerformSkip(data, dm.Skip);
                if (dm.Take > 0)
                    data = operation.PerformTake(data, dm.Take);
                return Json(new { result = data, count = count });
            }
        }

        private bool ConveyanceExists(int id)
        {
            return _context.Conveyance.Any(e => e.ConId == id);
        }
    }
}
