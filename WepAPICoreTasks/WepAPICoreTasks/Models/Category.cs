using System;
using System.Collections.Generic;

namespace WepAPICoreTasks.Models;

public partial class Category
{
    public int CategoryId { get; set; }

    public string? CategoryName { get; set; }

    public string? CategoryImage { get; set; }
}
