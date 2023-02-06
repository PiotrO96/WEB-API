using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PS4_WebApi.Server.Data;
using PS4_WebApi.Shared;
using PS4_WebApi.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PS4_WebApi.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KlienciController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public KlienciController(ApplicationDBContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var kliencis = await _context.Klienci.ToListAsync();
            return Ok(kliencis);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var klien = await _context.Klienci.FirstOrDefaultAsync(a => a.Id == id);
            return Ok(klien);
        }
        [HttpPost]
        public async Task<IActionResult> Post(Klient klienci)
        {
            _context.Add(klienci);
            await _context.SaveChangesAsync();
            return Ok(klienci.Id);
        }

        [HttpPut]
        public async Task<IActionResult> Put(Klient klienci)
        {
            _context.Entry(klienci).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var klien = new Klient { Id = id };
            _context.Remove(klien);
            await _context.SaveChangesAsync();
            return NoContent(); 
        }

    }
}
