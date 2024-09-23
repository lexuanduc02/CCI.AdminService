using CCI.Common.Enums;
using CCI.Domain.Contractors;
using System.ComponentModel.DataAnnotations.Schema;

namespace CCI.Domain.Entities
{
    [Table("Department")]
    public class Department : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public StatusEnum Status { get; set; }
        public Guid CompanyId { get; set; }
    }
}
