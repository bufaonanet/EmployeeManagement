using AutoMapper;
using EmployeeManagement.Api.DataAccess.Entities;

namespace EmployeeManagement.Api.MapperProfiles;

public class EmployeeProfile : Profile
{
    public EmployeeProfile()
    {
        CreateMap<InternalEmployee, Models.InternalEmployeeDto>();
    }
}