using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchDataApi.DataLayer;
using SchMod.ViewModels.StdFees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static SchDataApi.GenFunc.GloVar;
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
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            FeeForm feeForm =await  getStdDetails(_context, fRegNo, dSess, mdBId);
                List <ReceiptDetails> RecDets = new List<ReceiptDetails>();

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
            Receipt receiptX =new Receipt();
            receiptX = await getFeeDetail(_context, receipt, dSess, mdBId);

            //var receipt = await _context.Receipt.SingleOrDefaultAsync(m => m.AutoId == feeNo );

            if (receipt == null)
            {
                return NotFound();
            }

            return Ok(receiptX);
        }

        // PUT: api/Receipts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReceipt([FromRoute] int id, [FromBody] Receipt receipt)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != receipt.AutoId)
            {
                return BadRequest();
            }

            _context.Entry(receipt).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReceiptExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Receipts
        [HttpPost]
        public async Task<IActionResult> PostReceipt([FromBody] Receipt receipt)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Receipt.Add(receipt);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReceipt", new { id = receipt.AutoId }, receipt);
        }

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