using AutoMapper;
using Business;
using Entities;
using DTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LoginEx.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IProductBusiness _productBusiness;
        IMapper _mapper;

        public ProductController(IProductBusiness productBusiness, IMapper mapper)
        {
            this._productBusiness = productBusiness;
            this._mapper = mapper;
        }

        // GET: api/<ProductController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> Get([FromQuery] IEnumerable<string>? categories, string? name, int? minPrice, int? maxPrice)
        {
            IEnumerable<Product> products = await _productBusiness.GetProducts(categories, name, minPrice, maxPrice);
            IEnumerable<ProductDTO> productDTOs = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(products);
            return productDTOs.Count() > 0 ? Ok(productDTOs) : NoContent();
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> Get(int id)
        {
            Product product = await _productBusiness.GetProductById(id);
            ProductDTO productDto = _mapper.Map<Product, ProductDTO>(product);
            return productDto != null ? Ok(productDto) : NoContent();
        }

        // POST api/<ProductController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProductDTO productDto)
        {
            Product product = _mapper.Map<ProductDTO, Product>(productDto);
            product = await _productBusiness.AddProduct(product);
            productDto = _mapper.Map<Product, ProductDTO>(product);
            return productDto.ProductId != 0 ? Ok(productDto) : BadRequest();
        }
    }
}
