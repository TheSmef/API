using API.Models.Entity.Base;

namespace API.Data.Repositories.Base
{
    public interface IRepository<TEntity>
        where TEntity : BaseEntity
    {
        public Task<TEntity> AddItem(TEntity record, CancellationToken cancellationToken);
        public Task RemoveItem(Guid Id, CancellationToken cancellationToken);
        public Task<TEntity> UpdateItem(TEntity record, CancellationToken cancellationToken);
        public Task<bool> Exists(Guid Id, CancellationToken cancellationToken);
    }
}
