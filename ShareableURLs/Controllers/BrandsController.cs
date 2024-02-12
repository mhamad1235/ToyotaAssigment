using Microsoft.AspNetCore.Mvc;
using ShareableURLs.Data;
using ShareableURLs.DTOs;

namespace ShareableURLs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        public readonly BrandRepository repository;
        public BrandsController(BrandRepository brandRepository)
        {
            this.repository = brandRepository;
        }

        [HttpGet("")]
        public ActionResult<BrandDTO> List()
        {
            return Ok(this.repository.List());
        }

        [HttpGet("{id}")]
        public ActionResult<BrandDTO> Find(long id)
        {
            var item = this.repository.Find(id);

            if (item is null)
                return NotFound();

            return Ok(item);
        }

        [HttpGet("{id}/get-shareable-url")]
        public ActionResult<string> GetShareableURL(long id)
        {
            //This is returning the URL for Find. Which is not Shareable (Because it requires authentication)
            //Your task is to return a URL that grants access to this resource for 15 minutes.

            return $"{Request.Host}/api/brands/{id}";
        }
    }
}