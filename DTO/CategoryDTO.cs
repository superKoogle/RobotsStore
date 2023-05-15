using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DTO;

public partial class CategoryDTO
{
    public int CategoryId { get; set; }

    public string CategoryName { get; set; } = null!;

    //public virtual ICollection<ProductDTO> Products { get; } = new List<ProductDTO>();
}
