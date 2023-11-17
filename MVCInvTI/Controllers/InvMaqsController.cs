using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCInvTI.Data;
using MVCInvTI.Models;

namespace MVCInvTI.Controllers
{
    public class InvMaqsController : Controller
    {
        private readonly DBContext _context;

        public InvMaqsController(DBContext context)
        {
            _context = context;
        }

        // GET: InvMaqs
        public async Task<IActionResult> Index()
        {
              return _context.InvMaq != null ? 
                          View(await _context.InvMaq.ToListAsync()) :
                          Problem("Entity set 'DBContext.InvMaq'  is null.");
        }

        // GET: InvMaqs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.InvMaq == null)
            {
                return NotFound();
            }

            var invMaq = await _context.InvMaq
                .FirstOrDefaultAsync(m => m.idMaq == id);
            if (invMaq == null)
            {
                return NotFound();
            }

            return View(invMaq);
        }

        // GET: InvMaqs/Create
        public IActionResult Create()
        {
            InvMaqModel model = new();
            model.ProdutoList = _context.CadProd.ToList();
            return View(model);
        }

        // POST: InvMaqs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idMaq,NomeMaq,CodMaq,QtdMaq,Observacoes")] InvMaq invMaq)
        {
            if (ModelState.IsValid)
            {
                _context.Add(invMaq);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(invMaq);
        }

        // GET: InvMaqs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.InvMaq == null)
            {
                return NotFound();
            }

            var invMaq = await _context.InvMaq.FindAsync(id);
            if (invMaq == null)
            {
                return NotFound();
            }
            return View(invMaq);
        }

        // POST: InvMaqs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idMaq,NomeMaq,CodMaq,QtdMaq,Observacoes")] InvMaq invMaq)
        {
            if (id != invMaq.idMaq)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(invMaq);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InvMaqExists(invMaq.idMaq))
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
            return View(invMaq);
        }

        // GET: InvMaqs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.InvMaq == null)
            {
                return NotFound();
            }

            var invMaq = await _context.InvMaq
                .FirstOrDefaultAsync(m => m.idMaq == id);
            if (invMaq == null)
            {
                return NotFound();
            }

            return View(invMaq);
        }

        // POST: InvMaqs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.InvMaq == null)
            {
                return Problem("Entity set 'DBContext.InvMaq'  is null.");
            }
            var invMaq = await _context.InvMaq.FindAsync(id);
            if (invMaq != null)
            {
                _context.InvMaq.Remove(invMaq);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InvMaqExists(int id)
        {
          return (_context.InvMaq?.Any(e => e.idMaq == id)).GetValueOrDefault();
        }
    }
}
