namespace CCI.Model.DepartmentModels
{
    public class DepartmentModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int Status { get; set; }
        public Guid CompanyId { get; set; }
        public string CompanyName { get; set; }
    }
}
