using System;
using System.Collections.Generic;

namespace MyShop.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string? ProductName { get; set; }

    public int? ProductQuantity { get; set; }

    public double? ProductPrice { get; set; }

    public int? Active { get; set; }

    public int? CategoryId { get; set; }

    public string? ProductImage { get; set; }
    public string? ProductDescription { get; set; }

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual Category? Category { get; set; }
}
