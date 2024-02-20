using System;
using System.Collections.Generic;
using LSDA.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace LSDA.Database;

public partial class DatabaseContext : DbContext
{
    public DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=DESKTOP-NR8DVE4\\SQLEXPRESS;Database=GolosDetu;Trusted_Connection=True;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Participant>(entity =>
        {
            entity.ToTable("Participant");

            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Patronymic).HasMaxLength(100);
            entity.Property(e => e.Surname).HasMaxLength(100);

            entity.HasOne(d => d.Party).WithMany(p => p.Participants)
                .HasForeignKey(d => d.PartyId)
                .HasConstraintName("FK_Participant_Party");
        });

        modelBuilder.Entity<Party>(entity =>
        {
            entity.ToTable("Party");

            entity.Property(e => e.Title).HasMaxLength(100);
        });

        modelBuilder.Entity<Result>(entity =>
        {
            entity.HasKey(e => e.ParticipantId);

            entity.ToTable("Result");

            entity.Property(e => e.ParticipantId).ValueGeneratedNever();

            entity.HasOne(d => d.Participant).WithOne(p => p.Result)
                .HasForeignKey<Result>(d => d.ParticipantId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Result_Participant");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.ToTable("Role");

            entity.Property(e => e.Title).HasMaxLength(100);
        });


    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
