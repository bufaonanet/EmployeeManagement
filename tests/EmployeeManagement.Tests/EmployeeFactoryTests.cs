using EmployeeManagement.Api.Business;
using EmployeeManagement.Api.DataAccess.Entities;

namespace EmployeeManagement.Tests;

public class EmployeeFactoryTests
{
    private EmployeeFactory _employeeFactory;

    public EmployeeFactoryTests()
    {
         _employeeFactory = new EmployeeFactory();
    }

    [Fact]
    public void CreateEmployee_ConstructInternalEmploy_SalaryMustBe2500()
    {
        var emploee = (InternalEmployee)_employeeFactory
            .CreateEmployee("Douglas", "Souto");

        Assert.Equal(2500, emploee.Salary);
    }

    [Fact]
    public void CreateEmployee_ConstructInternalEmployee_SalaryMustBeBetween2500And3500()
    {
        // Arrange        

        // Act
        var employee = (InternalEmployee)_employeeFactory.CreateEmployee("Kevin", "Dockx");

        // Assert
        Assert.True(employee.Salary >= 2500 && employee.Salary <= 3500,
            "Salary not in acceptable range.");
    }

    [Fact]
    [Trait("Category", "EmployeeFactory_CreateEmployee_Salary")]
    public void CreateEmployee_ConstructInternalEmployee_SalaryMustBeBetween2500And3500_Alternative()
    {
        // Arrange       

        // Act
        var employee = (InternalEmployee)_employeeFactory.CreateEmployee("Kevin", "Dockx");

        // Assert
        Assert.True(employee.Salary >= 2500);
        Assert.True(employee.Salary <= 3500);
    }

    [Fact]
    [Trait("Category", "EmployeeFactory_CreateEmployee_Salary")]
    public void CreateEmployee_ConstructInternalEmployee_SalaryMustBeBetween2500And3500_AlternativeWithInRange()
    {
        // Arrange       

        // Act
        var employee = (InternalEmployee)_employeeFactory.CreateEmployee("Kevin", "Dockx");

        // Assert
        Assert.InRange(employee.Salary, 2500, 3500);
    }

    [Fact(Skip ="Skip this test demo")]
    [Trait("Category", "EmployeeFactory_CreateEmployee_Salary")]
    public void CreateEmployee_ConstructInternalEmployee_SalaryMustBe2500_PrecisionExample()
    {
        // Arrange       

        // Act
        var employee = (InternalEmployee)_employeeFactory.CreateEmployee("Kevin", "Dockx");
        employee.Salary = 2500.123m;

        // Assert
        Assert.Equal(2500, employee.Salary, 0);
    }

    [Fact]
    [Trait("Category", "EmployeeFactory_CreateEmployee_ReturnType")]
    public void CreateEmployee_IsExternalIsTrue_ReturnTypeMustBeExternalEmployee()
    {
        // Arrange       

        // Act
        var employee = _employeeFactory.CreateEmployee("Kevin", "Dockx", "Marvin", true);

        // Assert
        Assert.IsType<ExternalEmployee>(employee);
        //Assert.IsAssignableFrom<Employee>(employee);
    }

}