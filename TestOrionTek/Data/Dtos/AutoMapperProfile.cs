using TestOrionTek.Data.Models;
using AutoMapper;
using TestOrionTek.Data.Dtos.CustomersDto;
using TestOrionTek.Data.Dtos.CustomerDetailsDto;
using TestOrionTek.Data.Dtos.CompanyDto;

namespace TestOrionTek.Data.Dtos
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Customer, CustomersCreateDto>().ReverseMap();
            CreateMap<Customer, CustomersConsultDto>().ReverseMap();
            CreateMap<Customer, CustomersUpdateDto>().ReverseMap();

            CreateMap<CustomerDetails, CustomerDetailsUpdateDto>().ReverseMap();
            CreateMap<CustomerDetails, CustomerDetailsCreateDto>().ReverseMap();

            CreateMap<Company, CompanyCreateDto>().ReverseMap();
            CreateMap<Company, CompanyUpdateDto>().ReverseMap();
        }
    }
}
