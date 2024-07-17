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

        [HttpGet("search")]
        public async Task<IActionResult> SearchNews([FromQuery] SearchInfo param)
        {
            return Ok(await _newsService.SearchNewsFeedStory(param));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _newsService.DeleteNewsFeedStory(id);
            return NoContent();
        }
    }
}
