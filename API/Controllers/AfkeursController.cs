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
    public class AfkeursController : ApiController
    {
        private APIContext db = new APIContext();

        // GET: api/Afkeurs
        public IQueryable<AfkeurDTO> GetAfkeurs()
        {
            var afkeurs = db.Afkeurs.ProjectTo<AfkeurDTO>();
            return afkeurs;
        }

        // GET: api/Afkeurs/5
        [ResponseType(typeof(AfkeurDTO))]
        public async Task<IHttpActionResult> GetAfkeur(Guid id)
        {

            var afkeur = await db.Afkeurs.ProjectTo<AfkeurDTO>().SingleOrDefaultAsync(b => b.Id == id);

            if (afkeur == null)
            {
                return NotFound();
            }

            return Ok(afkeur);
        }

        // PUT: api/Afkeurs/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAfkeur(Guid id, AfkeurDTO afkeurDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != afkeurDTO.Id)
            {
                return BadRequest();
            }

            Afkeur afkeur = Mapper.Map<Afkeur>(afkeurDTO);
            db.Set<Afkeur>().Attach(afkeur);
            db.Entry(afkeur).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AfkeurExists(id))
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

        // POST: api/Afkeurs
        [ResponseType(typeof(AfkeurDTO))]
        public async Task<IHttpActionResult> PostAfkeur(AfkeurDTO afkeurDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Afkeur afkeur = Mapper.Map<Afkeur>(afkeurDTO);
            db.Afkeurs.Add(afkeur);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AfkeurExists(afkeur.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = afkeur.Id }, afkeur);
        }

        // DELETE: api/Afkeurs/5
        [ResponseType(typeof(AfkeurDTO))]
        public async Task<IHttpActionResult> DeleteAfkeur(Guid id)
        {
            using (var ctx = new APIContext())
            {
                var afkeur = ctx.Afkeurs.Where(b => b.Id == id).FirstOrDefault();

                if (afkeur == null)
                {
                    return NotFound();
                }
                ctx.Entry(afkeur).State = System.Data.Entity.EntityState.Deleted;
                await ctx.SaveChangesAsync();

                return Ok(afkeur);
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

        private bool AfkeurExists(Guid id)
        {
            return db.Afkeurs.Count(e => e.Id == id) > 0;
        }
    }
}