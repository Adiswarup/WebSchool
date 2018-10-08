using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchMod.Models.Convey;
using WebCat7.Data;
using System.Net.Http;
using static WebCat7.GenFunction.GloVar;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Collections;
using Syncfusion.EJ2.Base;
using Syncfusion.EJ2.Grids;
using Syncfusion.EJ2.Inputs;
using Syncfusion.EJ2.Linq;
//using WebCat7.GenFunction;

namespace WebCat7.Controllers.Convey
{
    public class VehicleTypesController : Controller
    {
        private readonly SchContext _context;

        public VehicleTypesController(SchContext context)
        {
            _context = context;
        }

        // GET: VehicleTypes
        public async Task<IActionResult> Index()
        {
            return View();
        //return View(await _context.VehicleType.ToListAsync());
        }

        // GET: VehicleTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleType = await _context.VehicleType
                .SingleOrDefaultAsync(m => m.VehicleTypeId == id);
            if (vehicleType == null)
            {
                return NotFound();
            }

            return View(vehicleType);
        }

        // GET: VehicleTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VehicleTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VehType")] VehicleType vehicleType)
        {
            //if (!(VehicleTypeExists(vehicleType.VehType)) && (ModelState.IsValid))
            //{
                if (ModelState.IsValid)
                {
                    using (HttpClient client = new HttpClient())
                    {
                        vehicleType.DBid = mdBId;
                        vehicleType.VehicleTypeId = 0;
                        client.BaseAddress = new Uri(iBaseURI);
                        MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                        client.DefaultRequestHeaders.Accept.Add(contentType);
                        string stringData = JsonConvert.SerializeObject(vehicleType);
                        var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");
                        HttpResponseMessage response = client.PostAsync("/api/vehicleTypes", contentData).Result;
                        ViewBag.Message = response.Content.ReadAsStringAsync().Result;
                        return RedirectToAction("Index");
                    }
                //}
            }
        return View(vehicleType);
        }
            

        // GET: VehicleTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(iBaseURI);
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                HttpResponseMessage response = client.GetAsync("/api/vehicleTypes/" + id).Result;
                string stringData = response.Content.ReadAsStringAsync().Result;
                VehicleType vehicleType = JsonConvert.DeserializeObject<VehicleType>(stringData);
                //var acaSession = await _context.AcaSession.SingleOrDefaultAsync(m => m.AutoId == id);
                if (vehicleType == null)
                {
                    return NotFound();
                }
            return View(vehicleType);
            }
        }

        // POST: VehicleTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VehicleTypeId,VehType")] VehicleType vehicleType)
        {
            //if (id != vehicleType.VehicleTypeId)
            //{
            //    return NotFound();
            //}

            if (ModelState.IsValid)
            {
                try
                {
                    using (HttpClient client = new HttpClient())
                    {
                        client.BaseAddress = new Uri(iBaseURI);
                        MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                        client.DefaultRequestHeaders.Accept.Add(contentType);
                        string stringData = JsonConvert.SerializeObject(vehicleType);
                        var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");
                        HttpResponseMessage response = client.PutAsync("/api/vehicleTypes/" + vehicleType.VehicleTypeId, contentData).Result;
                        ViewBag.Message = response.Content.ReadAsStringAsync().Result;
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehicleTypeExists(vehicleType.VehicleTypeId))
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
            return RedirectToAction("Index");
        }

        // GET: VehicleTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(iBaseURI);
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);

                HttpResponseMessage response = client.GetAsync("/api/VehicleTypes/" + id).Result;
                string stringData = response.Content.ReadAsStringAsync().Result;
                VehicleType vehicleType = JsonConvert.DeserializeObject<VehicleType>(stringData);
                return View(vehicleType);
            }
        }

        // POST: VehicleTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(iBaseURI);
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                HttpResponseMessage response = client.DeleteAsync("/api/VehicleTypes/Index/" + id).Result;
                TempData["Message"] = response.Content.ReadAsStringAsync().Result;
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public ActionResult Update([FromBody] VehicleTypeEdit vtVal)
        {
            try
            {
                vtVal.Value.DBid = mdBId;
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(iBaseURI);
                    MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                    client.DefaultRequestHeaders.Accept.Add(contentType);
                    string stringData = JsonConvert.SerializeObject(vtVal.Value);
                    var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");
                    HttpResponseMessage response = client.PutAsync("/api/VehicleTypes/" + vtVal.Key, contentData).Result;
                    ViewBag.Message = response.Content.ReadAsStringAsync().Result;
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VehicleTypeExists(vtVal.Value.VehicleTypeId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            //AcaSession acsess = JsonConvert.DeserializeObject<AcaSession>(value);
            return Json(vtVal.Value);
        }

        public ActionResult DataSource([FromBody] DataManagerRequest dm)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(iBaseURI);
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                HttpResponseMessage response = client.GetAsync("/api/VehicleTypes/?mdBID=" + mdBId).Result;
                var stringData = response.Content.ReadAsStringAsync().Result;
                List<VehicleType> acaSession = JsonConvert.DeserializeObject<List<VehicleType>>(stringData);
                DataOperations operation = new DataOperations();
                IEnumerable data = acaSession;
                var count = data.AsQueryable().Count();
                if (dm.Skip > 0)
                    data = operation.PerformSkip(data, dm.Skip);
                if (dm.Take > 0)
                    data = operation.PerformTake(data, dm.Take);
                return Json(new { result = data, count = count });
            }
        }

        private bool VehicleTypeExists(string vName)
        {
            return _context.VehicleType.Any(e => e.VehType == vName);
        }
        private bool VehicleTypeExists(int id)
        {
            return _context.VehicleType.Any(e => e.VehicleTypeId == id);
        }

    }
}
