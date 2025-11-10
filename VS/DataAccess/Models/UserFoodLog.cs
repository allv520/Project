using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class UserFoodLog
{
    public int FoodLogId { get; set; }

    public int UserId { get; set; }

    public int FoodId { get; set; }

    public DateTime ConsumedAt { get; set; }

    public int QuantityG { get; set; }

    public virtual User User { get; set; } = null!;
}
