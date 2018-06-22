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
    public class TourEventViewsController : ApiController
    {
        private NewModel db = new NewModel();

        // GET: api/TourEventViews
        public IQueryable<TourEventView> GetTourEventViews()
        {
            return db.TourEventViews;
        }

        // GET: api/TourEventViews/5
        [ResponseType(typeof(TourEventView))]
        public IHttpActionResult GetTourEventView(string id)
        {
            TourEventView tourEventView = db.TourEventViews.Find(id);
            if (tourEventView == null)
            {
                return NotFound();
            }

            return Ok(tourEventView);
        }

        // PUT: api/TourEventViews/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTourEventView(string id, TourEventView tourEventView)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tourEventView.EventMonth)
            {
                return BadRequest();
            }

            db.Entry(tourEventView).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TourEventViewExists(id))
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

        // POST: api/TourEventViews
        [ResponseType(typeof(TourEventView))]
        public IHttpActionResult PostTourEventView(TourEventView tourEventView)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TourEventViews.Add(tourEventView);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (TourEventViewExists(tourEventView.EventMonth))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tourEventView.EventMonth }, tourEventView);
        }

        // DELETE: api/TourEventViews/5
        [ResponseType(typeof(TourEventView))]
        public IHttpActionResult DeleteTourEventView(string id)
        {
            TourEventView tourEventView = db.TourEventViews.Find(id);
            if (tourEventView == null)
            {
                return NotFound();
            }

            db.TourEventViews.Remove(tourEventView);
            db.SaveChanges();

            return Ok(tourEventView);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TourEventViewExists(string id)
        {
            return db.TourEventViews.Count(e => e.EventMonth == id) > 0;
        }
    }
}