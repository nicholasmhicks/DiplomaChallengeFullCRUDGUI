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
using API.Models;

namespace API.Controllers
{
    public class ToursController : ApiController
    {
        private NewModel db = new NewModel();

        // GET: api/Tours
        public IQueryable<Tour> GetTours()
        {
            return db.Tours;
        }

        // GET: api/Tours/5
        [ResponseType(typeof(Tour))]
        public IHttpActionResult GetTour(string id)
        {
            Tour tour = db.Tours.Find(id);
            if (tour == null)
            {
                return NotFound();
            }

            return Ok(tour);
        }

        // PUT: api/Tours/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTour(string id, Tour tour)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tour.TourName)
            {
                return BadRequest();
            }

            db.Entry(tour).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TourExists(id))
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

        // POST: api/Tours
        [ResponseType(typeof(Tour))]
        public IHttpActionResult PostTour(Tour tour)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Tours.Add(tour);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (TourExists(tour.TourName))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tour.TourName }, tour);
        }

        // DELETE: api/Tours/5
        [ResponseType(typeof(Tour))]
        public IHttpActionResult DeleteTour(string id)
        {
            Tour tour = db.Tours.Find(id);
            if (tour == null)
            {
                return NotFound();
            }

            db.Tours.Remove(tour);
            db.SaveChanges();

            return Ok(tour);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TourExists(string id)
        {
            return db.Tours.Count(e => e.TourName == id) > 0;
        }
    }
}