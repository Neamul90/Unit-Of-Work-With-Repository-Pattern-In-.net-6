using Microsoft.EntityFrameworkCore;
using System.Security.Principal;
using UnitOfWorkWithRepositoryPattern.Context;
using UnitOfWorkWithRepositoryPattern.GenericRepository;
using UnitOfWorkWithRepositoryPattern.Model;

namespace UnitOfWorkWithRepositoryPattern.Service
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {

    }
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(ApplicationDbContext context, ILogger logger) : base(context, logger)
        {
        }
    }
   
}
