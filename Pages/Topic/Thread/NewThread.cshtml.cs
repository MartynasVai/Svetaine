using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Svetaine.Data;
using Svetaine.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using System.Security.Claims;

namespace Svetaine.Pages.Topic.Thread
{
    [Authorize]//patikrina ar yra prisijunges vartotojas
    public class NewThreadModel : PageModel
    {
        private readonly Svetaine.Data.TopicsContext _context;

        public NewThreadModel(Svetaine.Data.TopicsContext context)
        {
            _context = context;
        }

        public Topics Topics { get; set; }
        [BindProperty]
        public Threads Threads { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)//jeigu id nenurodytas
            {
                return NotFound();//404
            }

            Topics = await _context.Topics.FirstOrDefaultAsync(m => m.ID == id);//randa tema

            if (Topics == null)//jeigu neranda temos su tokiu id
            {
                return NotFound();//404
            }
            

            
            return Page();

        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (!ModelState.IsValid || id == null)
            {
                return RedirectToPage("./NewThread", new { id = id, });
            }

            
            _context.Threads.Add(Threads);

            Threads.UserID = User.FindFirstValue(ClaimTypes.NameIdentifier);//nustato iraso sukurejo id
            Threads.TopicID = id.GetValueOrDefault();//GetValueOrDefault() metodas nes id yra int? o ne int
            Threads.Date = DateTime.Now;//kada irasas sukurtas

            //situs du adminas gales settint kad uzrakint arba prisegti irasa
            Threads.Locked = false;//
            Threads.Pinned = false;//
            
        await _context.SaveChangesAsync();
            
           

           

            return RedirectToPage("./Details", new { id = Threads.ID, });//nusiuncia vartotoja i sukurta irasa

        }


    }
}