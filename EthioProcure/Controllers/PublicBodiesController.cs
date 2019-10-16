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
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace EthioProcure.Controllers
{
    public class PublicBodiesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PublicBodies
        public ActionResult Index()
        {
            return View("IndexOthers", db.pubo.ToList());
        }

        // GET: PublicBodies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PublicBody publicBody = (PublicBody)db.org.Find(id);
            if (publicBody == null)
            {
                return HttpNotFound();
            }
            ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());

            if ((User.IsInRole(RoleName.publicBody) && (publicBody.organizationName==user.orgName)) || User.IsInRole(RoleName.admin))
                return View("DetailsPublicBody", publicBody);
            return View("DetailsOthers", publicBody);
            
        }

        [HttpGet]
        [Route("PublicBodies/download/{fileName}/{id?}")]
        public FileResult download(String fileName,int? id)
        {
            var publicbody = (PublicBody)db.org.SingleOrDefault(c => c.OrganizationId == id);
            if(fileName=="pc")
                return File(publicbody.publicCertificate, "application/txt", publicbody.pcName);
            else
                return File(publicbody.logo, "application/txt", publicbody.logoName);

        }

        // GET: PublicBodies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PublicBodies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(
            String signature,
            HttpPostedFileBase pcFile,
            HttpPostedFileBase logoFile,
            [Bind(Include = "OrganizationId,organizationName,logo,logoName,description,email,telephone,publicCertificate,pcName")] PublicBody publicBody)
        {
            BinaryReader br = new BinaryReader(logoFile.InputStream);
            publicBody.logo = br.ReadBytes(logoFile.ContentLength);
            publicBody.logoName = logoFile.FileName;

            br = new BinaryReader(pcFile.InputStream);
            publicBody.publicCertificate = br.ReadBytes(pcFile.ContentLength);
            publicBody.pcName = pcFile.FileName;

            DigitalSignature ds = new DigitalSignature();
            bool verify = ds.verifyPbCert(publicBody.publicCertificate, signature);
            
            if(verify == true)
            {
                if (ModelState.IsValid)
                {
                    db.org.Add(publicBody);
                    db.SaveChanges();
                    return RedirectToAction("Register", "Account",
                    new
                    {
                        orgName = publicBody.organizationName,
                        role = RoleName.publicBody
                    });
                }
            }
            
            ViewBag.ver = "File could not be verified";
            return View(publicBody);
        }

        
        // GET: PublicBodies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PublicBody publicBody = (PublicBody)db.org.Find(id);
            if (publicBody == null)
            {
                return HttpNotFound();
            }
            return View(publicBody);
        }

        // POST: PublicBodies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(
            HttpPostedFileBase pcFile,
            HttpPostedFileBase logoFile,
            [Bind(Include = "OrganizationId,organizationName,logo,logoName,description,email,telephone,publicCertificate,pcName")] PublicBody publicBody)
        {
            BinaryReader br = new BinaryReader(logoFile.InputStream);
            publicBody.logo = br.ReadBytes(logoFile.ContentLength);
            publicBody.logoName = logoFile.FileName;

            br = new BinaryReader(pcFile.InputStream);
            publicBody.publicCertificate = br.ReadBytes(pcFile.ContentLength);
            publicBody.pcName = pcFile.FileName;

            if (ModelState.IsValid)
            {
                db.Entry(publicBody).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(publicBody);
        }

        [Authorize(Roles = "RoleName.admin, RoleName.publicBody")]
        // GET: PublicBodies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PublicBody publicBody = (PublicBody)db.org.Find(id);
            if (publicBody == null)
            {
                return HttpNotFound();
            }
            return View(publicBody);
        }

        // POST: PublicBodies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PublicBody publicBody = (PublicBody)db.org.Find(id);
            db.org.Remove(publicBody);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult getImage(int id)
        {
            PublicBody publicbody = (PublicBody)db.org.Find(id);
            return File(publicbody.logo, "image/jpg");
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
