using Domain.Entities;
using Domain.UnitOfWork;
using System.Security.Principal;
using UnitOfWorkWithRepositoryPattern.DTOS;

namespace UnitOfWorkWithRepositoryPattern.Services
{
  
    public interface ICategoryService
    {
        public Task<IEnumerable<Category>> GetAll();
        public Task<Category> AddAccount(CategoryCreated model);
        public Task<bool> UpdateAccount(Guid id, CategoryUpdate model);
        public Task<bool> DeleteAccount(Guid id);
        public Task<Category> GetAsync(Guid accountId);
    }
    public class CategoryService : ICategoryService
    {
        public IUnitOfWork _unitOfWork;
        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Category> AddAccount(CategoryCreated model)
        {
            try
            {
                var account = new Category
                {
                    Name = model.Name,
                  
                    CreatedDate = DateTime.Now,
                    CreatedBy = "1",
                    Status = "Active"
                };
                _unitOfWork.CategoryRepository.Add(account);
                await _unitOfWork.CommitAsync();
                return account;
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> DeleteAccount(Guid id)
        {
            try
            {
                var existAccount = _unitOfWork.CategoryRepository.Get(a => a.Id == id);
                if (existAccount == null)
                    return false;
                existAccount.Status = "Deleted";
                existAccount.ModifiedDate = DateTime.Now;
                _unitOfWork.CategoryRepository.Update(existAccount);
                await _unitOfWork.CommitAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            return await _unitOfWork.CategoryRepository.GetAllAsync(a => a.Status == "Active");
        }

        public async Task<Category> GetAsync(Guid id)
        {
            return (await _unitOfWork.CategoryRepository.GetAsync(a => a.Id == id));
        }

        public async Task<bool> UpdateAccount(Guid id, CategoryUpdate model)
        {
            try
            {
                var existAccount = _unitOfWork.CategoryRepository.Get(a => a.Id == id);
                if (existAccount == null)
                    return false;
                existAccount.Name = model.Name;
                existAccount.ModifiedDate = DateTime.Now;
                _unitOfWork.CategoryRepository.Update(existAccount);
                await _unitOfWork.CommitAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
