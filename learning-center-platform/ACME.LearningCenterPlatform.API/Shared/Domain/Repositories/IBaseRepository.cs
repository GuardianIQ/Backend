namespace ACME.LearningCenterPlatform.API.Shared.Domain.Repositories;

using System.Collections.Generic;
using System.Threading.Tasks;

public interface IBaseRepository<TEntity>
{
    Task AddAsync(TEntity entity);
    Task<TEntity?> FindByIdAsync(int id);
    void Update(TEntity entity);
    void Remove(TEntity entity);
    Task<IEnumerable<TEntity>> ListAsync();
}