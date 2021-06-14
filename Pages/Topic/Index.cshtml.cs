using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Svetaine.Data;
using Svetaine.Models;

namespace Svetaine.Pages.Topic
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly Svetaine.Data.TopicsContext _context;

        public IndexModel(Svetaine.Data.TopicsContext context)
        {
            _context = context;
        }

        public IList<Topics> Topics { get;set; }

        public async Task OnGetAsync()
        {
            List<Topics> Tlist = new List<Topics>();

            Tlist = await _context.Topics.ToListAsync();

            Topics = Tlist.OrderBy(o => o.Priority).ToList();//surikiuoja pagal priority

            
        }
    }
}
