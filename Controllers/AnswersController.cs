using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<ApplicationUser> _userManager;


        public AnswersController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
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
                .Include(a => a.ApplicationUser)
                .Include(a => a.QuestionsModel)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (answersModel == null)
            {
                return NotFound();
            }

            return View(answersModel);
        }

        // GET: Answers/Create
        [Authorize]
        public IActionResult Create(string id)
        {
            ViewData["QuestionsModelId"] = id;
            return View();
        }

        // POST: Answers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([FromForm] string questionsModelID, [FromForm] string body)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                var newAnswer = new AnswersModel {QuestionsModelID = questionsModelID, Body = body, ApplicationUserId = user.Id};
                _context.Add(newAnswer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Details), "Questions", new {id = newAnswer.QuestionsModelID});
            }
            return View();
        }

        // GET: Answers/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(string id)
        {
            Console.WriteLine(id);
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
