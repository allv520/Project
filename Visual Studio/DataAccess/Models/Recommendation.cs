using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class Recommendation
{
    public int RecommendationId { get; set; }

    public int UserId { get; set; }

    public string RecommendationText { get; set; } = null!;

    public string Category { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
