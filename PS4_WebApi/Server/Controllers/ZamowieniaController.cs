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
    public class ZamowieniaController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public ZamowieniaController(ApplicationDBContext context)
        {
            this._context = context;
        }



        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var zamowie = await _context.Zamowienia.ToListAsync();
            return Ok(zamowie);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var zamow = await _context.Zamowienia.FirstOrDefaultAsync(a => a.Id == id);
            return Ok(zamow);
        }
        [HttpPost]
        public async Task<IActionResult> Post(Zamowienie zamowienie)
        {
            _context.Add(zamowienie);
            await _context.SaveChangesAsync();
            return Ok(zamowienie.Id);
        }

        [HttpPut]
        public async Task<IActionResult> Put(Zamowienie zamowienie)
        {
            _context.Entry(zamowienie).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var zamow = new Zamowienie { Id = id };
            _context.Remove(zamow);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
