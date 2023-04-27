using EmployeeManagement.Api.Business;
using EmployeeManagement.Api.DataAccess.Services;
using EmployeeManagement.Tests.Services;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeManagement.Tests.Fixture;

public class EmployeeServiceWithAspNetCoreDIFixture
{
    private readonly ServiceProvider _serviceProvider;

    public IEmployeeManagementRepository EmployeeManagementRepository
        => _serviceProvider.GetService<IEmployeeManagementRepository>();

    public IEmployeeService EmployeeService
        => _serviceProvider.GetService<IEmployeeService>();

    public EmployeeServiceWithAspNetCoreDIFixture()
    {
        var services = new ServiceCollection();

        services.AddScoped<EmployeeFactory>();
        services.AddScoped<IEmployeeManagementRepository, EmployeeTestDataRepository>();
        services.AddScoped<IEmployeeService, EmployeeService>();

        // build provider
        _serviceProvider = services.BuildServiceProvider();
    }
}