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

        // public Threads Thread { get; set; }

        //  public IList<Topics> TopicsL { get; set; }
        public IList<Threads> ThreadL { get; set; }

        public string UserID {get; set;}

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            UserID = User.FindFirstValue(ClaimTypes.NameIdentifier);//randa user id

            if (id == null)//jeigu id nenurodytas
            {
                return NotFound();
            }

            Topics = await _context.Topics.FirstOrDefaultAsync(m => m.ID == id);//randa tema pagal id

            
            ThreadL = List(id);//irasu sarasas pagal id


            if (Topics == null)//jeigu nerado temos pagal id
            {
                return NotFound();
            }
            return Page();



        }

        private List<Threads> List(int? id)//metodas kuris grazina irasu sarasa sioje(id) temoje
        {
            var threads = from m in _context.Threads
                          select m;

            threads = threads.Where(s => s.TopicID == id);

            

            return threads.ToList();
            // throw new NotImplementedException();
        }





    }
}
