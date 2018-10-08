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
using static WebCat7.GenFunction.GloVar;
using static WebCat7.GenFunction.GloFunc;

namespace WebSchool.Controllers
{
    public class ReceiptsController : Controller
    {
        private readonly SchContext _context;

        public ReceiptsController(SchContext context)
        {
            _context = context;
        }

        // GET: Receipts
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.Receipt.ToListAsync());
        //}

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
            ViewBag.datasource = receipt.RecDetails;
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

        //// POST: Receipts/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("AutoId,RecId,ReceiptNo,BillNo,ReceiptDate,UniReg,RegNo,ForPeriod,AmountPayable,AmountPaid,IsDuesClearance,PaymentMode,BankName,ChqDated,ChqNumber,Remarks,PaidAt,SName,FeeHeading,DelRemarks,AcaSession")] Receipt receipt)
        //{
        //    if (id != receipt.AutoId)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(receipt);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!ReceiptExists(receipt.AutoId))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
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
