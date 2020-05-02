using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using QLNS.Models;

namespace QLNS.Controllers
{
    public class OrganizationsController : Controller
    {
        private QuanLyNhanSuEntities db = new QuanLyNhanSuEntities();

        // GET: Organizations
        public ActionResult Index(int PageIndex = 1, string TextSearch = "")
        {
            IQueryable<Organization> data = db.Organizations;
            ViewBag.TextSearch = "";
            // nếu có dữ liệu truyền vào TextSearch, tìm kiếm theo UserName 
            if (!string.IsNullOrEmpty(TextSearch))
            {
                ViewBag.TextSearch = TextSearch;
                data = data.Where(n => n.OrganizationName.Contains(TextSearch) || n.OrganizationCode.Contains(TextSearch));
            }
            ViewBag.status = Common.Common.GetStatuses;
            // phân trang
            var list = data.OrderByDescending(n => n.OrganizationId).ToPagedList(PageIndex, 10);
            return View(list);
        }

        // GET: Organizations/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Organization organization = db.Organizations.Find(id);
            var statuses = Common.Common.GetStatuses;
            ViewBag.status = Common.Common.GetStatuses.FirstOrDefault(n => n.StatusId == organization.IsActive);
            if (organization == null)
            {
                return HttpNotFound();
            }
            return View(organization);
        }

        // GET: Organizations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Organizations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrganizationId,OrganizationCode,OrganizationName,EffectiveStartDate,EffectiveEndDate,Address,IsActive,CreatedAt,UpdatedAt")] Organization organization)
        {
            if (ModelState.IsValid)
            {
                organization.CreatedAt = DateTime.Now;
                organization.UpdatedAt = DateTime.Now;
                organization.IsActive = 1;
                db.Organizations.Add(organization);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(organization);
        }

        // GET: Organizations/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Organization organization = db.Organizations.Find(id);
            var statuses = Common.Common.GetStatuses;
            var status = Common.Common.GetStatuses.FirstOrDefault(n => n.StatusId == organization.IsActive);
            ViewBag.statuses = new SelectList(statuses, "StatusId", "StatusName");
            
            if (organization == null)
            {
                return HttpNotFound();
            }
            return View(organization);
        }

        // POST: Organizations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrganizationId,OrganizationCode,OrganizationName,EffectiveStartDate,EffectiveEndDate,Address,IsActive,CreatedAt,UpdatedAt")] Organization organization)
        {
            if (ModelState.IsValid)
            {
                organization.UpdatedAt = DateTime.Now;
                db.Entry(organization).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(organization);
        }

        // GET: Organizations/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Organization organization = db.Organizations.Find(id);
            var statuses = Common.Common.GetStatuses;
            ViewBag.status = Common.Common.GetStatuses.FirstOrDefault(n => n.StatusId == organization.IsActive);
            if (organization == null)
            {
                return HttpNotFound();
            }
            return View(organization);
        }

        // POST: Organizations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Organization organization = db.Organizations.Find(id);
            db.Organizations.Remove(organization);
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
