using CCI.Common.Enums;
using CCI.Domain.Contractors;

namespace CCI.Domain.Entities;

public class UserDepartment : IEntity<Guid>
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid DepartmentId { get; set; }
    public StatusEnum StatusUser { get; set; }
    public bool IsAdminSystem { get; set; }
    public bool IsAdminDepartment { get; set; }
}
