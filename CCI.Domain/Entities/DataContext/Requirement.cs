using System.ComponentModel.DataAnnotations.Schema;
using CCI.Common;
using CCI.Domain.Contractors;

namespace CCI.Domain;

[Table("Requirement")]
public class Requirement : IEntity<int>
{
    public int Id { get; set; }
    public int RequirementType { get; set; }
    public Guid Source { get; set; }
    public Guid Owner { get; set; }
    public string Subject { get; set; }
    public string Content { get; set; }
    public RequirementStatus Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime ExpireAt { get; set; }
}
