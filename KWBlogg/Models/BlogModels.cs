using KWBlogg.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KWBlogg.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int PostID { get; set; }
        public string AuthorId { get; set; }
        public string CommentBody { get; set; }
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset? Updated { get; set; }
        public string UpdateReason { get; set; }



        public virtual ApplicationUser Author { get; set; }
        public virtual ApplicationUser Post { get; set; }
    }

    public class BlogPost
    {
        public BlogPost()
        {
            this.Comment = new HashSet<Comment>();
        }

        public int ID { get; set; }
        public string AuthorId { get; set; }
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset? Updated { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        [AllowHtml]
        public string Body { get; set; }
        public string MediaURL { get; set; }
        public string Abstract { get; set; }
        public bool Published { get; set; }


        public virtual ICollection<Comment> Comment { get; set; }

        //public HashSet<Comment> Comments { get; }
        public virtual ApplicationUser Author { get; set; }
        //public virtual 
    }
}