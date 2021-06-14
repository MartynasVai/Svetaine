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

namespace Svetaine.Pages.Topic.Thread
{
    [Authorize(Roles = "Moderator")]
    public class IndexModel : PageModel
    {
        private readonly Svetaine.Data.TopicsContext _context;

        public IndexModel(Svetaine.Data.TopicsContext context)
        {
            _context = context;
        }

        List<Threads> Tlist = new List<Threads>();
        public IList<Threads> Threads { get;set; }


        public async Task OnGetAsync()
        {
            Tlist = await _context.Threads.ToListAsync();//gauna irasu sarasa 
            Threads = Tlist.OrderByDescending(o => o.Pinned).ToList();//pinned sarasai perkeliami i prieki

            //Threads = await _context.Threads.ToListAsync();



        }
    }
}
