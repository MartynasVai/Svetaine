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

        public IList<Threads> Threads { get;set; }

        public async Task OnGetAsync()
        {
            Threads = await _context.Threads.ToListAsync();
        }
    }
}
