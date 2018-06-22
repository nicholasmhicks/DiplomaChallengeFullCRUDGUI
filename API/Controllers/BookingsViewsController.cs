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
    public class BookingsViewsController : ApiController
    {
        private NewModel db = new NewModel();

        // GET: api/BookingsViews
        public IQueryable<BookingsView> GetBookingsViews()
        {
            return db.BookingsViews;
        }

        // GET: api/BookingsViews/5
        [ResponseType(typeof(BookingsView))]
        public IHttpActionResult GetBookingsView(int id)
        {
            BookingsView bookingsView = db.BookingsViews.Find(id);
            if (bookingsView == null)
            {
                return NotFound();
            }

            return Ok(bookingsView);
        }

        // PUT: api/BookingsViews/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBookingsView(int id, BookingsView bookingsView)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bookingsView.BookingId)
            {
                return BadRequest();
            }

            db.Entry(bookingsView).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookingsViewExists(id))
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

        // POST: api/BookingsViews
        [ResponseType(typeof(BookingsView))]
        public IHttpActionResult PostBookingsView(BookingsView bookingsView)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.BookingsViews.Add(bookingsView);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (BookingsViewExists(bookingsView.BookingId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = bookingsView.BookingId }, bookingsView);
        }

        // DELETE: api/BookingsViews/5
        [ResponseType(typeof(BookingsView))]
        public IHttpActionResult DeleteBookingsView(int id)
        {
            BookingsView bookingsView = db.BookingsViews.Find(id);
            if (bookingsView == null)
            {
                return NotFound();
            }

            db.BookingsViews.Remove(bookingsView);
            db.SaveChanges();

            return Ok(bookingsView);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BookingsViewExists(int id)
        {
            return db.BookingsViews.Count(e => e.BookingId == id) > 0;
        }
    }
}