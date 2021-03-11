﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Svetaine.Data;
using Svetaine.Models;

namespace Svetaine.Pages.Topic
{
    public class DetailsModel : PageModel
    {
        private readonly Svetaine.Data.TopicsContext _context;

        public DetailsModel(Svetaine.Data.TopicsContext context)
        {
            _context = context;
        }

        public Topics Topics { get; set; }

        public Threads Thread { get; set; }

      //  public IList<Topics> TopicsL { get; set; }
        public IList<Threads> ThreadL { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Topics = await _context.Topics.FirstOrDefaultAsync(m => m.ID == id);

            ThreadL = await _context.Threads.ToListAsync();
            

            if (Topics == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}