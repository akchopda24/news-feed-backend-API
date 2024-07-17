using NewsFeed.DataAccess.CommanModel;
using NewsFeed.DataAccess.Entities;
using NewsFeed.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsFeed.Service.Interface
{
    public interface INewsFeedService
    {
        Task<IEnumerable<NewsFeedStoryDto>> GetNewsFeedStories();
        Task<PagedResult<NewsFeedStory>> SearchNewsFeedStory(SearchInfo param);
        //Task AddNewsFeedStory(NewsFeedStoryDto user);
        //Task UpdateNewsFeedStory(NewsFeedStoryDto user);
        Task DeleteNewsFeedStory(int id);
    }
}
