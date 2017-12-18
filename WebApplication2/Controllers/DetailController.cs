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
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class DetailController : ApiController
    {
        private OurDbContext db = new OurDbContext();

        // GET: api/Detail
        [HttpGet]
        public IQueryable<ADetail> GetDbdetail()
        {
            return db.Dbdetail;
        }

        // GET: api/Detail/5
        [ResponseType(typeof(ADetail))]
        public IHttpActionResult GetADetail(int id)
        {
            ADetail aDetail = db.Dbdetail.Find(id);
            if (aDetail == null)
            {
                return NotFound();
            }

            return Ok(aDetail);
        }

        // PUT: api/Detail/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutADetail(int id, ADetail aDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != aDetail.Id)
            {
                return BadRequest();
            }

            db.Entry(aDetail).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ADetailExists(id))
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

        // POST: api/Detail
        [ResponseType(typeof(ADetail))]
        public IHttpActionResult PostADetail(ADetail aDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Dbdetail.Add(aDetail);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = aDetail.Id }, aDetail);
        }

        // DELETE: api/Detail/5
        [ResponseType(typeof(ADetail))]
        public IHttpActionResult DeleteADetail(int id)
        {
            ADetail aDetail = db.Dbdetail.Find(id);
            if (aDetail == null)
            {
                return NotFound();
            }

            db.Dbdetail.Remove(aDetail);
            db.SaveChanges();

            return Ok(aDetail);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ADetailExists(int id)
        {
            return db.Dbdetail.Count(e => e.Id == id) > 0;
        }
    }
}