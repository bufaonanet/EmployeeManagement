using AutoMapper;
using EmployeeManagement.Api.Business;
using EmployeeManagement.Api.Controllers;
using EmployeeManagement.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace EmployeeManagement.Tests;

public class DemoInternalEmployeesControllerTests
{    
    [Fact]
    public async Task CreateInternalEmployee_InvalidInput_MustReturnBadRequest()
    {
        // Arrange
        var employeeServiceMock = new Mock<IEmployeeService>();
        var mapperMock = new Mock<IMapper>();
        var demoInternalEmployeesController = new DemoInternalEmployeesController(
            employeeServiceMock.Object, mapperMock.Object);

        var internalEmployeeForCreationDto = new InternalEmployeeForCreationDto();

        demoInternalEmployeesController.ModelState
                .AddModelError("FirstName", "Required");

        // Act 
        var result = await demoInternalEmployeesController
            .CreateInternalEmployee(internalEmployeeForCreationDto);

        // Assert
        var actionResult = Assert
            .IsType<ActionResult<InternalEmployeeDto>>(result);
        Assert.IsType<BadRequestObjectResult>(actionResult.Result);
    }
}
