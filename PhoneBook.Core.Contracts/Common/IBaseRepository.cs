using PhoneBook.Domain.Core;

namespace PhoneBook.Core.Contracts.Common
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity, new()
    {
        TEntity Add(TEntity entity);
        TEntity Get(int id);
        IQueryable<TEntity> GetAll();
        void Delete(int id);
    }
}
