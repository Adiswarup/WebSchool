using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SchMod.Models;
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
using static WebCat7.GenFunction.AcaFunctions;
using static WebCat7.GenFunction.GloVar;

namespace WebCat7.Controllers.StdFee
{
    public class DynaFeesController : Controller
    {
        private readonly SchContext _context;
        HttpClient client;
        string url = iBaseURI;
        List<SelectListItem> SchFeeNameLst;
        DateTime feeDueOn;

        public DynaFeesController(SchContext context)
        {
            _context = context;
            client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }

        // GET: DynaFees
        public async Task<IActionResult> Index()
        {
            GetSchClss(_context);
            ViewBag.SchClssLst =     new SelectList(SchClsLst, "Value", "Text", null);
            GetSchSession(_context);
            ViewBag.AcaSession =  new SelectList(SchSessLst, "Value", "Text", null);
            GetStdFeeCat(_context);
            ViewBag.StdFeeCat =   new SelectList(SchStdFeeCat, "Value", "Text", null);
            ViewBag.StdFeeName = new SelectList("None", "None");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index([Bind("Caption,ForMonth,Amount,FeeCaption,ForClass,StdCategory, SessionName ")] DynaFee dynaFee)
        {
            if (ModelState.IsValid)
            {
                GetSchClss(_context);
                ViewBag.SchClssLst = new SelectList(SchClsLst, "Value", "Text", null);
                GetSchSession(_context);
                ViewBag.AcaSession = new SelectList(SchSessLst, "Value", "Text", null);
                GetStdFeeCat(_context);
                ViewBag.StdFeeCat = new SelectList(SchStdFeeCat, "Value", "Text", null);
                ViewBag.StdFeeName = new SelectList("None", "None");
                if (dynaFee.ForClass != "")
                {
                    if (dynaFee.SessionName != "")
                    {
                        if (dynaFee.StdCategory != "")
                        {
                            HttpResponseMessage responseMessage = await client.GetAsync(url + "/api/Func/GetStdFeeName/?clss=" + dynaFee.ForClass + "&tSess=" + dynaFee.SessionName + "&stdFeeCat=" + dynaFee.StdCategory + "&dSess=" + dSess + "&mdBId=" + mdBId);
                            if (responseMessage.IsSuccessStatusCode)
                            {
                                var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                               SchFeeNameLst = JsonConvert.DeserializeObject<List<SelectListItem>>(responseData);
                            }
                        }
                    }
                }
                ViewBag.StdFeeName= new SelectList(SchFeeNameLst, "Value", "Text", null);
            }
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditDynaFee(DynaFee dynaFee)
        {
            try
            {
                ViewBag.Clss = dynaFee.ForClass;
                ViewBag.SessionName = dynaFee.SessionName;
                ViewBag.StdCategory = dynaFee.StdCategory;
                ViewBag.FeeCaption = dynaFee.FeeCaption;
                HttpResponseMessage responseMessage = await client.GetAsync(url + "/api/Func/GetStdFeeDate/?clss=" + dynaFee.ForClass + "&tSess=" + dynaFee.SessionName + "&stdFeeCat=" + dynaFee.StdCategory + "&stdFeeCap=" + dynaFee.FeeCaption + "&dSess=" + dSess + "&mdBId=" + mdBId);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                    feeDueOn = JsonConvert.DeserializeObject<DateTime>(responseData);
                }

                ViewBag.BillDate = feeDueOn;
                return View();
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> NewDynaFee(DynaFee dynaFee)
        {
            try
            {
                ViewBag.Clss = dynaFee.ForClass;
                ViewBag.SessionName = dynaFee.SessionName;
                ViewBag.StdCategory = dynaFee.StdCategory;
                ViewBag.FeeCaption = dynaFee.FeeCaption;
                return View(); 
            }
            catch
            {
                return View();
            }
        }



        // GET: DynaFees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dynaFee = await _context.DynaFee
                .SingleOrDefaultAsync(m => m.ClsFeeId == id);
            if (dynaFee == null)
            {
                return NotFound();
            }

            return View(dynaFee);
        }

        // GET: DynaFees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DynaFees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AutoId,ClsFeeId,FeeNo,Caption,ForMonth,Amount,FeeCaption,PayByDate,ForClass,StdCategory,DueOn")] DynaFee dynaFee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dynaFee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dynaFee);
        }

        // GET: DynaFees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dynaFee = await _context.DynaFee.SingleOrDefaultAsync(m => m.ClsFeeId == id);
            if (dynaFee == null)
            {
                return NotFound();
            }
            return View(dynaFee);
        }

