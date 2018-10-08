using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
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
using static WebCat7.GenFunction.GloVar;
using static WebCat7.GenFunction.AcaFunctions;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebCat7.Controllers.Basics
{
    public class ClssesController : Controller
    {
        private readonly SchContext _context;
        //private AcaFunctions acaFunctions = new AcaFunctions();
        //private StdFns stdFns = new StdFns();

        public ClssesController(SchContext context)
        {
            _context = context;    
        }

        // GET: Clsses
        public IActionResult Index()
        {
            AcaFunctions.GetSchTeachers(_context, false);
            ViewBag.dropdownTeacher = drpTeachLst;
            //ViewBag.dropdownTeacher = new SelectList(SchTeachLst, "Value", "Text", null);
            //new string[] { "Badminton", "Basketball", "Cricket", "Football", "Golf", "Gymnastics", "Hockey", "Tennis" };
            AcaFunctions.GetSchSession(_context);
            ViewBag.dropdownSession = strSessLst;  
            return View();
        }

        // GET: Clsses/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var clss = await _context.Clss
                .SingleOrDefaultAsync(m => m.AutoId == id);
            if (clss == null)
            {
                return NotFound();
            }

            return View(clss);
        }

        // GET: Clsses/Create
        public IActionResult Create()
        {
            AcaFunctions.GetSchTeachers(_context, true);
            ViewBag.dropdownTeacher = new SelectList(SchTeachLst, "Value", "Text", null); 
            return View();
        }

        // POST: Clsses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("ClsName,ClassTeacher,ClssNum")] Clss clss)
        {
            if (ModelState.IsValid)
            {
                if (!ClssExists(clss.ClsName))
                {
                    using (HttpClient client = new HttpClient())
                    {
                        client.BaseAddress = new Uri(GloVar.iBaseURI);
                        MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                        client.DefaultRequestHeaders.Accept.Add(contentType);
                        string stringData = JsonConvert.SerializeObject(clss);
                        var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");
                        HttpResponseMessage response = client.PostAsync("/api/Clsses", contentData).Result;
                        ViewBag.Message = response.Content.ReadAsStringAsync().Result;
                        return View(clss);
                    }
                }
            }
            return View(clss);
        }

        // GET: Clsses/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var clss = await _context.Clss.SingleOrDefaultAsync(m => m.AutoId == id);
            if (clss == null)
            {
                return NotFound();
            }
            return View(clss);
        }

        // POST: Clsses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind(" ClsName,ClassTeacher,StdStrength,ClssNum")] Clss clss)
        {
            if (id != clss.AutoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clss);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClssExists(clss.AutoId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(clss);
        }

        // GET: Clsses/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var clss = await _context.Clss
                .SingleOrDefaultAsync(m => m.AutoId == id);
            if (clss == null)
            {
                return NotFound();
            }

            return View(clss);
        }

        // POST: Clsses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clss = await _context.Clss.SingleOrDefaultAsync(m => m.AutoId == id);
            _context.Clss.Remove(clss);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Update([FromBody] ClssEdit clssVal)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    clssVal.Value.AcaSession = dSess;
                    clssVal.Value.DBid = mdBId;
                    client.BaseAddress = new Uri(GloVar.iBaseURI);
                    MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                    client.DefaultRequestHeaders.Accept.Add(contentType);
                    string stringData = JsonConvert.SerializeObject(clssVal.Value);
                    var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");
                    HttpResponseMessage response = client.PutAsync("/api/Clsses/" + clssVal.Key, contentData).Result;
                    ViewBag.Message = response.Content.ReadAsStringAsync().Result;
                    //return View(acaSession);
                }

                //_context.Update(acaSession);
                //await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClssExists(clssVal.Value.ClsId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            //AcaSession acsess = JsonConvert.DeserializeObject<AcaSession>(value);
            return Json(clssVal.Value);
        }


        public ActionResult DataSource(string sess,[FromBody] DataManagerRequest dm)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(GloVar.iBaseURI);
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                HttpResponseMessage response = client.GetAsync("/api/Clsses/?sess=" + sess + "&mdBId=" + mdBId).Result;
                var stringData = response.Content.ReadAsStringAsync().Result;
                List<Clss> clsses = JsonConvert.DeserializeObject<List<Clss>>(stringData);
                DataOperations operation = new DataOperations();
                IEnumerable data = clsses;
                var count = data.AsQueryable().Count();
                if (dm.Skip > 0)
                    data = operation.PerformSkip(data, dm.Skip);
                if (dm.Take > 0)
                    data = operation.PerformTake(data, dm.Take);
                return Json(new { result = data, count = count });
            }
        }

        private bool ClssExists(int id)
        {
            return _context.Clss.Any(e => e.AutoId == id);
        }
        private bool ClssExists(string  clss)
        {
            return _context.Clss.Any(e => e.ClsName == clss);
        }
    }
}
