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
using Microsoft.AspNetCore.Authorization;

namespace Svetaine.Pages.Topic
{
    [Authorize(Roles = "Moderator")]
    public class EditModel : PageModel
    {
        private readonly Svetaine.Data.TopicsContext _context;

        public EditModel(Svetaine.Data.TopicsContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Topics).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TopicsExists(Topics.ID))
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

        private bool TopicsExists(int id)
        {
            return _context.Topics.Any(e => e.ID == id);
        }
    }
}
