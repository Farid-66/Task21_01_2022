using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ethereal.Data;
using Ethereal.Models;
using Microsoft.AspNetCore.Identity;

namespace Ethereal.Areas.admin.Controllers
{
    [Area("admin")]
    public class TestimonialsController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<CustomUser> _userManager;

        public TestimonialsController(AppDbContext context, UserManager<CustomUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: admin/Testimonials
        public async Task<IActionResult> Index()
        {
            return View(_context.Testimonials.Include(t => t.CustomUser));
        }

        

        // GET: admin/Testimonials/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Testimonials testimonials)
        {
            if (ModelState.IsValid)
            {
                testimonials.CreateDate = DateTime.Now;
                testimonials.CustomUserId = _userManager.GetUserId(User);
                _context.Add(testimonials);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(testimonials);
        }

        // GET: admin/Testimonials/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testimonials = await _context.Testimonials.FindAsync(id);
            if (testimonials == null)
            {
                return NotFound();
            }
            return View(testimonials);
        }

        // POST: admin/Testimonials/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Content,CustomUserId,CreateDate")] Testimonials testimonials)
        {
            if (id != testimonials.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(testimonials);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TestimonialsExists(testimonials.Id))
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
            return View(testimonials);
        }

        // GET: admin/Testimonials/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testimonials = await _context.Testimonials
                .Include(t => t.CustomUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (testimonials == null)
            {
                return NotFound();
            }

            return View(testimonials);
        }

        // POST: admin/Testimonials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var testimonials = await _context.Testimonials.FindAsync(id);
            _context.Testimonials.Remove(testimonials);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index" , "Testimonials");
        }

        private bool TestimonialsExists(int id)
        {
            return _context.Testimonials.Any(e => e.Id == id);
        }
    }
}
