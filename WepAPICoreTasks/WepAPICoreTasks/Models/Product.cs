﻿using System;
using System.Collections.Generic;

namespace WepAPICoreTasks.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string? ProductName { get; set; }

    public string? Description { get; set; }

    public string? Price { get; set; }

    public string? CategoryId { get; set; }

    public string? ProductImage { get; set; }
}
