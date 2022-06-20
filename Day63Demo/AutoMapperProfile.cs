using AutoMapper;
using Day63Demo.Data.Models;
using Day63Demo.Models.ViewModel;

namespace Day63Demo
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserViewModel>().ReverseMap();
        }
    }
}
