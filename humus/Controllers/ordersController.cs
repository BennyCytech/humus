using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using humus.Models;

namespace humus.Controllers
{
    public class ordersController : Controller
    {
        _DAL dal = new _DAL();

        // GET: orders
        public ActionResult Index()
        {
            return View(dal.Getorder());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            order order = dal.Getorder().Find(x => x.id == id);
            if (order == null)
            {
                return HttpNotFound();
            }
            ViewData["lutPaymentMethod"] = dal.getlutTableListItems("lutPaymentMethod", false, false);
            return View(order);
        }

        // GET: orders/Create
        public ActionResult NewOrder()
        {
            ViewData["lutPaymentMethod"] = dal.getlutTableListItems("lutPaymentMethod", false, false);
            //ViewData["lutHumusKind"] = dal.getlutTableListItems("lutHumusKind", false, false);
            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NewOrder(order model)
        {
            ViewData["lutPaymentMethod"] = dal.getlutTableListItems("lutPaymentMethod", false, false);

            model.OrderSum = model.HidOrderSum;
            model.OrderCount = model.HidOrderCount;
            model.KiloCount = model.HidKiloCount;

            model.KiloSum1 = model.HidKiloSum1;
            model.KiloSum2 = model.HidKiloSum2;
            model.KiloSum3 = model.HidKiloSum3;
            model.KiloSum4 = model.HidKiloSum4;
            model.KiloSum5 = model.HidKiloSum5;
            model.KiloSum6 = model.HidKiloSum6;
            model.KiloSum7 = model.HidKiloSum7;
            model.KiloSum8 = model.HidKiloSum8;
            model.KiloSum9 = model.HidKiloSum9;
            model.KiloSum10 = model.HidKiloSum10;
            model.KiloSum11 = model.HidKiloSum11;
            model.KiloSum12 = model.HidKiloSum12;
            model.KiloSum13 = model.HidKiloSum13;
            model.KiloSum14 = model.HidKiloSum14;
            model.KiloSum15 = model.HidKiloSum15;
            model.KiloSum16 = model.HidKiloSum16;
            model.KiloSum17 = model.HidKiloSum17;
            model.KiloSum18 = model.HidKiloSum18;
            model.KiloSum19 = model.HidKiloSum19;
            model.KiloSum20 = model.HidKiloSum20;
            model.KiloSum21 = model.HidKiloSum21;

            model.sum1 = model.Hidsum1;
            model.sum2 = model.Hidsum2;
            model.sum3 = model.Hidsum3;
            model.sum4 = model.Hidsum4;
            model.sum5 = model.Hidsum5;
            model.sum6 = model.Hidsum6;
            model.sum7 = model.Hidsum7;
            model.sum8 = model.Hidsum8;
            model.sum9 = model.Hidsum9;
            model.sum10 = model.Hidsum10;

            var errors = ModelState
                .Where(x => x.Value.Errors.Count > 0)
                .Select(x => new { x.Key, x.Value.Errors })
                .ToArray();
            if (ModelState.IsValid)
            {
                dal.NewUpdateorder(model, "new");
                
                string FileName = Guid.NewGuid().ToString() + ".pdf";
                DirectoryInfo directory = new DirectoryInfo(System.Web.HttpContext.Current.Server.MapPath("~/images"));

                var pdfResult = new Rotativa.PartialViewAsPdf("~/Views/orders/Details.cshtml", model)
                {
                    FileName = "Template.pdf"
                };
                var resultSet = pdfResult.BuildPdf(ControllerContext);
                if (resultSet != null)
                {
                    string path = System.IO.Path.Combine(directory.FullName, FileName);
                    System.IO.FileStream fs = new System.IO.FileStream(path, System.IO.FileMode.Create, System.IO.FileAccess.ReadWrite);
                    System.IO.BinaryWriter bw = new System.IO.BinaryWriter(fs);
                    bw.Write(resultSet);
                    bw.Close();
                }

                //new Thread(() =>
                //{
                //    mail m = new mail();
                //    m.send(model, directory, FileName);
                //}).Start();

                mail m = new mail();
                m.send(model, directory, FileName);

                return RedirectToAction("ThankYou", new { n = model.name });
            }

            return View(model);
        }
        public ActionResult ThankYou(string n)
        {
            ViewBag.n = n;
            return View();
        }

        // GET: orders/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    order order = db.orders.Find(id);
        //    if (order == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(order);
        //}

        //// POST: orders/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "id,name,phone,address,fkPaymentMethod,remarks,o10,o9,o8,o7,o6,o5,o4,o3,o2,o1,fkMana10,fkMana9,fkMana8,fkMana7,fkMana6,fkMana5,fkMana4,fkMana3,fkMana2,fkMana1,thina10,gargirim10,egg10,eggplant10,thina9,gargirim9,egg9,eggplant9,thina8,gargirim8,egg8,eggplant8,thina7,gargirim7,egg7,eggplant7,thina6,gargirim6,egg6,eggplant6,thina5,gargirim5,egg5,eggplant5,thina4,gargirim4,egg4,eggplant4,thina3,gargirim3,egg3,eggplant3,thina2,gargirim2,egg2,eggplant2,thina1,gargirim1,egg1,eggplant1,sum10,sum9,sum8,sum7,sum6,sum5,sum4,sum3,sum2,sum1,OrderCount,OrderSum")] order order)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(order).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(order);
        //}

        //// GET: orders/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    order order = db.orders.Find(id);
        //    if (order == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(order);
        //}

        //// POST: orders/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    order order = db.orders.Find(id);
        //    db.orders.Remove(order);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
