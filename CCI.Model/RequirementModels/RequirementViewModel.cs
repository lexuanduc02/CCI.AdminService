namespace CCI.Model;

public class RequirementViewModel
{
    public int Id { get; set; }
    public int RequirementType { get; set; }
    public string RequirementTypeName { get; set; }
    public Guid Source { get; set; }
    public string SourceName { get; set; }
    public Guid Owner { get; set; }
    public string Subject { get; set; }
    public string Content { get; set; }
    public int Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime ExpireAt { get; set; }
}
