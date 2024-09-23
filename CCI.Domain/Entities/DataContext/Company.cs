using CCI.Common.Enums;
using CCI.Domain.Contractors;
using System.ComponentModel.DataAnnotations.Schema;

namespace CCI.Domain.Entities
{
    [Table("Company")]
    public class Company : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Information { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public int NumberOfStaff { get; set; }
        public DateTime DateFounded { get; set; }
        public StatusEnum Status { get; set; }
        public Guid CompanyImageId { get; set; }
    }
}
