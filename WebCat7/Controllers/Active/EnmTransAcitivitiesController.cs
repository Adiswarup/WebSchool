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
    public class EnmTransAcitivitiesController : Controller
    {
        private readonly SchContext _context;

        public EnmTransAcitivitiesController(SchContext context)
        {
            _context = context;
        }

        // GET: EnmTransAcitivities
        [HttpGet]
        [ActionName("Index")]
        public async Task<IActionResult> Index_Get(EnmTransActivity enmTransActivity)
        {
            GetSchClss(_context);
            ViewBag.Schclsses = new SelectList(SchClsLst, "Value", "Text", null);
            GetActivityGroup(_context);
            ViewBag.ActGrps = new SelectList(SchActivityGroup, "Value", "Text", null);
            GetActivity(_context, "Thinking Skills", true);
             enmTransActivity.StdClss = "IX-A";
            enmTransActivity.TransActDate = DateTime.Now;
            enmTransActivity.TransActGroup = "Thinking Skills";
            GetActivity(_context, enmTransActivity.TransActGroup, true);
            ViewBag.dropdownActivity = drpActLst;
            return View(enmTransActivity);
        }

        [HttpPost]
        [ActionName("Index")]
        public async Task<ActionResult> Index_Post([Bind("StdClss,TransActDate,TransActGroup")]EnmTransActivity enmTransActivity)
        {
            try
            {
                //if (ModelState.IsValid)
                //{
                    GetSchClss(_context);
                    ViewBag.Schclsses = new SelectList(SchClsLst, "Value", "Text", null);
                    GetActivityGroup(_context);
                    ViewBag.ActGrps = new SelectList(SchActivityGroup, "Value", "Text", null); 
                    GetActivity(_context, enmTransActivity.TransActGroup, true);
                    ViewBag.dropdownActivity = drpActLst;
                //}
                    return View(enmTransActivity);
            }
            catch
            {
                return View(enmTransActivity);
            }
        }

        [HttpPost]
        public ActionResult Update(string clss, string actGrps, string actDate, [FromBody] TransActivityEdit TransActVal)
        {
            //if (TransActVal.Value.Commit)
            //{
                try
                {
               TransActVal.Value.TransActDate =  DateTime.Parse(actDate);
                TransActVal.Value.DBid = mdBId;
                    using (HttpClient client = new HttpClient())
                    {
                        client.BaseAddress = new Uri(GloVar.iBaseURI);
                        MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                        client.DefaultRequestHeaders.Accept.Add(contentType);
                        string stringData = JsonConvert.SerializeObject(TransActVal.Value);
                        var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");
                        HttpResponseMessage response = client.PutAsync("/api/EnmTransActivities/" + TransActVal.Key, contentData).Result;
                        ViewBag.Message = response.Content.ReadAsStringAsync().Result;
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnmTransAcitivityExists(TransActVal.Value.AutoId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            
            //AcaSession acsess = JsonConvert.DeserializeObject<AcaSession>(value);
            return Json(TransActVal.Value);
        }

        public ActionResult DataSource(string clss, string actGrps, string actDate, [FromBody] DataManagerRequest dm)
        {

            double fActDate = GloFunc.ToOADate(DateTime.Parse( actDate));
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(GloVar.iBaseURI);
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                HttpResponseMessage response = client.GetAsync("/api/EnmTransActivities?clss=" + clss + "&actGrps=" + actGrps + "&actDate=" + fActDate + "&dSess=" + dSess + "&mdBID=" + mdBId).Result;
                var stringData = response.Content.ReadAsStringAsync().Result;
                EnmTransActivity  transActs = JsonConvert.DeserializeObject<EnmTransActivity>(stringData);
                DataOperations operation = new DataOperations();
                IEnumerable data = transActs.ActivityList;
                var count = data.AsQueryable().Count();
                if (dm.Skip > 0)
                    data = operation.PerformSkip(data, dm.Skip);
                if (dm.Take > 0)
                    data = operation.PerformTake(data, dm.Take);
                return Json(new { result = data, count = count });
            }
        }


        private bool EnmTransAcitivityExists(int id)
        {
            return _context.EnmTransActivity.Any(e => e.AutoId == id);
        }
    }
}
