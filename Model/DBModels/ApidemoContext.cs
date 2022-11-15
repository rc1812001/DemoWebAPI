using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Model.DBModels;

/// <summary>
/// 
/// </summary>
public partial class ApidemoContext : DbContext
{

    /// <summary>
    /// 
    /// </summary>
    public ApidemoContext()
    {
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="options"></param>
    public ApidemoContext(DbContextOptions<ApidemoContext> options)
        : base(options)
    {
    }



    /// <summary>
    /// 
    /// </summary>
    public virtual DbSet<StudentTable> StudentTables { get; set; }



    /// <summary>
    /// 
    /// </summary>
    /// <param name="optionsBuilder"></param>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

       => optionsBuilder.UseSqlServer("Server=(LocalDb)\\MSSQLLocalDB;Database=APIDemo;Trusted_Connection=True;");


    /// <summary>
    /// 
    /// </summary>
    /// <param name="modelBuilder"></param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<StudentTable>(entity =>
        {
            entity.HasKey(e => e.StudentId);

            entity.ToTable("StudentTable");

            entity.Property(e => e.StudentId).HasColumnName("StudentID");
            entity.Property(e => e.City).HasMaxLength(50);
            entity.Property(e => e.MobileNumber).HasMaxLength(50);
            entity.Property(e => e.StudentName).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
