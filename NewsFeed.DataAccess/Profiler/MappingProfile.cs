using AutoMapper;
using NewsFeed.DataAccess.Entities;
using NewsFeed.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsFeed.DataAccess.Profiler
{
    public class MappingProfile : Profile
    {
        /// <summary>
        /// Mapping Automapper
        /// </summary>
        public MappingProfile()
        {
            CreateMap<NewsFeedStory, NewsFeedStoryDto>();
            CreateMap<NewsFeedStoryDto, NewsFeedStory>()
                .ForAllMembers(d=>d.AllowNull());
        }
    }
}
