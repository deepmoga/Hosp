using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Admin2.Models;
using Hospoital_app.Models;

namespace Hospoital_app.Controllers
{
    public class DoctorsController : Controller
    {
        private dbcontext db = new dbcontext();

        // GET: Doctors
        public async Task<ActionResult> Index()
        {
            return View(await db.Doctors.ToListAsync());
        }

        // GET: Doctors/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doctors doctors = await db.Doctors.FindAsync(id);
            if (doctors == null)
            {
                return HttpNotFound();
            }
            return View(doctors);
        }

        // GET: Doctors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Doctors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,FirstName,LastName,Phone,UserName,Password")] Doctors doctors)
        {
            if (ModelState.IsValid)
            {
                db.Doctors.Add(doctors);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(doctors);
        }

        // GET: Doctors/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doctors doctors = await db.Doctors.FindAsync(id);
            if (doctors == null)
            {
                return HttpNotFound();
            }
            return View(doctors);
        }

        // POST: Doctors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,FirstName,LastName,Phone,UserName,Password")] Doctors doctors)
        {
            if (ModelState.IsValid)
            {
                db.Entry(doctors).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(doctors);
        }

        // GET: Doctors/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doctors doctors = await db.Doctors.FindAsync(id);
            if (doctors == null)
            {
                return HttpNotFound();
            }
            return View(doctors);
        }

        // POST: Doctors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Doctors doctors = await db.Doctors.FindAsync(id);
            db.Doctors.Remove(doctors);
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
