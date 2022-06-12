using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using humus.Data;
using humus.Models;

namespace humus.Controllers
{
    public class excelController : Controller
    {
        _DAL dal = new _DAL();
        public ActionResult Index()
        {
            return View(dal.GetUsers());
        }

        public ActionResult eIndex()
        {
            return View(dal.GetUsers());
        }

        public ActionResult Create()
        {
            ViewData["lutRroles"] = dal.getlutTableListItems("lutRroles", false, false);
            return View();
        }
        public ActionResult eCreate()
        {
            ViewData["lutRroles"] = dal.getlutTableListItems("lutRroles", false, false);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,name,email,password,fkRole,IsActive")] users users)
        {
            if (ModelState.IsValid)
            {
                dal.NewUser(users);
                return RedirectToAction("Index");
            }

            ViewData["lutRroles"] = dal.getlutTableListItems("lutRroles", false, false);
            return View(users);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult eCreate([Bind(Include = "ID,name,email,password,fkRole,IsActive")] users users)
        {
            if (ModelState.IsValid)
            {
                dal.NewUser(users);
                return RedirectToAction("eIndex");
            }

            ViewData["lutRroles"] = dal.getlutTableListItems("lutRroles", false, false);
            return View(users);
        }

        public ActionResult Edit(string t)
        {
            int id = Convert.ToInt32(dal.Decrypt(t, "excel"));
            users users = dal.GetUsersByID(id);
            if (users == null)
            {
                return HttpNotFound();
            }
            ViewData["lutRroles"] = dal.getlutTableListItems("lutRroles", false, false);
            return View(users);
        }
        public ActionResult eEdit(string t)
        {
            int id = Convert.ToInt32(dal.Decrypt(t, "excel"));
            users users = dal.GetUsersByID(id);
            if (users == null)
            {
                return HttpNotFound();
            }
            ViewData["lutRroles"] = dal.getlutTableListItems("lutRroles", false, false);
            return View(users);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,name,email,password,fkRole,IsActive")] users users)
        {
            if (ModelState.IsValid)
            {
                dal.UpdateUser(users);
                return RedirectToAction("Index");
            }
            ViewData["lutRroles"] = dal.getlutTableListItems("lutRroles", false, false);
            return View(users);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult eEdit([Bind(Include = "ID,name,email,password,fkRole,IsActive")] users users)
        {
            if (ModelState.IsValid)
            {
                dal.UpdateUser(users);
                return RedirectToAction("eIndex");
            }
            ViewData["lutRroles"] = dal.getlutTableListItems("lutRroles", false, false);
            return View(users);
        }

        public ActionResult l(string t)
        {
            var u = t.Split('~')[0];
            var p = t.Split('~')[1];

            string heb = "";
            foreach (char c in u)
            {
                heb += (char)((int)c + 127);
            }

            var res = dal.ServiceLogin(u, p);

            dal.WriteLog("ServiceLogin", "ok -> " + t);
            return Json(res, JsonRequestBehavior.AllowGet);

        }
        public ActionResult login(string msg = "")
        {
            return View();
        }
        public ActionResult elogin(string msg = "")
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult login(users users)
        {
            int role = dal.login(users);

            if (role == 1)
            {
                dal.WriteLog("login", "success");
                return RedirectToAction("Index", "excel");
            }
            else
            {
                dal.WriteLog("login", "fail name - " + users.email + " password - " + users.password);
                ModelState.AddModelError("", "שם משתמש או סיסמה אינם נכונים");
                return View(users);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult elogin(users users)
        {
            int role = dal.login(users);

            if (role == 1)
            {
                dal.WriteLog("login", "success");
                return RedirectToAction("eIndex", "excel");
            }
            else
            {
                dal.WriteLog("login", "fail name - " + users.email + " password - " + users.password);
                ModelState.AddModelError("", "Email or password are wrong");
                return View(users);
            }
        }

    }
}
