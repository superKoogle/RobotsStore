using Entities;
using Business;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LoginEx.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        ICategoryBusiness _categoryBusiness;
        IMapper _mapper;

        public CategoryController(ICategoryBusiness categoryBusiness, IMapper mapper)
        {
            this._categoryBusiness = categoryBusiness;
            _mapper = mapper;
        }
        // GET: api/<CategoryController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> Get()
        {
            IEnumerable<Category> categories = await _categoryBusiness.GetCategories();
            IEnumerable<CategoryDTO> categoryDTOs = _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDTO>>(categories);
            return categoryDTOs.Count()>0 ? Ok(categoryDTOs) : NoContent();
        }

        // POST api/<CategoryController>
        [HttpPost]
        public async Task<ActionResult<CategoryDTO>> Post([FromBody] CategoryDTO categoryDto)
        {
            Category category = _mapper.Map<CategoryDTO, Category>(categoryDto);
            Category newCategory = await _categoryBusiness.addCategory(category);
            CategoryDTO newCategoryDTO = _mapper.Map<Category, CategoryDTO>(newCategory);
            return newCategoryDTO != null ? Ok(newCategoryDTO) : BadRequest();
        }

    }
}
