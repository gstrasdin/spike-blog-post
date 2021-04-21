using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spike.Jane.Blog.Web.Models
{
    public class PostViewModel
    {
        public int Id { get; set; }
        public DateTime? Date { get; set; }
        public string Title { get; set; }
        public string Categories { get; set; }
        public Uri ImageUrl { get; set; }
    }
}
