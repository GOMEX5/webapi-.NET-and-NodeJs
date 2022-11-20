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
    public class LibrosController : ControllerBase
    {
        private ILibroService _oLibroService;

        public LibrosController(ILibroService oLibroService)
        {
            _oLibroService = oLibroService;
        }

        // GET: api/<LibrosController>
        [HttpGet]
        public IEnumerable<Libros> Get()
        {
            return _oLibroService.Gets();
        }

        // GET api/<LibrosController>/5
        [HttpGet("{id}", Name = "Get1")]
        public Libros    Get(int id)
        {
            return _oLibroService.Get(id);
        }

        // POST api/<LibrosController>
        [HttpPost]
        public void Post([FromBody] Libros oLibro)
        {
            if (ModelState.IsValid) _oLibroService.Add(oLibro);
        }

        // PUT api/<LibrosController>/5
        [HttpPut]
        public void Put([FromBody] Libros oLibro)
        {
            if (ModelState.IsValid) _oLibroService.Update(oLibro);
        }
        // DELETE api/<LibrosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            if (id != 0) _oLibroService.Delete(id);
        }
    }
    }
