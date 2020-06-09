using System;
using System.Collections.Generic;

namespace BlogBackend.Models
{
    public partial class User
    {
        public User()
        {
            Blog = new HashSet<Blog>();
            Comment = new HashSet<Comment>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime? DateCreated { get; set; }
        public byte[] LastModified { get; set; }

        public virtual ICollection<Blog> Blog { get; set; }
        public virtual ICollection<Comment> Comment { get; set; }
    }
}
