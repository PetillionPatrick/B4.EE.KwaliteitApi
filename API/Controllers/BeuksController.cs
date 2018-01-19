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
using API.Models;
using API.Models.DTO;
using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace API.Controllers
{
    public class BeuksController : ApiController
    {
        private APIContext db = new APIContext();

        // GET: api/Beuks
        public IQueryable<BeukDTO> GetBeuks()
        {
            var beuks = db.Beuks.ProjectTo<BeukDTO>();
            return beuks;
        }

        // GET: api/Beuks/5
        [ResponseType(typeof(BeukDTO))]
        public async Task<IHttpActionResult> GetBeuk(Guid id)
        {
            var beuk = await db.Beuks.ProjectTo<BeukDTO>().SingleOrDefaultAsync(b => b.Id == id);

            if (beuk == null)
            {
                return NotFound();
            }

            return Ok(beuk);
        }

        // PUT: api/Beuks/5
        [ResponseType(typeof(void))]
        [HttpPut]
        public async Task<IHttpActionResult> PutBeuk(Guid id, BeukDTO beukDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != beukDTO.Id)
            {
                return BadRequest();
            }

            Beuk beuk = Mapper.Map<Beuk>(beukDTO);
            db.Set<Beuk>().Attach(beuk);
            db.Entry(beuk).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BeukExists(id))
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

        // POST: api/Beuks
        [ResponseType(typeof(BeukDTO))]
        [HttpPost]
        public async Task<IHttpActionResult> PostBeuk(BeukDTO beukDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Beuk beuk = Mapper.Map<Beuk>(beukDTO);
            db.Beuks.Add(beuk);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BeukExists(beuk.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = beuk.Id }, beuk);
        }

        // DELETE: api/Beuks/5
        [ResponseType(typeof(BeukDTO))]
        public async Task<IHttpActionResult> DeleteBeuk(Guid id)
        {
            using (var ctx = new APIContext())
            {
                var beuk = ctx.Beuks.Where(b => b.Id == id).FirstOrDefault();

                if (beuk == null)
                {
                    return NotFound();
                }
                ctx.Entry(beuk).State = System.Data.Entity.EntityState.Deleted;
                await ctx.SaveChangesAsync();

                return Ok(beuk);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BeukExists(Guid id)
        {
            return db.Beuks.Count(e => e.Id == id) > 0;
        }
    }
}