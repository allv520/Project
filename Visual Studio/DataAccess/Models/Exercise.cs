using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class Exercise
{
    public int ExerciseId { get; set; }

    public string Name { get; set; } = null!;

    public decimal CaloriesBurnedPerMin { get; set; }

    public virtual ICollection<UserActivityLog> UserActivityLogs { get; set; } = new List<UserActivityLog>();
}
