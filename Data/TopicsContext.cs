using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Svetaine.Models;

namespace Svetaine.Data
{
    public class TopicsContext : DbContext
    {
        public TopicsContext (DbContextOptions<TopicsContext> options)
            : base(options)
        {
        }

        public DbSet<Svetaine.Models.Topics> Topics { get; set; }

        public DbSet<Svetaine.Models.Threads> Threads { get; set; }

        public DbSet<Svetaine.Models.Replies> Replies { get; set; }


    }
}
