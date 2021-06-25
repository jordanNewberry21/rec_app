using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace rec_app.Data
{
    public partial class rec_appv1Context : DbContext
    {
        public rec_appv1Context()
        {
        }

        public rec_appv1Context(DbContextOptions<rec_appv1Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Cuisine> Cuisines { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<License> Licenses { get; set; }
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<Rating> Ratings { get; set; }
        public virtual DbSet<Restaurant> Restaurants { get; set; }
        public virtual DbSet<Store> Stores { get; set; }
        public virtual DbSet<StoreType> StoreTypes { get; set; }
        public virtual DbSet<TvShow> TvShows { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;Database=rec_appv1;Username=jordannewberry;Password=ILov3C4ll3y");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "C");

            modelBuilder.Entity<Book>(entity =>
            {
                entity.ToTable("books");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Genre).HasColumnName("genre");

                entity.Property(e => e.Rating).HasColumnName("rating");

                entity.Property(e => e.Read)
                    .HasColumnName("read")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.RecommendedBy)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("recommended_by");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("title");

                entity.Property(e => e.WouldRecommend).HasColumnName("would_recommend");

                entity.HasOne(d => d.GenreNavigation)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.Genre)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("books_genre_fkey");

                entity.HasOne(d => d.RatingNavigation)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.Rating)
                    .HasConstraintName("books_rating_fkey");
            });

            modelBuilder.Entity<Cuisine>(entity =>
            {
                entity.ToTable("cuisine");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Type)
                    .HasColumnType("character varying")
                    .HasColumnName("type");
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.ToTable("genres");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasColumnType("character varying")
                    .HasColumnName("name");
            });

            modelBuilder.Entity<License>(entity =>
            {
                entity.ToTable("licenses");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.License1)
                    .HasColumnType("character varying")
                    .HasColumnName("license");
            });

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.ToTable("movies");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Genre).HasColumnName("genre");

                entity.Property(e => e.Rating).HasColumnName("rating");

                entity.Property(e => e.RecommendedBy)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("recommended_by");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("title");

                entity.Property(e => e.Watched)
                    .HasColumnName("watched")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.WouldRecommend).HasColumnName("would_recommend");

                entity.HasOne(d => d.GenreNavigation)
                    .WithMany(p => p.Movies)
                    .HasForeignKey(d => d.Genre)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("movies_genre_fkey");

                entity.HasOne(d => d.RatingNavigation)
                    .WithMany(p => p.Movies)
                    .HasForeignKey(d => d.Rating)
                    .HasConstraintName("movies_rating_fkey");
            });

            modelBuilder.Entity<Rating>(entity =>
            {
                entity.ToTable("ratings");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.RatingNumber).HasColumnName("rating_number");
            });

            modelBuilder.Entity<Restaurant>(entity =>
            {
                entity.ToTable("restaurants");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CuisineType).HasColumnName("cuisine_type");

                entity.Property(e => e.Delivery).HasColumnName("delivery");

                entity.Property(e => e.Drinks).HasColumnName("drinks");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("name");

                entity.Property(e => e.Rating).HasColumnName("rating");

                entity.Property(e => e.RecommendedBy)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("recommended_by");

                entity.Property(e => e.Visited)
                    .HasColumnName("visited")
                    .HasDefaultValueSql("false");

                entity.HasOne(d => d.CuisineTypeNavigation)
                    .WithMany(p => p.Restaurants)
                    .HasForeignKey(d => d.CuisineType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("restaurants_cuisine_type_fkey");

                entity.HasOne(d => d.DrinksNavigation)
                    .WithMany(p => p.Restaurants)
                    .HasForeignKey(d => d.Drinks)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("restaurants_drinks_fkey");

                entity.HasOne(d => d.RatingNavigation)
                    .WithMany(p => p.Restaurants)
                    .HasForeignKey(d => d.Rating)
                    .HasConstraintName("restaurants_rating_fkey");
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.ToTable("stores");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("name");

                entity.Property(e => e.Rating).HasColumnName("rating");

                entity.Property(e => e.RecommendedBy)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("recommended_by");

                entity.Property(e => e.StoreType).HasColumnName("store_type");

                entity.Property(e => e.Visited)
                    .HasColumnName("visited")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.WouldRecommend).HasColumnName("would_recommend");

                entity.HasOne(d => d.RatingNavigation)
                    .WithMany(p => p.Stores)
                    .HasForeignKey(d => d.Rating)
                    .HasConstraintName("stores_rating_fkey");

                entity.HasOne(d => d.StoreTypeNavigation)
                    .WithMany(p => p.Stores)
                    .HasForeignKey(d => d.StoreType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("stores_store_type_fkey");
            });

            modelBuilder.Entity<StoreType>(entity =>
            {
                entity.ToTable("store_types");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Type)
                    .HasColumnType("character varying")
                    .HasColumnName("type");
            });

            modelBuilder.Entity<TvShow>(entity =>
            {
                entity.ToTable("tv_shows");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Genre).HasColumnName("genre");

                entity.Property(e => e.Rating).HasColumnName("rating");

                entity.Property(e => e.RecommendedBy)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("recommended_by");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("title");

                entity.Property(e => e.Watched)
                    .HasColumnName("watched")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.WouldRecommend).HasColumnName("would_recommend");

                entity.HasOne(d => d.GenreNavigation)
                    .WithMany(p => p.TvShows)
                    .HasForeignKey(d => d.Genre)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tv_shows_genre_fkey");

                entity.HasOne(d => d.RatingNavigation)
                    .WithMany(p => p.TvShows)
                    .HasForeignKey(d => d.Rating)
                    .HasConstraintName("tv_shows_rating_fkey");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
