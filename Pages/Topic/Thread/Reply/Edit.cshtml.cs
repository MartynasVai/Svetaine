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
using System.Security.Claims;

namespace Svetaine.Pages.Topic.Thread.Reply
{
    [Authorize(Roles = "User")]
    public class EditModel : PageModel
    {
        private readonly Svetaine.Data.TopicsContext _context;

        public EditModel(Svetaine.Data.TopicsContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Replies Replies { get; set; }



        public string UserID { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Replies = await _context.Replies.FirstOrDefaultAsync(m => m.ID == id);
            UserID = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (Replies == null)
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

            _context.Attach(Replies).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RepliesExists(Replies.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }


            return RedirectToPage("/Topic/Thread/Details", new { id = Replies.ThreadID, });//grazina i irasa
        }

        private bool RepliesExists(int id)
        {
            return _context.Replies.Any(e => e.ID == id);
        }
    }
}
