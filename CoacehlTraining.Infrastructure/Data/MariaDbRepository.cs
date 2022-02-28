using Ardalis.Specification.EntityFrameworkCore;
using GV.DomainModel.SharedKernel.Interfaces;

namespace CoacehlTraining.Infrastructure.Data
{
    public class MariaDbRepository<T> : RepositoryBase<T>, IRepository<T>, IReadRepository<T> where T : class
    {
        private readonly MariaDbContext DbContext;

        public MariaDbRepository(MariaDbContext dbContext) : base(dbContext)
        {
            DbContext = dbContext;
        }
    }
}
