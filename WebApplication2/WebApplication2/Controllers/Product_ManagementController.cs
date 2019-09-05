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
    public class Product_ManagementController : Controller
    {
        private trdbEntities db = new trdbEntities();

        // GET: Product_Management
        public ActionResult Index()
        {
            return View(db.Product_Management.ToList());
        }

        // GET: Product_Management/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product_Management product_Management = db.Product_Management.Find(id);
            if (product_Management == null)
            {
                return HttpNotFound();
            }
            return View(product_Management);
        }

        // GET: Product_Management/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product_Management/Create
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、https://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,商品名,単価,販売価格,産地")] Product_Management product_Management)
        {
            if (ModelState.IsValid)
            {
                Models.Inventory_Control inventory_Control = new Inventory_Control();
                Models.Sales_Management sales_Management = new Sales_Management();
                db.Inventory_Control.Add(inventory_Control);
                db.Product_Management.Add(product_Management);
                db.Sales_Management.Add(sales_Management);

                inventory_Control.ID = product_Management.ID;
                sales_Management.ID = product_Management.ID;
                inventory_Control.商品名 = product_Management.商品名;
                sales_Management.商品名 = product_Management.商品名;
                inventory_Control.単価 = product_Management.単価;
                sales_Management.販売価格 = product_Management.販売価格;

                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product_Management);
        }

        // GET: Product_Management/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product_Management product_Management = db.Product_Management.Find(id);
            if (product_Management == null)
            {
                return HttpNotFound();
            }
            return View(product_Management);
        }

        // POST: Product_Management/Edit/5
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、https://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,商品名,単価,販売価格,産地")] Product_Management product_Management)
        {
            if (ModelState.IsValid)
            {
                db.SaveChanges();
                Models.Inventory_Control inventory_Control = new Inventory_Control();
                Models.Sales_Management sales_Management = new Sales_Management();

                db.Entry(product_Management).State = EntityState.Modified;

                inventory_Control.ID = product_Management.ID;
                sales_Management.ID = product_Management.ID;
                inventory_Control.商品名 = product_Management.商品名;
                sales_Management.商品名 = product_Management.商品名;
                inventory_Control.単価 = product_Management.単価;
                sales_Management.販売価格 = product_Management.販売価格;
                inventory_Control.総個数 = (from inventory in db.Inventory_Control
                                         where inventory.ID == product_Management.ID
                                         select inventory.総個数).Single();
                inventory_Control.総額 = (from inventory in db.Inventory_Control
                                        where inventory.ID == product_Management.ID
                                        select inventory.総額).Single();
                inventory_Control.登録日時 = (from inventory in db.Inventory_Control
                                          where inventory.ID == product_Management.ID
                                          select inventory.登録日時).Single(); 
                sales_Management.販売個数 = (from sales in db.Sales_Management
                                         where sales.ID == product_Management.ID
                                         select sales.販売個数).Single();
                sales_Management.合計金額 = (from sales in db.Sales_Management
                                         where sales.ID == product_Management.ID
                                         select sales.合計金額).Single();
                sales_Management.登録日時 = (from sales in db.Sales_Management
                                         where sales.ID == product_Management.ID
                                         select sales.登録日時).Single();

                db.Entry(inventory_Control).State = EntityState.Modified;
                db.Entry(sales_Management).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product_Management);
        }

        // GET: Product_Management/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product_Management product_Management = db.Product_Management.Find(id);
            if (product_Management == null)
            {
                return HttpNotFound();
            }
            return View(product_Management);
        }

        // POST: Product_Management/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Product_Management product_Management = db.Product_Management.Find(id);
            Inventory_Control inventory_Control = db.Inventory_Control.Find(id);
            Sales_Management sales_Management = db.Sales_Management.Find(id);
            db.Product_Management.Remove(product_Management);
            db.Inventory_Control.Remove(inventory_Control);
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
