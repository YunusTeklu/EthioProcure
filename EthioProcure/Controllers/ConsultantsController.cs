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
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;

namespace EthioProcure.Controllers
{
    public class ConsultantsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Consultants
        public ActionResult Index()
        {
            return View("IndexOthers", db.cons.ToList());
        }

        // GET: Consultants/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consultant consultant = (Consultant)db.org.Find(id);
            if (consultant == null)
            {
                return HttpNotFound();
            }
            //To find the identity of the user
            ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            
            if ((User.IsInRole(RoleName.consultant) && (consultant.organizationName==user.orgName)) || User.IsInRole(RoleName.admin))
                return View("DetailsConsultant", consultant);
            return View("DetailsOthers", consultant);
        }

        [HttpGet]
        [Route("Consultants/download/{fileName}/{id?}")]
        public FileResult download( String fileName,int? id)
        {
            var consultant = (Consultant)db.org.SingleOrDefault(c=>c.OrganizationId==id);
            
            if(fileName=="bl")
                return File(consultant.businessLicence, "application/txt", consultant.blName);
            else if(fileName=="tr")
                return File(consultant.tinReg, "application/txt", consultant.tinName);
            else
                return File(consultant.consultancyContract, "application/txt", consultant.ccname);
        }

        // GET: Consultants/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Consultants/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(
            HttpPostedFileBase logoFile,
            HttpPostedFileBase blFile,
            HttpPostedFileBase ccFile,
            HttpPostedFileBase trFile,
            [Bind(Include = "OrganizationId,organizationName,logo,logoName,description,email,telephone,tinNo,businessLicence,blName,consultancyContract,ccname, tinReg,tinName")] Consultant consultant)
        {
            BinaryReader br = new BinaryReader(logoFile.InputStream);
            consultant.logo = br.ReadBytes(logoFile.ContentLength);
            consultant.logoName = logoFile.FileName;

            br = new BinaryReader(blFile.InputStream);
            consultant.businessLicence = br.ReadBytes(blFile.ContentLength);
            consultant.blName = blFile.FileName;

            br = new BinaryReader(ccFile.InputStream);
            consultant.consultancyContract = br.ReadBytes(ccFile.ContentLength);
            consultant.ccname = ccFile.FileName;

            br = new BinaryReader(trFile.InputStream);
            consultant.tinReg = br.ReadBytes(trFile.ContentLength);
            consultant.tinName = trFile.FileName;

            if (ModelState.IsValid)
            {
                db.org.Add(consultant);
                db.SaveChanges();
                return RedirectToAction("Register", "Account",
                    new
                    {
                        orgName = consultant.organizationName,
                        role = RoleName.consultant
                    });
            }

            return View(consultant);
        }

        
        // GET: Consultants/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consultant consultant = (Consultant)db.org.Find(id);
            if (consultant == null)
            {
                return HttpNotFound();
            }
            return View(consultant);
        }

        // POST: Consultants/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(
            HttpPostedFileBase edlogoFile,
            HttpPostedFileBase edblFile,
            HttpPostedFileBase edccFile,
            HttpPostedFileBase trFile,
            [Bind(Include = "OrganizationId,organizationName,logo,logoName,description,email,telephone,tinNo,businessLicence,blName,consultancyContract,ccname, tinReg,tinName")] Consultant consultant)
        {
            BinaryReader br = new BinaryReader(edlogoFile.InputStream);
            consultant.logo = br.ReadBytes(edlogoFile.ContentLength);
            consultant.logoName = edlogoFile.FileName;

            br = new BinaryReader(edblFile.InputStream);
            consultant.businessLicence = br.ReadBytes(edblFile.ContentLength);
            consultant.blName = edblFile.FileName;

            br = new BinaryReader(edccFile.InputStream);
            consultant.consultancyContract = br.ReadBytes(edccFile.ContentLength);
            consultant.ccname = edccFile.FileName;

            br = new BinaryReader(trFile.InputStream);
            consultant.tinReg = br.ReadBytes(trFile.ContentLength);
            consultant.tinName = trFile.FileName;

            if (ModelState.IsValid)
            {
                db.Entry(consultant).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(consultant);
        }

        [Authorize(Roles = "RoleName.admin, RoleName.consultant")]
        // GET: Consultants/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consultant consultant = (Consultant)db.org.Find(id);
            if (consultant == null)
            {
                return HttpNotFound();
            }
            return View(consultant);
        }

        // POST: Consultants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Consultant consultant = (Consultant)db.org.Find(id);
            db.org.Remove(consultant);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult getImage(int id)
        {
            Consultant consultant = (Consultant)db.org.Find(id);
            return File(consultant.logo, "image/jpg");
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