        // POST: DynaFees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AutoId,ClsFeeId,FeeNo,Caption,ForMonth,Amount,FeeCaption,PayByDate,ForClass,StdCategory,DueOn")] DynaFee dynaFee)
        {
            if (id != dynaFee.ClsFeeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dynaFee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DynaFeeExists(dynaFee.ClsFeeId))
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
            return View(dynaFee);
        }

        // GET: DynaFees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dynaFee = await _context.DynaFee
                .SingleOrDefaultAsync(m => m.ClsFeeId == id);
            if (dynaFee == null)
            {
                return NotFound();
            }

            return View(dynaFee);
        }

        // POST: DynaFees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dynaFee = await _context.DynaFee.SingleOrDefaultAsync(m => m.ClsFeeId == id);
            _context.DynaFee.Remove(dynaFee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public ActionResult Update(string clss, string tSess, string stdFeeCat,string feeCap, DateTime feeDate, [FromBody] DynaFeeEdit dynaFeeVal)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    dynaFeeVal.Value.ForClass = clss;
                    dynaFeeVal.Value.StdCategory = stdFeeCat;
                    dynaFeeVal.Value.SessionName = tSess;
                    dynaFeeVal.Value.FeeCaption = feeCap;
                    dynaFeeVal.Value.ForMonth =  feeDate;
                    dynaFeeVal.Value.DBid = mdBId;
                    client.BaseAddress = new Uri(GloVar.iBaseURI);
                    MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                    client.DefaultRequestHeaders.Accept.Add(contentType);
                    string stringData = JsonConvert.SerializeObject(dynaFeeVal.Value);
                    var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");
                    HttpResponseMessage response = client.PutAsync("/api/DynaFees/" + dynaFeeVal.Key, contentData).Result;
                    ViewBag.Message = response.Content.ReadAsStringAsync().Result;
                }

                //_context.Update(acaSession);
                //await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DynaFeeExists(dynaFeeVal.Value.ClsFeeId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            //AcaSession acsess = JsonConvert.DeserializeObject<AcaSession>(value);
            return Json(dynaFeeVal.Value);
        }

        public ActionResult DataSource(string clss, string tSess, string stdFeeCat,string FeeCap, [FromBody] DataManagerRequest dm)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(GloVar.iBaseURI);
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                HttpResponseMessage response = client.GetAsync("/api/DynaFees?clss=" + clss  + "&tSess=" + tSess + "&stdFeeCat=" 
                                        + stdFeeCat + "&FeeCap=" + FeeCap + "&dSess=" + dSess + "&mdBID=" + mdBId).Result;
                var stringData = response.Content.ReadAsStringAsync().Result;
                List<DynaFee> dynaFee = JsonConvert.DeserializeObject<List<DynaFee>>(stringData);
                IEnumerable data = dynaFee;

                var count = data.AsQueryable().Count();
                DataResult resultx = new DataResult();
                DataOperations operation = new DataOperations();
                List<string> str = new List<string>();
                if (dm.Aggregates != null)
                {
                    for (var i = 0; i < dm.Aggregates.Count; i++)
                        str.Add(dm.Aggregates[i].Field);
                    resultx.aggregate = operation.PerformSelect(data, str);
                    //resultx.aggregate = operation.GetSummaryValue(data.AsQueryable(), SummaryType.Sum, dm.Aggregates[0].Field);
                }
                resultx.count = count;
                resultx.result = data;

                if (dm.Skip > 0)
                    data = operation.PerformSkip(data, dm.Skip);
                if (dm.Take > 0)
                    data = operation.PerformTake(data, dm.Take);
                //return Json(new { result = data, count = count });
                return Json(resultx);
            }
        }

        private bool DynaFeeExists(int id)
        {
            return _context.DynaFee.Any(e => e.ClsFeeId == id);
        }
    }


}
