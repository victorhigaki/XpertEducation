using XpertEducation.Core.DomainObjects;

namespace XpertEducation.Core.Data;

public interface IRepository<TEntity> : IDisposable where TEntity : Entity
{
    IUnitOfWork UnitOfWork { get; }
}
