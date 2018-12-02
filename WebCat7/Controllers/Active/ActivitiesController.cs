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
    public class ActivitiesController : Controller
    {
        private readonly SchContext _context;

        public ActivitiesController(SchContext context)
        {
            _context = context;
        }

        // GET: Activities
        public async Task<IActionResult> Index()
        {
            GetActivityGroup(_context);
            ViewBag.dropdownActGrp = StrActivityGroup;
            ViewBag.ActGrp = drpActivityGroup;
            return View();
        }

        // GET: Activities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activity = await _context.Activity
                .SingleOrDefaultAsync(m => m.AutoId == id);
            if (activity == null)
            {
                return NotFound();
            }

            return View(activity);
        }

        // GET: Activities/Create
        public IActionResult Create()
        {
            GetActivityGroup(_context);
            ViewBag.ActGrp = new SelectList(SchActivityGroup, "Value", "Text", null);
            return View();
        }

        // POST: Activities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("ActivityName,ActivityValue,ActivityGroup,ActGroupId,ActivityRemarks,ActivityDate,SendSms,SendEmail, DBid")] Activity activity)
        {
            if (!ActivityExists(activity.ActivityId))
            {
                activity.DBid = mdBId;
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(GloVar.iBaseURI);
                    MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                    client.DefaultRequestHeaders.Accept.Add(contentType);
                    string stringData = JsonConvert.SerializeObject(activity);
                    var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");
                    HttpResponseMessage response = client.PostAsync("/api/Activities", contentData).Result;
                    ViewBag.Message = response.Content.ReadAsStringAsync().Result;
                    if (response.IsSuccessStatusCode)
                    {
                        GetActivityGroup(_context);
                        ViewBag.ActGrp = new SelectList(SchActivityGroup, "Value", "Text", null);
                        ViewBag.Remark = "Creation of Activity '" + activity.ActivityName + "' Successful";
                        return View();
                    }
                    else
                    {
                        GetActivityGroup(_context);
                        ViewBag.ActGrp = new SelectList(SchActivityGroup, "Value", "Text", null);
                        ViewBag.Remark = "Creation of Session '" + activity.ActivityName + "' Failed!. Please Try Again";
                        return View(activity);
                    }
                }
            }
            else
            {
                GetActivityGroup(_context);
                ViewBag.ActGrp = new SelectList(SchActivityGroup, "Value", "Text", null);
                return View(activity);
            }
        }

        // GET: Activities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var activity = await _context.Activity.SingleOrDefaultAsync(m => m.AutoId == id);
            if (activity == null)
            {
                return NotFound();
            }
            return View(activity);
        }

        // POST: Activities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ActivityName,ActivityValue,ActivityGroup,ActGroupId,ActivityRemarks,ActivityDate,SendSms,SendEmail,LoginName,Dormant,ModTime,CTerminal,DBid")] Activity activity)
        {
            if (id != activity.AutoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(activity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ActivityExists(activity.AutoId))
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
            return View(activity);
        }

        // GET: Activities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activity = await _context.Activity
                .SingleOrDefaultAsync(m => m.AutoId == id);
            if (activity == null)
            {
                return NotFound();
            }

            return View(activity);
        }

        // POST: Activities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var activity = await _context.Activity.SingleOrDefaultAsync(m => m.AutoId == id);
            _context.Activity.Remove(activity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public ActionResult Update([FromBody] ActivityEdit activityVal)
        {
            try
            {
                activityVal.Value.ActSession = dSess;
                activityVal.Value.DBid = mdBId;
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(GloVar.iBaseURI);
                    MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                    client.DefaultRequestHeaders.Accept.Add(contentType);
                    string stringData = JsonConvert.SerializeObject(activityVal.Value);
                    var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");
                    HttpResponseMessage response = client.PutAsync("/api/Activities/" + activityVal.Key, contentData).Result;
                    ViewBag.Message = response.Content.ReadAsStringAsync().Result;
                    //return View(acaSession);
                }

                //_context.Update(acaSession);
                //await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActivityExists(activityVal.Value.ActivityId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            //AcaSession acsess = JsonConvert.DeserializeObject<AcaSession>(value);
            return Json(activityVal.Value);
        }

        public ActionResult DataSource(string ActGrp, [FromBody] DataManagerRequest dm)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(iBaseURI);
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                HttpResponseMessage response = client.GetAsync("/api/Activities/?mdBID=" + mdBId + "&ActGrp=" + ActGrp).Result;
                var stringData = response.Content.ReadAsStringAsync().Result;
                List<Activity> acaSession = JsonConvert.DeserializeObject<List<Activity>>(stringData);
                DataOperations operation = new DataOperations();
                IEnumerable data = acaSession;
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

        private bool ActivityExists(int id)
        {
            return _context.Activity.Any(e => e.AutoId == id);
        }
    }
}
