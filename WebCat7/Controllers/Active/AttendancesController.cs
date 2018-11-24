using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchMod.Models.Active;
using WebCat7.Data;
using System.Net.Http;
using System.Net.Http.Headers;
using WebCat7.GenFunction;
using Newtonsoft.Json;
using Syncfusion.EJ2.Base;
using Syncfusion.EJ2.Grids;
using Syncfusion.EJ2.Inputs;
using Syncfusion.EJ2.Linq;
using System.Collections;
using static WebCat7.GenFunction.GloVar;
using static WebCat7.GenFunction.GloFunc;
using static WebCat7.GenFunction.AcaFunctions;


namespace WebCat7.Controllers.Active
{
    public class AttendancesController : Controller
    {
        private readonly SchContext _context;

        public AttendancesController(SchContext context)
        {
            _context = context;
        }

        // GET: Attendances
        public async Task<IActionResult> Index()
        {
            List<string> ls = new List<string>
            {
                "Class",
                "Lunch",
                "Bus"
            };

            GetSchClss(_context);
            ViewBag.clsses = StrClsLst;
            ViewBag.dropdownAtType = ls;
            ViewBag.AtType = "Class";
            ViewBag.AtDate = DateTime.Now;
            return View();
            //return View(await _context.Attendance.ToListAsync());
        }

        // GET: Attendances/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attendance = await _context.Attendance
                .SingleOrDefaultAsync(m => m.AutoId == id);
            if (attendance == null)
            {
                return NotFound();
            }

            return View(attendance);
        }

        // GET: Attendances/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Attendances/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AutoId,AttId,UniReg,RegNum,Clss,Month,Year,AtType,AttDate,Cause,Remark,AcaSession,Dormant,LoginName,ModTime,CTerminal,DBid")] Attendance attendance)
        {
            if (ModelState.IsValid)
            {
                _context.Add(attendance);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(attendance);
        }

        // GET: Attendances/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attendance = await _context.Attendance.SingleOrDefaultAsync(m => m.AutoId == id);
            if (attendance == null)
            {
                return NotFound();
            }
            return View(attendance);
        }

        // POST: Attendances/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AutoId,AttId,UniReg,RegNum,Clss,Month,Year,AtType,AttDate,Cause,Remark,AcaSession,Dormant,LoginName,ModTime,CTerminal,DBid")] Attendance attendance)
        {
            if (id != attendance.AutoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(attendance);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AttendanceExists(attendance.AutoId))
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
            return View(attendance);
        }

        // GET: Attendances/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attendance = await _context.Attendance
                .SingleOrDefaultAsync(m => m.AutoId == id);
            if (attendance == null)
            {
                return NotFound();
            }

            return View(attendance);
        }

        // POST: Attendances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var attendance = await _context.Attendance.SingleOrDefaultAsync(m => m.AutoId == id);
            _context.Attendance.Remove(attendance);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        public ActionResult Update(string clss, string atType, DateTime AtDate, [FromBody] AttendanceEdit AttVal)
        {
            AttVal.Value.DBid = mdBId;
            AttVal.Value.AcaSession = dSess;
            AttVal.Value.Clss = clss;
            AttVal.Value.AtType = atType;
            AttVal.Value.AttDate = AtDate;
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(GloVar.iBaseURI);
                    MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                    client.DefaultRequestHeaders.Accept.Add(contentType);
                    string stringData = JsonConvert.SerializeObject(AttVal.Value);
                    var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");
                    HttpResponseMessage response = client.PutAsync("/api/Attendances/" + AttVal.Key, contentData).Result;
                    ViewBag.Message = response.Content.ReadAsStringAsync().Result;
                    //return View(acaSession);
                }

                //_context.Update(acaSession);
                //await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AttendanceExists(AttVal.Value.AttId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            //AcaSession acsess = JsonConvert.DeserializeObject<AcaSession>(value);
            return Json(AttVal.Value);
        }

        public ActionResult DataSource(string clss, string atType, DateTime AtDate, [FromBody] DataManagerRequest dm)
        {
            if (atType == null) {
                return RedirectToAction("Index");
            }
            if (clss == null)
            {
                return RedirectToAction("Index");
            }
            if (AtDate == null)
            {
                return RedirectToAction("Index");
            }
           if (AtDate.ToOADate() == 0)
            {
                return RedirectToAction("Index");
            }
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(GloVar.iBaseURI);
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                HttpResponseMessage response = client.GetAsync("/api/Attendances/?clss=" + clss + "&atType=" + atType + "&atDate="  + AtDate.ToOADate()  + " &dSess=" + dSess + "&mdBId=" + mdBId).Result;
                var stringData = response.Content.ReadAsStringAsync().Result;
                List<Attendance> AttMe = JsonConvert.DeserializeObject<List<Attendance>>(stringData);
                DataOperations operation = new DataOperations();
                IEnumerable data = AttMe;
                var count = data.AsQueryable().Count();
                if (dm.Skip > 0)
                    data = operation.PerformSkip(data, dm.Skip);
                if (dm.Take > 0)
                    data = operation.PerformTake(data, dm.Take);
                return Json(new { result = data, count = count });
            }
        }

        private bool AttendanceExists(int id)
        {
            return _context.Attendance.Any(e => e.AutoId == id);
        }
    }
}
