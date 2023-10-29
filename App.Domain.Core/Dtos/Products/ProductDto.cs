using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Dtos.Products
{
    public class ProductDto
    {
        public string Name { get; set; } = null!;

        public int CategoryId { get; set; }

        public string? Description { get; set; }

        public double? BasePrice { get; set; }

        public bool IsDeleted { get; set; }
    }
}
