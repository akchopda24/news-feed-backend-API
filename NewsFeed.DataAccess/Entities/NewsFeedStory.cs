using System;
using System.Collections.Generic;

namespace NewsFeed.DataAccess.Entities;

public partial class NewsFeedStory
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? NewsLink { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? ModifiedDate { get; set; }
}
