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
    public class UsuariosController : ControllerBase
    {
        private IUsuarioService _oUsuarioService;

        public UsuariosController(IUsuarioService oUsuarioService)
        {
            _oUsuarioService = oUsuarioService;
        }

        // GET: api/<UsuariosController>
        [HttpGet]
        public IEnumerable<Usuarios> Get()
        {
            return _oUsuarioService.Gets();
        }

        // GET api/<UsuariosController>/5
        [HttpGet("{id}", Name = "Get")]
        public Usuarios Get(int id)
        {
            return _oUsuarioService.Get(id);
        }

        [HttpGet("[action]/{correo}", Name = "GetCorreo")]
        public Usuarios GetCorreo(string correo)
        {
            return _oUsuarioService.GetCorreo(correo);
        }
        // POST api/<UsuariosController>
        [HttpPost]
        public void Post([FromBody] Usuarios oUsuario)
        {
            if (ModelState.IsValid) _oUsuarioService.Add(oUsuario);
        }

        // PUT api/<UsuariosController>/5
        [HttpPut]
        public void Put([FromBody] Usuarios oUsuario)
        {
            if (ModelState.IsValid) _oUsuarioService.Update(oUsuario);
        }
        // DELETE api/<UsuariosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            if (id != 0) _oUsuarioService.Delete(id);
        }
    }
    }
