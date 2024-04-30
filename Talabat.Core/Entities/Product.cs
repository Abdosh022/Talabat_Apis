using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talabat.Core.Entities
{
    public class Product:BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string PictureUrl { get; set; }
        public decimal Price { get; set; }

        public int BrandId { get; set; } // foregin key column:productBrand
        public ProductBrand Brand { get; set; } //navigational property [ONE]

        public int CategoryId { get; set; } // foregin key column:productBrand
        public ProductCategory Category { get; set; } //navigational property [ONE]
    }
}
