using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NLayerProject.API.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "{0} alan boş geçilemez")]
        public string Name { get; set; }
        [Range(1,int.MaxValue,ErrorMessage ="{0} alan 1 den büyük olmak zorundadır")]
        public int Stock { get; set; }
        [Range(1,double.MaxValue,ErrorMessage = "{0} alan 1 den büyük olmak zorundadır")]
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        
    }
}
