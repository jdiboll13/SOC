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
    public class AnswersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AnswersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Answers
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            return View(await _context.AnswersModel.ToListAsync());
        }

        // GET: Answers/Details/5
        [Authorize]
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var answersModel = await _context.AnswersModel
                .SingleOrDefaultAsync(m => m.ID == id);
            if (answersModel == null)
            {
                return NotFound();
            }

            return View(answersModel);
        }

        // GET: Answers/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Answers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("ID,Body,VoteCount,DatePosted,UserID,QuestionID")] AnswersModel answersModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(answersModel);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            return View(answersModel);
        }

        // GET: Answers/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var answersModel = await _context.AnswersModel.SingleOrDefaultAsync(m => m.ID == id);
            if (answersModel == null)
            {
                return NotFound();
            }
            return View(answersModel);
        }

        // POST: Answers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(string id, [Bind("ID,Body,VoteCount,DatePosted,UserID,QuestionID")] AnswersModel answersModel)
        {
            if (id != answersModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(answersModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnswersModelExists(answersModel.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", "Home");
            }
            return View(answersModel);
        }

        // GET: Answers/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var answersModel = await _context.AnswersModel
                .SingleOrDefaultAsync(m => m.ID == id);
            if (answersModel == null)
            {
                return NotFound();
            }

            return View(answersModel);
        }

        // POST: Answers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var answersModel = await _context.AnswersModel.SingleOrDefaultAsync(m => m.ID == id);
            _context.AnswersModel.Remove(answersModel);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }

        private bool AnswersModelExists(string id)
        {
            return _context.AnswersModel.Any(e => e.ID == id);
        }
    }
}
