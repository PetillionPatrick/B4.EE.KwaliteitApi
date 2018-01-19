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
    public class LineInspectorsController : ApiController
    {
        private APIContext db = new APIContext();

        // GET: api/LineInspectors
        public IQueryable<LineInspectorDTO> GetLineInspectors()
        {
            var li = db.LineInspectors.ProjectTo<LineInspectorDTO>();
            return li;
        }

        // GET: api/LineInspectors/5
        [ResponseType(typeof(LineInspectorDTO))]
        public async Task<IHttpActionResult> GetLineInspector(Guid id)
        {
            var lineInspector = await db.LineInspectors.ProjectTo<LineInspectorDTO>().SingleOrDefaultAsync(b => b.Id == id);
            if (lineInspector == null)
            {
                return NotFound();
            }

            return Ok(lineInspector);
        }

        // PUT: api/LineInspectors/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutLineInspector(Guid id, LineInspectorDTO lineInspectorDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != lineInspectorDTO.Id)
            {
                return BadRequest();
            }
            LineInspector lineInspector = Mapper.Map<LineInspector>(lineInspectorDTO);
            db.Set<LineInspector>().Attach(lineInspector);
            db.Entry(lineInspector).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LineInspectorExists(id))
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

        // POST: api/LineInspectors
        [ResponseType(typeof(LineInspectorDTO))]
        [HttpPost]
        public async Task<IHttpActionResult> PostLineInspector(LineInspectorDTO lineInspectorDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            LineInspector lineInspector = Mapper.Map<LineInspector>(lineInspectorDTO);
            db.LineInspectors.Add(lineInspector);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                if (LineInspectorExists(lineInspector.Id))
                {
                    return Conflict();
                }
                else
                {
                    Debug.WriteLine(ex.Message);
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = lineInspector.Id }, lineInspector);
        }

        // DELETE: api/LineInspectors/5
        [ResponseType(typeof(LineInspectorDTO))]
        public async Task<IHttpActionResult> DeleteLineInspector(Guid id)
        {
            using (var ctx = new APIContext())
            {
                var lineInspector = ctx.LineInspectors.Where(b => b.Id == id).FirstOrDefault();

                if (lineInspector == null)
                {
                    return NotFound();
                }
                ctx.Entry(lineInspector).State = System.Data.Entity.EntityState.Deleted;
                await ctx.SaveChangesAsync();

                return Ok(lineInspector);
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

        private bool LineInspectorExists(Guid id)
        {
            return db.LineInspectors.Count(e => e.Id == id) > 0;
        }
    }
}