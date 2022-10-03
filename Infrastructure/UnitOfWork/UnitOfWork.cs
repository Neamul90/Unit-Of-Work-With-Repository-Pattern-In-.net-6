using Domain.Repositories;
using Domain.UnitOfWork;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _dbContext;
        private ICategoryRepository _categoryRepository;
        private IUserRepository _userRepository;
       

        public UnitOfWork(ApplicationContext context)
        {
            _dbContext = context;
        }
        public ICategoryRepository CategoryRepository { get { return _categoryRepository = _categoryRepository ?? new CategoryRepository(_dbContext); } }
        public IUserRepository UserRepository { get { return _userRepository = _userRepository ?? new UserRepository(_dbContext); } }


        public void Commit()
              => _dbContext.SaveChanges();


        public async Task CommitAsync()
            => await _dbContext.SaveChangesAsync();


        public void Rollback()
            => _dbContext.Dispose();


        public async Task RollbackAsync()
            => await _dbContext.DisposeAsync();
       
    }
}
