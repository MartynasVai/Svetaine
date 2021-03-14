using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Svetaine.Data;
using Svetaine.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Svetaine.Pages.Topic.Thread
{
    public class DeleteThreadModel : PageModel
    {
        private readonly Svetaine.Data.TopicsContext _context;

        public DeleteThreadModel(Svetaine.Data.TopicsContext context)
        {
            _context = context;
        }
        public Threads Thread { get; set; }


        public string UserID { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {

            

            if (id == null)
            {
                return NotFound();
            }

            Thread = await _context.Threads.FirstOrDefaultAsync(m => m.ID == id);

            UserID = User.FindFirstValue(ClaimTypes.NameIdentifier);

            return Page();
        }
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            UserID = User.FindFirstValue(ClaimTypes.NameIdentifier);

            Thread = await _context.Threads.FirstOrDefaultAsync(m => m.ID == id);

            return Page();
        }
    }
}
