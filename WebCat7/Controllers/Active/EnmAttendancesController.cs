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
    public class EnmAttendancesController : Controller
    {
        private readonly SchContext _context;

        public EnmAttendancesController(SchContext context)
        {
            _context = context;
        }

        // GET: Attendances
        [HttpGet]
        [ActionName("Index")]
        public IActionResult Index_Get()
        {
            List<string> ls = new List<string>
            {
                "Class",
                "Lunch",
                "Bus"
            };
            EnmAttendance enmAttendance = new EnmAttendance();
            GetSchClss(_context);
            ViewBag.Schclsses = new SelectList(SchClsLst, "Value", "Text", null);
            ViewBag.dropdownAtType = ls;
            enmAttendance.AttType  = "Class";
            enmAttendance.AttDate = DateTime.Now;
            return View(enmAttendance);
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

        [HttpPost]
        public ActionResult Update(string clss, string atType, DateTime AtDate, [FromBody] EnmAttendanceEdit AttVal)
        {
            AttVal.Value.DBid = mdBId;
            AttVal.Value.StdClss = clss;
            AttVal.Value.AttType = atType;
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
                    HttpResponseMessage response = client.PutAsync("/api/EnmAttendances/" + AttVal.Key, contentData).Result;
                    ViewBag.Message = response.Content.ReadAsStringAsync().Result;
                    //return View(acaSession);
                }

                //_context.Update(acaSession);
                //await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AttendanceExists(AttVal.Value.AutoId))
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
                HttpResponseMessage response = client.GetAsync("/api/EnmAttendances/?clss=" + clss + "&atType=" + atType + "&atDate="  + AtDate.ToOADate()  + " &dSess=" + dSess + "&mdBId=" + mdBId).Result;
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
