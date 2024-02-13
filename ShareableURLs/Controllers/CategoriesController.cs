﻿using Microsoft.AspNetCore.Mvc;
using ShareableURLs.Data;
using ShareableURLs.DTOs;

namespace ShareableURLs.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly CategoryRepository repository;
    public CategoriesController(CategoryRepository brandRepository)
    {
        this.repository = brandRepository;
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
        return Ok(Request.Host + Url.Action(nameof(Share), new { id = id }));
    }

    [HttpGet("{id}/share")]
    public ActionResult<CategoryDTO> Share(long id)
    {
        return Find(id);
    }
}