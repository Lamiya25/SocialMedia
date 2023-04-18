using Microsoft.EntityFrameworkCore;
using SocialMedia.Application.Repositories;
using SocialMedia.Domain.Common;
using SocialMedia.Persistance.Contexts;
using System.Linq.Expressions;

namespace SocialMedia.Persistance.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _context;
        public ReadRepository(AppDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public IQueryable<T> GetAll(bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking(); 
            return query;
        }

        public IQueryable<T> GetAllWhere(Expression<Func<T, bool>> method, bool tracking = true)
        {
            var query = Table.Where(method);
            if(!tracking)
                query = query.AsNoTracking();
            return query;
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> method, bool tracking = true)
        {
            var query = Table.Where(method);
            if (!tracking)
                query = query.AsNoTracking();
            return await query.FirstOrDefaultAsync();
        }

        public async Task<T> GetByIdAsync(string id, bool tracking = true)
        {
            var query = Table.Where(x=>x.Id == id);
            if (!tracking)
                query = query.AsNoTracking();
            return await query.FirstOrDefaultAsync();
        }
    }
}
