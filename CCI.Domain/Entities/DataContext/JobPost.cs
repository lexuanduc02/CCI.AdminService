using CCI.Domain.Contractors;

namespace CCI.Domain.Entities;

public class JobPost : IEntity<Guid>
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Salary { get; set; }
    public Guid IdJobType { get; set; }
    public Guid IdUser { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime ExpiredAt { get; set; }
    public int IsActive { get; set; }
}
