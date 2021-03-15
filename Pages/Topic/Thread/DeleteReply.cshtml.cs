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

namespace Svetaine.Pages.Topic.Thread.Reply
{
    public class DeleteReplyModel : PageModel
    {
        private readonly Svetaine.Data.TopicsContext _context;

        public DeleteReplyModel(Svetaine.Data.TopicsContext context)
        {
            _context = context;
        }
        public Replies Reply { get; set; }


        public string UserID { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {



            if (id == null)
            {
                return NotFound();
            }

            Reply = await _context.Replies.FirstOrDefaultAsync(m => m.ID == id);

            UserID = User.FindFirstValue(ClaimTypes.NameIdentifier);

            return Page();
        }
        public async Task<IActionResult> OnPostAsync(int? id)
        {

            UserID = User.FindFirstValue(ClaimTypes.NameIdentifier);

            Reply = await _context.Replies.FirstOrDefaultAsync(m => m.ID == id);


            UserID = User.FindFirstValue(ClaimTypes.NameIdentifier);



            if (UserID == Reply.UserID)
            { //patikrina ar iraso kurejas trina irasa
                _context.Replies.Remove(Reply);
                _context.SaveChanges();
                return RedirectToPage("/Topic/Thread/Details", new { id = Reply.ThreadID, });
            }




            return Page();
        }

    }
}
