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
    public class OrdersController : ApiController
    {
        private APIContext db = new APIContext();

        // GET: api/Orders
        public IQueryable<OrderDTO> GetOrders()
        {
            var orders = db.Orders.ProjectTo<OrderDTO>();
            return orders;
        }

        // GET: api/Orders/5
        [ResponseType(typeof(OrderDTO))]
        public async Task<IHttpActionResult> GetOrder(Guid id)
        {
            var order = await db.Orders.ProjectTo<OrderDTO>().SingleOrDefaultAsync(b => b.Id == id);

            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }

        // PUT: api/Orders/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutOrder(Guid id, OrderDTO orderDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != orderDTO.Id)
            {
                return BadRequest();
            }

            Order order = Mapper.Map<Order>(orderDTO);
            db.Set<Order>().Attach(order);
            db.Entry(order).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(id))
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

        // POST: api/Orders
        [ResponseType(typeof(OrderDTO))]
        public async Task<IHttpActionResult> PostOrder(OrderDTO orderDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Order order = Mapper.Map<Order>(orderDTO);
            db.Orders.Add(order);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (OrderExists(order.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = order.Id }, order);
        }

        // DELETE: api/Orders/5
        [ResponseType(typeof(OrderDTO))]
        public async Task<IHttpActionResult> DeleteOrder(Guid id)
        {
            using (var ctx = new APIContext())
            {
                var order = ctx.Orders.Where(b => b.Id == id).FirstOrDefault();

                if (order == null)
                {
                    return NotFound();
                }
                ctx.Entry(order).State = System.Data.Entity.EntityState.Deleted;
                await ctx.SaveChangesAsync();

                return Ok(order);
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

        private bool OrderExists(Guid id)
        {
            return db.Orders.Count(e => e.Id == id) > 0;
        }
    }
}