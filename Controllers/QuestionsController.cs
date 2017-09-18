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
    public class QuestionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public QuestionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Questions
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            return View(await _context.QuestionsModel.ToListAsync());
        }

        // GET: Questions/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var questionsModel = await _context.QuestionsModel
                .SingleOrDefaultAsync(m => m.ID == id);
            if (questionsModel == null)
            {
                return NotFound();
            }

            return View(questionsModel);
        }

        // GET: Questions/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Questions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("ID,Title,Body,VoteCount,DatePosted,UserId")] QuestionsModel questionsModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(questionsModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(questionsModel);
        }

        // GET: Questions/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var questionsModel = await _context.QuestionsModel.SingleOrDefaultAsync(m => m.ID == id);
            if (questionsModel == null)
            {
                return NotFound();
            }
            return View(questionsModel);
        }

        // POST: Questions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Title,Body,VoteCount,DatePosted,UserId")] QuestionsModel questionsModel)
        {
            if (id != questionsModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(questionsModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuestionsModelExists(questionsModel.ID))
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
            return View(questionsModel);
        }

        // GET: Questions/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var questionsModel = await _context.QuestionsModel
                .SingleOrDefaultAsync(m => m.ID == id);
            if (questionsModel == null)
            {
                return NotFound();
            }

            return View(questionsModel);
        }

        // POST: Questions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var questionsModel = await _context.QuestionsModel.SingleOrDefaultAsync(m => m.ID == id);
            _context.QuestionsModel.Remove(questionsModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuestionsModelExists(int id)
        {
            return _context.QuestionsModel.Any(e => e.ID == id);
        }
    }
}
