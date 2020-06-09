using System.Collections.Generic;
using BlogBackend.ServiceModels;

namespace BlogBackend.Services.Interfaces
{
  public interface IBlogService
  {
    IEnumerable<Blog> GetBlogs();
    Blog CreateBlog(Blog blog);
  }
}