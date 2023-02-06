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
    public class PrzedmiotyController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public PrzedmiotyController(ApplicationDBContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var przed = await _context.Przedmioty.ToListAsync();
            return Ok(przed);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var prze = await _context.Przedmioty.FirstOrDefaultAsync(a => a.Id == id);
            return Ok(prze);
        }
        [HttpPost]
        public async Task<IActionResult> Post(Przedmiot przedmiot)
        {
            _context.Add(przedmiot);
            await _context.SaveChangesAsync();
            return Ok(przedmiot.Id);
        }

        [HttpPut]
        public async Task<IActionResult> Put(Przedmiot przedmiot)
        {
            _context.Entry(przedmiot).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var prze = new Przedmiot { Id = id };
            _context.Remove(prze);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
