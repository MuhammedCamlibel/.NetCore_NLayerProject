﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NLayerProject.WEB.DTOs
{
    public class CategoryWithProductsDto : CategoryDto
    {

        public IEnumerable<ProductDto> Products { get; set; }


    }
}
