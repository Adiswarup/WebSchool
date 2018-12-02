using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SchMod.Models.Basics;
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

namespace WebCat7.Controllers.Basics
{
    //[EnableCors("AllowCors")]
    public class TeachersController : Controller
    {
        public static List<Teachers> TechLst = new List<Teachers>();
        private readonly SchContext _context;

        public TeachersController(SchContext context)
        {
            _context = context;
        }

        //// GET: Teachers
        //public async Task<JsonResult> TeachSource() //jsonresult
        //{
        //    TechLst = await acaFunctions.GetTeachLst(_context, GloVar.dSess);
        //    var list = TechLst.ToList();
        //    return Json(new { result = list, count = list.Count });
        //    //return TechLst;  //Json(list);
        //    //return View(await acaFunctions.GetTeachLst(_context , GloVar.dSess));
        //}

        // public async Task<IEnumerable<Teachers>> GetAll()
        //{
        //    TechLst = await acaFunctions.GetTeachLst(_context, GloVar.dSess);
        //    return TechLst;
        //}

        [EnableCors("AllowCors")]
        public ActionResult Index()
        {
            return View();
        }

        // GET: Teachers/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teachers = await _context.Teachers
                .SingleOrDefaultAsync(m => m.AutoId == id);
            if (teachers == null)
            {
                return NotFound();
            }

            return View(teachers);
        }

        // GET: Teachers/Create
        public IActionResult Create()
        {
                return View();
        }

        // POST: Teachers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Teachers teachers)
        {
            if (ModelState.IsValid)
            {
                if (!TeachersExists(teachers.tName))
                {
                    teachers.dBid = mdBId;
                    using (HttpClient client = new HttpClient())
                    {
                        client.BaseAddress = new Uri(GloVar.iBaseURI);
                        MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                        client.DefaultRequestHeaders.Accept.Add(contentType);
                        string stringData = JsonConvert.SerializeObject(teachers);
                        var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");
                        HttpResponseMessage response = client.PostAsync("/api/Teachers", contentData).Result;
                        ViewBag.Message = response.Content.ReadAsStringAsync().Result;
                        if (response.IsSuccessStatusCode)
                        {
                            ViewBag.Remark = "Creation of Teacher '" + teachers.tName + "' Successful";
                            return View();
                        }
                        else
                        {
                            ViewBag.Remark = "Creation of Teacher '" + teachers.tName + "' Failed!. Please Try Again";
                            return View(teachers);
                        }
                    }
                }
                else
                {
                    ViewBag.Remark = "Failed Teacher '" + teachers.tName + "' Already Exists.";
                    return View(teachers);
                }
            }
            else
            {
                ViewBag.Remark = "Failed! Teacher '" + teachers.tName + "' Unable To create. PleaseTry Again.";
                return View(teachers);
            }
        }

        // GET: Teachers/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teachers = await _context.Teachers.SingleOrDefaultAsync(m => m.AutoId == id);
            if (teachers == null)
            {
                return NotFound();
            }
            return View(teachers);
        }

        // POST: Teachers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AutoId,TName,TTelephone,TeachLoginName,TeachEMail")] Teachers teachers)
        {
            if (id != teachers.AutoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(teachers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeachersExists(teachers.AutoId))
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
            return View(teachers);
        }

        // GET: Teachers/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teachers = await _context.Teachers
                .SingleOrDefaultAsync(m => m.AutoId == id);
            if (teachers == null)
            {
                return NotFound();
            }

            return View(teachers);
        }

        // POST: Teachers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var teachers = await _context.Teachers.SingleOrDefaultAsync(m => m.AutoId == id);
            _context.Teachers.Remove(teachers);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }


        [HttpPost]
        public ActionResult Update([FromBody] TeachersEdit teachVal)
        {
            try
            {
                teachVal.Value.dBid = mdBId ;
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(GloVar.iBaseURI);
                    MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                    client.DefaultRequestHeaders.Accept.Add(contentType);
                    string stringData = JsonConvert.SerializeObject(teachVal.Value);
                    var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");
                    HttpResponseMessage response = client.PutAsync("/api/Teachers/" + teachVal.Key, contentData).Result;
                    ViewBag.Message = response.Content.ReadAsStringAsync().Result;
                    //return View(acaSession);
                }

                //_context.Update(acaSession);
                //await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeachersExists(teachVal.Value.teachId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            //AcaSession acsess = JsonConvert.DeserializeObject<AcaSession>(value);
            return Json(teachVal.Value);
        }

        public ActionResult DataSource([FromBody] DataManagerRequest dm)
         {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(GloVar.iBaseURI);
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                HttpResponseMessage response = client.GetAsync("/api/Teachers/?dSess=" + dSess + "&mdBID=" + mdBId).Result;
                var stringData = response.Content.ReadAsStringAsync().Result;
                List<Teachers> teachData = JsonConvert.DeserializeObject<List<Teachers>>(stringData);
                DataOperations operation = new DataOperations();
                IEnumerable data = teachData;
                var count = data.AsQueryable().Count();
                if (dm.Skip > 0)
                    data = operation.PerformSkip(data, dm.Skip);
                if (dm.Take > 0)
                    data = operation.PerformTake(data, dm.Take);
                return Json(new { result = data, count = count });
            }
        }

        private bool TeachersExists(int id)
        {
            return _context.Teachers.Any(e => e.AutoId == id);
        }
        private bool TeachersExists(string teachName)
        {
            return _context.Teachers.Any(e => e.tName == teachName);
        }
    }
}
