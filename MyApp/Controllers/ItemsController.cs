using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyApp.Data;
using MyApp.Models;

namespace MyApp.Controllers
{
    public class ItemsController : Controller
    {
        // Injecting the database context to access the items
        private readonly MyAppContext _context;
        // Constructor to inject the database context
        public ItemsController(MyAppContext context)
        {
            _context = context;
        }
        // Action method to display the list of items
        public async Task<IActionResult> Index()
        {
            var item = await _context.Items.Include(s => s.SerialNumber)
                                                    .Include(c=> c.Category)
                                                    .ToListAsync();
            return View(item);
        }
        // Action method to display the details of a specific item
        public IActionResult Details(int id)
        {
            var item = _context.Items.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }

        // Action method to display the form for creating a new item
        public IActionResult Create()
        {
            return View();
        }

        // Action method to handle the form submission for creating a new item
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id, Name, Price")] Item item)
        {
            if (ModelState.IsValid)
            {
                _context.Items.Add(item);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(item);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var item = await _context.Items.FirstOrDefaultAsync(x=>x.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id, Name, Price")] Item item)
        {
            if (id != item.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(item);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Items.Any(e => e.Id == item.Id))
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
            return View(item);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var item = await _context.Items.FirstOrDefaultAsync(x => x.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var item = await _context.Items.FindAsync(id);
            if (item != null)
            {
                _context.Items.Remove(item);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }
    }
}
