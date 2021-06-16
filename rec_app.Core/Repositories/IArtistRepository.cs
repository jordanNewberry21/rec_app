using System.Collections.Generic;
using System.Threading.Tasks;
using rec_app.Core.Models;

namespace rec_app.Core.Repositories
{
    public interface IArtistRepository : IRepository<Artist>
    {
        Task<IEnumerable<Artist>> GetAllWithMusicAsync();
        Task<Artist> GetWithMusicsByIdAsync(int id);
    }
}
