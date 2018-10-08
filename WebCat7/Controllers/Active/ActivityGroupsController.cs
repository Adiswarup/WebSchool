using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SchMod.Models.Active;
using SchMod.Models.Basics;
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
    public class ActivityGroupsController : Controller
    {
        private readonly SchContext _context;

        public ActivityGroupsController(SchContext context)
        {
            _context = context;
        }

        // GET: ActivityGroups
        public async Task<IActionResult> Index()
        {
            // List<dropDown> lsGradeType = new List<dropDown>
            //{
            //    new dropDown("5 Point Scale", "5 Point Scale"),
            //    new dropDown("3 Point Scale", "3 Point Scale"),
            //};
            AcaFunctions.GetActivityGradeType(_context, false);
            AcaFunctions.GetSchSession(_context);
            ViewBag.dropdownSession = strSessLst;
            ViewBag.dropdownGradeType = drpActGrdLst; // lsGradeType;
            return View();
        }

        // GET: ActivityGroups/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activityGroup = await _context.ActivityGroup
                .SingleOrDefaultAsync(m => m.AutoId == id);
            if (activityGroup == null)
            {
                return NotFound();
            }

            return View(activityGroup);
        }

        // GET: ActivityGroups/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ActivityGroups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ActGroupName,IsReflectedInReportCard,ActGroupReportCard,ActGroupMotive,ActCode,GradeType,Clss,ActSn")] ActivityGroup activityGroup)
        {
            if (ModelState.IsValid)
            {
                if (!ActivityGroupExists(activityGroup.ActGroupName))
                {
                    using (HttpClient client = new HttpClient())
                    {
                        client.BaseAddress = new Uri(GloVar.iBaseURI);
                        MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                        client.DefaultRequestHeaders.Accept.Add(contentType);
                        string stringData = JsonConvert.SerializeObject(activityGroup);
                        var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");
                        HttpResponseMessage response = client.PostAsync("/api/ActivityGroups", contentData).Result;
                        ViewBag.Message = response.Content.ReadAsStringAsync().Result;
                        return View(activityGroup);
                    }
                }
            }

            //if (ModelState.IsValid)
            //{
            //    _context.Add(activityGroup);
            //    await _context.SaveChangesAsync();
            //    return RedirectToAction(nameof(Index));
            //}
            //return View(activityGroup);
            return RedirectToAction("Index");
        }

        // GET: ActivityGroups/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activityGroup = await _context.ActivityGroup.SingleOrDefaultAsync(m => m.AutoId == id);
            if (activityGroup == null)
            {
                return NotFound();
            }
            return View(activityGroup);
        }

        // POST: ActivityGroups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AutoId,ActGroupId,ActGroupName,IsReflectedInReportCard,ActGroupReportCard,ActGroupMotive,ActCode,GradeType,Clss,ActSn,ActClss,ActSession")] ActivityGroup activityGroup)
        {
            if (id != activityGroup.AutoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(activityGroup);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ActivityGroupExists(activityGroup.AutoId))
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
            return View(activityGroup);
        }

        // GET: ActivityGroups/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activityGroup = await _context.ActivityGroup
                .SingleOrDefaultAsync(m => m.AutoId == id);
            if (activityGroup == null)
            {
                return NotFound();
            }

            return View(activityGroup);
        }

        // POST: ActivityGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var activityGroup = await _context.ActivityGroup.SingleOrDefaultAsync(m => m.AutoId == id);
            _context.ActivityGroup.Remove(activityGroup);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public ActionResult Update([FromBody] ActivityGroupEdit ActGroupVal)
        {
            try
            {
                ActGroupVal.Value.ActSession = dSess;
                ActGroupVal.Value.DBid = mdBId;
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(GloVar.iBaseURI);
                    MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                    client.DefaultRequestHeaders.Accept.Add(contentType);
                    string stringData = JsonConvert.SerializeObject(ActGroupVal.Value);
                    var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");
                    HttpResponseMessage response = client.PutAsync("/api/ActivityGroups/" + ActGroupVal.Key, contentData).Result;
                    ViewBag.Message = response.Content.ReadAsStringAsync().Result;
                    //return View(acaSession);
                }

                //_context.Update(acaSession);
                //await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActivityGroupExists(ActGroupVal.Value.ActGroupId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            //AcaSession acsess = JsonConvert.DeserializeObject<AcaSession>(value);
            return Json(ActGroupVal.Value);
        }

        public ActionResult DataSource([FromBody] DataManagerRequest dm)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(iBaseURI);
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                HttpResponseMessage response = client.GetAsync("/api/ActivityGroups/?mdBID=" + mdBId).Result;
                var stringData = response.Content.ReadAsStringAsync().Result;
                List<ActivityGroup> acaSession = JsonConvert.DeserializeObject<List<ActivityGroup>>(stringData);
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

        private bool ActivityGroupExists(int actGrpID)
        {
            return _context.ActivityGroup.Any(e => e.ActGroupId == actGrpID);
        }
        private bool ActivityGroupExists(string ActGrpName)
        {
            return _context.ActivityGroup.Any(e => e.ActGroupName == ActGrpName);
        }
    }
}
