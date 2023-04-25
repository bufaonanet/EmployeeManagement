using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Api.DataAccess.Entities;

public class Course
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public bool IsNew { get; set; } = true;
    public string Title { get; set; }
    public List<InternalEmployee> EmployeesThatAttended { get; set; } = new List<InternalEmployee>();

    public Course(string title)
    {
        Title = title;
    }
}