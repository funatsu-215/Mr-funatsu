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
    public class Sales_ManagementController : Controller
    {
        private trdbEntities db = new trdbEntities();

        // GET: Sales_Management
        public ActionResult Index()
        {
            return View(db.Sales_Management.ToList());
        }

        // GET: Sales_Management/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sales_Management sales_Management = db.Sales_Management.Find(id);
            if (sales_Management == null)
            {
                return HttpNotFound();
            }
            return View(sales_Management);
        }

        // GET: Sales_Management/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sales_Management/Create
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、https://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,商品名,販売価格,販売個数,合計金額,登録日時")] Sales_Management sales_Management)
        {
            if (ModelState.IsValid)
            {
                db.Sales_Management.Add(sales_Management);
                sales_Management.ID = (from sales in db.Product_Management
                                       where sales.ID == sales_Management.ID
                                       select sales.ID).Single();
                sales_Management.商品名 = (from sales in db.Product_Management
                                        where sales.ID == sales_Management.ID
                                        select sales.商品名).Single();
                sales_Management.販売価格 = (from sales in db.Product_Management
                                         where sales.ID == sales_Management.ID
                                         select sales.販売価格).Single();
                sales_Management.合計金額 = sales_Management.販売価格 * sales_Management.販売個数;
                sales_Management.登録日時 = DateTime.Now;

                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sales_Management);
        }

        // GET: Sales_Management/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sales_Management sales_Management = db.Sales_Management.Find(id);
            if (sales_Management == null)
            {
                return HttpNotFound();
            }
            return View(sales_Management);
        }

        // POST: Sales_Management/Edit/5
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、https://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,商品名,販売価格,販売個数,合計金額,登録日時")] Sales_Management sales_Management)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sales_Management).State = EntityState.Modified;

                sales_Management.ID = (from sales in db.Product_Management
                                       where sales.ID == sales_Management.ID
                                       select sales.ID).Single();
                sales_Management.商品名 = (from sales in db.Product_Management
                                        where sales.ID == sales_Management.ID
                                        select sales.商品名).Single();
                sales_Management.販売価格 = (from sales in db.Product_Management
                                         where sales.ID == sales_Management.ID
                                         select sales.販売価格).Single();
                sales_Management.合計金額 = sales_Management.販売価格 * sales_Management.販売個数;
                sales_Management.登録日時 = DateTime.Now;

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sales_Management);
        }

        // GET: Sales_Management/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sales_Management sales_Management = db.Sales_Management.Find(id);
            if (sales_Management == null)
            {
                return HttpNotFound();
            }
            return View(sales_Management);
        }

        // POST: Sales_Management/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Sales_Management sales_Management = db.Sales_Management.Find(id);
            db.Sales_Management.Remove(sales_Management);
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
