using CRM.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Domain.Entities
{
    public class Lead
    {
        public Guid Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string JobTitle { get; set; }
        public required string Email { get; set; }
        public required string PhoneNumber { get; set; }
        public Guid CompanyId { get; set; }
        public required Company Company { get; set; } // Many-to-one relationship with Company
        public LeadStatus Status { get; set; }
        [DataType(DataType.Date)]
        public DateTime? FirstContactedOn { get; set; }
    }
}
