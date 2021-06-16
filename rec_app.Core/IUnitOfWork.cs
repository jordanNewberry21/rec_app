using System;
using System.Threading.Tasks;
using rec_app.Core.Repositories;

namespace rec_app.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IMusicRepository Musics { get; }
        IArtistRepository Artists { get; }
        Task<int> CommitAsync();
    }
}
