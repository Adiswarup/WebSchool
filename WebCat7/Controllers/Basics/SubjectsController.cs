using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
    public class SubjectsController : Controller
    {
        private readonly SchContext _context;

        public SubjectsController(SchContext context)
        {
            _context = context;
        }

        // GET: Subjects
        public async Task<IActionResult> Index()
        {
            GetSchClss(_context);
            //ViewBag.clsses = GetSchClss(_context, GloVar.dSess);
            //List<string> ls = new List<string>();
            ViewBag.clsses = StrClsLst;
            //ls.Add("All");
            //ls.Add("IX-A");
            //ls.Add("IX-B");
            //List<dropDown> lsTeach = new List<dropDown>();
            //lsTeach.Add(new dropDown("All", "All"));
            //lsTeach.Add(new dropDown("Ferasat", "Ferasat"));
            //lsTeach.Add(new dropDown("Gaurav", "Gaurav"));
            //lsTeach.Add("All");
            //lsTeach.Add("Ferasat");
            //lsTeach.Add("Gaurav");
            //ViewBag.clsses = ls;
            AcaFunctions.GetSchTeachers(_context, false);
            ViewBag.dropdownTeacher = drpTeachLst;
            return View();
        }

        // GET: Subjects/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subjects = await _context.Subjects
                .SingleOrDefaultAsync(m => m.SubAutoId == id);
            if (subjects == null)
            {
                return NotFound();
            }

            return View(subjects);
        }

        // GET: Subjects/Create
        public IActionResult Create()
        {
            GetSchTeachers(_context, true);
            ViewBag.dropdownTeacher = new SelectList(SchTeachLst, "Value", "Text", null);  //drpTeachLst;
            GetSchClss(_context);
            ViewBag.dropdownClass = new SelectList(SchClsLst, "Value", "Text", null);  //drpClsLst;
            return View();
        }

        // POST: Subjects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SubId,SubName,SubCode,Clss,PrefTeacher")] Subjects subjects)
        {
            if (ModelState.IsValid)
            {
                if (!SubjectsExistsName(subjects.SubName))
                {
                    using (HttpClient client = new HttpClient())
                    {
                        client.BaseAddress = new Uri(GloVar.iBaseURI);
                        MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                        client.DefaultRequestHeaders.Accept.Add(contentType);
                        string stringData = JsonConvert.SerializeObject(subjects);
                        var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");
                        HttpResponseMessage response = client.PostAsync("/api/Subjects", contentData).Result;
                        ViewBag.Message = response.Content.ReadAsStringAsync().Result;
                        if (response.IsSuccessStatusCode)
                        {
                            ViewBag.Remark = "Creation of Subject '" + subjects.SubName + "' Successful";
                            GetSchTeachers(_context, true);
                            ViewBag.dropdownTeacher = new SelectList(SchTeachLst, "Value", "Text", null);  //drpTeachLst;
                            GetSchClss(_context);
                            ViewBag.dropdownClass = new SelectList(SchClsLst, "Value", "Text", null);  //drpClsLst;
                            return View();
                        }
                        else
                        {
                            ViewBag.Remark = "Creation of Subject '" + subjects.SubName + "' Failed!. Please Try Again";
                            GetSchTeachers(_context, true);
                            ViewBag.dropdownTeacher = new SelectList(SchTeachLst, "Value", "Text", null);  //drpTeachLst;
                            GetSchClss(_context);
                            ViewBag.dropdownClass = new SelectList(SchClsLst, "Value", "Text", null);  //drpClsLst;
                            return View(subjects);
                        }
                    }
                }
                else
                {
                    ViewBag.Remark = "Failed Subject '" + subjects.SubName + "' Already Exists.";
                    GetSchTeachers(_context, true);
                    ViewBag.dropdownTeacher = new SelectList(SchTeachLst, "Value", "Text", null);  //drpTeachLst;
                    GetSchClss(_context);
                    ViewBag.dropdownClass = new SelectList(SchClsLst, "Value", "Text", null);  //drpClsLst;
                    return View(subjects);
                }
            }
            else
            {
                ViewBag.Remark = "Failed! Subject '" + subjects.SubName + "' Unable To create. PleaseTry Again.";
                GetSchTeachers(_context, true);
                ViewBag.dropdownTeacher = new SelectList(SchTeachLst, "Value", "Text", null);  //drpTeachLst;
                GetSchClss(_context);
                ViewBag.dropdownClass = new SelectList(SchClsLst, "Value", "Text", null);  //drpClsLst;
                return View(subjects);
            }
        }

        // GET: Subjects/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subjects = await _context.Subjects.SingleOrDefaultAsync(m => m.SubAutoId == id);
            if (subjects == null)
            {
                return NotFound();
            }
            return View(subjects);
        }

        // POST: Subjects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SubId,SubName,SubCode,Clss,PrefTeacher,TeachId")] Subjects subjects)
        {
            if (id != subjects.SubAutoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(subjects);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubjectsExists(subjects.SubAutoId))
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
            return View(subjects);
        }

        // GET: Subjects/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subjects = await _context.Subjects
                .SingleOrDefaultAsync(m => m.SubAutoId == id);
            if (subjects == null)
            {
                return NotFound();
            }

            return View(subjects);
        }

        // POST: Subjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var subjects = await _context.Subjects.SingleOrDefaultAsync(m => m.SubAutoId == id);
            _context.Subjects.Remove(subjects);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Update([FromBody] SubjectsEdit subjectsVal)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    subjectsVal.Value.AcaSession = dSess;
                    subjectsVal.Value.DBid = mdBId;
                    client.BaseAddress = new Uri(GloVar.iBaseURI);
                    MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                    client.DefaultRequestHeaders.Accept.Add(contentType);
                    string stringData = JsonConvert.SerializeObject(subjectsVal.Value);
                    var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");
                    HttpResponseMessage response = client.PutAsync("/api/Subjects/" + subjectsVal.Key, contentData).Result;
                    ViewBag.Message = response.Content.ReadAsStringAsync().Result;
                    //return View(acaSession);
                }

                //_context.Update(acaSession);
                //await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubjectsExists(subjectsVal.Value.SubId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            //AcaSession acsess = JsonConvert.DeserializeObject<AcaSession>(value);
            return Json(subjectsVal.Value);
        }


        public ActionResult DataSource(string clss, [FromBody] DataManagerRequest dm)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(GloVar.iBaseURI);
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                HttpResponseMessage response = client.GetAsync("/api/Subjects?clss=" + clss + "&dSess=" + dSess + "&mdBID=" + mdBId).Result;
                var stringData = response.Content.ReadAsStringAsync().Result;
                List<Subjects> subjects = JsonConvert.DeserializeObject<List<Subjects>>(stringData);
                DataOperations operation = new DataOperations();
                IEnumerable data = subjects;
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


        private bool SubjectsExists(int id)
        {
            return _context.Subjects.Any(e => e.SubAutoId == id);
        }

        private bool SubjectsExistsName(string subName)
        {
            return _context.Subjects.Any(e => e.SubName == subName);
        }
    }
}
