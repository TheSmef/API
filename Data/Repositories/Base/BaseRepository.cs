
using API.Data.Context;
using API.Models.Entity.Base;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Repositories.Base
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity>
        where TEntity : BaseEntity
    {
        protected readonly DataContext _context;

        public BaseRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<TEntity> AddItem(TEntity record, CancellationToken cancellationToken)
        {
            _context.Set<TEntity>().Add(record);
            await _context.SaveChangesAsync(cancellationToken);
            return record;
        }

        public Task<bool> Exists(Guid Id, CancellationToken cancellationToken)
        {
            return _context.Set<TEntity>()
                .AnyAsync(x => x.Id == Id, cancellationToken);
        }

        public async Task RemoveItem(Guid Id, CancellationToken cancellationToken)
        {
            var record = await _context.Set<TEntity>()
                .FirstOrDefaultAsync(x => x.Id == Id, cancellationToken);
            if (record != null)
            {
                _context.Set<TEntity>().Remove(record);
                await _context.SaveChangesAsync(cancellationToken);
            }
        }

        public async Task<TEntity> UpdateItem(TEntity record, CancellationToken cancellationToken)
        {
            _context.Set<TEntity>().Update(record);
            await _context.SaveChangesAsync(cancellationToken);
            return record;
        }
    }
}
