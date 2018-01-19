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
    public class StatusController : ApiController
    {
        private APIContext db = new APIContext();

        // GET: api/Status
        public IQueryable<StatusDTO> GetStatus()
        {
            var status = db.Status.ProjectTo<StatusDTO>();
            return status;
        }

        // GET: api/Status/5
        [ResponseType(typeof(StatusDTO))]
        public async Task<IHttpActionResult> GetStatus(Guid id)
        {
            var status = await db.Status.ProjectTo<StatusDTO>().SingleOrDefaultAsync(b => b.Id == id);

            if (status == null)
            {
                return NotFound();
            }

            return Ok(status);
        }

        // PUT: api/Status/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutStatus(Guid id, StatusDTO statusDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != statusDTO.Id)
            {
                return BadRequest();
            }

            Status status = Mapper.Map<Status>(statusDTO);
            db.Set<Status>().Attach(status);
            db.Entry(status).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StatusExists(id))
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

        // POST: api/Status
        [ResponseType(typeof(StatusDTO))]
        public async Task<IHttpActionResult> PostStatus(StatusDTO statusDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Status status = Mapper.Map<Status>(statusDTO);
            db.Status.Add(status);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                if (StatusExists(status.Id))
                {
                    return Conflict();
                }
                else
                {
                    Debug.WriteLine(ex.Message);
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = status.Id }, status);
        }

        // DELETE: api/Status/5
        [ResponseType(typeof(StatusDTO))]
        public async Task<IHttpActionResult> DeleteStatus(Guid id)
        {
            using (var ctx = new APIContext())
            {
                var status = ctx.Status.Where(b => b.Id == id).FirstOrDefault();

                if (status == null)
                {
                    return NotFound();
                }
                ctx.Entry(status).State = System.Data.Entity.EntityState.Deleted;
                await ctx.SaveChangesAsync();

                return Ok(status);
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

        private bool StatusExists(Guid id)
        {
            return db.Status.Count(e => e.Id == id) > 0;
        }
    }
}