using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SchMod.Models.Active;
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
using static WebCat7.GenFunction.AcaFunctions;
using static WebCat7.GenFunction.GloVar;

namespace WebCat7.Controllers.Active
{
    public class TransActivitiesController : Controller
    {
        private readonly SchContext _context;

        public TransActivitiesController(SchContext context)
        {
            _context = context;
        }

        // GET: TransActivities
        public async Task<IActionResult> Index()
        {
            GetSchClss(_context);
            ViewBag.clsses = new SelectList(SchClsLst, "Value", "Text", null);
            GetActivityGroup(_context);
            ViewBag.ActGrps = new SelectList(SchActivityGroup, "Value", "Text", null);
            GetActivity(_context, "Thinking Skills", true);
            ViewBag.dropdownActivity = drpActLst;
            ViewBag.ActDate = DateTime.Now;
            return View();
        }

        public void FillActivityDropDown(string actGrps)
        {
            GetActivity(_context, actGrps, true);
            ViewBag.dropdownActivity = drpActLst;
        }
        // GET: TransActivities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transActivity = await _context.TransActivity
                .SingleOrDefaultAsync(m => m.AutoId == id);
            if (transActivity == null)
            {
                return NotFound();
            }

            return View(transActivity);
        }

        // GET: TransActivities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TransActivities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TransActName,ActivityId,ActivityName,RegNumber,RollNumber,TransActValue,TransActDate,TransActObserver,StdName,StdClss,TeachId,TransActRemarks,Score,UniReg")] TransActivity transActivity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(transActivity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(transActivity);
        }

        // GET: TransActivities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transActivity = await _context.TransActivity.SingleOrDefaultAsync(m => m.AutoId == id);
            if (transActivity == null)
            {
                return NotFound();
            }
            return View(transActivity);
        }

        // POST: TransActivities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AutoId,TransActId,TransActName,ActivityId,ActivityName,RegNumber,RollNumber,TransActValue,TransActDate,TransActObserver,StdName,StdClss,TeachId,TransActRemarks,Score,UniReg")] TransActivity transActivity)
        {
            if (id != transActivity.AutoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(transActivity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransActivityExists(transActivity.AutoId))
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
            return View(transActivity);
        }

        // GET: TransActivities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transActivity = await _context.TransActivity
                .SingleOrDefaultAsync(m => m.AutoId == id);
            if (transActivity == null)
            {
                return NotFound();
            }

            return View(transActivity);
        }

        // POST: TransActivities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var transActivity = await _context.TransActivity.SingleOrDefaultAsync(m => m.AutoId == id);
            _context.TransActivity.Remove(transActivity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public ActionResult Update(DateTime actDate,[FromBody] TransActivityEdit TransActVal)
        {
            if(TransActVal.Value.Commit)
            {
                try
                {
                    TransActVal.Value.TransActDate = actDate;
                    TransActVal.Value.DBid = mdBId;
                    using (HttpClient client = new HttpClient())
                    {
                        client.BaseAddress = new Uri(GloVar.iBaseURI);
                        MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                        client.DefaultRequestHeaders.Accept.Add(contentType);
                        string stringData = JsonConvert.SerializeObject(TransActVal.Value);
                        var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");
                        HttpResponseMessage response = client.PutAsync("/api/TransActivities/" + TransActVal.Key, contentData).Result;
                        ViewBag.Message = response.Content.ReadAsStringAsync().Result;
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransActivityExists(TransActVal.Value.AutoId))
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
            return Json(TransActVal.Value);
        }

        public ActionResult DataSource(string clss, string actGrps, string actDate, [FromBody] DataManagerRequest dm)
        {

            double fActDate=0; //= GloFunc.ToOADate(actDate);
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(GloVar.iBaseURI);
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                HttpResponseMessage response = client.GetAsync("/api/TransActivities?clss=" + clss + "&actGrps=" + actGrps + "&actDate=" + fActDate + "&dSess=" + dSess + "&mdBID=" + mdBId).Result;
                var stringData = response.Content.ReadAsStringAsync().Result;
                List<TransActivity> transActs = JsonConvert.DeserializeObject<List<TransActivity>>(stringData);
                DataOperations operation = new DataOperations();
                IEnumerable data = transActs;
                var count = data.AsQueryable().Count();
                if (dm.Skip > 0)
                    data = operation.PerformSkip(data, dm.Skip);
                if (dm.Take > 0)
                    data = operation.PerformTake(data, dm.Take);
                return Json(new { result = data, count = count });
            }
        }

        private bool TransActivityExists(int id)
        {
            return _context.TransActivity.Any(e => e.AutoId == id);
            //value="https://paynetzuat.atomtech.in/paynetz/epi/fts?login=[MerchantLogin]pass=[MerchantPass]ttype=[TransactionType]" +
            //    "prodid=[ProductID]amt=[TransactionAmount]txncurr=[TransactionCurrency]txnscamt=[TransactionServiceCharge]" +
            //    "clientcode=[ClientCode]txnid=[TransactionID]date=[TransactionDateTime]custacc=[CustomerAccountNo]" +
            //    "mdd=[MerchantDiscretionaryData]bankid=[BankID]ru=[ru]signature=[signature]" 
        }
    }
}
