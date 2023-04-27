using EmployeeManagement.Api.Business;
using EmployeeManagement.Tests.Services;

namespace EmployeeManagement.Tests.Fixture;

public class EmployeeServiceFixture : IDisposable
{
    public EmployeeTestDataRepository EmployeeManagementTestDataRepository { get; }
    public EmployeeService EmployeeService { get; }

    public EmployeeServiceFixture()
    {
        EmployeeManagementTestDataRepository =
            new EmployeeTestDataRepository();

        EmployeeService =
            new EmployeeService(EmployeeManagementTestDataRepository, new EmployeeFactory());
    }

    public void Dispose()
    {
        //Clean up the setup code, if required
    }
}