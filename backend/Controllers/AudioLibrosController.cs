using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BackEnd.Models;
using BackEnd.IServices;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AudioLibrosController : ControllerBase
    {
        private IAudioLibroService _oAudioLibroService;

        public AudioLibrosController(IAudioLibroService oAudioLibroService)
        {
            _oAudioLibroService = oAudioLibroService;
        }

        // GET: api/<AudioLibrosController>
        [HttpGet]
        public IEnumerable<AudioLibros> Get()
        {
            return _oAudioLibroService.Gets();
        }

        // GET api/<AudioLibrosController>/5
        [HttpGet("{id}")]
        public AudioLibros Get(int id)
        {
            return _oAudioLibroService.Get(id);
        }

        // POST api/<AudioLibrosController>
        [HttpPost]
        public void Post([FromBody] AudioLibros oAudioLibro)
        {
            if (ModelState.IsValid) _oAudioLibroService.Add(oAudioLibro);
        }

        // PUT api/<AudioLibrosController>/5
        [HttpPut]
        public void Put([FromBody] AudioLibros oAudioLibro)
        {
            if (ModelState.IsValid) _oAudioLibroService.Update(oAudioLibro);
        }
        // DELETE api/<AudioLibrosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            if (id != 0) _oAudioLibroService.Delete(id);
        }
    }
    }
