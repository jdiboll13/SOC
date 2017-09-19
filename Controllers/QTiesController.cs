using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SOC.Data;
using SOC.Models;

namespace SOC.Controllers
{
    public class QTiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public QTiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: QTies
        [Authorize]
        public async Task<IActionResult> Index()
        {
            return View(await _context.QTiesModel.ToListAsync());
        }

        // GET: QTies/Details/5
        [Authorize]
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var qTiesModel = await _context.QTiesModel
                .SingleOrDefaultAsync(m => m.ID == id);
            if (qTiesModel == null)
            {
                return NotFound();
            }

            return View(qTiesModel);
        }

        // GET: QTies/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: QTies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("ID,TagID,QuestionID")] QTiesModel qTiesModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(qTiesModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(qTiesModel);
        }

        // GET: QTies/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var qTiesModel = await _context.QTiesModel.SingleOrDefaultAsync(m => m.ID == id);
            if (qTiesModel == null)
            {
                return NotFound();
            }
            return View(qTiesModel);
        }

        // POST: QTies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(string id, [Bind("ID,TagID,QuestionID")] QTiesModel qTiesModel)
        {
            if (id != qTiesModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(qTiesModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QTiesModelExists(qTiesModel.ID))
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
            return View(qTiesModel);
        }

        // GET: QTies/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var qTiesModel = await _context.QTiesModel
                .SingleOrDefaultAsync(m => m.ID == id);
            if (qTiesModel == null)
            {
                return NotFound();
            }

            return View(qTiesModel);
        }

        // POST: QTies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var qTiesModel = await _context.QTiesModel.SingleOrDefaultAsync(m => m.ID == id);
            _context.QTiesModel.Remove(qTiesModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QTiesModelExists(string id)
        {
            return _context.QTiesModel.Any(e => e.ID == id);
        }
    }
}
