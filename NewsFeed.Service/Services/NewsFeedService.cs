using AutoMapper;
using NewsFeed.DataAccess.CommanModel;
using NewsFeed.DataAccess.Entities;
using NewsFeed.DataAccess.Repository;
using NewsFeed.Service.Interface;

namespace NewsFeed.Service.Services
{
    public class NewsFeedService : INewsFeedService
    {
        private readonly IGenericRepository<NewsFeedStory> _newsRepository;
        private const string CacheKey = "NewsCache";
        private readonly IMapper _mapper;

        public NewsFeedService(
            IGenericRepository<NewsFeedStory> newsRepository
            , IMapper mapper
            )
        {
            _newsRepository = newsRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<NewsFeedStory>> SearchNewsFeedStory(SearchInfo param)
        {
            var result = new PagedResult<NewsFeedStory>();

            result = await _newsRepository.GetSearchData(
                x => x.Title.Contains(param.SearchValue.ToLower())
                , param.PageNumber
                , param.PageSize);

            return result;
        }
    }
}
