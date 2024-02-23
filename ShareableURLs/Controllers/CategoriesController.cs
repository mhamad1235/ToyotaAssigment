using Microsoft.AspNetCore.Mvc;
using ShareableURLs.Data;
using ShareableURLs.DTOs;
using System;

namespace ShareableURLs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly CategoryRepository repository;

        public CategoriesController(CategoryRepository categoryRepository)
        {
            this.repository = categoryRepository;
        }

        [HttpGet("")]
        public ActionResult<CategoryDTO> List()
        {
            return Ok(this.repository.List());
        }

        [HttpGet("{id}")]
        public ActionResult<CategoryDTO> Find(long id)
        {
            var item = this.repository.Find(id);

            if (item is null)
                return NotFound();

            return Ok(item);
        }

        [HttpGet("{id}/get-shareable-url")]
        public ActionResult<string> GetShareableURL(long id)
        {
            string token = GenerateToken(id); // Generate a token based on the category ID
            string shareableUrl = $"{Request.Scheme}://{Request.Host}/api/categories/{id}/share?token={token}";
            return Ok(shareableUrl);
        }

        [HttpGet("{id}/share")]
        public ActionResult<CategoryDTO> Share(long id, [FromQuery] string token)
        {
            if (ValidateToken(token, id)) // Validate the token
            {
                var category = repository.Find(id);
                if (category != null)
                    return Ok(category);
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
