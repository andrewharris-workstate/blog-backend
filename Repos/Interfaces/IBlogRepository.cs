using System.Collections.Generic;
using BlogBackend.Models;

namespace BlogBackend.Repos.Interfaces
{
  public interface IBlogRepository
  {
    IEnumerable<Blog> GetBlogs();
    Blog CreateBlog(Blog blog);
  }
}