using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace NewsFeed.DataAccess.Entities;

public partial class NewsFeedDbContext : DbContext
{
    public NewsFeedDbContext()
    {
    }

    public NewsFeedDbContext(DbContextOptions<NewsFeedDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<NewsFeedStory> NewsFeedStories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<NewsFeedStory>(entity =>
        {
            entity.ToTable("NewsFeedStory");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.NewsLink).HasMaxLength(500);
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
