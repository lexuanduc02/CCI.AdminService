using System.ComponentModel.DataAnnotations.Schema;
using CCI.Common.Enums;
using CCI.Domain.Contractors;

namespace CCI.Domain;

[Table("RequirementType")]
public class RequirementType : IEntity<int>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public StatusEnum Status { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime CreatedAt { get; set; }
}
