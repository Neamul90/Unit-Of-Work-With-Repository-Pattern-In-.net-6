using Domain.Entities;
using Domain.UnitOfWork;
using System.Security.Principal;

namespace UnitOfWorkWithRepositoryPattern.Services
{
  
    public interface ICategoryService
    {
        public Task<IEnumerable<Category>> GetAll();
        public Task<Category> AddAccount(AccountCreated model);
        public Task<bool> UpdateAccount(Guid id, AccountUpdate model);
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
        public async Task<Account> AddAccount(AccountCreated model)
        {
            try
            {
                var account = new Account
                {
                    Name = model.Name,
                    ParentAccountId = model.ParentAccountId,
                    CreatedDate = DateTime.Now,
                    CreatedBy = "1",
                    IsSystemCreated = false,
                    Status = "Active"
                };
                _unitOfWork.AccountRepository.Add(account);
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
                var existAccount = _unitOfWork.AccountRepository.Get(a => a.Id == id);
                if (existAccount == null)
                    return false;
                existAccount.Status = "Deleted";
                existAccount.ModifiedDate = DateTime.Now;
                _unitOfWork.AccountRepository.Update(existAccount);
                await _unitOfWork.CommitAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<IEnumerable<Account>> GetAll()
        {
            return await _unitOfWork.AccountRepository.GetAllAsync(a => a.Status == "Active");
        }

        public async Task<Account> GetAsync(Guid accountId)
        {
            return (await _unitOfWork.AccountRepository.GetAsync(a => a.Id == accountId));
        }

        public async Task<bool> UpdateAccount(Guid id, AccountUpdate model)
        {
            try
            {
                var existAccount = _unitOfWork.AccountRepository.Get(a => a.Id == id);
                if (existAccount == null)
                    return false;
                existAccount.ParentAccountId = model.ParentAccountId;
                existAccount.Name = model.Name;
                existAccount.ModifiedDate = DateTime.Now;
                _unitOfWork.AccountRepository.Update(existAccount);
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
