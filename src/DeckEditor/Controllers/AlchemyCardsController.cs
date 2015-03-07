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
    public class AlchemyCardsController : Controller
    {
        private readonly CardDesignEntities _db = new CardDesignEntities();

        // GET: AlchemyCards
        public async Task<ActionResult> Index()
        {
            var alchemyCards = _db.AlchemyCards.Include(a => a.AlchemyElement).Include(a => a.AlchemyRank);
            return View(await alchemyCards.ToListAsync());
        }

        // GET: AlchemyCards/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            AlchemyCard alchemyCard = await _db.AlchemyCards.FindAsync(id);
            if (alchemyCard == null)
            {
                return HttpNotFound();
            }
            return View(alchemyCard);
        }

        // GET: AlchemyCards/Create
        public ActionResult Create()
        {
            ViewBag.Element = new SelectList(_db.AlchemyElements, "Id", "Name");
            ViewBag.Rank = new SelectList(_db.AlchemyRanks, "Id", "Name");
            return View();
        }

        // POST: AlchemyCards/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Element,Name,VictoryPoints,Rank,Costs")] AlchemyCard alchemyCard)
        {
            if (ModelState.IsValid)
            {
                _db.AlchemyCards.Add(alchemyCard);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.Element = new SelectList(_db.AlchemyElements, "Id", "Name", alchemyCard.Element);
            ViewBag.Rank = new SelectList(_db.AlchemyRanks, "Id", "Name", alchemyCard.Rank);
            return View(alchemyCard);
        }

        // GET: AlchemyCards/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            AlchemyCard alchemyCard = await _db.AlchemyCards.FindAsync(id);
            if (alchemyCard == null)
            {
                return HttpNotFound();
            }
            ViewBag.Element = new SelectList(_db.AlchemyElements, "Id", "Name", alchemyCard.Element);
            ViewBag.Rank = new SelectList(_db.AlchemyRanks, "Id", "Name", alchemyCard.Rank);
            return View(alchemyCard);
        }

        // POST: AlchemyCards/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Element,Name,VictoryPoints,Rank,Costs")] AlchemyCard alchemyCard)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(alchemyCard).State = EntityState.Modified;
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Element = new SelectList(_db.AlchemyElements, "Id", "Name", alchemyCard.Element);
            ViewBag.Rank = new SelectList(_db.AlchemyRanks, "Id", "Name", alchemyCard.Rank);
            return View(alchemyCard);
        }

        // GET: AlchemyCards/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            AlchemyCard alchemyCard = await _db.AlchemyCards.FindAsync(id);
            if (alchemyCard == null)
            {
                return HttpNotFound();
            }
            return View(alchemyCard);
        }

        // POST: AlchemyCards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            AlchemyCard alchemyCard = await _db.AlchemyCards.FindAsync(id);
            _db.AlchemyCards.Remove(alchemyCard);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
