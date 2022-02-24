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
using MVCRestApi.Models;

namespace MVCRestApi.Controllers
{
    public class CalisanlarsController : ApiController
    {
        private KurulusEntities db = new KurulusEntities();

        // GET: api/Calisanlars
        public IQueryable<Calisanlar> GetCalisanlar()
        {
            return db.Calisanlar;
        }

        // GET: api/Calisanlars/5
        [ResponseType(typeof(Calisanlar))]
        public IHttpActionResult GetCalisanlar(int id)
        {
            Calisanlar calisanlar = db.Calisanlar.Find(id);
            if (calisanlar == null)
            {
                return NotFound();
            }

            return Ok(calisanlar);
        }

        // PUT: api/Calisanlars/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCalisanlar(int id, Calisanlar calisanlar)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != calisanlar.CalisanId)
            {
                return BadRequest();
            }

            db.Entry(calisanlar).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CalisanlarExists(id))
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

        // POST: api/Calisanlars
        [ResponseType(typeof(Calisanlar))]
        public IHttpActionResult PostCalisanlar(Calisanlar calisanlar)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Calisanlar.Add(calisanlar);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = calisanlar.CalisanId }, calisanlar);
        }

        // DELETE: api/Calisanlars/5
        [ResponseType(typeof(Calisanlar))]
        public IHttpActionResult DeleteCalisanlar(int id)
        {
            Calisanlar calisanlar = db.Calisanlar.Find(id);
            if (calisanlar == null)
            {
                return NotFound();
            }

            db.Calisanlar.Remove(calisanlar);
            db.SaveChanges();

            return Ok(calisanlar);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CalisanlarExists(int id)
        {
            return db.Calisanlar.Count(e => e.CalisanId == id) > 0;
        }
    }
}