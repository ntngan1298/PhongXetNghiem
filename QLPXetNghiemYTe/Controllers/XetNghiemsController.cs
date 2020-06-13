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
    [RoutePrefix("XetNghiem")]
    public class XetNghiemsController : ApiController
    {
        private QLPXetNghiemYTEntities db = new QLPXetNghiemYTEntities();
        public XetNghiemsController()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }
        // GET: api/XetNghiems
        public IQueryable<XetNghiem> GetXetNghiems()
        {
            return db.XetNghiems;
        }

        // GET: api/XetNghiems/5
        [ResponseType(typeof(XetNghiem))]
        public IHttpActionResult GetXetNghiem(int id)
        {
            XetNghiem xetNghiem = db.XetNghiems.Find(id);
            if (xetNghiem == null)
            {
                return NotFound();
            }

            return Ok(xetNghiem);
        }

        // PUT: api/XetNghiems/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutXetNghiem(int id, XetNghiem xetNghiem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != xetNghiem.ID)
            {
                return BadRequest();
            }

            db.Entry(xetNghiem).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!XetNghiemExists(id))
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

        // POST: api/XetNghiems
        [ResponseType(typeof(XetNghiem))]
        public IHttpActionResult PostXetNghiem(XetNghiem xetNghiem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.XetNghiems.Add(xetNghiem);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (XetNghiemExists(xetNghiem.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = xetNghiem.ID }, xetNghiem);
        }

        // DELETE: api/XetNghiems/5
        [ResponseType(typeof(XetNghiem))]
        public IHttpActionResult DeleteXetNghiem(int id)
        {
            XetNghiem xetNghiem = db.XetNghiems.Find(id);
            if (xetNghiem == null)
            {
                return NotFound();
            }

            db.XetNghiems.Remove(xetNghiem);
            db.SaveChanges();

            return Ok(xetNghiem);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool XetNghiemExists(int id)
        {
            return db.XetNghiems.Count(e => e.ID == id) > 0;
        }


        [HttpGet]
        [Route("GetXNinHSXN/{id}")]
        [ResponseType(typeof(List<XetNghiem>))]
        public IHttpActionResult GetXNinHSXN(int id)
        {
            var XNlst = db.GetXNinHSXN(id);

            if (XNlst == null)
            {
                return NotFound();
            }

            return Ok(XNlst);
        }
    }
}