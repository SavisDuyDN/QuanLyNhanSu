using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QLNS.Models;
using PagedList;
using QLNS.Common;

namespace QLNS.Controllers
{
    public class UsersController : Controller
    {
        private QuanLyNhanSuEntities db = new QuanLyNhanSuEntities();

        // GET: Users
        public ActionResult Index(int PageIndex = 1, string TextSearch = "")
        {
            IQueryable<User> data = db.Users;
            ViewBag.TextSearch = "";
            // nếu có dữ liệu truyền vào TextSearch, tìm kiếm theo UserName 
            if (!string.IsNullOrEmpty(TextSearch))
            {
                ViewBag.TextSearch = TextSearch;
                data = data.Where(n => n.Username.Contains(TextSearch));
            }
            // phân trang
            var list = data.OrderByDescending(n => n.UserId).ToPagedList(PageIndex, 10);
            return View(list);
        }

        // GET: Users/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            var roles = Common.Common.GetRoles;
            ViewBag.Roles = roles;
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserId,Username,Password,Role")] User user)
        {
            if (ModelState.IsValid)
            {
                var us = db.Users.FirstOrDefault(n => n.Username == user.Username);
                if(us != null)
                {
                    ViewBag.Roles = Common.Common.GetRoles;
                    ModelState.AddModelError("", "Tài khoản đã tồn tại !");
                    return View();
                }
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.Roles = Common.Common.GetRoles;
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserId,Username,Password,Role")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            var roles = Common.Common.GetRoles;
            if (user == null)
            {
                return HttpNotFound();
            }
            var role = roles.Where(n => n.Id == user.Role).FirstOrDefault();
            ViewBag.Role = role ?? new Role();
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
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
