using System.ComponentModel.DataAnnotations;

namespace CCI.Model;

public class UpdateRequirementStatusRequest
{
    [Required]
    public int RequirementId { get; set; }
    [Required]
    public RequirementStatus RequirementStatus { get; set; }
}

public enum RequirementStatus
{
    ToDo = 1,
    Processing = 2,
    Done = 3
}
