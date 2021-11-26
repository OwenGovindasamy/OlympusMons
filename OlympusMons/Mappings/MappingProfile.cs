using AutoMapper;
using OlympusMons.Models;
using OlympusMons.ViewModels;

namespace OlympusMons.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TestVM, Test>().ReverseMap();
        }
    }
}
