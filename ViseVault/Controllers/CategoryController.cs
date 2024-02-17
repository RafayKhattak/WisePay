using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ViseVault.Models;

namespace ViseVault.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Category
        public async Task<IActionResult> Index()
        {
            // Check if Categories entity set is not null
            return _context.Categories != null ?
                        View(await _context.Categories.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.Categories'  is null.");
        }


        // GET: Category/AddOrEdit
        public IActionResult AddOrEdit(int id = 0)
        {
            // If id is 0, return a new category to the view, else return the category with the given id
            if (id == 0)
                return View(new Category());
            else
                return View(_context.Categories.Find(id));
        }

        // POST: Category/AddOrEdit
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("CategoryId,Title,Icon,Type")] Category category)
        {
            // Check if the ModelState is valid
            if (ModelState.IsValid)
            {
                // If CategoryId is 0, it's a new category, add it to the context, else update the existing one
                if (category.CategoryId == 0)
                    _context.Add(category);
                else
                    _context.Update(category);

                // Save changes to the database
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index)); // Redirect to the Index action
            }
            return View(category); // Return the same view with errors
        }


        // POST: Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            // Check if Categories entity set is null
            if (_context.Categories == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Categories'  is null.");
            }

            // Find the category with the given id
            var category = await _context.Categories.FindAsync(id);

            // If category is found, remove it from the context
            if (category != null)
            {
                _context.Categories.Remove(category);
            }

            // Save changes to the database
            await _context.SaveChangesAsync();

            // Redirect to the Index action
            return RedirectToAction(nameof(Index));
        }
    }
}
