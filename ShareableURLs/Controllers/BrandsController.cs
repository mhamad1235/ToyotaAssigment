using Microsoft.AspNetCore.Mvc;
using ShareableURLs.Data;
using ShareableURLs.DTOs;

namespace ShareableURLs.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BrandsController : ControllerBase
{
    private readonly BrandRepository repository;
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
        return Ok(Request.Host + Url.Action(nameof(Share), new { id = id }));
    }

    [HttpGet("{id}/share")]
    public ActionResult<BrandDTO> Share(long id)
    {
        return Find(id);
    }
}