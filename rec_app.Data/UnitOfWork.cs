using System.Threading.Tasks;
using rec_app.Core;
using rec_app.Core.Repositories;
using rec_app.Data.Repositories;

namespace rec_app.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RecAppDbContext _context;
        private MusicRepository _musicRepository;
        private ArtistRepository _artistRepository;

        public UnitOfWork(RecAppDbContext context)
        {
            this._context = context;
        }

        public IMusicRepository Musics => _musicRepository = _musicRepository ?? new MusicRepository(_context);

        public IArtistRepository Artists => _artistRepository = _artistRepository ?? new ArtistRepository(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
