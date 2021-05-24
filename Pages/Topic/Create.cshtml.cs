using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Svetaine.Data;
using Svetaine.Models;
using Microsoft.AspNetCore.Authorization;

namespace Svetaine.Pages.Topic
{
    [Authorize(Roles = "Moderator")]
    public class CreateModel : PageModel
    {
        private readonly Svetaine.Data.TopicsContext _context;

        public CreateModel(Svetaine.Data.TopicsContext context)
        {
            _context = context;
        }
        
        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Topics Topics { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Topics.Add(Topics);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
