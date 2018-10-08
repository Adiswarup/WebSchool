using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using SchMod.Models.Studs;
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
using WebCat7.Data;
using WebCat7.GenFunction;
using static WebCat7.GenFunction.AcaFunctions;
using static WebCat7.GenFunction.GloVar;

namespace WebCat7.Controllers.Std
{
    public class SearchStdController : Controller
    {
        private readonly SchContext _context;

        public SearchStdController(SchContext context)
        {
            _context = context;
        }

        //private AcaFunctions acaFunctions = new AcaFunctions ();
        //private StdFns stdFns= new StdFns ();

        public ActionResult Index(SearchStd model)
        {
            string searchStr = model.SeaStr;
            IEnumerable<Students> StdDets;
            if (model.SClass == null)
            {
                SearchStd searchStd = new SearchStd
                {
                    SStdID = 0,
                    SUniReg = 0,
                    SRegNumber = 0,
                    SStdName = "",
                    SeaStr = "",
                    SClass = "",
                    SGender = 0,
                    SDOB = DateTime.Now
                };
                //searchStd.stdList = stdFns.GetStdList(_context, "2016-17", "").Result;
                GetSchClss(_context);
                ViewBag.clsses = StrClsLst;
                //ViewBag.stdList = new SelectList(SchClsLst, "Value", "Text", null);
                return View(searchStd);
            }
            else
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        ViewBag.sClss = model.SClass;
                        AcaFunctions.GetSchClss(_context);
                        ViewBag.stdList = new SelectList(SchClsLst, "Value", "Text", null);

                        using (HttpClient client = new HttpClient())
                        {
                            client.BaseAddress = new Uri(GloVar.iBaseURI);
                            MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                            client.DefaultRequestHeaders.Accept.Add(contentType);
                            HttpResponseMessage response = client.GetAsync("/api/SearchStds?SClass=" + model.SClass + "&tSearchStr=" + searchStr + "&dSess=" + dSess + "&mdBID=" + mdBId).Result;  //
                            var stringData = response.Content.ReadAsStringAsync().Result;
                            StdDets = JsonConvert.DeserializeObject<IEnumerable<Students>>(stringData);
                        }

                        ViewBag.datasource = StdDets;
                    }
                    return View(model);
                }
                catch
                {
                    return View();
                }
            }
        }



        public IActionResult Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var searchStd = _context.SearchStd;

            //ViewBag.datasource = stdFns.GetStdList(_context, "2016-17", model.sClass).Result;  //model.stdList

            if (searchStd == null)
            {
                return NotFound();
            }

            return View(searchStd);
        }
        public ActionResult DataSource(string Clss,string tSearchStr, [FromBody] DataManagerRequest dm)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(GloVar.iBaseURI);
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                HttpResponseMessage response = client.GetAsync("/api/SearchStds?SClass=" + Clss + "&tSearchStr=" + tSearchStr + "&dSess=" + dSess + "&mdBID=" + mdBId).Result;
                var stringData = response.Content.ReadAsStringAsync().Result;
                IEnumerable<Students> stdLst = JsonConvert.DeserializeObject<IEnumerable<Students>>(stringData);
                DataOperations operation = new DataOperations();
                IEnumerable data = stdLst;
                var count = data.AsQueryable().Count();
                //ViewBag.stdFee = stdFee;
                if (dm.Skip > 0)
                    data = operation.PerformSkip(data, dm.Skip);
                if (dm.Take > 0)
                    data = operation.PerformTake(data, dm.Take);
                return Json(new { result = data, count = count });
            }
        }
        public ActionResult Update([FromBody] StudentsEdit stdEdit)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(GloVar.iBaseURI);
                    MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                    client.DefaultRequestHeaders.Accept.Add(contentType);
                    string stringData = JsonConvert.SerializeObject(stdEdit.Value);
                    var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");
                    HttpResponseMessage response = client.PutAsync("/api/Studentd/" + stdEdit.Key, contentData).Result;
                    ViewBag.Message = response.Content.ReadAsStringAsync().Result;
                    //return View(acaSession);
                }

                //_context.Update(acaSession);
                //await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                //if (!SubjectsExists(subjectsVal.Value.SubId))
                //{
                //    return NotFound();
                //}
                //else
                //{
                //    throw;
                //}
            }
            //AcaSession acsess = JsonConvert.DeserializeObject<AcaSession>(value);
            return Json(stdEdit.Value);
        }

        //[HttpPost]
        //public ActionResult Index(SearchStd model)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            ViewBag.sClss = model.sClass;
        //            ViewBag.SchClssLst = AcaFunctions.GetSchClss(GloVar.dSess);
        //            model.stdList = stdFns.GetStdList("2016-17", model.sClass);
        //        }
        //        return View(model);
        //    }
        //    catch
        //    {
        //        return View();
        //    }

        //}

    }
}