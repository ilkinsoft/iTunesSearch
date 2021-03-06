﻿using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using iTunesSearch.Models;
using System.Web.Helpers;

namespace iTunesSearch.Controllers
{
    public class InteractionsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Interactions
        public async Task<ActionResult> Index()
        {
            var interactions = db.Interactions
                .GroupBy(i => i.ClickedAdUrl)
                .Select(group => new GroupedInteraction
                {
                    ClickedAdUrl = group.Key,
                    ClickCount = group.Count()
                })
                .OrderByDescending(i => i.ClickCount);

            return View(await interactions.ToListAsync());
        }
        public async Task<ActionResult> Detailed()
        {
            var interactions = db.Interactions.Include(i => i.User);
            return View(await interactions.ToListAsync());
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
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "UserId,ClickedAdUrl,InteractionTime,DeviceName,IpAddress,ScreenSize")] Interaction interaction)
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

        public string DrawChart()
        {
            var interactions = db.Interactions
                .GroupBy(i => i.ClickedAdUrl)
                .Select(group => new GroupedInteraction
                {
                    ClickedAdUrl = group.Key,
                    ClickCount = group.Count()
                })
                .OrderByDescending(i => i.ClickCount);

            var myChart = new Chart(width: 600, height: 400, theme: ChartTheme.Vanilla3D)
                .AddTitle("User Interactions")
                .AddSeries(
                    chartType: "pie",
                    name: "Interactions",
                    xValue: interactions.Select(i => i.ClickedAdUrl).ToArray(),
                    yValues: interactions.Select(i => i.ClickCount).ToArray()
                    ).GetBytes("jpeg");

            return System.Convert.ToBase64String(myChart);
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
