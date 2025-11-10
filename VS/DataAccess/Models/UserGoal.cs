using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class UserGoal
{
    public int GoalId { get; set; }

    public int UserId { get; set; }

    public DateOnly GoalDate { get; set; }

    public int DailyCaloriesGoal { get; set; }

    public int DailyProteinGoalG { get; set; }

    public int DailyFatGoalG { get; set; }

    public int DailyCarbsGoalG { get; set; }

    public virtual User User { get; set; } = null!;
}
