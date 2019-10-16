using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EthioProcure.Models;
using System.IO;

namespace EthioProcure.Controllers
{
    public class SuppliersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Suppliers
        public ActionResult Index()
        {
            return View(db.sup.ToList());
        }

        // GET: Suppliers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supplier supplier = (Supplier)db.org.Find(id);
            if (supplier == null)
            {
                return HttpNotFound();
            }
            return View(supplier);
        }

        [HttpGet]
        [Route("Suppliers/download/{fileName}/{id?}")]
        public FileResult download(String fileName, int? id)
        {
            var supplier = (Supplier)db.org.SingleOrDefault(c => c.OrganizationId == id);

            if (fileName == "bl")
                return File(supplier.businessLicence, "application/txt", supplier.blName);
            else
                return File(supplier.logo, "application/txt", supplier.logoName);
        }

        // GET: Suppliers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Suppliers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(
            HttpPostedFileBase logoFile,
            HttpPostedFileBase blFile,
            [Bind(Include = "OrganizationId,organizationName,logo,logoName,description,email,telephone,tinNo,businessLicence,blName,bankName,accountNo")] Supplier supplier)
        {
            BinaryReader br = new BinaryReader(logoFile.InputStream);
            supplier.logo = br.ReadBytes(logoFile.ContentLength);
            supplier.logoName = logoFile.FileName;

            br = new BinaryReader(blFile.InputStream);
            supplier.businessLicence = br.ReadBytes(blFile.ContentLength);
            supplier.blName = blFile.FileName;

            if (ModelState.IsValid)
            {
                db.org.Add(supplier);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(supplier);
        }

        // GET: Suppliers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supplier supplier = (Supplier)db.org.Find(id);
            if (supplier == null)
            {
                return HttpNotFound();
            }
            return View(supplier);
        }

        // POST: Suppliers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(
            HttpPostedFileBase logoFile,
            HttpPostedFileBase blFile,
            [Bind(Include = "OrganizationId,organizationName,logo,logoName,description,email,telephone,tinNo,businessLicence,blName,bankName,accountNo")] Supplier supplier)
        {
            BinaryReader br = new BinaryReader(logoFile.InputStream);
            supplier.logo = br.ReadBytes(logoFile.ContentLength);
            supplier.logoName = logoFile.FileName;

            br = new BinaryReader(blFile.InputStream);
            supplier.businessLicence = br.ReadBytes(blFile.ContentLength);
            supplier.blName = blFile.FileName;

            if (ModelState.IsValid)
            {
                db.Entry(supplier).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(supplier);
        }

        // GET: Suppliers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supplier supplier = (Supplier)db.org.Find(id);
            if (supplier == null)
            {
                return HttpNotFound();
            }
            return View(supplier);
        }

        // POST: Suppliers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Supplier supplier = (Supplier)db.org.Find(id);
            db.org.Remove(supplier);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult getImage(int id)
        {
            Supplier supplier = (Supplier)db.org.Find(id);
            return File(supplier.logo, "image/jpg");
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
