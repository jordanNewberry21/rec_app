﻿using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using rec_app.Core.Models;
using rec_app.Core.Services;
using rec_app.Api.Resources;
using rec_app.Api.Validators;
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

        [HttpPost("")]
        public async Task<ActionResult<MusicResource>> CreateMusic([FromBody] SaveMusicResource saveMusicResource)
        {
            var validator = new SaveMusicResourceValidator();
            var validationResult = await validator.ValidateAsync(saveMusicResource);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var musicToCreate = _mapper.Map<SaveMusicResource, Music>(saveMusicResource);

            var newMusic = await _musicService.CreateMusic(musicToCreate);

            var music = await _musicService.GetMusicById(newMusic.Id);

            var musicResource = _mapper.Map<Music, MusicResource>(music);

            return Ok(musicResource);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<MusicResource>> UpdateMusic(int id, [FromBody] SaveMusicResource saveMusicResource)
        {
            var validator = new SaveMusicResourceValidator();
            var validationResult = await validator.ValidateAsync(saveMusicResource);

            var requestIsInvalid = id == 0 || !validationResult.IsValid;

            if (requestIsInvalid)
                return BadRequest(validationResult.Errors);

            var musicToUpdate = await _musicService.GetMusicById(id);

            if (musicToUpdate == null)
                return NotFound();

            var music = _mapper.Map<SaveMusicResource, Music>(saveMusicResource);

            await _musicService.UpdateMusic(musicToUpdate, music);

            var updatedMusic = await _musicService.GetMusicById(id);
            var updatedMusicResource = _mapper.Map<Music, MusicResource>(updatedMusic);

            return Ok(updatedMusicResource);
        }
    }
}

