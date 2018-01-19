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
    public class OperatorsController : ApiController
    {
        private APIContext db = new APIContext();

        // GET: api/Operators
        public IQueryable<OperatorDTO> GetOperators()
        {
            var operators = db.Operators.ProjectTo<OperatorDTO>();
            return operators;
        }

        // GET: api/Operators/5
        [ResponseType(typeof(OperatorDTO))]
        public async Task<IHttpActionResult> GetOperator(Guid id)
        {
            var @operator = await db.Operators.ProjectTo<OperatorDTO>().SingleOrDefaultAsync(b => b.Id == id);
            if (@operator == null)
            {
                return NotFound();
            }

            return Ok(@operator);
        }

        // PUT: api/Operators/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutOperator(Guid id, OperatorDTO operatorDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != operatorDTO.Id)
            {
                return BadRequest();
            }
            Operator @operator = Mapper.Map<Operator>(operatorDTO);
            db.Set<Operator>().Attach(@operator);
            db.Entry(@operator).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OperatorExists(id))
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

        // POST: api/Operators
        [ResponseType(typeof(OperatorDTO))]
        public async Task<IHttpActionResult> PostOperator(OperatorDTO operatorDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Operator @operator = Mapper.Map<Operator>(operatorDTO);
            db.Operators.Add(@operator);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (OperatorExists(@operator.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = @operator.Id }, @operator);
        }

        // DELETE: api/Operators/5
        [ResponseType(typeof(OperatorDTO))]
        public async Task<IHttpActionResult> DeleteOperator(Guid id)
        {
            using (var ctx = new APIContext())
            {
                var @operator = ctx.Operators.Where(b => b.Id == id).FirstOrDefault();

                if (@operator == null)
                {
                    return NotFound();
                }
                ctx.Entry(@operator).State = System.Data.Entity.EntityState.Deleted;
                await ctx.SaveChangesAsync();

                return Ok(@operator);
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

        private bool OperatorExists(Guid id)
        {
            return db.Operators.Count(e => e.Id == id) > 0;
        }
    }
}