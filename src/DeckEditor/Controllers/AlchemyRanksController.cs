using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Model;

namespace DeckEditor.Controllers
{
    public class AlchemyRanksController : Controller
    {
        private CardDesignEntities db = new CardDesignEntities();

        // GET: AlchemyRanks
        public async Task<ActionResult> Index()
        {
            return View(await db.AlchemyRanks.ToListAsync());
        }

        // GET: AlchemyRanks/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AlchemyRank alchemyRank = await db.AlchemyRanks.FindAsync(id);
            if (alchemyRank == null)
            {
                return HttpNotFound();
            }
            return View(alchemyRank);
        }

        // GET: AlchemyRanks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AlchemyRanks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,ShortName")] AlchemyRank alchemyRank)
        {
            if (ModelState.IsValid)
            {
                db.AlchemyRanks.Add(alchemyRank);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(alchemyRank);
        }

        // GET: AlchemyRanks/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AlchemyRank alchemyRank = await db.AlchemyRanks.FindAsync(id);
            if (alchemyRank == null)
            {
                return HttpNotFound();
            }
            return View(alchemyRank);
        }

        // POST: AlchemyRanks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,ShortName")] AlchemyRank alchemyRank)
        {
            if (ModelState.IsValid)
            {
                db.Entry(alchemyRank).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(alchemyRank);
        }

        // GET: AlchemyRanks/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AlchemyRank alchemyRank = await db.AlchemyRanks.FindAsync(id);
            if (alchemyRank == null)
            {
                return HttpNotFound();
            }
            return View(alchemyRank);
        }

        // POST: AlchemyRanks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            AlchemyRank alchemyRank = await db.AlchemyRanks.FindAsync(id);
            db.AlchemyRanks.Remove(alchemyRank);
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
