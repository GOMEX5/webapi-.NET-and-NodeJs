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
    public class PeriodicosController : ControllerBase
    {
        private IPeriodicoService _oPeriodicoService;

        public PeriodicosController(IPeriodicoService oPeriodicoService)
        {
            _oPeriodicoService = oPeriodicoService;
        }

        // GET: api/<PeriodicosController>
        [HttpGet]
        public IEnumerable<Periodicos> Get()
        {
            return _oPeriodicoService.Gets();
        }

        // GET api/<PeriodicosController>/5
        [HttpGet("{id}")]
        public Periodicos Get(int id)
        {
            return _oPeriodicoService.Get(id);
        }

        // POST api/<PeriodicosController>
        [HttpPost]
        public void Post([FromBody] Periodicos oPeriodico)
        {
            if (ModelState.IsValid) _oPeriodicoService.Add(oPeriodico);
        }

        // PUT api/<PeriodicosController>/5
        [HttpPut]
        public void Put([FromBody] Periodicos oPeriodico)
        {
            if (ModelState.IsValid) _oPeriodicoService.Update(oPeriodico);
        }
        // DELETE api/<PeriodicosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            if (id != 0) _oPeriodicoService.Delete(id);
        }
    }
    }
