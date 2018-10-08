using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchMod.Models.Convey;
using WebCat7.Data;
using static WebCat7.GenFunction.AcaFunctions;
using System.Net.Http;
using static WebCat7.GenFunction.GloVar;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Syncfusion.EJ2.Base;
using Syncfusion.EJ2.Grids;
using Syncfusion.EJ2.Inputs;
using Syncfusion.EJ2.Linq;
using System.Collections;

namespace WebCat7.Controllers.Convey
{
    public class VehicleDescriptionsController : Controller
    {
        private readonly SchContext _context;

        public VehicleDescriptionsController(SchContext context)
        {
            _context = context;
        }

        // GET: VehicleDescriptions
        public async Task<IActionResult> Index()
        {
            GetVehTypLst(_context);
            ViewBag.vehTyp = drpVehTypLst;
            return View();
        }

        // GET: VehicleDescriptions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleDescription = await _context.VehicleDescription
                .SingleOrDefaultAsync(m => m.VehicleId == id);
            if (vehicleDescription == null)
            {
                return NotFound();
            }

            return View(vehicleDescription);
        }

        // GET: VehicleDescriptions/Create
        public IActionResult Create()
        {
            GetVehTypLst(_context);
            ViewBag.dropdownVehType = new SelectList(SchVehTypLst, "Value", "Text", null); ;
            return View();
        }

        // POST: VehicleDescriptions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("VehicleName,VehicleType,VDriver,VNumber,DriverAddress,DriverDetails,VehicleDetails,ContactPhone,Capacity,Circuit")] VehicleDescription vehicleDescription)
        {
            if (ModelState.IsValid)
            {
                using (HttpClient client = new HttpClient())
                {
                    vehicleDescription.DBid = mdBId;
                    vehicleDescription.LoginName = strLoginName;
                    vehicleDescription.ModTime = DateTime.Now ;
                    client.BaseAddress = new Uri(iBaseURI);
                    MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                    client.DefaultRequestHeaders.Accept.Add(contentType);
                    string stringData = JsonConvert.SerializeObject(vehicleDescription);
                    var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");
                    HttpResponseMessage response = client.PostAsync("/api/vehicleDescriptions", contentData).Result;
                    ViewBag.Message = response.Content.ReadAsStringAsync().Result;
                    //return View(vehicleDescription);
                }
            }
            return View(vehicleDescription);
        }

        // GET: VehicleDescriptions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleDescription = await _context.VehicleDescription.SingleOrDefaultAsync(m => m.VehicleId == id);
            if (vehicleDescription == null)
            {
                return NotFound();
            }
            return View(vehicleDescription);
        }

        // POST: VehicleDescriptions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VehicleId,VehicleName,VehicleType,VDriver,VNumber,DriverAddress,DriverDetails,VehicleDetails,ContactPhone,Capacity,Circuit")] VehicleDescription vehicleDescription)
        {
            if (id != vehicleDescription.VehicleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehicleDescription);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehicleDescriptionExists(vehicleDescription.VehicleId))
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
            return View(vehicleDescription);
        }

        // GET: VehicleDescriptions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleDescription = await _context.VehicleDescription
                .SingleOrDefaultAsync(m => m.VehicleId == id);
            if (vehicleDescription == null)
            {
                return NotFound();
            }

            return View(vehicleDescription);
        }

        // POST: VehicleDescriptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vehicleDescription = await _context.VehicleDescription.SingleOrDefaultAsync(m => m.VehicleId == id);
            _context.VehicleDescription.Remove(vehicleDescription);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public ActionResult Update([FromBody] VehicleDescriptionEdit vehDesVal)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    vehDesVal.Value.DBid  = mdBId;
                    client.BaseAddress = new Uri(iBaseURI);
                    MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                    client.DefaultRequestHeaders.Accept.Add(contentType);
                    string stringData = JsonConvert.SerializeObject(vehDesVal.Value);
                    var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");
                    HttpResponseMessage response = client.PutAsync("/api/vehicleDescriptions/" + vehDesVal.Key, contentData).Result;
                    ViewBag.Message = response.Content.ReadAsStringAsync().Result;
                    //return View(acaSession);
                }

                //_context.Update(acaSession);
                //await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VehicleDescriptionExists(vehDesVal.Value.VehicleId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            //AcaSession acsess = JsonConvert.DeserializeObject<AcaSession>(value);
            //return Json(vehDesVal.Value);
            return RedirectToAction(nameof(Index));
        }

        public ActionResult DataSource(string clss, [FromBody] DataManagerRequest dm)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(iBaseURI);
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                HttpResponseMessage response = client.GetAsync("/api/vehicleDescriptions?mdBID=" + mdBId).Result;
                var stringData = response.Content.ReadAsStringAsync().Result;
                List<VehicleDescription> subjects = JsonConvert.DeserializeObject<List<VehicleDescription>>(stringData);
                DataOperations operation = new DataOperations();
                IEnumerable data = subjects;
                var count = data.AsQueryable().Count();
                if (dm.Skip > 0)
                    data = operation.PerformSkip(data, dm.Skip);
                if (dm.Take > 0)
                    data = operation.PerformTake(data, dm.Take);
                return Json(new { result = data, count = count });
            }
        }

        private bool VehicleDescriptionExists(int id)
        {
            return _context.VehicleDescription.Any(e => e.VehicleId == id);
        }
        private bool VehicleDescriptionExists(string vd)
        {
            return _context.VehicleDescription.Any(e => e.VehicleName == vd);
        }
    }
}
