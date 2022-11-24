using AutoMapper;
using FluentValidationDemo.DTO;
using FluentValidationDemo.Models;

namespace FluentValidationDemo.Mappings
{
    public class CustomerCreateMapper: Profile
    {
        public CustomerCreateMapper()
        {
            CreateMap<CustomerDto, Customer>();
        }
    }
}
