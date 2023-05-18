using TestOrionTek.Data.Models;
using AutoMapper;
using TestOrionTek.Data.Dtos.CustomersDto;

namespace TestOrionTek.Data.Dtos
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Customer, CustomersCreateDto>().ReverseMap();
            CreateMap<Customer, CustomersConsultDto>().ReverseMap();
            CreateMap<Customer, CustomersUpdateDto>().ReverseMap();
        }
    }
}
