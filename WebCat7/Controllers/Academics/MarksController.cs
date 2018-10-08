using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SchMod.Models.Marx;
using Syncfusion.EJ2.Base;
using Syncfusion.EJ2.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using WebCat7.Data;
using WebCat7.GenFunction;
using static WebCat7.GenFunction.GloVar;

namespace WebCat7.Controllers.Academics
{
    public class MarksController : Controller
    {
        private readonly SchContext _context;

        public MarksController(SchContext context)
        {
            _context = context;
        }
        //private AcaFunctions acaFunctions = new AcaFunctions() ;
        //private StdFns stdFns = new StdFns ();

        //AcaFunctions AcaFun = new AcaFunctions();
        // GET: Marks
        public ActionResult Index()
        {
            return View();
        }

        // GET: Marks/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Marks/Create
        public ActionResult Create()
        {
            return View();
        }

        // GET: Marks/MarksEntry
        public ActionResult MarksEntry(SelectMarks selectMarks)
        {
            //var mSubID = await AcaFunctions.GetSubID(_context, selectMarks.SubName, selectMarks.MClss);
            //var subType = await GetGradeType(_context, selectMarks.SubName, selectMarks.MClss);
            //var mrkLst = await AcaFunctions.GetMarksLst(_context, selectMarks.MClss);
            //ViewBag.DataSource = mrkLst;
            ViewBag.Clss = selectMarks.MClss;
            ViewBag.SubName = selectMarks.SubName;
            ViewBag.ExamName = selectMarks.ExamName;
            //ViewBag.SubID = mSubID;
            //ViewBag.subType = subType;
            //var grid = new WebGrid(mrkLst);
            return View();
        }

        public ActionResult DataSource(string clss ,string ExamName,  string SubName, [FromBody] DataManagerRequest dm)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(GloVar.iBaseURI);
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                HttpResponseMessage response = client.GetAsync("/api/Marks?clss=" + clss + "&ExamName=" + ExamName + "&SubName=" + SubName + "&dSess=" + dSess + "&mdBID=" + mdBId).Result;
                var stringData = response.Content.ReadAsStringAsync().Result;
                List<Marks> marks = JsonConvert.DeserializeObject<List<Marks>>(stringData);
                DataOperations operation = new DataOperations();
                IEnumerable data = marks;
                var count = data.AsQueryable().Count();
                if (dm.Skip > 0)
                    data = operation.PerformSkip(data, dm.Skip);
                if (dm.Take > 0)
                    data = operation.PerformTake(data, dm.Take);
                return Json(new { result = data, count = count });
            }
        }

        [HttpPost]
        public ActionResult Update([FromBody] MarksEdit marksVal)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(GloVar.iBaseURI);
                    MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                    client.DefaultRequestHeaders.Accept.Add(contentType);
                    string stringData = JsonConvert.SerializeObject(marksVal.Value);
                    var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");
                    HttpResponseMessage response = client.PutAsync("/api/Marks/" + marksVal.Key, contentData).Result;
                    ViewBag.Message = response.Content.ReadAsStringAsync().Result;
                    //return View(acaSession);
                }

                //_context.Update(acaSession);
                //await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!MarksExists(marksVal.value.MkID))
                //{
                //    return NotFound();
                //}
                //else
                //{
                //    throw;
                //}
            }
            //AcaSession acsess = JsonConvert.DeserializeObject<AcaSession>(value);
            return Json(marksVal.Value);
        }


        // POST: Marks/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Marks/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Marks/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Marks/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Marks/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
