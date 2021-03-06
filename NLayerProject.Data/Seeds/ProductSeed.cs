using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayerProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerProject.Data.Seeds
{
    public class ProductSeed : IEntityTypeConfiguration<Product>
    {

        private readonly int[] _ids;

        public ProductSeed(int[] ids)
        {
            _ids = ids;
        }

        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                 new Product { Id =1,Name="Pilot Kalem",Price=12.50m,Stock=50,CategoryId=_ids[0]},
                 new Product { Id = 2, Name = "Kurşun Kalem", Price = 20m, Stock = 50, CategoryId = _ids[0] },
                 new Product { Id = 3, Name = "Tükenmez Kalem", Price = 30m, Stock = 50, CategoryId = _ids[0] },
                 new Product { Id = 4, Name = "Küçük Boy Defter", Price = 40.50m, Stock = 50, CategoryId = _ids[1] },
                 new Product { Id = 5, Name = "Orta Boy Defter", Price = 50.50m, Stock = 50, CategoryId = _ids[1] },
                 new Product { Id = 6, Name = "Büyük Boy Defter", Price = 55.50m, Stock = 50, CategoryId = _ids[1] }
                );
        }
    }
}
