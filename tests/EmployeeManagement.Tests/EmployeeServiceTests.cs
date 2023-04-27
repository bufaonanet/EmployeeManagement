﻿using EmployeeManagement.Api.Business.Exceptions;
using EmployeeManagement.Api.DataAccess.Entities;
using EmployeeManagement.Tests.Fixture;
using Xunit.Abstractions;

namespace EmployeeManagement.Tests;

[Collection("EmployeeServiceCollection")]
public class EmployeeServiceTests //: IClassFixture<EmployeeServiceFixture>
{
    private readonly EmployeeServiceFixture _employeeServiceFixture;
    private readonly ITestOutputHelper _testOutputHelper;
    public EmployeeServiceTests(
        EmployeeServiceFixture employeeServiceFixture, 
        ITestOutputHelper testOutputHelper)
    {
        _employeeServiceFixture = employeeServiceFixture;
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void CreateInternalEmployee_InternalEmployeeCreated_MustHaveAttendedFirstObligatoryCourse_WithObject()
    {
        // Arrange    
        var obligatoryCourse = _employeeServiceFixture.EmployeeManagementTestDataRepository
                .GetCourse(Guid.Parse("37e03ca7-c730-4351-834c-b66f280cdb01"));

        // Act
        var internalEmployee = _employeeServiceFixture.EmployeeService
            .CreateInternalEmployee("Brooklyn", "Cannon");

        _testOutputHelper.WriteLine($"Employee after Act: " +
              $"{internalEmployee.FirstName} {internalEmployee.LastName}");
        internalEmployee.AttendedCourses
            .ForEach(c => _testOutputHelper.WriteLine($"Attended course: {c.Id} {c.Title}"));

        // Assert
        Assert.Contains(obligatoryCourse, internalEmployee.AttendedCourses);

    }

    [Fact]
    public void CreateInternalEmployee_InternalEmployeeCreated_MustHaveAttendedFirstObligatoryCourse_WithPredicate()
    {
        // Arrange       

        // Act
        var internalEmployee = _employeeServiceFixture.EmployeeService
            .CreateInternalEmployee("Brooklyn", "Cannon");

        // Assert
        Assert.Contains(internalEmployee.AttendedCourses,
            course => course.Id == Guid.Parse("37e03ca7-c730-4351-834c-b66f280cdb01"));
    }

    [Fact]
    public void CreateInternalEmployee_InternalEmployeeCreated_AttendedCoursesMustMatchObligatoryCourses()
    {
        // Arrange       
        var obligatoryCourses = _employeeServiceFixture.EmployeeManagementTestDataRepository
            .GetCourses(
                Guid.Parse("37e03ca7-c730-4351-834c-b66f280cdb01"),
                Guid.Parse("1fd115cf-f44c-4982-86bc-a8fe2e4ff83e"));

        // Act
        var internalEmployee = _employeeServiceFixture.EmployeeService
            .CreateInternalEmployee("Brooklyn", "Cannon");

        // Assert
        Assert.Equal(obligatoryCourses, internalEmployee.AttendedCourses);
    }

    [Fact]
    public void CreateInternalEmployee_InternalEmployeeCreated_AttendedCoursesMustNotBeNew()
    {
        // Arrange       

        // Act
        var internalEmployee = _employeeServiceFixture.EmployeeService
            .CreateInternalEmployee("Brooklyn", "Cannon");

        // Assert
        //foreach (var course in internalEmployee.AttendedCourses)
        //{
        //    Assert.False(course.IsNew);
        //}
        Assert.All(internalEmployee.AttendedCourses,
            course => Assert.False(course.IsNew));
    }

    public async Task CreateInternalEmployee_InternalEmployeeCreated_AttendedCoursesMustMatchObligatoryCourses_Async()
    {
        // Arrange

        var obligatoryCourses = await _employeeServiceFixture.EmployeeManagementTestDataRepository
            .GetCoursesAsync(
                Guid.Parse("37e03ca7-c730-4351-834c-b66f280cdb01"),
                Guid.Parse("1fd115cf-f44c-4982-86bc-a8fe2e4ff83e"));

        // Act
        var internalEmployee = await _employeeServiceFixture.EmployeeService
            .CreateInternalEmployeeAsync(
            "Brooklyn", "Cannon");

        // Assert
        Assert.Equal(obligatoryCourses, internalEmployee.AttendedCourses);
    }

    [Fact]
    public async Task GiveRaise_RaiseBelowMinimumGiven_EmployeeInvalidRaiseExceptionMustBeThrown()
    {
        // Arrange         

        var internalEmployee = new InternalEmployee(
            "Brooklyn", "Cannon", 5, 3000, false, 1);

        // Act & Assert
        await Assert.ThrowsAsync<EmployeeInvalidRaiseException>(
            async () =>
            await _employeeServiceFixture.EmployeeService
                .GiveRaiseAsync(internalEmployee, 50)
            );

    }
}