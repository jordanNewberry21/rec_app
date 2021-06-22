using Microsoft.EntityFrameworkCore;
using rec_app.Core.Models;
using rec_app.Data.Configurations;

namespace rec_app.Data
{
    public class RecAppDbContext : DbContext
    {
        public DbSet<Music> Musics { get; set; }
        public DbSet<Artist> Artists { get; set; }

        public RecAppDbContext(DbContextOptions<RecAppDbContext> options)
            : base(options)
        {   }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .ApplyConfiguration(new MusicConfiguration());

            builder
                .ApplyConfiguration(new ArtistConfiguration());
        }
    }
}
