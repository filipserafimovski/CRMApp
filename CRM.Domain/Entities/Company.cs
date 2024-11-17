using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM.Domain.Enums;

namespace CRM.Domain.Entities
{
    public class Company
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Location { get; set; }
        public required CompanySize Size { get; set; }
        public ICollection<Lead>? Leads { get; set; } // One-to-many relationship
        public Guid ProductId { get; set; }
        public required Product Product { get; set; } // One-to-many relationship
    }
}
