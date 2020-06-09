using System;
using BlogBackend.ServiceModels;
using BlogBackend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BlogBackend.Controllers
{
  [ApiController]
  [Route("[Controller]")]
  public class BlogController : ControllerBase
  {
    private readonly ILogger<BlogController> _logger;
    private readonly IBlogService _service;

    public BlogController(IBlogService service, ILogger<BlogController> logger)
    {
      _logger = logger;
      _service = service;
    }

    [HttpGet]
    public IActionResult Get()
    {
      try
      {
        var blogs = _service.GetBlogs();

        return Ok(blogs);
      }
      catch (Exception e)
      {
        _logger.LogError(e, "Error in GetBlog");

        throw e;
      }
    }

    [HttpPost]
    public IActionResult Post([FromBody] Blog blog)
    {
      try
      {
        blog = _service.CreateBlog(blog);

        return Ok(blog);
      }
      catch (Exception e)
      {
        _logger.LogError(e, "Error in PostBlog");

        throw e;
      }
    }
  }
}