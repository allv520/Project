using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class UserActivityLog
{
    public int ActivityLogId { get; set; }

    public int? UserId { get; set; }

    public int? ExerciseId { get; set; }

    public DateOnly? ActivityDate { get; set; }

    public int? DurationMin { get; set; }

    public virtual Exercise? Exercise { get; set; }

    public virtual User? User { get; set; }
}
