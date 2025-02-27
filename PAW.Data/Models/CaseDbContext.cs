using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PAW.Data.Models;

public partial class CaseDbContext : DbContext
{
    public CaseDbContext()
    {
    }

    public CaseDbContext(DbContextOptions<CaseDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<OfficeRequest> OfficeRequests { get; set; }

    public virtual DbSet<OfficeRequestDetail> OfficeRequestDetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=Badm-Davila;Database=CaseDB;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<OfficeRequest>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__OfficeRe__3213E83F2AC4B07B");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AssignedTo)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("assigned_to");
            entity.Property(e => e.Category)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("category");
            entity.Property(e => e.CompletionDate).HasColumnName("completion_date");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.Priority)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasDefaultValue("Medium")
                .HasColumnName("priority");
            entity.Property(e => e.RequestDate).HasColumnName("request_date");
            entity.Property(e => e.RequestType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("request_type");
            entity.Property(e => e.RequesterEmail)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("requester_email");
            entity.Property(e => e.RequesterName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("requester_name");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("Pending")
                .HasColumnName("status");
        });

        modelBuilder.Entity<OfficeRequestDetail>(entity =>
        {
            entity.HasKey(e => e.DetailId).HasName("PK__OfficeRe__38E9A224AB2BC225");

            entity.Property(e => e.DetailId).HasColumnName("detail_id");
            entity.Property(e => e.AddedBy)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("added_by");
            entity.Property(e => e.AddedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("added_date");
            entity.Property(e => e.DetailText)
                .HasColumnType("text")
                .HasColumnName("detail_text");
            entity.Property(e => e.DetailType)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("detail_type");
            entity.Property(e => e.RequestId).HasColumnName("request_id");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
