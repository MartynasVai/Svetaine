using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Svetaine.Data;
using Svetaine.Models;

namespace Svetaine.Pages.Topic.Thread
{
    public class EditModel : PageModel
    {
        private readonly Svetaine.Data.TopicsContext _context;

        public EditModel(Svetaine.Data.TopicsContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Threads Threads { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Threads = await _context.Threads.FirstOrDefaultAsync(m => m.ID == id);

            if (Threads == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Threads).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ThreadsExists(Threads.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ThreadsExists(int id)
        {
            return _context.Threads.Any(e => e.ID == id);
        }
    }
}
