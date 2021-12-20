using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NLayerProject.WEB.DTOs
{
    public class CategoryDto
    {
        [JsonPropertyName("id")]
        public int Id  { get; set; }
        [Required(ErrorMessage ="Bu Alan Zorunludur.")]
        [JsonPropertyName("name")]
        public string Name { get; set; }

    }
}
