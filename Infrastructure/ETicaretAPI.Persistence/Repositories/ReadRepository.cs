using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities.Common;
using ETicaretAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly ETicaretAPIDbContext _context;

        public ReadRepository(ETicaretAPIDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public IQueryable<T> GetAll(bool tracking = true)
        {
            var query = Table.AsQueryable();

            // Sadece okuma işlemi yapacağımız için hız ve maliyet acısından EF Core Tracking mekanizmasını kapatıyoruz.
            if (!tracking)
                query = query.AsNoTracking();

            return query;
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true)
        {
            var query = Table.Where(method);

            // Sadece okuma işlemi yapacağımız için hız ve maliyet acısından EF Core Tracking mekanizmasını kapatıyoruz.
            if (!tracking)
                query = query.AsNoTracking();

            return query;
        }
            

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true)
        {
            var query = Table.AsQueryable();

            // Sadece okuma işlemi yapacağımız için hız ve maliyet acısından EF Core Tracking mekanizmasını kapatıyoruz.
            if (!tracking)
                query = query.AsNoTracking();

            return await query.FirstOrDefaultAsync(method);
        }

        public async Task<T> GetByIdAsync(string id, bool tracking = true)
        {

            // => await Table.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));
            // Yukaridakide olabilir ama find daha mantıklı
            // => await Table.FindAsync(Guid.Parse(id));

            var query = Table.AsQueryable();

            // Sadece okuma işlemi yapacağımız için hız ve maliyet acısından EF Core Tracking mekanizmasını kapatıyoruz.
            if (!tracking)
                query = query.AsNoTracking();

            // Tracking' i devre dışı bıraktığımız için find methodu olmaz o yüzden marker ile istediğimiz veriyi getiriyoruz.
            return await query.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));

        }
    }
}
