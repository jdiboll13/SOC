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
    public class TagsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TagsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Tags
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            return View(await _context.TagsModel.ToListAsync());
        }

        // GET: Tags/Details/5
        [Authorize]
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tagsModel = await _context.TagsModel
                .SingleOrDefaultAsync(m => m.ID == id);
            if (tagsModel == null)
            {
                return NotFound();
            }

            return View(tagsModel);
        }

        // GET: Tags/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tags/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("ID,TagName")] TagsModel tagsModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tagsModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tagsModel);
        }

        // GET: Tags/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tagsModel = await _context.TagsModel.SingleOrDefaultAsync(m => m.ID == id);
            if (tagsModel == null)
            {
                return NotFound();
            }
            return View(tagsModel);
        }

        // POST: Tags/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(string id, [Bind("ID,TagName")] TagsModel tagsModel)
        {
            if (id != tagsModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tagsModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TagsModelExists(tagsModel.ID))
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
            return View(tagsModel);
        }

        // GET: Tags/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tagsModel = await _context.TagsModel
                .SingleOrDefaultAsync(m => m.ID == id);
            if (tagsModel == null)
            {
                return NotFound();
            }

            return View(tagsModel);
        }

        // POST: Tags/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var tagsModel = await _context.TagsModel.SingleOrDefaultAsync(m => m.ID == id);
            _context.TagsModel.Remove(tagsModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TagsModelExists(string id)
        {
            return _context.TagsModel.Any(e => e.ID == id);
        }
    }
}
