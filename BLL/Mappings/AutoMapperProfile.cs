using AutoMapper;
using BLL.DataTransferObjects;
using BLL.Models;
using BLL.UserModels;

namespace BLL.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserForList>();
            CreateMap<User, UserForRegister>();
            CreateMap<UserForRegister, User>();
            CreateMap<Item, ItemDto>();
            CreateMap<ItemForCreationDto, Item>();
            CreateMap<OrderForCreationDto, Order>();
            CreateMap<ItemForUpdateDto, Item>();
        }
    }
}
