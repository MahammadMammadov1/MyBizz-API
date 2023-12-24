using AutoMapper;
using Mybizz.DTOs.Member;
using Mybizz.DTOs.Profession;
using Mybizz.Entities;

namespace Mybizz.MappingProfile
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<MemberCreateDto,Member>().ReverseMap();
            CreateMap<MemberUpdateDto,Member>().ReverseMap();
            CreateMap<MemberGetDto,Member>().ReverseMap();

            CreateMap<ProfessionCreateDto, Profession>().ReverseMap();
            CreateMap<ProfessionGetDto, Profession>().ReverseMap();
            CreateMap<ProfessionUpdateDto, Profession>().ReverseMap();

            
        }
    }
}
