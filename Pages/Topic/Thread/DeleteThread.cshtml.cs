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
            


            if (id == null)//jei id nenurodytas
            {
                return NotFound();
            }

            Thread = await _context.Threads.FirstOrDefaultAsync(m => m.ID == id);//randa irasa

            if (Thread == null)//jei nerado
            {
                return NotFound();
            }

            UserID = User.FindFirstValue(ClaimTypes.NameIdentifier);//user id

            return Page();
        }
        public async Task<IActionResult> OnPostAsync(int? id)
        {

            UserID = User.FindFirstValue(ClaimTypes.NameIdentifier);//user id

            Thread = await _context.Threads.FirstOrDefaultAsync(m => m.ID == id);

            IList<Replies> RepliesL;

            UserID = User.FindFirstValue(ClaimTypes.NameIdentifier);

            RepliesL = List(id);//atsakymu sarasas pagal id

            if (UserID==Thread.UserID) { //patikrina ar iraso kurejas trina irasa
                _context.Replies.RemoveRange(RepliesL);
                _context.Threads.Remove(Thread);
                _context.SaveChanges();
                return RedirectToPage("/Topic/Details", new { id = Thread.TopicID, });//grazina atgal i tema kurioje buvo irasas
            }




            return Page();
        }
        private List<Replies> List(int? id)//metodas kuris grazina atsakymu sarasa siame irase
        {
            var Replies = from m in _context.Replies
                          select m;

            Replies = Replies.Where(s => s.ThreadID == id);



            return Replies.ToList();
            // throw new NotImplementedException();
        }
    }
}
