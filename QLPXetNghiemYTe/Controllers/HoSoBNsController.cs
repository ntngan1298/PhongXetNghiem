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
    [RoutePrefix("HoSoBN")]
    public class HoSoBNsController : ApiController
    {
        private QLPXetNghiemYTEntities db = new QLPXetNghiemYTEntities();

        // GET: api/HoSoBNs
        public IQueryable<HoSoBN> GetHoSoBNs()
        {
            return db.HoSoBNs;
        }
               
        // GET: api/HoSoBNs/5
        [ResponseType(typeof(HoSoBN))]
        public IHttpActionResult GetHoSoBN(int id)
        {
            HoSoBN hoSoBN = db.HoSoBNs.Find(id);
            if (hoSoBN == null)
            {
                return NotFound();
            }

            return Ok(hoSoBN);
        }

        [HttpGet]
        [Route("GetDonGiaXNinHSBN/{id}")]
        public IHttpActionResult GetDonGiaXNinHSBN(int id)
        {
            var XNLst = db.GetDonGiaXNinHSBN(id);

            if (XNLst == null)
            {
                return NotFound();
            }

            return Ok(XNLst);
        }


        // PUT: api/HoSoBNs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutHoSoBN(int id, HoSoBN hoSoBN)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != hoSoBN.ID)
            {
                return BadRequest();
            }

            db.Entry(hoSoBN).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HoSoBNExists(id))
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

        // POST: api/HoSoBNs
        [ResponseType(typeof(HoSoBN))]
        public IHttpActionResult PostHoSoBN(HoSoBN hoSoBN)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.HoSoBNs.Add(hoSoBN);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = hoSoBN.ID }, hoSoBN);
        }


        //[ResponseType(typeof(HoSoBN))]
        //public IHttpActionResult PostHoSoBNs(Dictionary<string,List<string>> hoSoBNs)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    if (hoSoBNs != null && hoSoBNs.ContainsKey("ListXN") && hoSoBNs.ContainsKey("idBN")&&hoSoBNs.Count > 0)
        //    {
        //        foreach(var idXN in hoSoBNs["ListXN"])
        //        {
        //            save(hoSoBNs("idBN"), idXN);
        //        }
        //    }
        //    for( int i=0; i < hoSoBNs.Count(); i++)
        //    {
                
        //    }
        // //   db.HoSoBNs.Add(hoSoBN);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = hoSoBN.ID }, hoSoBNs);
        //}
        [HttpPost]
        [Route("ThanhToan/{id}")]
        public IHttpActionResult ThanhToan(int id)
        {
             db.UpdateStatusHSBN(id);

           

            return Ok();
        }

        // DELETE: api/HoSoBNs/5
        [ResponseType(typeof(HoSoBN))]
        public IHttpActionResult DeleteHoSoBN(int id)
        {
            HoSoBN hoSoBN = db.HoSoBNs.Find(id);
            if (hoSoBN == null)
            {
                return NotFound();
            }

            db.HoSoBNs.Remove(hoSoBN);
            db.SaveChanges();

            return Ok(hoSoBN);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HoSoBNExists(int id)
        {
            return db.HoSoBNs.Count(e => e.ID == id) > 0;
        }
    }
}