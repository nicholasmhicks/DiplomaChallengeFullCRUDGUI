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
    public class TourViewsController : ApiController
    {
        private NewModel db = new NewModel();

        // GET: api/TourViews
        public IQueryable<TourView> GetTourViews()
        {
            return db.TourViews;
        }

        // GET: api/TourViews/5
        [ResponseType(typeof(TourView))]
        public IHttpActionResult GetTourView(string id)
        {
            TourView tourView = db.TourViews.Find(id);
            if (tourView == null)
            {
                return NotFound();
            }

            return Ok(tourView);
        }

        // PUT: api/TourViews/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTourView(string id, TourView tourView)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tourView.TourName)
            {
                return BadRequest();
            }

            db.Entry(tourView).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TourViewExists(id))
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

        // POST: api/TourViews
        [ResponseType(typeof(TourView))]
        public IHttpActionResult PostTourView(TourView tourView)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TourViews.Add(tourView);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (TourViewExists(tourView.TourName))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tourView.TourName }, tourView);
        }

        // DELETE: api/TourViews/5
        [ResponseType(typeof(TourView))]
        public IHttpActionResult DeleteTourView(string id)
        {
            TourView tourView = db.TourViews.Find(id);
            if (tourView == null)
            {
                return NotFound();
            }

            db.TourViews.Remove(tourView);
            db.SaveChanges();

            return Ok(tourView);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TourViewExists(string id)
        {
            return db.TourViews.Count(e => e.TourName == id) > 0;
        }
    }
}