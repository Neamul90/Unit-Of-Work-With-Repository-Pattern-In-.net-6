using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UnitOfWorkWithRepositoryPattern.DTOS;
using UnitOfWorkWithRepositoryPattern.Services;

namespace UnitOfWorkWithRepositoryPattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMapper _mapper;
        private ICategoryService _categoryService;
        public CategoryController(IMapper mapper, ICategoryService categoryService)
        {
            _mapper = mapper;
            _categoryService = categoryService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var categories =await _categoryService.GetAll();
            return Ok(categories);
        }
        [HttpPost]
        public async Task<IActionResult> Post(CategoryCreated categoryCreated)
        {
            Category userViewModel = _mapper.Map<Category>(categoryCreated);
            var category =await _categoryService.AddAccount(userViewModel);
            return Ok(category);
        }
    }
}
