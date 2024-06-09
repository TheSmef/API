using API.Models.Entity.Base;

namespace API.Data.Repositories.Base
{
    /// <summary>
    /// Репозиторий для взамодействия с данными <typeparamref name="TEntity"/>
    /// </summary>
    /// <typeparam name="TEntity">Тип данных для взаимодействия внутри репозитория, тип данных для сета</typeparam>
    public interface IRepository<TEntity>
        where TEntity : BaseEntity
    {
        /// <summary>
        /// Метод для добавления <typeparamref name="TEntity"/>
        /// </summary>
        /// <param name="record">Запись для добавления</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Добавленная запись <typeparamref name="TEntity"/></returns>
        public Task<TEntity> AddItem(TEntity record, CancellationToken cancellationToken);
        /// <summary>
        /// Метод для удаления <typeparamref name="TEntity"/>
        /// </summary>
        /// <param name="Id">Идентификатор удаляемой записи <typeparamref name="TEntity"/></param>
        /// <param name="cancellationToken"></param>
        /// <returns>Task</returns>
        public Task RemoveItem(Guid Id, CancellationToken cancellationToken);
        /// <summary>
        /// Метод для изменения <typeparamref name="TEntity"/>
        /// </summary>
        /// <param name="record">Запись для изменения</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Изменённая запись <typeparamref name="TEntity"/></returns>
        public Task<TEntity> UpdateItem(TEntity record, CancellationToken cancellationToken);
        /// <summary>
        /// Метод для проверки существования записи <typeparamref name="TEntity"/>
        /// </summary>
        /// <param name="Id">Идентификатор записи <typeparamref name="TEntity"/></param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>true если запись существует, false если - нет</returns>
        public Task<bool> Exists(Guid Id, CancellationToken cancellationToken);
    }
}
