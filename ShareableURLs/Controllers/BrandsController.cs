using Microsoft.AspNetCore.Mvc;
using ShareableURLs.Data;
using ShareableURLs.DTOs;
using System;

namespace ShareableURLs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly BrandRepository repository;

        public BrandsController(BrandRepository brandRepository)
        {
            this.repository = brandRepository;
        }

        [HttpGet("{id}/get-shareable-url")]
        public ActionResult<string> GetShareableURL(long id)
        {
            string token = GenerateToken(id);
            string shareableUrl = $"{Request.Scheme}://{Request.Host}/api/brands/{id}/share?token={token}";
            return Ok(shareableUrl);
        }

        [HttpGet("{id}/share")]
        public ActionResult<BrandDTO> Share(long id, [FromQuery] string token)
        {
            if (ValidateToken(token, id)) 
            {
                var brand = repository.Find(id);
                if (brand != null)
                    return Ok(brand);
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
