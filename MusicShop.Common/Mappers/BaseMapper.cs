using AutoMapper;
using MusicShop.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Common.Mappers
{
    public class BaseMapper<T, TDto, TUpdate, TCreate> : Profile where T : BaseModel
    {
        public BaseMapper()
        {
            CreateMap<TCreate, T>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => 1))
                .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => DateTime.Now));

            CreateMap<T, TCreate>();

            CreateMap<TUpdate, T>()
                .ForMember(dest => dest.UpdatedDate, opt => opt.MapFrom(src => DateTime.Now));

            CreateMap<T, TDto>();
            CreateMap<TDto, T>();
        }
    }
}
