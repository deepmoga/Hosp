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
    public class HospitalDetailsController : Controller
    {
        private dbcontext db = new dbcontext();

        // GET: HospitalDetails
        public async Task<ActionResult> Index()
        {
            return View(await db.HospitalDetails.ToListAsync());
        }

        // GET: HospitalDetails/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HospitalDetails hospitalDetails = await db.HospitalDetails.FindAsync(id);
            if (hospitalDetails == null)
            {
                return HttpNotFound();
            }
            return View(hospitalDetails);
        }

        // GET: HospitalDetails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HospitalDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,HospitalName,Address,City,Zipcode,Email,Phone,Status")] HospitalDetails hospitalDetails)
        {
            if (ModelState.IsValid)
            {
                db.HospitalDetails.Add(hospitalDetails);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(hospitalDetails);
        }

        // GET: HospitalDetails/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HospitalDetails hospitalDetails = await db.HospitalDetails.FindAsync(id);
            if (hospitalDetails == null)
            {
                return HttpNotFound();
            }
            return View(hospitalDetails);
        }

        // POST: HospitalDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,HospitalName,Address,City,Zipcode,Email,Phone,Status")] HospitalDetails hospitalDetails)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hospitalDetails).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(hospitalDetails);
        }

        // GET: HospitalDetails/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HospitalDetails hospitalDetails = await db.HospitalDetails.FindAsync(id);
            if (hospitalDetails == null)
            {
                return HttpNotFound();
            }
            return View(hospitalDetails);
        }

        // POST: HospitalDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            HospitalDetails hospitalDetails = await db.HospitalDetails.FindAsync(id);
            db.HospitalDetails.Remove(hospitalDetails);
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
