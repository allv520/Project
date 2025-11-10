using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class FoodItem
{
    public int FoodId { get; set; }

    public string Name { get; set; } = null!;

    public int Calories { get; set; }

    public decimal ProteinG { get; set; }

    public decimal FatG { get; set; }

    public decimal CarbsG { get; set; }

    public int ServingSizeG { get; set; }
}
