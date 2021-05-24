using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Svetaine.Data;
using Svetaine.Models;
using Microsoft.AspNetCore.Authorization;


namespace Svetaine.Pages.Topic
{
    [Authorize(Roles = "Moderator")]
    public class DeleteModel : PageModel
    {
        private readonly Svetaine.Data.TopicsContext _context;

        public DeleteModel(Svetaine.Data.TopicsContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Topics Topics { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Topics = await _context.Topics.FirstOrDefaultAsync(m => m.ID == id);

            if (Topics == null)
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

            Topics = await _context.Topics.FindAsync(id);

            if (Topics != null)
            {
                _context.Topics.Remove(Topics);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
