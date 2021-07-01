using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using rec_app.Core.Models;
using rec_app.Core.Services;
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
            return Ok(musics);
        }
            private readonly IMusicService _musicService;

            public MusicsController(IMusicService musicService, IMapper mapper)
            {
                this._musicService = musicService;
            }
        }
    }

