﻿using System;
using System.Collections.Generic;

namespace MyShop.Models;

public partial class Cart
{
    public int CartId { get; set; }

    public int? UserId { get; set; }

    public int? ProductId { get; set; }

    public int? Quantity { get; set; }

    public DateOnly? CreateAt { get; set; }

    public int? Active { get; set; }

    public virtual Product? Product { get; set; }

    public virtual User? User { get; set; }
}
