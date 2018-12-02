using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchMod.Models.Studs;
using WebCat7.Data;
using System.Net.Http;
using System.Net.Http.Headers;
using static WebCat7.GenFunction.GloVar;
using Newtonsoft.Json;
using static WebCat7.GenFunction.AcaFunctions;
using System.IO;
using WebCat7.GenFunction;

namespace WebCat7.Controllers.Std
{
    public class StudentsController : Controller
    {
        private readonly SchContext _context;
        HttpClient client;
        public List<SelectListItem> SchClssLst;
        public List<SelectListItem> SchFeeCatLst;

        public StudentsController(SchContext context)
        {
            _context = context;
            client = new HttpClient();
            client.BaseAddress = new Uri(iBaseURI);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        // GET: Students
        public async Task<IActionResult> Index()
        {
            return View(await _context.Students.ToListAsync());
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Profile(int RegNumber)
        {
            Students students = new Students();
            //if (RegNumber == null)
            //{
            //    return NotFound();
            //}
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(iBaseURI);
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                HttpResponseMessage response = client.GetAsync("/api/Func/getStdGenEdit/?RegNum=" + RegNumber + "&dSess=" + dSess + "&mdBID=" + mdBId).Result;  //
                var stringData = response.Content.ReadAsStringAsync().Result;
                students = JsonConvert.DeserializeObject<Students>(stringData);
            }

            if (students == null)
            {
                return NotFound();
            }
            //var pathPict = Path.Combine(
            //    Directory.GetCurrentDirectory(),
            //    "wwwroot" + "/userImages/", RegNumber + "Pict.jpg");

            string imreBase64Data = Convert.ToBase64String(students.ImajePict);
            string imgDataURL = String.Format("data:image/jpg;base64,{0}", imreBase64Data);
            ViewBag.ImPict = imgDataURL;

            return View(students);
        }

        // GET: Students/Create
        public async Task<IActionResult> Create()
        {
            HttpResponseMessage responseMessage = await client.GetAsync("/api/Func/GetSchClss/?dSess=" + dSess + "&mdBId=" + mdBId);
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                SchClssLst = JsonConvert.DeserializeObject<List<SelectListItem>>(responseData);
            }
            ViewBag.schClsLst = new SelectList(SchClssLst, "Value", "Text", null);
            responseMessage = await client.GetAsync("/api/Func/GetFeeCat/?dSess=" + dSess + "&mdBId=" + mdBId);
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                SchFeeCatLst = JsonConvert.DeserializeObject<List<SelectListItem>>(responseData);
            }
            ViewBag.SchFeeCatLst = new SelectList(SchFeeCatLst, "Value", "Text", null);
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StdName,Sex,Dob,ParentsNamesF,PresentClass,StdCategory,EmailAddress,ConPhone")] Students students)
        {
            if (ModelState.IsValid)
            {
                students.StdSession = dSess;
                students.DBid = mdBId;
                string stringData = JsonConvert.SerializeObject(students);
                var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PutAsync("/api/Func/CreateStd", contentData).Result;
                ViewBag.Message = response.Content.ReadAsStringAsync().Result;

                return RedirectToAction("Edit");
            }
            return View(students);
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(int RegNumber)
        {
            Students students = new Students();
            HttpResponseMessage responseMessage = await client.GetAsync("/api/Func/GetSchClss/?dSess=" + dSess + "&mdBId=" + mdBId);
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                SchClssLst = JsonConvert.DeserializeObject<List<SelectListItem>>(responseData);
            }
            ViewBag.schClsLst = new SelectList(SchClssLst, "Value", "Text", null);
            responseMessage = await client.GetAsync("/api/Func/GetFeeCat/?dSess=" + dSess + "&mdBId=" + mdBId);
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                SchFeeCatLst = JsonConvert.DeserializeObject<List<SelectListItem>>(responseData);
            }
            ViewBag.SchFeeCatLst = new SelectList(SchFeeCatLst, "Value", "Text", null);

