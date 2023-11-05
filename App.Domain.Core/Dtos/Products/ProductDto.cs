using App.Domain.Core.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Dtos.Products
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public int CategoryId { get; set; }

        public string? Description { get; set; }

        public double? BasePrice { get; set; }

        public bool IsDeleted { get; set; }
        public virtual ICollection<BoothProductDto> BoothProducts { get; set; } = new List<BoothProductDto>();

        public virtual CategoryDto Category { get; set; } = null!;

        public virtual ICollection<ProductAttributeValueDto> ProductAttributeValues { get; set; } = new List<ProductAttributeValueDto>();
    }
}
