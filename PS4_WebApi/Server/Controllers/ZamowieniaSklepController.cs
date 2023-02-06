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
    public class ZamowieniaSklepController : ControllerBase
    {

        private readonly ApplicationDBContext _context;

        public ZamowieniaSklepController(ApplicationDBContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public IEnumerable<mojSklep> GetZamowieniaSzczegol()
        {
            var wynik = (from przedmioty in _context.Przedmioty
                         join sklep in _context.Zamowienia
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

            var zamowienie = await _context.Zamowienia.FindAsync(id);

            if (zamowienie == null)
            {
                return NotFound();
            }

            return Ok(zamowienie);
        }

        // PUT: api/ShoppingDetails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShoppingDetails([FromRoute] int id, [FromBody] Zamowienie zamowienie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != zamowienie.Id)
            {
                return BadRequest();
            }

            _context.Entry(zamowienie).State = EntityState.Modified;

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
        public async Task<IActionResult> PostShoppingDetails([FromBody] Zamowienie zamowienie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Zamowienia.Add(zamowienie);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetZamowieniaSzczegol", new { id = zamowienie.Id }, zamowienie);
        }

        // DELETE: api/ShoppingDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShoppingDetails([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var zamowienie = await _context.Zamowienia.FindAsync(id);
            if (zamowienie == null)
            {
                return NotFound();
            }

            _context.Zamowienia.Remove(zamowienie);
            await _context.SaveChangesAsync();

            return Ok(zamowienie);
        }

        private bool ShoppingDetailsExists(int id)
        {
            return _context.Zamowienia.Any(e => e.Id == id);
        }


    }
}
