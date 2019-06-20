using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using System.Text;
using System.Threading.Tasks;
using Domain.Models;


namespace Domain
{
 public   class AssignmentDBContext : DbContext
    {
        public AssignmentDBContext() : base("DBConnection")
        {

        }
        public DbSet<BusinessEntities> BusinessEntities { get; set; }
        public DbSet<MarkupPlan> MarkupPlan { get; set; }

      
    }
    
}
