using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Svetaine.Data;
using Svetaine.Models;

namespace Svetaine.Pages.Topic.Thread
{
    public class DeleteModel : PageModel
    {
        private readonly Svetaine.Data.TopicsContext _context;

        public DeleteModel(Svetaine.Data.TopicsContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Threads = await _context.Threads.FindAsync(id);

            if (Threads != null)
            {
                _context.Threads.Remove(Threads);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
