using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchMod.Models.StdFees;
using SchMod.ViewModels.StdFees;
using WebCat7.Data;
using System.Net.Http;
using WebCat7.GenFunction;
using System;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using static WebCat7.GenFunction.PayFunc;
using static WebCat7.GenFunction.GloVar;
using static WebCat7.GenFunction.GloFunc;

namespace WebSchool.Controllers
{
    public class ReceiptsController : Controller
    {
        private readonly SchContext _context;
        HttpClient client;

        public ReceiptsController(SchContext context)
        {
            _context = context;
            client = new HttpClient();
            client.BaseAddress = new Uri(iBaseURI);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        // POST: Receipts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReceiptDate,  UniReg,  RegNo,  StdName,  Gender,  Clss, ForPeriod, AmountPayable, AmountPaid," +
            "ConvenienceFee, Remarks, SName,  FeeHeading, AcaSession, StdCat")] Receipt receipt)
        {
            using (HttpClient client = new HttpClient())
            {
                PayMod payMod = new PayMod();

                payMod.TransactionAmount = receipt.AmountPaid.ToString();
                payMod.TransactionDateTime = receipt.ReceiptDate.ToShortDateString();
                payMod.udf1 = receipt.RegNo.ToString();
                payMod.udf2 = receipt.ForPeriod.ToString();
                payMod.udf3 = receipt.FeeHeading;
                payMod.udf4 = receipt.RollNo.ToString();
                payMod.udf5 = receipt.StdCat;
                payMod.udf6 = receipt.DBid.ToString();
                payMod.udf7 = receipt.ConvenienceFee.ToString();
                string TransURL = TransferFund(payMod);
                //HttpRequestMessage httpRequestMessage;
                //httpRequestMessage.RequestUri = TransURL;
                Redirect(TransURL);

                client.BaseAddress = new Uri(GloVar.iBaseURI);
                string stringData = JsonConvert.SerializeObject(receipt);
                var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PostAsync("api/receipts", contentData).Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    receipt = JsonConvert.DeserializeObject<Receipt>(data);
                }
            }
            return View(receipt);
        }

        // GET: Receipts/Edit/5
        public IActionResult Edit(int fRegNo, int feeNo, string feeCaption)
        {
            Receipt receipt;
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(GloVar.iBaseURI);
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                HttpResponseMessage response = client.GetAsync("/api/Receipts?fRegNo=" + fRegNo + "&feeNo=" + feeNo + "&dSess=" + dSess + "&mdBID=" + mdBId).Result;  //
                var stringData = response.Content.ReadAsStringAsync().Result;
                receipt = JsonConvert.DeserializeObject<Receipt>(stringData);
            }
            //receipt.FeeHeading = repSplXMLChr( feeCaption);
            ViewBag.DataSrc = receipt;
            receipt.ConvenienceFee = 30;
           receipt.AmountPaid = receipt.AmountPaid+30;
            receipt.AmountPayable = receipt.AmountPayable+30;
           return View(receipt);
        }


        // GET: Receipts/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Receipts/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("AutoId,RecId,ReceiptNo,BillNo,ReceiptDate,UniReg,RegNo,ForPeriod,AmountPayable,AmountPaid,IsDuesClearance,PaymentMode,BankName,ChqDated,ChqNumber,Remarks,PaidAt,SName,FeeHeading,DelRemarks,AcaSession")] Receipt receipt)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(receipt);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(receipt);
        //}

        //// GET: Receipts/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var receipt = await _context.Receipt.SingleOrDefaultAsync(m => m.AutoId == id);
        //    if (receipt == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(receipt);
        //}


        //// GET: Receipts/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var receipt = await _context.Receipt
        //        .SingleOrDefaultAsync(m => m.AutoId == id);
        //    if (receipt == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(receipt);
        //}

        //// POST: Receipts/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var receipt = await _context.Receipt.SingleOrDefaultAsync(m => m.AutoId == id);
        //    _context.Receipt.Remove(receipt);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool ReceiptExists(int id)
        //{
        //    return _context.Receipt.Any(e => e.AutoId == id);
        //}
    }
}
