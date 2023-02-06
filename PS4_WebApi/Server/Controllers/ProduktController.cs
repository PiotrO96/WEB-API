using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PS4_WebApi.Server.Data;
using PS4_WebApi.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using PS4_WebApi.Shared;

namespace PS4_WebApi.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProduktController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public ProduktController(ApplicationDBContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var produk = await _context.Produkty.ToListAsync();
            return Ok(produk);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var produ = await _context.Produkty.FirstOrDefaultAsync(a => a.Id == id);
            return Ok(produ);
        }
        [HttpPost]
        public async Task<IActionResult> Post(Produkt produkt)
        {
            _context.Add(produkt);
            await _context.SaveChangesAsync();
            return Ok(produkt.Id);
        }

        [HttpPut]
        public async Task<IActionResult> Put(Produkt produkt)
        {
            _context.Entry(produkt).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var produkt = new Produkt { Id = id };
            _context.Remove(produkt);
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }
}
