using System.ComponentModel.DataAnnotations;

namespace CCI.Model;

public class CreateUserDepartmentRequest
{
    [Required]
    public Guid UserId { get; set; }
    [Required]
    public Guid DepartmentId { get; set; }
    public StatusEnum StatusUser { get; set; }
    public bool IsAdminSystem { get; set; }
    public bool IsAdminDepartment { get; set; }
}

public enum StatusEnum
{
    Active,
    Inactive
}
