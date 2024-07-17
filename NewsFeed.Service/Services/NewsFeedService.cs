using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using NewsFeed.DataAccess.CommanModel;
using NewsFeed.DataAccess.Entities;
using NewsFeed.DataAccess.Models;
using NewsFeed.DataAccess.Repository;
using NewsFeed.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsFeed.Service.Services
{
    public class NewsFeedService : INewsFeedService
    {
        private readonly IMemoryCache _cache;
        private readonly IGenericRepository<NewsFeedStory> _newsRepository;
        private const string CacheKey = "NewsCache";
        private readonly IMapper _mapper;

        public NewsFeedService(IMemoryCache cache,
            IGenericRepository<NewsFeedStory> newsRepository
            , IMapper mapper
            )
        {
            _cache = cache;
            _newsRepository = newsRepository;
            _mapper = mapper;
        }


        public async Task<IEnumerable<NewsFeedStoryDto>> GetNewsFeedStories()
        {

            //if (!_cache.TryGetValue(CacheKey, out IEnumerable<NewsFeedStory>? cachedNews))
            //{
            //    cachedNews = (IEnumerable<NewsFeedStory>?)await _newsRepository.GetAll();
            //    _cache.Set(CacheKey, cachedNews);
            //}

            var cachedNews = await _newsRepository.GetAll();
            if (cachedNews == null)
            {
                return null;
            }
            try
            {
                return _mapper.Map<IEnumerable<NewsFeedStoryDto>>(cachedNews);

            }
            catch (Exception ex)
            {

                throw;
            }
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

        //public async Task AddNewsFeedStory(NewsFeedStoryDto model)
        //{
        //    if (model.Id == 0)
        //    {
        //        var newsFeedStory = _mapper.Map<NewsFeedStory>(model);
        //        await _newsRepository.Create(newsFeedStory);
        //    }
        //}

        //public async Task UpdateNewsFeedStory(NewsFeedStoryDto model)
        //{
        //    var newsFeedStory = await _newsRepository.GetById(model.Id);

        //    if (newsFeedStory != null)
        //    {
        //        newsFeedStory = _mapper.Map(model, newsFeedStory);

        //        await _newsRepository.Update(newsFeedStory);
        //    }
        //}

        public async Task DeleteNewsFeedStory(int id)
        {
            var newsFeedStory = await _newsRepository.GetById(id);

            if (newsFeedStory == null)
            {
                return;
            }
            await _newsRepository.Delete(newsFeedStory);
        }
    }
}
