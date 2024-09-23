using System.ComponentModel.DataAnnotations;

namespace CCI.Model.DepartmentModels
{
    public class UpdateDepartmentRequest
    {
        [Required]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        [Required]
        public Guid CompanyId { get; set; }
    }
}
