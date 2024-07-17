using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsFeed.DataAccess.Models
{
    public class NewsFeedStoryDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? NewsLink { get; set; }
    }
}
