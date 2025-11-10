using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Models;

public partial class TrackerContext : DbContext
{
    public TrackerContext()
    {
    }

    public TrackerContext(DbContextOptions<TrackerContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DailySummary> DailySummarys { get; set; }

    public virtual DbSet<Exercise> Exercises { get; set; }

    public virtual DbSet<FoodItem> FoodItems { get; set; }

    public virtual DbSet<Recommendation> Recommendations { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserActivityLog> UserActivityLogs { get; set; }

    public virtual DbSet<UserFoodLog> UserFoodLogs { get; set; }

    public virtual DbSet<UserGoal> UserGoals { get; set; }

    public virtual DbSet<WaterIntakeLog> WaterIntakeLogs { get; set; }

    public virtual DbSet<WeightLog> WeightLogs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DailySummary>(entity =>
        {
            entity.HasKey(e => e.SummaryId);

            entity.Property(e => e.SummaryId)
                .ValueGeneratedNever()
                .HasColumnName("SummaryID");
            entity.Property(e => e.TotalCarbsG)
                .HasColumnType("decimal(7, 2)")
                .HasColumnName("TotalCarbs_g");
            entity.Property(e => e.TotalFatG)
                .HasColumnType("decimal(7, 2)")
                .HasColumnName("TotalFat_g");
            entity.Property(e => e.TotalProteinG)
                .HasColumnType("decimal(7, 2)")
                .HasColumnName("TotalProtein_g");
            entity.Property(e => e.TotalWaterMl).HasColumnName("TotalWater_ml");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.DailySummaries)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DailySummarys_User");
        });

        modelBuilder.Entity<Exercise>(entity =>
        {
            entity.ToTable("Exercise");

            entity.Property(e => e.ExerciseId)
                .ValueGeneratedNever()
                .HasColumnName("ExerciseID");
            entity.Property(e => e.CaloriesBurnedPerMin).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<FoodItem>(entity =>
        {
            entity.HasKey(e => e.FoodId);

            entity.ToTable("FoodItem");

            entity.Property(e => e.FoodId)
                .ValueGeneratedNever()
                .HasColumnName("FoodID");
            entity.Property(e => e.CarbsG)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("Carbs_g");
            entity.Property(e => e.FatG)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("Fat_g");
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.ProteinG)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("Protein_g");
            entity.Property(e => e.ServingSizeG).HasColumnName("ServingSize_g");
        });

        modelBuilder.Entity<Recommendation>(entity =>
        {
            entity.ToTable("Recommendation");

            entity.Property(e => e.RecommendationId)
                .ValueGeneratedNever()
                .HasColumnName("RecommendationID");
            entity.Property(e => e.Category).HasMaxLength(50);
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.Recommendations)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Recommendation_User");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.Property(e => e.UserId)
                .ValueGeneratedNever()
                .HasColumnName("UserID");
            entity.Property(e => e.Gender)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.HeightCm)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("Height_cm");
            entity.Property(e => e.PasswordHash).HasMaxLength(50);
            entity.Property(e => e.Username).HasMaxLength(50);
        });

        modelBuilder.Entity<UserActivityLog>(entity =>
        {
            entity.HasKey(e => e.ActivityLogId);

            entity.ToTable("UserActivityLog");

            entity.Property(e => e.ActivityLogId)
                .ValueGeneratedNever()
                .HasColumnName("ActivityLogID");
            entity.Property(e => e.DurationMin).HasColumnName("Duration_min");
            entity.Property(e => e.ExerciseId).HasColumnName("ExerciseID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Exercise).WithMany(p => p.UserActivityLogs)
                .HasForeignKey(d => d.ExerciseId)
                .HasConstraintName("FK_UserActivityLog_Exercise");

            entity.HasOne(d => d.User).WithMany(p => p.UserActivityLogs)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_UserActivityLog_User");
        });

        modelBuilder.Entity<UserFoodLog>(entity =>
        {
            entity.HasKey(e => e.FoodLogId);

            entity.ToTable("UserFoodLog");

            entity.Property(e => e.FoodLogId)
                .ValueGeneratedNever()
                .HasColumnName("FoodLogID");
            entity.Property(e => e.ConsumedAt).HasColumnType("datetime");
            entity.Property(e => e.FoodId).HasColumnName("FoodID");
            entity.Property(e => e.QuantityG).HasColumnName("Quantity_g");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.UserFoodLogs)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserFoodLog_User");
        });

        modelBuilder.Entity<UserGoal>(entity =>
        {
            entity.HasKey(e => e.GoalId);

            entity.Property(e => e.GoalId)
                .ValueGeneratedNever()
                .HasColumnName("GoalID");
            entity.Property(e => e.DailyCarbsGoalG).HasColumnName("DailyCarbsGoal_g");
            entity.Property(e => e.DailyFatGoalG).HasColumnName("DailyFatGoal_g");
            entity.Property(e => e.DailyProteinGoalG).HasColumnName("DailyProteinGoal_g");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.UserGoals)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserGoals_User");
        });

        modelBuilder.Entity<WaterIntakeLog>(entity =>
        {
            entity.HasKey(e => e.WaterLogId);

            entity.ToTable("WaterIntakeLog");

            entity.Property(e => e.WaterLogId)
                .ValueGeneratedNever()
                .HasColumnName("WaterLogID");
            entity.Property(e => e.AmountMl).HasColumnName("Amount_ml");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.WaterIntakeLogs)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WaterIntakeLog_User");
        });

        modelBuilder.Entity<WeightLog>(entity =>
        {
            entity.HasKey(e => e.WeightLog1);

            entity.ToTable("WeightLog");

            entity.Property(e => e.WeightLog1)
                .ValueGeneratedNever()
                .HasColumnName("WeightLog");
            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.WeightKg)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("Weight_kg");

            entity.HasOne(d => d.User).WithMany(p => p.WeightLogs)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WeightLog_User");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
