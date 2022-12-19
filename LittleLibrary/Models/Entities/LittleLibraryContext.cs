using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace LittleLibrary.Models.Entities;

public partial class LittleLibraryContext : DbContext
{
    public LittleLibraryContext(DbContextOptions<LittleLibraryContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Book> Books { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Books__3214EC07288B87D5");

            entity.Property(e => e.Author).HasMaxLength(50);
            entity.Property(e => e.Image).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
