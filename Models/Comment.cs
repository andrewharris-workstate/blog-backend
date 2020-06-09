using System;
using System.Collections.Generic;

namespace BlogBackend.Models
{
    public partial class Comment
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int BlogId { get; set; }
        public string Content { get; set; }
        public bool? IsApproved { get; set; }
        public DateTime? DateCreated { get; set; }
        public byte[] LastModified { get; set; }

        public virtual Blog Blog { get; set; }
        public virtual User User { get; set; }
    }
}
