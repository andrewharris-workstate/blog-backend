using System;
using System.Collections.Generic;

namespace BlogBackend.Models
{
    public partial class Blog
    {
        public Blog()
        {
            Comment = new HashSet<Comment>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime? DateCreated { get; set; }
        public byte[] LastModified { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Comment> Comment { get; set; }
    }
}
