using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SongsReview.Entities.Entities;

public partial class SongsReviewContext : DbContext
{
    public SongsReviewContext()
    {
    }

    public SongsReviewContext(DbContextOptions<SongsReviewContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Album> Albums { get; set; }

    public virtual DbSet<Artist> Artists { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<Song> Songs { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=SongsReview;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Album>(entity =>
        {
            entity.HasKey(e => e.AlbumId).HasName("PK__Album__97B4BE378E4DD786");

            entity.ToTable("Album");

            entity.Property(e => e.CoverArtUrl)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Artist).WithMany(p => p.Albums)
                .HasForeignKey(d => d.ArtistId)
                .HasConstraintName("FK__Album__ArtistId__29572725");
        });

        modelBuilder.Entity<Artist>(entity =>
        {
            entity.HasKey(e => e.ArtistId).HasName("PK__Artist__25706B5069617701");

            entity.ToTable("Artist");

            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.PhotoUrl)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasKey(e => e.ReviewId).HasName("PK__Review__74BC79CE49F64630");

            entity.ToTable("Review");

            entity.Property(e => e.Review1)
                .HasColumnType("text")
                .HasColumnName("Review");
            entity.Property(e => e.Username)
                .HasMaxLength(16)
                .IsUnicode(false);

            entity.HasOne(d => d.Song).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.SongId)
                .HasConstraintName("FK__Review__SongId__38996AB5");

            entity.HasOne(d => d.UsernameNavigation).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.Username)
                .HasConstraintName("FK__Review__Username__37A5467C");
        });

        modelBuilder.Entity<Song>(entity =>
        {
            entity.HasKey(e => e.SongId).HasName("PK__Song__12E3D697DD3735AA");

            entity.ToTable("Song");

            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Album).WithMany(p => p.Songs)
                .HasForeignKey(d => d.AlbumId)
                .HasConstraintName("FK__Song__AlbumId__2F10007B");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Username).HasName("PK__User__536C85E5A65B89CC");

            entity.ToTable("User");

            entity.Property(e => e.Username)
                .HasMaxLength(16)
                .IsUnicode(false);
            entity.Property(e => e.PhotoUrl)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
