using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
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
    public class UnitsController : ApiController
    {
        private APIContext db = new APIContext();

        // GET: api/Units
        public IQueryable<UnitDTO> GetUnits()
        {
            var units = db.Units.ProjectTo<UnitDTO>();
            return units;
        }

        // GET: api/Units/5
        [ResponseType(typeof(UnitDTO))]
        public async Task<IHttpActionResult> GetUnit(Guid id)
        {
            var unit = await db.Units.ProjectTo<Unit>().SingleOrDefaultAsync(b => b.Id == id);
            if (unit == null)
            {
                return NotFound();
            }

            return Ok(unit);
        }

        // PUT: api/Units/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutUnit(Guid id, UnitDTO unitDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != unitDTO.Id)
            {
                return BadRequest();
            }

            Unit unit = Mapper.Map<Unit>(unitDTO);
            db.Set<Unit>().Attach(unit);
            db.Entry(unit).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UnitExists(id))
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

        // POST: api/Units
        [ResponseType(typeof(UnitDTO))]
        public async Task<IHttpActionResult> PostUnit(UnitDTO unitDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Unit unit = Mapper.Map<Unit>(unitDTO);
            db.Units.Add(unit);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                if (UnitExists(unit.Id))
                {
                    return Conflict();
                }
                else
                {
                    Debug.WriteLine(ex.Message);
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = unit.Id }, unit);
        }

        // DELETE: api/Units/5
        [ResponseType(typeof(UnitDTO))]
        public async Task<IHttpActionResult> DeleteUnit(Guid id)
        {
            using (var ctx = new APIContext())
            {
                var unit = ctx.Units.Where(b => b.Id == id).FirstOrDefault();

                if (unit == null)
                {
                    return NotFound();
                }
                ctx.Entry(unit).State = System.Data.Entity.EntityState.Deleted;
                await ctx.SaveChangesAsync();

                return Ok(unit);
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

        private bool UnitExists(Guid id)
        {
            return db.Units.Count(e => e.Id == id) > 0;
        }
    }
}