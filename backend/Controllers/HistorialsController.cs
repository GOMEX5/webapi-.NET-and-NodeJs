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
    public class HistorialsController : ControllerBase
    {
        private IHistorialService _oHistorialService;

        public HistorialsController(IHistorialService oHistorialService)
        {
            _oHistorialService = oHistorialService;
        }

        // GET: api/<HistorialsController>
        [HttpGet]
        public IEnumerable<Historials> Get()
        {
            return _oHistorialService.Gets();
        }

        // GET api/<HistorialsController>/5
        [HttpGet("{id}")]
        public Historials Get(int id)
        {
            return _oHistorialService.Get(id);
        }

        // POST api/<HistorialsController>
        [HttpPost]
        public void Post([FromBody] Historials oHistorial)
        {
            if (ModelState.IsValid) _oHistorialService.Add(oHistorial);
        }

        // PUT api/<HistorialsController>/5
        [HttpPut]
        public void Put([FromBody] Historials oHistorial)
        {
            if (ModelState.IsValid) _oHistorialService.Update(oHistorial);
        }
        // DELETE api/<HistorialsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            if (id != 0) _oHistorialService.Delete(id);
        }
    }
    }
