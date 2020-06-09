using System;
using System.Linq;
using System.Collections.Generic;
using BlogBackend.Repos.Interfaces;
using BlogBackend.ServiceModels;
using BlogEntity = BlogBackend.Models.Blog;
using BlogBackend.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace BlogBackend.Services
{
  public class BlogService : IBlogService
  {
    private readonly IBlogRepository _repo;
    private readonly ILogger<BlogService> _logger;

    public BlogService(IBlogRepository repo, ILogger<BlogService> logger)
    {
      _repo = repo;
      _logger = logger;
    }

    public IEnumerable<Blog> GetBlogs()
    {
      var blogs = new List<Blog>();

      try
      {
        blogs = _repo.GetBlogs().Select(b => new Blog()
        {
          Id = b.Id,
          UserId = b.UserId,
          Title = b.Title,
          Content = b.Content,
          DateCreated = b.DateCreated,
          LastModified = b.LastModified
        }).ToList();
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
        var entity = new BlogEntity()
        {
          UserId = blog.UserId,
          Title = blog.Title,
          Content = blog.Content
        };
        entity = _repo.CreateBlog(entity);

        blog.Id = entity.Id;
        blog.DateCreated = entity.DateCreated;
        blog.LastModified = entity.LastModified;
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