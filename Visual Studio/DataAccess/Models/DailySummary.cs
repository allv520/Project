using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class DailySummary
{
    public int SummaryId { get; set; }

    public int UserId { get; set; }

    public DateOnly SummaryDate { get; set; }

    public int TotalCaloriesConsumed { get; set; }

    public int TotalCaloriesBurned { get; set; }

    public int TotalWaterMl { get; set; }

    public decimal TotalProteinG { get; set; }

    public decimal TotalFatG { get; set; }

    public decimal TotalCarbsG { get; set; }

    public virtual User User { get; set; } = null!;
}
