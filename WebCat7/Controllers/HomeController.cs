using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SchMod.Models.General;
using WebCat7.GenFunction;
using static WebCat7.GenFunction.GloVar;

namespace WebCat7.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            DashMod dashMod = new DashMod();
            double toDate =(int) DateTime.Now.ToOADate();
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(iBaseURI);
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                HttpResponseMessage response = client.GetAsync("/api/DashMods/?actDate=" + toDate + "&dSess=" + dSess + "&mdBID=" + mdBId).Result;  //
                var stringData = response.Content.ReadAsStringAsync().Result;
                dashMod = JsonConvert.DeserializeObject<DashMod>(stringData);
            }


            return View(dashMod);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
