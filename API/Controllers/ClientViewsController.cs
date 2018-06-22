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
    public class ClientViewsController : ApiController
    {
        private NewModel db = new NewModel();

        // GET: api/ClientViews
        public IQueryable<ClientView> GetClientViews()
        {
            return db.ClientViews;
        }

        // GET: api/ClientViews/5
        [ResponseType(typeof(ClientView))]
        public IHttpActionResult GetClientView(int id)
        {
            ClientView clientView = db.ClientViews.Find(id);
            if (clientView == null)
            {
                return NotFound();
            }

            return Ok(clientView);
        }

        // PUT: api/ClientViews/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutClientView(int id, ClientView clientView)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != clientView.ClientId)
            {
                return BadRequest();
            }

            db.Entry(clientView).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientViewExists(id))
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

        // POST: api/ClientViews
        [ResponseType(typeof(ClientView))]
        public IHttpActionResult PostClientView(ClientView clientView)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ClientViews.Add(clientView);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ClientViewExists(clientView.ClientId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = clientView.ClientId }, clientView);
        }

        // DELETE: api/ClientViews/5
        [ResponseType(typeof(ClientView))]
        public IHttpActionResult DeleteClientView(int id)
        {
            ClientView clientView = db.ClientViews.Find(id);
            if (clientView == null)
            {
                return NotFound();
            }

            db.ClientViews.Remove(clientView);
            db.SaveChanges();

            return Ok(clientView);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ClientViewExists(int id)
        {
            return db.ClientViews.Count(e => e.ClientId == id) > 0;
        }
    }
}