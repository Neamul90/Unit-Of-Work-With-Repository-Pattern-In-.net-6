using AutoMapper;
using Domain.Entities;
using UnitOfWorkWithRepositoryPattern.DTOS;

namespace UnitOfWorkWithRepositoryPattern.AutoMapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserCreated>();
            CreateMap<CategoryCreated, Category>();
        }
    }
}
