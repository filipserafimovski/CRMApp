using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Domain.Entities
{
    public class Sale
    {
        public Guid Id { get; set; }
        [DataType(DataType.Date)]
        public required DateTime SaleDate { get; set; }
        public required int Quantity { get; set; }
        public required int Discount { get; set; }
        public required decimal Revenue { get; set; }

        // Navigation properties
        public Guid UserId { get; set; }
        public Guid LeadId { get; set; }
        public required Lead Lead { get; set; }
        public Guid ProductId { get; set; }
        public required Product Product { get; set; }
    }
}
