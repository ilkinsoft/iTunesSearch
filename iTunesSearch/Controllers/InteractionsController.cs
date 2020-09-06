using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using iTunesSearch.Models;

namespace iTunesSearch.Controllers
{
    public class InteractionsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Interactions
        public async Task<ActionResult> Index()
        {
            var interactions = db.Interactions.Include(i => i.User);
            return View(await interactions.ToListAsync());
        }

        // GET: Interactions/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Interaction interaction = await db.Interactions.FindAsync(id);
            if (interaction == null)
            {
                return HttpNotFound();
            }
            return View(interaction);
        }

        // GET: Interactions/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email");
            return View();
        }

        // POST: Interactions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "UserId,ClickedAdUrl,InteractionTime,DeviceName,ScreenSize")] Interaction interaction)
        {
            if (ModelState.IsValid)
            {
                db.Interactions.Add(interaction);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.Users, "Id", "Email", interaction.UserId);
            return View(interaction);
        }

        // GET: Interactions/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Interaction interaction = await db.Interactions.FindAsync(id);
            if (interaction == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email", interaction.UserId);
            return View(interaction);
        }

        // POST: Interactions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "UserId,ClickedAdUrl,InteractionTime,DeviceName,ScreenSize")] Interaction interaction)
        {
            if (ModelState.IsValid)
            {
                db.Entry(interaction).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email", interaction.UserId);
            return View(interaction);
        }

        // GET: Interactions/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Interaction interaction = await db.Interactions.FindAsync(id);
            if (interaction == null)
            {
                return HttpNotFound();
            }
            return View(interaction);
        }

        // POST: Interactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            Interaction interaction = await db.Interactions.FindAsync(id);
            db.Interactions.Remove(interaction);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
