using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class WaterIntakeLog
{
    public int WaterLogId { get; set; }

    public int UserId { get; set; }

    public DateOnly LogDate { get; set; }

    public int AmountMl { get; set; }

    public virtual User User { get; set; } = null!;
}
