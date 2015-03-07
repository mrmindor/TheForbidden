using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Model;

namespace DeckEditor.Controllers
{
    public class AlchemyCostsController : ApiController
    {
        private CardDesignEntities db = new CardDesignEntities();

        // GET: api/AlchemyCosts
        public IQueryable<AlchemyCost> GetAlchemyCosts()
        {
            return db.AlchemyCosts;
        }

        // GET: api/AlchemyCosts/5
        [ResponseType(typeof(AlchemyCost))]
        public async Task<IHttpActionResult> GetAlchemyCost(int id)
        {
            AlchemyCost alchemyCost = await db.AlchemyCosts.FindAsync(id);
            if (alchemyCost == null)
            {
                return NotFound();
            }

            return Ok(alchemyCost);
        }

        // PUT: api/AlchemyCosts/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAlchemyCost(int id, AlchemyCost alchemyCost)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != alchemyCost.Id)
            {
                return BadRequest();
            }

            db.Entry(alchemyCost).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlchemyCostExists(id))
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

        // POST: api/AlchemyCosts
        [ResponseType(typeof(AlchemyCost))]
        public async Task<IHttpActionResult> PostAlchemyCost(AlchemyCost alchemyCost)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AlchemyCosts.Add(alchemyCost);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = alchemyCost.Id }, alchemyCost);
        }

        // DELETE: api/AlchemyCosts/5
        [ResponseType(typeof(AlchemyCost))]
        public async Task<IHttpActionResult> DeleteAlchemyCost(int id)
        {
            AlchemyCost alchemyCost = await db.AlchemyCosts.FindAsync(id);
            if (alchemyCost == null)
            {
                return NotFound();
            }

            db.AlchemyCosts.Remove(alchemyCost);
            await db.SaveChangesAsync();

            return Ok(alchemyCost);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AlchemyCostExists(int id)
        {
            return db.AlchemyCosts.Count(e => e.Id == id) > 0;
        }
    }
}