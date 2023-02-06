using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PS4_WebApi.Server.Data;
using PS4_WebApi.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace PS4_WebApi.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KoszykController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public KoszykController(ApplicationDBContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public IEnumerable<mojSklep> GetZamowieniaSzczegol()
        {
            var wynik = (from przedmioty in _context.Przedmioty
                         join sklep in _context.Koszyki
                              on przedmioty.Id equals sklep.Id
                         select new mojSklep
                         {

                             SklepId = sklep.Id,
                             NazwaPrzedmiotu = przedmioty.Przedmiot_Nazwa,

                             Zamawiajacy = sklep.Zamowienie_Nalezy,
                             Ilosc = sklep.Zamowienie_Ilosc,
                             CalkowitaIlosc = sklep.Zamowienie_Ilosc,
                             Opis = sklep.Zamowienie_Sklad,

                         }).ToList();


            return wynik;
        }

        // GET: api/ShoppingDetails/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetZamowieniaSzczegol([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var zamowienie = await _context.Koszyki.FindAsync(id);

            if (zamowienie == null)
            {
                return NotFound();
            }

            return Ok(zamowienie);
        }

        // PUT: api/ShoppingDetails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShoppingDetails([FromRoute] int id, [FromBody] Koszyk koszyk)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != koszyk.Id)
            {
                return BadRequest();
            }

            _context.Entry(koszyk).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShoppingDetailsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ShoppingDetails
        [HttpPost]
        public async Task<IActionResult> PostShoppingDetails([FromBody] Koszyk koszyk)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Koszyki.Add(koszyk);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetZamowieniaSzczegol", new { id = koszyk.Id }, koszyk);
        }

        // DELETE: api/ShoppingDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShoppingDetails([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var koszyk = await _context.Koszyki.FindAsync(id);
            if (koszyk == null)
            {
                return NotFound();
            }

            _context.Koszyki.Remove(koszyk);
            await _context.SaveChangesAsync();

            return Ok(koszyk);
        }

        private bool ShoppingDetailsExists(int id)
        {
            return _context.Koszyki.Any(e => e.Id == id);
        }
    }
}
