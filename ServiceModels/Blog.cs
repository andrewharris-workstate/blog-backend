using System;

namespace BlogBackend.ServiceModels
{
  public class Blog
  {
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime? DateCreated { get; set; }
    public byte[] LastModified { get; set; }
  }
}