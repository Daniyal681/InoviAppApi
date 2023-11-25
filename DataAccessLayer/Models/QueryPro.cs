using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Inovi.DataAccessLayer.Models;

public partial class QueryPro : DbContext
{
    public QueryPro()
    {
    }

    public QueryPro(DbContextOptions<QueryPro> options)
        : base(options)
    {
    }

    public virtual DbSet<Query> Queries { get; set; }

    public virtual DbSet<QueryStatus> QueryStatuses { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-URSATJE;Database=QueryPro;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Query>(entity =>
        {
            entity.ToTable("Query");

            entity.Property(e => e.QueryId).HasColumnName("query_id");
            entity.Property(e => e.AttachmentLink).HasColumnName("attachment_link");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CreatedOn)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("created_on");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.IsActive).HasColumnName("is_active");
            entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");
            entity.Property(e => e.ModifiedOn)
                .HasColumnType("datetime")
                .HasColumnName("modified_on");
            entity.Property(e => e.Remarks).HasColumnName("remarks");
            entity.Property(e => e.RemarksBy).HasColumnName("remarks_by");
            entity.Property(e => e.RemarksOn)
                .HasColumnType("datetime")
                .HasColumnName("remarks_on");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .HasColumnName("title");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Queries)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Query_User");
        });

        modelBuilder.Entity<QueryStatus>(entity =>
        {
            entity.ToTable("QueryStatus");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CreatedOn)
                .HasColumnType("datetime")
                .HasColumnName("created_on");
            entity.Property(e => e.IsActive).HasColumnName("is_active");
            entity.Property(e => e.QueryId).HasColumnName("query_id");
            entity.Property(e => e.StatusId).HasColumnName("status_id");

            entity.HasOne(d => d.Query).WithMany(p => p.QueryStatuses)
                .HasForeignKey(d => d.QueryId)
                .HasConstraintName("FK_QueryStatus_Query");

            entity.HasOne(d => d.Status).WithMany(p => p.QueryStatuses)
                .HasForeignKey(d => d.StatusId)
                .HasConstraintName("FK_QueryStatus_Status");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.ToTable("Status");

            entity.Property(e => e.StatusId).HasColumnName("status_id");
            entity.Property(e => e.IsActive).HasColumnName("is_active");
            entity.Property(e => e.Status1)
                .HasMaxLength(50)
                .HasColumnName("status");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CreatedOn)
                .HasColumnType("datetime")
                .HasColumnName("created_on");
            entity.Property(e => e.EmailAddress)
                .HasMaxLength(50)
                .HasColumnName("email_address");
            entity.Property(e => e.FName)
                .HasMaxLength(50)
                .HasColumnName("f_name");
            entity.Property(e => e.IsActive).HasColumnName("is_active");
            entity.Property(e => e.LName)
                .HasMaxLength(50)
                .HasColumnName("l_name");
            entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");
            entity.Property(e => e.ModifiedOn)
                .HasColumnType("datetime")
                .HasColumnName("modified_on");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .HasColumnName("password");
            entity.Property(e => e.UserRoleId).HasColumnName("user_role_id");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .HasColumnName("username");

            entity.HasOne(d => d.UserRole).WithMany(p => p.Users)
                .HasForeignKey(d => d.UserRoleId)
                .HasConstraintName("FK_User_UserRole");
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.ToTable("UserRole");

            entity.Property(e => e.UserRoleId).HasColumnName("user_role_id");
            entity.Property(e => e.IsActive).HasColumnName("is_active");
            entity.Property(e => e.Role)
                .HasMaxLength(50)
                .HasColumnName("role");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
