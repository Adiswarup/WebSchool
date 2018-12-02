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


namespace WebCat7.Controllers.Basics
{
    public class StdHousesController : Controller
    {
        private readonly SchContext _context;

        public StdHousesController(SchContext context)
        {
            _context = context;    
        }

        // GET: StdHouses
        public async Task<IActionResult> Index()
        {
            return View();    
        }

        // GET: StdHouses/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stdHouse = await _context.StdHouse
                .SingleOrDefaultAsync(m => m.StdHouseId == id);
            if (stdHouse == null)
            {
                return NotFound();
            }

            return View(stdHouse);
        }

        // GET: StdHouses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StdHouses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  IActionResult  Create([Bind("StHouse")] StdHouse stdHouse)
        {
            if (ModelState.IsValid)
            {
                if (!StdHouseExists(stdHouse.StHouse))
                {
                    using (HttpClient client = new HttpClient())
                    {
                        client.BaseAddress = new Uri(GloVar.iBaseURI);
                        MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                        client.DefaultRequestHeaders.Accept.Add(contentType);
                        string stringData = JsonConvert.SerializeObject(stdHouse);
                        var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");
                        HttpResponseMessage response = client.PostAsync("/api/StdHouses", contentData).Result;
                        ViewBag.Message = response.Content.ReadAsStringAsync().Result;
                        if (response.IsSuccessStatusCode)
                        {
                            ViewBag.Remark = "Creation of Color/House '" + stdHouse.StHouse + "' Successful";
                            return View();
                        }
                        else
                        {
                            ViewBag.Remark = "Creation of Color/House '" + stdHouse.StHouse + "' Failed!. Please Try Again";
                            return View(stdHouse);
                        }
                    }
                }
                else
                {
                    ViewBag.Remark = "Failed Color/House '" + stdHouse.StHouse + "' Already Exists.";
                    return View(stdHouse);
                }
            }
            else
            {
                ViewBag.Remark = "Failed! Color/House '" + stdHouse.StHouse + "' Unable To create. PleaseTry Again.";
                return View(stdHouse);
            }
        }

        // GET: StdHouses/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stdHouse = await _context.StdHouse.SingleOrDefaultAsync(m => m.StdHouseId == id);
            if (stdHouse == null)
            {
                return NotFound();
            }
            return View(stdHouse);
        }

        // POST: StdHouses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StdHouseId,StHouse")] StdHouse stdHouse)
        {
            if (id != stdHouse.StdHouseId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stdHouse);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StdHouseExists(stdHouse.StdHouseId))
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
            return View(stdHouse);
        }

        // GET: StdHouses/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stdHouse = await _context.StdHouse
                .SingleOrDefaultAsync(m => m.StdHouseId == id);
            if (stdHouse == null)
            {
                return NotFound();
            }

            return View(stdHouse);
        }

        // POST: StdHouses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var stdHouse = await _context.StdHouse.SingleOrDefaultAsync(m => m.StdHouseId == id);
            _context.StdHouse.Remove(stdHouse);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Update([FromBody] StdHouseEdit stdHouseVal)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(GloVar.iBaseURI);
                    MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                    client.DefaultRequestHeaders.Accept.Add(contentType);
                    string stringData = JsonConvert.SerializeObject(stdHouseVal.Value);
                    var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");
                    HttpResponseMessage response = client.PutAsync("/api/StdHouses/" + stdHouseVal.Key, contentData).Result;
                    ViewBag.Message = response.Content.ReadAsStringAsync().Result;
                    //return View(acaSession);
                }

                //_context.Update(acaSession);
                //await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StdHouseExists(stdHouseVal.Value.StdHouseId ))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            //AcaSession acsess = JsonConvert.DeserializeObject<AcaSession>(value);
            return Json(stdHouseVal.Value);
        }


        public ActionResult DataSource([FromBody] DataManagerRequest dm)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(GloVar.iBaseURI);
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                HttpResponseMessage response = client.GetAsync("/api/StdHouses?mdBId=" + mdBId).Result;
                var stringData = response.Content.ReadAsStringAsync().Result;
                List<StdHouse> stdHouse = JsonConvert.DeserializeObject<List<StdHouse>>(stringData);
                DataOperations operation = new DataOperations();
                IEnumerable data = stdHouse;
                var count = data.AsQueryable().Count();
                if (dm.Skip > 0)
                    data = operation.PerformSkip(data, dm.Skip);
                if (dm.Take > 0)
                    data = operation.PerformTake(data, dm.Take);
                return Json(new { result = data, count = count });
            }
        }

        private bool StdHouseExists(int id)
        {
            return _context.StdHouse.Any(e => e.StdHouseId == id);
        }
        private bool StdHouseExists(String  HouseName)
        {
            return _context.StdHouse.Any(e => e.StHouse == HouseName);
        }
    }
}
