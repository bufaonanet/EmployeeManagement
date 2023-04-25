using EmployeeManagement.Api.DataAccess.Entities;

namespace EmployeeManagement.Api.DataAccess.Services;

public interface IEmployeeManagementRepository
{
    Task<IEnumerable<InternalEmployee>> GetInternalEmployeesAsync();

    InternalEmployee? GetInternalEmployee(Guid employeeId);

    Task<InternalEmployee?> GetInternalEmployeeAsync(Guid employeeId);

    Task<Course?> GetCourseAsync(Guid courseId);

    Course? GetCourse(Guid courseId);

    Task<List<Course>> GetCoursesAsync(params Guid[] courseIds);

    List<Course> GetCourses(params Guid[] courseIds);

    void AddInternalEmployee(InternalEmployee internalEmployee);

    Task SaveChangesAsync();
}
