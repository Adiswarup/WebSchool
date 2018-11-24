using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SchMod.Models.Active;
using Syncfusion.EJ2;
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
using static WebCat7.GenFunction.AcaFunctions;
using static WebCat7.GenFunction.GloVar;

namespace WebCat7.Controllers.Active
{
    public class ActiLogsController : Controller
    {
        private readonly SchContext _context;

        public ActiLogsController(SchContext context)
        {
            _context = context;
        }

        // GET: ActiLogs
        public async Task<IActionResult> Index()
        {
            GetSchClss(_context);
            ViewBag.clsses = StrClsLst;
            GetActivityGroup(_context);
            ViewBag.ActGrps = StrActGrpLst;
            ViewBag.ColCount = 4;
            return View();
            //return View(await _context.ActiLog.ToListAsync());
        }

        // GET: ActiLogs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actiLog = await _context.ActiLog
                .SingleOrDefaultAsync(m => m.AutoId == id);
            if (actiLog == null)
            {
                return NotFound();
            }

            return View(actiLog);
        }

        // GET: ActiLogs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ActiLogs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AutoId,Clss,ActGroup,ActName,ActVal,ActName1,ActVal1,ActName2,ActVal2,ActName3,ActVal3,ActName4,ActVal4,ActName5,ActVal5,ActName6,ActVal6,ActName7,ActVal7")] ActiLog actiLog)
        {
            if (ModelState.IsValid)
            {
                _context.Add(actiLog);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(actiLog);
        }

        // GET: ActiLogs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actiLog = await _context.ActiLog.SingleOrDefaultAsync(m => m.AutoId == id);
            if (actiLog == null)
            {
                return NotFound();
            }
            return View(actiLog);
        }

        // POST: ActiLogs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AutoId,Clss,ActGroup,ActName,ActVal,ActName1,ActVal1,ActName2,ActVal2,ActName3,ActVal3,ActName4,ActVal4,ActName5,ActVal5,ActName6,ActVal6,ActName7,ActVal7")] ActiLog actiLog)
        {
            if (id != actiLog.AutoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(actiLog);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ActiLogExists(actiLog.AutoId))
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
            return View(actiLog);
        }

        // GET: ActiLogs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actiLog = await _context.ActiLog
                .SingleOrDefaultAsync(m => m.AutoId == id);
            if (actiLog == null)
            {
                return NotFound();
            }

            return View(actiLog);
        }

        // POST: ActiLogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var actiLog = await _context.ActiLog.SingleOrDefaultAsync(m => m.AutoId == id);
            _context.ActiLog.Remove(actiLog);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public ActionResult Update([FromBody] ActiLogEdit ActiLogsVal)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(GloVar.iBaseURI);
                    MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                    client.DefaultRequestHeaders.Accept.Add(contentType);
                    string stringData = JsonConvert.SerializeObject(ActiLogsVal.Value);
                    var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");
                    HttpResponseMessage response = client.PutAsync("/api/ActiLogs/" + ActiLogsVal.Key, contentData).Result;
                    ViewBag.Message = response.Content.ReadAsStringAsync().Result;
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActiLogExists(ActiLogsVal.Value.AutoId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            //AcaSession acsess = JsonConvert.DeserializeObject<AcaSession>(value);
            return Json(ActiLogsVal.Value);
        }

        public ActionResult DataSource(string clss, string actGrps, [FromBody] DataManagerRequest dm)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(GloVar.iBaseURI);
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                HttpResponseMessage response = client.GetAsync("/api/ActiLogs?clss=" + clss + "&actGrps=" + actGrps + "&dSess=" + dSess + "&mdBID=" + mdBId).Result;
                var stringData = response.Content.ReadAsStringAsync().Result;
                List<ActiLog> subjects = JsonConvert.DeserializeObject<List<ActiLog>>(stringData);
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

        private bool ActiLogExists(int id)
        {
            return _context.ActiLog.Any(e => e.AutoId == id);
        }
    }
}
