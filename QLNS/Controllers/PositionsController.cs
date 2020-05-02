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
    public class PositionsController : Controller
    {
        // quản lý chức vụ
        private QuanLyNhanSuEntities db = new QuanLyNhanSuEntities();

        // GET: Positions
        public ActionResult Index(int PageIndex = 1, string TextSearch = "")
        {
            IQueryable<Position> data = db.Positions;
            ViewBag.TextSearch = "";
            // nếu có dữ liệu truyền vào TextSearch, tìm kiếm theo UserName 
            if (!string.IsNullOrEmpty(TextSearch))
            {
                ViewBag.TextSearch = TextSearch;
                data = data.Where(n => n.PositionCode.Contains(TextSearch) || n.PositionName.Contains(TextSearch));
            }
            // phân trang
            var list = data.OrderByDescending(n => n.PositionId).ToPagedList(PageIndex, 10);
            return View(list);
        }

        // GET: Positions/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Position position = db.Positions.Find(id);
            var statuses = Common.Common.GetStatuses;
            ViewBag.statuses = statuses;
            ViewBag.status = statuses.FirstOrDefault(n => n.StatusId == position.IsActive);
            if (position == null)
            {
                return HttpNotFound();
            }
            return View(position);
        }

        // GET: Positions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Positions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PositionId,PositionCode,PositionName,Description,IsActive,CreatedAt,UpdatedAt")] Position position)
        {
            if (ModelState.IsValid)
            {
                // status 1 = active, 0 = not active
                position.UpdatedAt = DateTime.Now;
                position.CreatedAt = DateTime.Now;
                position.IsActive = 1;
                db.Positions.Add(position);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(position);
        }

        // GET: Positions/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var statuses = Common.Common.GetStatuses;
            Position position = db.Positions.Find(id);
            ViewBag.statuses = statuses;
            ViewBag.status = statuses.FirstOrDefault(n => n.StatusId == position.IsActive);
            if (position == null)
            {
                return HttpNotFound();
            }
            return View(position);
        }

        // POST: Positions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PositionId,PositionCode,PositionName,Description,IsActive,CreatedAt,UpdatedAt")] Position position)
        {
            if (ModelState.IsValid)
            {
                position.UpdatedAt = DateTime.Now;
                db.Entry(position).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(position);
        }

        // GET: Positions/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Position position = db.Positions.Find(id);
            if (position == null)
            {
                return HttpNotFound();
            }
            return View(position);
        }

        // POST: Positions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Position position = db.Positions.Find(id);
            db.Positions.Remove(position);
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
