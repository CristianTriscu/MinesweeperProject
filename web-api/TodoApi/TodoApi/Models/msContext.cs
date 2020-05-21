using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace TodoApi.Models
{
    public class msContext : DbContext
    {
        public msContext(DbContextOptions<msContext> options)
            : base(options)
        {
        }
       
        public DbSet<ms> MsItems { get; set; }
    }
}