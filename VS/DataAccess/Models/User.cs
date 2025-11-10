using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class User
{
    public int UserId { get; set; }

    public string PasswordHash { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Username { get; set; } = null!;

    public DateOnly DateOfBirth { get; set; }

    public string Gender { get; set; } = null!;

    public decimal HeightCm { get; set; }

    public virtual ICollection<DailySummary> DailySummaries { get; set; } = new List<DailySummary>();

    public virtual ICollection<Recommendation> Recommendations { get; set; } = new List<Recommendation>();

    public virtual ICollection<UserActivityLog> UserActivityLogs { get; set; } = new List<UserActivityLog>();

    public virtual ICollection<UserFoodLog> UserFoodLogs { get; set; } = new List<UserFoodLog>();

    public virtual ICollection<UserGoal> UserGoals { get; set; } = new List<UserGoal>();

    public virtual ICollection<WaterIntakeLog> WaterIntakeLogs { get; set; } = new List<WaterIntakeLog>();

    public virtual ICollection<WeightLog> WeightLogs { get; set; } = new List<WeightLog>();
}
