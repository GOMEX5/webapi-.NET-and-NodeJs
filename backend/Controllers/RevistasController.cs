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
    public class RevistasController : ControllerBase
    {
        private IRevistaService _oRevistaService;

        public RevistasController(IRevistaService oRevistaService)
        {
            _oRevistaService = oRevistaService;
        }

        // GET: api/<RevistasController>
        [HttpGet]
        public IEnumerable<Revistas> Get()
        {
            return _oRevistaService.Gets();
        }

        // GET api/<RevistasController>/5
        [HttpGet("{id}")]
        public Revistas Get(int id)
        {
            return _oRevistaService.Get(id);
        }

        // POST api/<RevistasController>
        [HttpPost]
        public void Post([FromBody] Revistas oRevista)
        {
            if (ModelState.IsValid) _oRevistaService.Add(oRevista);
        }

        // PUT api/<RevistasController>/5
        [HttpPut]
        public void Put([FromBody] Revistas oRevista)
        {
            if (ModelState.IsValid) _oRevistaService.Update(oRevista);
        }
        // DELETE api/<RevistasController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            if (id != 0) _oRevistaService.Delete(id);
        }
    }
    }
