using _8Sual.DTO;
using _8Sual.Model;
using _8Sual.Model.Admin;
using AutoMapper;

namespace _8Sual.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<AdminUser,AdminUserDTO>().ReverseMap();
            CreateMap<Statistic, StatisticDTO>().ReverseMap();
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<Question, QuestionDTO>().ReverseMap();

        }
    }
}
