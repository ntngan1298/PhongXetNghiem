using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using QLPXetNghiemYTe.Entities;

namespace QLPXetNghiemYTe.Controllers
{
    [RoutePrefix("BenhNhans")]
    public class BenhNhansController : ApiController
    {
        private QLPXetNghiemYTEntities db = new QLPXetNghiemYTEntities();
        public BenhNhansController()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }
      
        // GET: api/BenhNhans
        public IQueryable<BenhNhan> GetBenhNhans()
        {
            return db.BenhNhans;
        }

        // GET: api/BenhNhans/5
        [ResponseType(typeof(BenhNhan))]
        public IHttpActionResult GetBenhNhan(int id)
        {
            BenhNhan benhNhan = db.BenhNhans.Find(id);
            if (benhNhan == null)
            {
                return NotFound();
            }

            return Ok(benhNhan);
        }
        [HttpGet]
        [Route("GetBNinHD/{id}")]
        [ResponseType(typeof(List<BenhNhan>))]
        public IHttpActionResult GetBNinHD(int id)
        {
            var BNlst = db.GetBNinHD(id);

            if (BNlst == null)
            {
                return NotFound();
            }

            return Ok(BNlst);
        }
        // PUT: api/BenhNhans/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBenhNhan(int id, BenhNhan benhNhan)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != benhNhan.ID)
            {
                return BadRequest();
            }

            db.Entry(benhNhan).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BenhNhanExists(id))
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

        // POST: api/BenhNhans
        [ResponseType(typeof(BenhNhan))]
        public IHttpActionResult PostBenhNhan(BenhNhan benhNhan)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.BenhNhans.Add(benhNhan);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (BenhNhanExists(benhNhan.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = benhNhan.ID }, benhNhan);
        }

        // DELETE: api/BenhNhans/5
        [ResponseType(typeof(BenhNhan))]
        public IHttpActionResult DeleteBenhNhan(int id)
        {
            BenhNhan benhNhan = db.BenhNhans.Find(id);
            if (benhNhan == null)
            {
                return NotFound();
            }

            db.BenhNhans.Remove(benhNhan);
            db.SaveChanges();

            return Ok(benhNhan);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BenhNhanExists(int id)
        {
            return db.BenhNhans.Count(e => e.ID == id) > 0;
        }


    }
}