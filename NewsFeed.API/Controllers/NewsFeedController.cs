using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewsFeed.DataAccess.CommanModel;
using NewsFeed.DataAccess.Models;
using NewsFeed.Service.Interface;

namespace NewsFeed.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsFeedController : ControllerBase
    {
        private readonly INewsFeedService _newsService;

        public NewsFeedController(INewsFeedService newsService)
        {
            _newsService = newsService;
        }

        /// <summary>
        /// Get All News Feed URL : https://localhost:7189/api/NewsFeed/search
        /// Search value URL : https://localhost:7189/api/NewsFeed/search?SearchValue=news&PageNumber=1&PageSize=10
        /// </summary>
        /// <param name="SearchValue">It should be string. It's not mendatory</param>
        /// <param name="PageNumber">It should be integer. It's default value is 1</param>
        /// <param name="PageSize">It should be integer. It's default value is 10</param>
        /// <returns>
        /// It will return Json with below field
        /// Items : list of data
        /// TotalCount : total records of news feeds
        /// PageNumber : total records of news feeds
        /// PageSize : total records display per page
        /// </returns>
        [HttpGet("search")]
        public async Task<IActionResult> SearchNews([FromQuery] SearchInfo param)
        {
            return Ok(await _newsService.SearchNewsFeedStory(param));
        }

    }
}
