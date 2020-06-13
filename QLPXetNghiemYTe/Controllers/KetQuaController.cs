using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ClosedXML.Excel;
using QLPXetNghiemYTe.Entities;

namespace QLPXetNghiemYTe.Controllers
{
    [RoutePrefix("KetQua")]
    public class KetQuaController : ApiController
    {
        
        private QLPXetNghiemYTEntities db = new QLPXetNghiemYTEntities();

        // GET: api/KetQua
        public void GetHoSoXNBNs()
        {
              
    }

        [HttpGet]
        [Route("{id}")]
        [ResponseType(typeof(HoSoXNBN))]
        public IHttpActionResult GetHoSoXNBN(int id)
        {
            var ketqua = db.GetKQXN(id);
            if (ketqua == null)
            {
                return NotFound();
            }

            return Ok(ketqua);
        }

        // PUT: api/KetQua/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutHoSoXNBN(int id, HoSoXNBN hoSoXNBN)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != hoSoXNBN.ID)
            {
                return BadRequest();
            }

            db.Entry(hoSoXNBN).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HoSoXNBNExists(id))
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

        // POST: api/KetQua
        [ResponseType(typeof(HoSoXNBN))]
        public IHttpActionResult PostHoSoXNBN(HoSoXNBN hoSoXNBN)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.HoSoXNBNs.Add(hoSoXNBN);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = hoSoXNBN.ID }, hoSoXNBN);
        }

        // DELETE: api/KetQua/5
        [ResponseType(typeof(HoSoXNBN))]
        public IHttpActionResult DeleteHoSoXNBN(int id)
        {
            HoSoXNBN hoSoXNBN = db.HoSoXNBNs.Find(id);
            if (hoSoXNBN == null)
            {
                return NotFound();
            }

            db.HoSoXNBNs.Remove(hoSoXNBN);
            db.SaveChanges();

            return Ok(hoSoXNBN);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HoSoXNBNExists(int id)
        {
            return db.HoSoXNBNs.Count(e => e.ID == id) > 0;
        }

    
    }
}