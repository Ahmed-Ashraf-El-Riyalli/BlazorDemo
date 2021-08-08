using AuthDemo2.Data;
using System.Threading.Tasks;

namespace AuthDemo2.Services
{
    public class UnitOfWork<T> : IUnitOfWork<T> where T : class
    {
        private readonly ApplicationDbContext _db;


        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Entity = new Repository<T>(db);
        }


        public IRepository<T> Entity { get; init; }

        public async Task Save()
        {
            await _db.SaveChangesAsync();
        }
    }
}
