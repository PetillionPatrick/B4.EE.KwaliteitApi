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
    public class MachinesController : ApiController
    {
        private APIContext db = new APIContext();

        // GET: api/Machines
        public IQueryable<MachineDTO> GetMachines()
        {
            var machines = db.Machines.ProjectTo<MachineDTO>();
            return machines;
        }

        //public IQueryable<MachineDTO> GetMachines(Guid beukId)
        //{
        //    var machines = db.Machines.ProjectTo<MachineDTO>(m => m.BeukId == beukId);
        //    return machines;
        //}

        // GET: api/Machines/5
        [ResponseType(typeof(MachineDTO))]
        public async Task<IHttpActionResult> GetMachine(Guid id)
        {
            var machine = await db.Machines.ProjectTo<MachineDTO>().SingleOrDefaultAsync(b => b.Id == id);

            if (machine == null)
            {
                return NotFound();
            }

            return Ok(machine);
        }

        // PUT: api/Machines/5
        [ResponseType(typeof(void))]
        [HttpPut]
        public async Task<IHttpActionResult> PutMachine(Guid id, MachineDTO machineDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != machineDTO.Id)
            {
                return BadRequest();
            }

            Machine machine = Mapper.Map<Machine>(machineDTO);
            db.Set<Machine>().Attach(machine);
            db.Entry(machine).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MachineExists(id))
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

        // POST: api/Machines
        [ResponseType(typeof(Machine))]
        [HttpPost]
        public async Task<IHttpActionResult> PostMachine(MachineDTO machineDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Machine machine = Mapper.Map<Machine>(machineDTO);
            db.Machines.Add(machine);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MachineExists(machine.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = machine.Id }, machine);
        }

        // DELETE: api/Machines/5
        [ResponseType(typeof(MachineDTO))]
        public async Task<IHttpActionResult> DeleteMachine(Guid id)
        {
            using (var ctx = new APIContext())
            {
                var machine = ctx.Machines.Where(b => b.Id == id).FirstOrDefault();

                if (machine == null)
                {
                    return NotFound();
                }
                ctx.Entry(machine).State = System.Data.Entity.EntityState.Deleted;
                await ctx.SaveChangesAsync();

                return Ok(machine);
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

        private bool MachineExists(Guid id)
        {
            return db.Machines.Count(e => e.Id == id) > 0;
        }
    }
}