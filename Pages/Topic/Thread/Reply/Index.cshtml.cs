using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Svetaine.Data;
using Svetaine.Models;

namespace Svetaine.Pages.Topic.Thread.Reply
{
    public class IndexModel : PageModel
    {
        private readonly Svetaine.Data.TopicsContext _context;

        public IndexModel(Svetaine.Data.TopicsContext context)
        {
            _context = context;
        }

        public IList<Replies> Replies { get;set; }

        public async Task OnGetAsync()
        {
            Replies = await _context.Replies.ToListAsync();
        }
    }
}
