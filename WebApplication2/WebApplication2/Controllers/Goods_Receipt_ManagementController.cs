using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class Goods_Receipt_ManagementController : Controller
    {
        private trdbEntities db = new trdbEntities();

        // GET: Goods_Receipt_Management
        public ActionResult Index()
        {
            return View(db.Goods_Receipt_Management.ToList());
        }

        // GET: Goods_Receipt_Management/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Goods_Receipt_Management goods_Receipt_Management = db.Goods_Receipt_Management.Find(id);
            if (goods_Receipt_Management == null)
            {
                return HttpNotFound();
            }
            return View(goods_Receipt_Management);
        }

        // GET: Goods_Receipt_Management/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Goods_Receipt_Management/Create
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、https://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,商品名,仕入価格,個数,合計金額,登録日時")] Goods_Receipt_Management goods_Receipt_Management)
        {
            if (ModelState.IsValid)
            {
                db.Goods_Receipt_Management.Add(goods_Receipt_Management);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(goods_Receipt_Management);
        }

        // GET: Goods_Receipt_Management/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Goods_Receipt_Management goods_Receipt_Management = db.Goods_Receipt_Management.Find(id);
            if (goods_Receipt_Management == null)
            {
                return HttpNotFound();
            }
            return View(goods_Receipt_Management);
        }

        // POST: Goods_Receipt_Management/Edit/5
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、https://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,商品名,仕入価格,個数,合計金額,登録日時")] Goods_Receipt_Management goods_Receipt_Management)
        {
            if (ModelState.IsValid)
            {
                db.Entry(goods_Receipt_Management).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(goods_Receipt_Management);
        }

        // GET: Goods_Receipt_Management/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Goods_Receipt_Management goods_Receipt_Management = db.Goods_Receipt_Management.Find(id);
            if (goods_Receipt_Management == null)
            {
                return HttpNotFound();
            }
            return View(goods_Receipt_Management);
        }

        // POST: Goods_Receipt_Management/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Goods_Receipt_Management goods_Receipt_Management = db.Goods_Receipt_Management.Find(id);
            db.Goods_Receipt_Management.Remove(goods_Receipt_Management);
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
