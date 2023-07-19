using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using StowageApplication.Data;
using StowageApplication.Models;

namespace StowageApplication.Controllers
{
    public class FileStowagesController : Controller
    {
        private readonly FileStowageContext _context;

        public FileStowagesController(FileStowageContext context)
        {
            _context = context;
        }

        // GET: FileStowages
        [Route("FileStowages")]
        public async Task<IActionResult> Index()
        {
              return _context.FileStowage != null ? 
                          View(await _context.FileStowage.ToListAsync()) :
                          Problem("Entity set 'FileStowageContext.FileStowage'  is null.");
        }

        // GET: FileStowages/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.FileStowage == null)
            {
                return NotFound();
            }

            var fileStowage = await _context.FileStowage
                .FirstOrDefaultAsync(m => m.ID == id);
            if (fileStowage == null)
            {
                return NotFound();
            }

            return View(fileStowage);
        }

        // GET: FileStowages/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FileStowages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,FileName,FileSize,RemotePath,UploadDate")] FileStowage fileStowage)
        {
            if (ModelState.IsValid)
            {
                fileStowage.ID = Guid.NewGuid();
                _context.Add(fileStowage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fileStowage);
        }

        // GET: FileStowages/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.FileStowage == null)
            {
                return NotFound();
            }

            var fileStowage = await _context.FileStowage.FindAsync(id);
            if (fileStowage == null)
            {
                return NotFound();
            }
            return View(fileStowage);
        }

        // POST: FileStowages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ID,FileName,FileSize,RemotePath,UploadDate")] FileStowage fileStowage)
        {
            if (id != fileStowage.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fileStowage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FileStowageExists(fileStowage.ID))
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
            return View(fileStowage);
        }

        // GET: FileStowages/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.FileStowage == null)
            {
                return NotFound();
            }

            var fileStowage = await _context.FileStowage
                .FirstOrDefaultAsync(m => m.ID == id);
            if (fileStowage == null)
            {
                return NotFound();
            }

            return View(fileStowage);
        }

        // POST: FileStowages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.FileStowage == null)
            {
                return Problem("Entity set 'FileStowageContext.FileStowage'  is null.");
            }
            var fileStowage = await _context.FileStowage.FindAsync(id);
            if (fileStowage != null)
            {
                _context.FileStowage.Remove(fileStowage);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FileStowageExists(Guid id)
        {
          return (_context.FileStowage?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
