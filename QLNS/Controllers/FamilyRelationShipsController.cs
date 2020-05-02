using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QLNS.Models;

namespace QLNS.Controllers
{
    public class FamilyRelationShipsController : Controller
    {
        private QuanLyNhanSuEntities db = new QuanLyNhanSuEntities();

        // GET: FamilyRelationShips
        public ActionResult Index()
        {
            return View(db.FamilyRelationShips.ToList());
        }

        // GET: FamilyRelationShips/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FamilyRelationShip familyRelationShip = db.FamilyRelationShips.Find(id);
            if (familyRelationShip == null)
            {
                return HttpNotFound();
            }
            return View(familyRelationShip);
        }

        // GET: FamilyRelationShips/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FamilyRelationShips/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FamilyRelationshipId,FamilyRelationshipName,FamilyRelationshipCode,FullName,DateOfBirth,Gender,PermanentAddress,CurrentAddress,Job,IdentityCardNumber,EmployeeId,RelativeTypeId")] FamilyRelationShip familyRelationShip)
        {
            if (ModelState.IsValid)
            {
                db.FamilyRelationShips.Add(familyRelationShip);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(familyRelationShip);
        }

        // GET: FamilyRelationShips/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FamilyRelationShip familyRelationShip = db.FamilyRelationShips.Find(id);
            if (familyRelationShip == null)
            {
                return HttpNotFound();
            }
            return View(familyRelationShip);
        }

        // POST: FamilyRelationShips/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FamilyRelationshipId,FamilyRelationshipName,FamilyRelationshipCode,FullName,DateOfBirth,Gender,PermanentAddress,CurrentAddress,Job,IdentityCardNumber,EmployeeId,RelativeTypeId")] FamilyRelationShip familyRelationShip)
        {
            if (ModelState.IsValid)
            {
                db.Entry(familyRelationShip).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(familyRelationShip);
        }

        // GET: FamilyRelationShips/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FamilyRelationShip familyRelationShip = db.FamilyRelationShips.Find(id);
            if (familyRelationShip == null)
            {
                return HttpNotFound();
            }
            return View(familyRelationShip);
        }

        // POST: FamilyRelationShips/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            FamilyRelationShip familyRelationShip = db.FamilyRelationShips.Find(id);
            db.FamilyRelationShips.Remove(familyRelationShip);
            db.SaveChanges();
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
