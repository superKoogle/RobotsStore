using Business;
using Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LoginEx.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IProductBusiness _productBusiness;

        public ProductController(IProductBusiness productBusiness)
        {
            this._productBusiness = productBusiness;
        }

        // GET: api/<ProductController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> Get([FromQuery]IEnumerable<string>? categories,string? name, int? minPrice, int? maxPrice)
        {

            IEnumerable<Product> products = await _productBusiness.GetProducts(categories,name,minPrice,maxPrice);
            return products.Count() > 0 ? Ok(products) : NoContent();
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> Get(int id)
        {
            Product product = await _productBusiness.GetProductById(id);
            return product!=null ? Ok(product) : NoContent();
        }

        // POST api/<ProductController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Product product)
        {
            product = await _productBusiness.AddProduct(product);
            return product.ProductId != 0 ? Ok(product) : BadRequest();
        }
    }
}
