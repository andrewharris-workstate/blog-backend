using System;
using System.Linq;
using System.Collections.Generic;
using BlogBackend.Models;
using BlogBackend.Repos.Interfaces;
using Microsoft.Extensions.Logging;

namespace BlogBackend.Repos.Implementations
{
  public class BlogRepository : IBlogRepository
  {
    private readonly ILogger<BlogRepository> _logger;
    private readonly BlogContext _context;

    public BlogRepository(BlogContext context, ILogger<BlogRepository> logger) {
      _context = context;
      _logger = logger;
    }

    public IEnumerable<Blog> GetBlogs()
    {
      var blogs = new List<Blog>();

      try
      {
        blogs = _context.Blog.OrderByDescending(b => b.DateCreated)
                  .ToList();
      }
      catch (Exception e)
      {
        _logger.LogError(e, "Error in GetBlogs");
        throw e;
      }

      return blogs;
    }

    public Blog CreateBlog(Blog blog)
    {
      try
      {
        _context.Blog.Add(blog);
        _context.SaveChanges();
      }
      catch (Exception e)
      {
        _logger.LogError(e, "Error in CreateBlog");
        throw e;
      }

      return blog;
    }
  }
}