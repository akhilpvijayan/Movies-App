using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MoviesAppproject.Models
{
    public partial class MoviesAppContext : DbContext
    {
        public MoviesAppContext()
        {
        }

        public MoviesAppContext(DbContextOptions<MoviesAppContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Movies> Movies { get; set; }
        public virtual DbSet<Reviews> Reviews { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=LAPTOP-SIJ9TPCE;Initial Catalog=MoviesApp;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movies>(entity =>
            {
                entity.HasKey(e => e.MovieId)
                    .HasName("PK__Movies__4BD2941AF6FFC8A2");

                entity.Property(e => e.CoverImage)
                    .HasColumnName("COVER_IMAGE")
                    .IsUnicode(false);

                entity.Property(e => e.Isactive).HasColumnName("ISACTIVE");

                entity.Property(e => e.MovieDesc)
                    .IsRequired()
                    .HasColumnName("MOVIE_DESC")
                    .IsUnicode(false);

                entity.Property(e => e.MovieGenre)
                    .IsRequired()
                    .HasColumnName("MOVIE_GENRE")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MovieLang)
                    .IsRequired()
                    .HasColumnName("MOVIE_LANG")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MovieName)
                    .IsRequired()
                    .HasColumnName("MOVIE_NAME")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MovieRelease)
                    .HasColumnName("MOVIE_RELEASE")
                    .HasColumnType("date");

                entity.Property(e => e.TitleImage)
                    .HasColumnName("TITLE_IMAGE")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Reviews>(entity =>
            {
                entity.HasKey(e => e.Reviewid)
                    .HasName("PK__REVIEWS__DDDCEB4A51A93096");

                entity.ToTable("REVIEWS");

                entity.Property(e => e.Reviewid).HasColumnName("REVIEWID");

                entity.Property(e => e.Movieid).HasColumnName("MOVIEID");

                entity.Property(e => e.Review)
                    .HasColumnName("REVIEW")
                    .IsUnicode(false);

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.Movieid)
                    .HasConstraintName("FK__REVIEWS__MOVIEID__2D27B809");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.Userid)
                    .HasName("PK__USERS__7B9E7F35570CC666");

                entity.ToTable("USERS");

                entity.Property(e => e.Userid).HasColumnName("USERID");

                entity.Property(e => e.Contact)
                    .HasColumnName("CONTACT")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Email)
                    .HasColumnName("EMAIL")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("USERNAME")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Userpassword)
                    .IsRequired()
                    .HasColumnName("USERPASSWORD")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
