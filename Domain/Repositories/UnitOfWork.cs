using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
  public  class UnitOfWork
    {
        private AssignmentDBContext _db;

        public UnitOfWork()
        {
            this._db = new AssignmentDBContext();
        }
        public int Save() => _db.SaveChanges();


        public IRepository<BusinessEntities> BusinessEntitiesRepo;
        public IRepository<BusinessEntities> BusinessEntitiesRepository
        {
            get
            {
                if (this.BusinessEntitiesRepo == null)
                {
                    this.BusinessEntitiesRepo = new Repository<BusinessEntities>(_db);

                }
                return BusinessEntitiesRepo;
            }
        }

        public IRepository<MarkupPlan> MarkupPlanRepo;
        public IRepository<MarkupPlan> MarkupPlanRepository
        {
            get
            {
                if (this.MarkupPlanRepo == null)
                {
                    this.MarkupPlanRepo = new Repository<MarkupPlan>(_db);

                }
                return MarkupPlanRepo;
            }
        }

    }
}
