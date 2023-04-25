using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Api.DataAccess.Entities;

/// <summary>
/// Base class for all employees     
/// </summary>
public abstract class Employee
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string FirstName { get; set; }

    [Required]
    [MaxLength(100)]
    public string LastName { get; set; }

    [NotMapped]
    public string FullName
    {
        get { return $"{FirstName} {LastName}"; }
    }

    public Employee(
           string firstName,
           string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }
}