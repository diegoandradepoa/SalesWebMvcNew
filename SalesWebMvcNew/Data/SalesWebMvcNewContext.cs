using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalesWebMvcNew.Models;

namespace SalesWebMvcNew.Data
{
    public class SalesWebMvcNewContext : DbContext
    {
        public SalesWebMvcNewContext (DbContextOptions<SalesWebMvcNewContext> options)
            : base(options)
        {
        }

        public DbSet<SalesWebMvcNew.Models.Department> Department { get; set; }
        public DbSet<SalesWebMvcNew.Models.Seller> Seller { get; set; }
        public DbSet<SalesWebMvcNew.Models.SalesRecord> SalesRecord { get; set; }
    }
}
