using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchMod.Models.General;
using WebCat7.Data;

namespace WebCat7.Controllers.Basics
{
    public class AccountHeadsController : Controller
    {
        private readonly SchContext _context;

        public AccountHeadsController(SchContext context)
        {
            _context = context;    
        }

        // GET: AccountHeads
        public async Task<IActionResult> Index()
        {
            return View(await _context.AccountHead.ToListAsync());
        }

        // GET: AccountHeads/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accountHead = await _context.AccountHead
                .SingleOrDefaultAsync(m => m.AccId == id);
            if (accountHead == null)
            {
                return NotFound();
            }

            return View(accountHead);
        }

        // GET: AccountHeads/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AccountHeads/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AccId,AccName,Type,Balance")] AccountHead accountHead)
        {
            if (ModelState.IsValid)
            {
                _context.Add(accountHead);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(accountHead);
        }

        // GET: AccountHeads/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accountHead = await _context.AccountHead.SingleOrDefaultAsync(m => m.AccId == id);
            if (accountHead == null)
            {
                return NotFound();
            }
            return View(accountHead);
        }

        // POST: AccountHeads/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AccId,AccName,Type,Balance")] AccountHead accountHead)
        {
            if (id != accountHead.AccId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(accountHead);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccountHeadExists(accountHead.AccId))
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
            return View(accountHead);
        }

        // GET: AccountHeads/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accountHead = await _context.AccountHead
                .SingleOrDefaultAsync(m => m.AccId == id);
            if (accountHead == null)
            {
                return NotFound();
            }

            return View(accountHead);
        }

        // POST: AccountHeads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var accountHead = await _context.AccountHead.SingleOrDefaultAsync(m => m.AccId == id);
            _context.AccountHead.Remove(accountHead);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool AccountHeadExists(int id)
        {
            return _context.AccountHead.Any(e => e.AccId == id);
        }
    }
}
