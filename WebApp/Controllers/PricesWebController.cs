using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Results;
using DAL.DTO;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class PricesWebController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Web
        public JsonResult<List<PriceDto>> GetAllPrices()
        {
            return Json(db.PriceDtoes.ToList());
        }

        // GET: api/Web/5
        [ResponseType(typeof(PriceDto))]
        public async Task<IHttpActionResult> GetPriceDto(long id)
        {
            PriceDto priceDto = await db.PriceDtoes.FindAsync(id);
            if (priceDto == null)
            {
                return NotFound();
            }

            return Ok(priceDto);
        }

        // PUT: api/Web/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPriceDto(long id, PriceDto priceDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != priceDto.Id)
            {
                return BadRequest();
            }

            db.Entry(priceDto).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PriceDtoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Web
        [ResponseType(typeof(PriceDto))]
        public async Task<IHttpActionResult> PostPriceDto(PriceDto priceDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PriceDtoes.Add(priceDto);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { Id = priceDto.Id }, priceDto);
        }

        // DELETE: api/Web/5
        [ResponseType(typeof(PriceDto))]
        public async Task<IHttpActionResult> DeletePriceDto(long id)
        {
            PriceDto priceDto = await db.PriceDtoes.FindAsync(id);
            if (priceDto == null)
            {
                return NotFound();
            }

            db.PriceDtoes.Remove(priceDto);
            await db.SaveChangesAsync();

            return Ok(priceDto);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PriceDtoExists(long id)
        {
            return db.PriceDtoes.Count(e => e.Id == id) > 0;
        }
    }
}