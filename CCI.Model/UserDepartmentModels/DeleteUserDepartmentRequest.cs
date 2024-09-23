using System.ComponentModel.DataAnnotations;

namespace CCI.Model;

public class DeleteUserDepartmentRequest
{
    [Required]
    public Guid UserId { get; set; }
    [Required]
    public Guid DepartmentId { get; set; }
}