            responseMessage = await client.GetAsync("/api/Func/getStdGenEdit/?regNum=" + RegNumber + "&dSess=" + dSess + "&mdBId=" + mdBId);
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                students = JsonConvert.DeserializeObject<Students>(responseData);
            }
            return View(students);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("RegNumber,StdName,Sex,Dob,Religion,ParentsNamesF,OccupationF,QualificationF,ParentsNamesM,OccupationM,QualificationM,AnnualIncome,PresentClass,Address,Address1,City,State,PostalCode,StdCategory,Photo,EmailAddress,ColorHouse,Notes,Weight,PresentRollNo,Hphone,Mphone,Nationality,ConPhone,BoardNo,StdGenCategory,Aadhar,DBid,StdSession")] Students students)
        {
            if (ModelState.IsValid)
            {
                client.BaseAddress = new Uri(GloVar.iBaseURI);
                string stringData = JsonConvert.SerializeObject(students);
                //String content = new String(JsonConvert.SerializeObject(students));
                var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response =  client.PostAsync( "api/Func/saveEditGen", contentData).Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    students = JsonConvert.DeserializeObject<Students>(data);
                }
            }
            return View(students);
        }

        //[HttpGet("/{RegNumber}")]
        public async Task<IActionResult> EditAddress(int RegNumber)
        {
            Students students = new Students();
            HttpResponseMessage responseMessage = await client.GetAsync("/api/Func/getStdAddressEdit/?regNum=" + RegNumber + "&dSess=" + dSess + "&mdBId=" + mdBId);
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                students = JsonConvert.DeserializeObject<Students>(responseData);
            }
            return View(students);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAddress([Bind("RegNumber,StdName,Sex,Dob,Religion,ParentsNamesF,OccupationF,QualificationF,ParentsNamesM,OccupationM,QualificationM,AnnualIncome,PresentClass,Address,Address1,City,State,PostalCode,StdCategory,Photo,EmailAddress,ColorHouse,Notes,Weight,PresentRollNo,Hphone,Mphone,Nationality,ConPhone,BoardNo,StdGenCategory,Aadhar")] Students students)
        {
            if (ModelState.IsValid)
            {
                string stringData = JsonConvert.SerializeObject(students);
                //String content = new String(JsonConvert.SerializeObject(students));
                var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PostAsync("api/Func/saveEditAddress", contentData).Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    students = JsonConvert.DeserializeObject<Students>(data);
                }
            }
            return View(students);
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> EditFamily( int RegNumber)
        {
            Students students = new Students();
            HttpResponseMessage responseMessage = await client.GetAsync("/api/Func/getStdFamilyEdit/?regNum=" + RegNumber + "&dSess=" + dSess + "&mdBId=" + mdBId);
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                students = JsonConvert.DeserializeObject<Students>(responseData);
            }
            return View(students);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditFamily(int RegNumber, [Bind("RegNumber,StdName,Sex,Dob,Religion,ParentsNamesF,OccupationF,QualificationF,ParentsNamesM,OccupationM,QualificationM,AnnualIncome,PresentClass,Address,Address1,City,State,PostalCode,StdCategory,Photo,EmailAddress,ColorHouse,Notes,Weight,PresentRollNo,Hphone,Mphone,Nationality,ConPhone,BoardNo,StdGenCategory,Aadhar")] Students students)
        {
            if (RegNumber != students.RegNumber)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(students);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentsExists(students.RegNumber))
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
            return View(students);
        }

        public async Task<IActionResult> EditHealth(int RegNumber)
        {
            Students students = new Students();
            HttpResponseMessage responseMessage = await client.GetAsync("/api/Func/getStdHealthEdit/?regNum=" + RegNumber + "&dSess=" + dSess + "&mdBId=" + mdBId);
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                students = JsonConvert.DeserializeObject<Students>(responseData);
            }
            return View(students);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditHealth(int RegNumber, [Bind("RegNumber,UniReg, FirstName, Notes, PermAilment, BloodGroup, Height,Weight, Teeth, VisionL, VisionR, OralHygiene, SplAilment, PermIdentification")] Students students)
        {
            if (RegNumber != students.RegNumber)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(students);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentsExists(students.RegNumber))
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
            return View(students);
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var students = await _context.Students
                .SingleOrDefaultAsync(m => m.StdId == id);
            if (students == null)
            {
                return NotFound();
            }

            return View(students);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var students = await _context.Students.SingleOrDefaultAsync(m => m.StdId == id);
            _context.Students.Remove(students);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool StudentsExists(int id)
        {
            return _context.Students.Any(e => e.StdId == id);
        }
    }
}
