using System;
using System.Collections.Generic;

namespace MyShop.Models;

public partial class User
{
    public int UserId { get; set; }

    public string? UserName { get; set; }

    public string? UserEmail { get; set; }

    public int? UserRole { get; set; }

    public string? UserPassword { get; set; }

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();
}
