using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchMod.Models.Marx;
using System.Threading.Tasks;
using WebCat7.Data;
using static WebCat7.GenFunction.AcaFunctions;
using static WebCat7.GenFunction.GloVar;
using System.Net.Http;
using System;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace WebCat7.Controllers.Academics
{
    public class SelectMarksController : Controller
    {
        //private AcaFunctions acaFunctions = new AcaFunctions();   
        public List<SelectListItem> SchClssLst;

        private readonly SchContext _context;
        HttpClient client;
        string url = iBaseURI;
        public SelectMarksController(SchContext context)
        {
            _context = context;
            client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        //AcaFunctions AcaFun
        // GET: SelectMarks
        public ActionResult Index()
        {
            return View();
        }
        // GET: SelectMarks
        public async  Task<ActionResult> Choose()
        {
            //ViewBag.SchSessLst =await GetSchSession(_context);
            GetSchClss(_context);
            ViewBag.SchClssLst = new SelectList(SchClsLst, "Value", "Text", null);
            ViewBag.SchExmLst =await GetSchExm(_context, dClss);
            ViewBag.SchSubLst =await  GetSchSub(_context, dClss, dExm );
            return View();
        }

        // POST: SelectMarks/Choose
        [HttpPost]
        public async Task<ActionResult> Choose(SelectMarks selectMarks)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    HttpResponseMessage responseMessage = await client.GetAsync(url + "/api/Func/GetSchClss/?dSess=" + dSess + "&mdBId=" + mdBId);
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                        SchClssLst = JsonConvert.DeserializeObject<List<SelectListItem>>(responseData);
                        //ViewBag.SchSessLst = await GetSchSession(_context);
                    }
                    //    GetSchClss(_context);
                    ViewBag.SchClssLst = new SelectList(SchClssLst, "Value", "Text", null);
                    ViewBag.SchExmLst = await GetSchExm(_context, selectMarks.MClss);
                    ViewBag.SchSubLst = await GetSchSub(_context, selectMarks.MClss,selectMarks.ExamName );
                }
                return View(selectMarks);
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        //[SubmitButtonSelector(Name = "Delete")]
        public ActionResult ChSubjects(SelectMarks selectMarks)
        {
            try
            {
                // TODO: Add update logic here
                //@Html.ActionLink("Marks", "Choose", "SelectMarks")
                return RedirectToAction("..//Marks/MarksEntry",selectMarks);
            }
            catch
            {
                return View();
            }
        }

        // GET: SelectMarks/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SelectMarks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SelectMarks/Create
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

        // GET: SelectMarks/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SelectMarks/Edit/5
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

        // GET: SelectMarks/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SelectMarks/Delete/5
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
