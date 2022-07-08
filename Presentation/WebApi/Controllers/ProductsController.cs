using Application.Abstract;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private readonly IProductRepository _context;

        public ProductsController(IProductRepository context)
        {
            _context = context;
        }

        [HttpGet(Name = "Get")]
        public async Task<IEnumerable<Product>> GetAsync()
        {
            return await _context.GetAllAsync();
        }
        [HttpGet("{id}")]
        public async Task<Product> Find(int id)
        {
            return await _context.GetByIdAsync(id);
        }

        [HttpPost(Name = "Add")]
        public void Add(Product product)
        {
            _context.CreateAsync(product);
        }

        [HttpPost(Name = "Update")]
        public void Update(Product product)
        {
            _context.Update(product);
        }

        [HttpDelete(Name = "Delete")]
        public void Delete(int id)
        {
            _context.Delete(id);
        }

    }
}
