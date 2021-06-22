using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using rec_app.Core.Models;
using rec_app.Core.Repositories;

namespace rec_app.Data.Repositories
{
    public class ArtistRepository : Repository<Artist>, IArtistRepository
    {
        public ArtistRepository(RecAppDbContext context)
            : base(context)
        { }

        public async Task<IEnumerable<Artist>> GetAllWithMusicAsync()
        {
            return await RecAppDbContext.Artists
                .Include(a => a.Musics)
                .ToListAsync();
        }

        public Task<Artist> GetWithMusicsByIdAsync(int id)
        {
            return RecAppDbContext.Artists
                .Include(a => a.Musics)
                .SingleOrDefaultAsync(a => a.Id == id);
        }

        private RecAppDbContext RecAppDbContext
        {
            get { return Context as RecAppDbContext; }
        }
    }
}