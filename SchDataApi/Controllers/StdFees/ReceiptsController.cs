using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchDataApi.DataLayer;
using SchMod.Models.StdFees;
using SchMod.ViewModels.StdFees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static SchDataApi.GenFunc.StdFunc;

namespace SchDataApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Receipts")]
    public class ReceiptsController : Controller
    {
        private readonly SchContext _context;

        public ReceiptsController(SchContext context)
        {
            _context = context;
        }

        [HttpPost("PayReceipt")]
        public IActionResult PayReceipt([FromForm]  string amt, string auth_code, string bank_name, string bank_txn,
            string CardNumber, string clientcode, string date, string desc, string discriminator, string f_code, string ipg_txn_id,
            string mer_txn, string merchant_id, string mmp_txn, string prod, string signature, string surcharge, string udf1,
            string udf2, string udf3, string udf4, string udf5, string udf6, string udf7, string udf8, string udf9)
        {
            PayMod payMod = new PayMod();
            payMod.TransactionAmount = amt;
            payMod.Auth_code = auth_code;
            payMod.Bank_name = bank_name;
            payMod.Bank_txn = bank_txn;
            payMod.CardNumber = CardNumber;
            payMod.ClientCode = clientcode;
            payMod.TransactionDateTime = date;
            payMod.Desc = desc;
            payMod.Discriminator = discriminator;
            payMod.f_code = f_code;
            payMod.TransactionID = ipg_txn_id;
            payMod.mer_txn = mer_txn;
            payMod.MerchantLogin = merchant_id;
            payMod.mmp_txn = mmp_txn;
            payMod.ProductID = prod;
            payMod.signature = signature;
            payMod.surcharge = surcharge;
            payMod.udf1 = udf1;
            payMod.udf2 = udf2;
            payMod.udf3 = udf3;
            payMod.udf4 = udf4;
            payMod.udf5 = udf5;
            payMod.udf6 = udf6;
            payMod.udf7 = udf7;
            payMod.udf8 = udf8;
            payMod.udf9 = udf9;
            return Ok(payMod);
            //using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
            //{
            //    return await reader.ReadToEndAsync();
            //}
        }

        // GET: api/Receipts
        //[HttpGet]
        //public IEnumerable<Receipt> GetReceipt()
        //{
        //    return _context.Receipt;
        //}

        // GET: api/Receipts/5
        [HttpGet]
        public async Task<IActionResult> GetReceipt(int fRegNo, int feeNo, string dSess, int mdBId)//, int feeNo
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}
            FeeForm feeForm = await getStdDetails(_context, fRegNo, dSess, mdBId);
            List<ReceiptDetails> RecDets = new List<ReceiptDetails>();

            Receipt receipt = new Receipt
            {
                RegNo = fRegNo,
                UniReg = feeForm.UniReg,
                StdName = feeForm.StdName,
                Clss = feeForm.Clss,
                RollNo = feeForm.RollNo,
                ReceiptDate = DateTime.Now,
                StdCat = feeForm.StdCat,
                ForPeriod = feeNo,
                AcaSession = dSess,
                DBid = mdBId,
                RecDetails = RecDets
            };
            Receipt receiptX = new Receipt();
            receiptX = await getFeeDetail(_context, receipt, dSess, mdBId);

            //var receipt = await _context.Receipt.SingleOrDefaultAsync(m => m.AutoId == feeNo );

            if (receipt == null)
            {
                return NotFound();
            }

            return Ok(receiptX);
        }

        // POST: api/Receipts
        //[HttpPost]
        //public async Task<IActionResult> PostReceipt([FromBody] Receipt receipt)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    string TransURL = TransferFund();

        //    HttpContext.Response.Redirect(TransURL, false);

        //    using (HttpClient client = new HttpClient())
        //    {
        //        HttpRequestMessage httpRequest = new HttpRequestMessage(HttpMethod.Get,TransURL) ;
        //        client.BaseAddress = new Uri("https://paynetzuat.atomtech.in");
        //        MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
        //        client.DefaultRequestHeaders.Accept.Add(contentType);
        //        HttpContext.Response.Redirect(TransURL);
        //        //HttpResponseMessage response = client.SendAsync(request: httpRequest).Result;
        //        //ViewBag.Message = response.Content.ReadAsStringAsync().Result;
        //    }
        //    //InititiatePayment(receipt);

        //    //_context.Receipt.Add(receipt);
        //    //await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetReceipt", new { id = receipt.AutoId }, receipt);
        //}

        // DELETE: api/Receipts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReceipt([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var receipt = await _context.Receipt.SingleOrDefaultAsync(m => m.AutoId == id);
            if (receipt == null)
            {
                return NotFound();
            }

            _context.Receipt.Remove(receipt);
            await _context.SaveChangesAsync();

            return Ok(receipt);
        }

        private bool ReceiptExists(int id)
        {
            return _context.Receipt.Any(e => e.AutoId == id);
        }
    }
}