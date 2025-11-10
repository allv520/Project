using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class WeightLog
{
    public int WeightLog1 { get; set; }

    public int UserId { get; set; }

    public DateOnly LogDate { get; set; }

    public decimal WeightKg { get; set; }

    public virtual User User { get; set; } = null!;
}
