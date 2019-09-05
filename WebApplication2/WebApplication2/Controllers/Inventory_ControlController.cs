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
    public class Inventory_ControlController : Controller
    {
        private trdbEntities db = new trdbEntities();

        // GET: Inventory_Control
        public ActionResult Index()
        {
            return View(db.Inventory_Control.ToList());
        }

        // GET: Inventory_Control/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inventory_Control inventory_Control = db.Inventory_Control.Find(id);
            if (inventory_Control == null)
            {
                return HttpNotFound();
            }
            return View(inventory_Control);
        }

        // GET: Inventory_Control/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Inventory_Control/Create
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、https://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,商品名,単価,総個数,総額,登録日時")] Inventory_Control inventory_Control)
        {
            if (ModelState.IsValid)
            {
                    db.Inventory_Control.Add(inventory_Control);

                    inventory_Control.ID = (from inventory in db.Product_Management
                                            where inventory.ID == inventory_Control.ID
                                            select inventory.ID).Single();
                    inventory_Control.商品名 = (from inventory in db.Product_Management
                                             where inventory.ID == inventory_Control.ID
                                             select inventory.商品名).Single();
                    inventory_Control.単価 = (from inventory in db.Product_Management
                                            where inventory.ID == inventory_Control.ID
                                            select inventory.単価).Single();
                    inventory_Control.総額 = inventory_Control.単価 * inventory_Control.総個数;
                    inventory_Control.登録日時 = DateTime.Now;

                    db.SaveChanges();
                
                
                return RedirectToAction("Index");
            }

            return View(inventory_Control);
        }

        // GET: Inventory_Control/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inventory_Control inventory_Control = db.Inventory_Control.Find(id);
            if (inventory_Control == null)
            {
                return HttpNotFound();
            }
            return View(inventory_Control);
        }

        // POST: Inventory_Control/Edit/5
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、https://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,商品名,単価,総個数,総額,登録日時")] Inventory_Control inventory_Control)
        {
            if (ModelState.IsValid)
            { 
                db.Entry(inventory_Control).State = EntityState.Modified;

                inventory_Control.ID = (from inventory in db.Product_Management
                                        where inventory.ID == inventory_Control.ID
                                        select inventory.ID).Single();
                inventory_Control.商品名 = (from inventory in db.Product_Management
                                         where inventory.ID == inventory_Control.ID
                                         select inventory.商品名).Single();
                inventory_Control.単価 = (from inventory in db.Product_Management
                                        where inventory.ID == inventory_Control.ID
                                        select inventory.単価).Single();


                inventory_Control.総額 = inventory_Control.単価 * inventory_Control.総個数;
                inventory_Control.登録日時 = DateTime.Now;

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(inventory_Control);
        }

        // GET: Inventory_Control/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inventory_Control inventory_Control = db.Inventory_Control.Find(id);
            if (inventory_Control == null)
            {
                return HttpNotFound();
            }
            return View(inventory_Control);
        }

        // POST: Inventory_Control/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Inventory_Control inventory_Control = db.Inventory_Control.Find(id);
            db.Inventory_Control.Remove(inventory_Control);
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
