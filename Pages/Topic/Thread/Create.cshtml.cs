using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Svetaine.Data;
using Svetaine.Models;

namespace Svetaine.Pages.Topic.Thread
{
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
        public Threads Threads { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Threads.Add(Threads);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
