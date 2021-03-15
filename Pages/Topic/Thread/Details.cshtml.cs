using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Svetaine.Data;
using Svetaine.Models;
using System.Security.Claims;

namespace Svetaine.Pages.Topic.Thread.Reply
{
    public class DetailsModel : PageModel
    {
        private readonly Svetaine.Data.TopicsContext _context;

        public DetailsModel(Svetaine.Data.TopicsContext context)
        {
            _context = context;
        }

        public Threads Threads { get; set; }

        [BindProperty]
        public Replies Replies { get; set; }
        public IList<Replies> RepliesL { get; set; }

        public string UserID { get; set; }



        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Threads = await _context.Threads.FirstOrDefaultAsync(m => m.ID == id);

            UserID = User.FindFirstValue(ClaimTypes.NameIdentifier);//randa user id


            if (Threads == null)
            {
                return NotFound();
            }
            

            RepliesL = List(id);//atsakymu sarasas pagal id




            return Page();
        }

        private List<Replies> List(int? id)//metodas kuris grazina atsakymu sarasa sioje(id) temoje
        {
            

            var replies = from m in _context.Replies
                          select m;

            replies = replies.Where(s => s.ThreadID == id);



            return replies.ToList();
            // throw new NotImplementedException();
        }
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            Threads = await _context.Threads.FirstOrDefaultAsync(m => m.ID == id);

            if (!ModelState.IsValid)
            {
                return RedirectToPage("./Details", new { id = Threads.ID, });
            }
            _context.Replies.Add(Replies);

            Replies.UserID = User.FindFirstValue(ClaimTypes.NameIdentifier);//nustato iraso sukurejo id
            Replies.ThreadID = id.GetValueOrDefault();//GetValueOrDefault() metodas nes id yra int? o ne int
            Replies.Date = DateTime.Now;//kada irasas sukurtas



            await _context.SaveChangesAsync();




            return RedirectToPage("./Details", new { id = Threads.ID, });//perkrauna puslapi
            

        }

    }
}
