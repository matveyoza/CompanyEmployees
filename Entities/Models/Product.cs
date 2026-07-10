using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Product
    {
        [Column("ProductId")]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public Guid CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
