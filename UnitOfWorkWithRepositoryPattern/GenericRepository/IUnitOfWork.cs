
using UnitOfWorkWithRepositoryPattern.Service;

namespace UnitOfWorkWithRepositoryPattern.GenericRepository
{
    public interface IUnitOfWork
    {
        IEmployeeRepository Employee { get; }
        Task CompleteAsync();
        void Dispose();
    }
}
