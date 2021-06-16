using System.Collections.Generic;
using System.Threading.Tasks;
using rec_app.Core.Models;

namespace rec_app.Core.Repositories
{
    public interface IMusicRepository : IRepository<Music>
    {
        Task<IEnumerable<Music>> GetAllWithArtistAsync();
        Task<Music> GetWithArtistByIdAsync(int id);
        Task<IEnumerable<Music>> GetAllWithArtistByArtistIdAsync(int ArtistId);
    }
}
