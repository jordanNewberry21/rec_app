using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using rec_app.Core.Models;
using rec_app.Core.Services;
using rec_app.Api.Resources;
using AutoMapper;

namespace rec_app.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicsController : ControllerBase
    {
        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<Music>>> GetAllMusics()
        {
            var musics = await _musicService.GetAllWithArtist();
            var musicResources = _mapper.Map<IEnumerable<Music>, IEnumerable<MusicResource>>(musics);
            return Ok(musicResources);
        }

        private readonly IMusicService _musicService;
        private readonly IMapper _mapper;

        public MusicsController(IMusicService musicService, IMapper mapper)
        {
            this._mapper = mapper;
            this._musicService = musicService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MusicResource>> GetMusicById(int id)
        {
            var music = await _musicService.GetMusicById(id);
            var musicResource = _mapper.Map<Music, MusicResource>(music);

            return Ok(musicResource);
        }
    }
}

