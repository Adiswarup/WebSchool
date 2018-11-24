using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SchMod.ViewModels.StdFees;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using WebCat7.GenFunction;
using static WebCat7.GenFunction.GloVar;

namespace WebCat7.Controllers.StdFee
{
    public class FeeFormsController : Controller
    {
        // GET: FeeForms
        public ActionResult Index()
        {
               return View();
        }

        // GET: FeeForms/Details/5
        [HttpGet]
        //[ValidateAntiForgeryToken]
        public ActionResult Fee_Std(int RegNo)
        {
            FeeForm feeForm = new FeeForm();
            if (RegNo != 0)
            {
                try
                {
                    using (HttpClient client = new HttpClient())
                    {
                        client.BaseAddress = new Uri(GloVar.iBaseURI);
                        MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                        client.DefaultRequestHeaders.Accept.Add(contentType);
                        string stringData = JsonConvert.SerializeObject(RegNo);
                        var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");
                        HttpResponseMessage response = client.GetAsync("/api/FeeForms/" + RegNo + "?dSess=" + dSess + "&mdBID=" + mdBId).Result;
                        stringData = response.Content.ReadAsStringAsync().Result;
                        feeForm = JsonConvert.DeserializeObject<FeeForm>(stringData);
                    }
                }
                catch (HttpRequestException)
                {

                }
            }
            return View(feeForm);
        }

        // GET: FeeForms/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FeeForms/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Trans_Fee_Summ(FeeForm feeForm)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("..//FeeSumm/Details", feeForm);
            }
            catch
            {
                return View();
            }
        }

        // GET: FeeForms/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: FeeForms/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // GET: FeeForms/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FeeForms/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}