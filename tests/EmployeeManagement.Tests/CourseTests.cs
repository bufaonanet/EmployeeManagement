using EmployeeManagement.Api.DataAccess.Entities;

namespace EmployeeManagement.Tests;

public class CourseTests
{
    [Fact]
    public void Contructor_ConstructCourser_IsNewMustBeTrue()
    {
        //Act
        var course = new Course("Disaster Management 101");

        //Assert
        Assert.True(course.IsNew);
    }
}