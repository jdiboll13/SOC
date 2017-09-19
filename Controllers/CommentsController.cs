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
    public class CommentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CommentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Comments
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            return View(await _context.CommentsModel.ToListAsync());
        }

        // GET: Comments/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var commentsModel = await _context.CommentsModel
                .SingleOrDefaultAsync(m => m.ID == id);
            if (commentsModel == null)
            {
                return NotFound();
            }

            return View(commentsModel);
        }

        // GET: Comments/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Comments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("ID,Body,DatePosted,UserID,QuestionID,AnswerID")] CommentsModel commentsModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(commentsModel);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            return View(commentsModel);
        }

        // GET: Comments/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var commentsModel = await _context.CommentsModel.SingleOrDefaultAsync(m => m.ID == id);
            if (commentsModel == null)
            {
                return NotFound();
            }
            return View(commentsModel);
        }

        // POST: Comments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(string id, [Bind("ID,Body,DatePosted,UserID,QuestionID,AnswerID")] CommentsModel commentsModel)
        {
            if (id != commentsModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(commentsModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CommentsModelExists(commentsModel.ID))
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
            return View(commentsModel);
        }

        // GET: Comments/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var commentsModel = await _context.CommentsModel
                .SingleOrDefaultAsync(m => m.ID == id);
            if (commentsModel == null)
            {
                return NotFound();
            }

            return View(commentsModel);
        }

        // POST: Comments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var commentsModel = await _context.CommentsModel.SingleOrDefaultAsync(m => m.ID == id);
            _context.CommentsModel.Remove(commentsModel);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }

        private bool CommentsModelExists(string id)
        {
            return _context.CommentsModel.Any(e => e.ID == id);
        }
    }
}
