using EmployeeManagement.Api.DataAccess.Entities;

namespace EmployeeManagement.Api.Business;

public interface IPromotionService
{
    Task<bool> PromoteInternalEmployeeAsync(InternalEmployee employee);
}