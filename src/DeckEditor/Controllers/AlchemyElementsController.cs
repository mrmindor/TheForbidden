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
    public class AlchemyElementsController : Controller
    {
        private readonly CardDesignEntities _db = new CardDesignEntities();

        // GET: AlchemyElements
        public async Task<ActionResult> Index()
        {
            return View(await _db.AlchemyElements.ToListAsync());
        }

        // GET: AlchemyElements/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AlchemyElement alchemyElement = await _db.AlchemyElements.FindAsync(id);
            if (alchemyElement == null)
            {
                return HttpNotFound();
            }
            return View(alchemyElement);
        }

        // GET: AlchemyElements/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AlchemyElements/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,Initial,StrokeColor,FillColor")] AlchemyElement alchemyElement)
        {
            if (ModelState.IsValid)
            {
                _db.AlchemyElements.Add(alchemyElement);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(alchemyElement);
        }

        // GET: AlchemyElements/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AlchemyElement alchemyElement = await _db.AlchemyElements.FindAsync(id);
            if (alchemyElement == null)
            {
                return HttpNotFound();
            }
            return View(alchemyElement);
        }

        // POST: AlchemyElements/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Initial,StrokeColor,FillColor")] AlchemyElement alchemyElement)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(alchemyElement).State = EntityState.Modified;
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(alchemyElement);
        }

        // GET: AlchemyElements/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AlchemyElement alchemyElement = await _db.AlchemyElements.FindAsync(id);
            if (alchemyElement == null)
            {
                return HttpNotFound();
            }
            return View(alchemyElement);
        }

        // POST: AlchemyElements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            AlchemyElement alchemyElement = await _db.AlchemyElements.FindAsync(id);
            _db.AlchemyElements.Remove(alchemyElement);
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
