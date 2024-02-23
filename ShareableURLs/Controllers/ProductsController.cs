using Microsoft.AspNetCore.Mvc;
using ShareableURLs.Data;
using ShareableURLs.DTOs;
using System;

namespace ShareableURLs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductRepository repository;

        public ProductsController(ProductRepository productRepository)
        {
            this.repository = productRepository;
        }

        [HttpGet("")]
        public ActionResult<ProductDTO> List()
        {
            return Ok(this.repository.List());
        }

        [HttpGet("{id}")]
        public ActionResult<ProductDTO> Find(long id)
        {
            var item = this.repository.Find(id);

            if (item is null)
                return NotFound();

            return Ok(item);
        }

        [HttpGet("{id}/get-shareable-url")]
        public ActionResult<string> GetShareableURL(long id)
        {
            string token = GenerateToken(id); // Generate a token based on the product ID
            string shareableUrl = $"{Request.Scheme}://{Request.Host}/api/products/{id}/share?token={token}";
            return Ok(shareableUrl);
        }

        [HttpGet("{id}/share")]
        public ActionResult<ProductDTO> Share(long id, [FromQuery] string token)
        {
            if (ValidateToken(token, id)) // Validate the token
            {
                var product = repository.Find(id);
                if (product != null)
                    return Ok(product);
                else
                    return NotFound();
            }
            else
            {
                return Unauthorized();
            }
        }

        private string GenerateToken(long id)
        {
            
            return Guid.NewGuid().ToString();
        }

        private bool ValidateToken(string token, long id)
        {
            
            return !string.IsNullOrEmpty(token);
        }
    }
}
