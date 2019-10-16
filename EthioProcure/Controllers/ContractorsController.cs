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
    public class ContractorsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Contractors
        public ActionResult Index()
        {
            return View("IndexOthers", db.contr.ToList());
        }

        // GET: Contractors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contractor contractor = (Contractor)db.org.Find(id);
            if (contractor == null)
            {
                return HttpNotFound();
            }
            ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());

            if ((User.IsInRole(RoleName.contractor) && (contractor.organizationName==user.orgName)) || User.IsInRole(RoleName.admin))
                return View("DetailsContractor", contractor);
            return View("DetailsOthers", contractor);
            
        }

        [HttpGet]
        [Route("Contractors/download/{fileName}/{id?}")]
        public FileResult download(String fileName, int? id)
        {
            var contractor = (Contractor)db.org.SingleOrDefault(c => c.OrganizationId == id);

            if (fileName == "bl")
                return File(contractor.businessLicence, "application/txt", contractor.blName);
            else if (fileName == "coc")
                return File(contractor.certificateOfCompetency, "application/txt", contractor.cocName);
            else if (fileName == "ar")
                return File(contractor.auditReport, "application/txt", contractor.arName);
            else if (fileName == "mc")
                return File(contractor.machinaryCertificate, "application/txt", contractor.mcName);
            else if (fileName == "sc")
                return File(contractor.staffCV, "application/txt", contractor.scName);
            else if (fileName=="pl") 
                return File(contractor.performanceletter, "application/txt", contractor.plName);
            else if (fileName == "tc")
                return File(contractor.taxClearance, "application/txt", contractor.taxClrName);
            else if (fileName == "vr")
                return File(contractor.vatRegistration, "application/txt", contractor.vatRagName);
            else if (fileName == "fr")
                return File(contractor.fppaReg, "application/txt", contractor.fppaRegName);
            else
                return File(contractor.tinReg, "application/txt", contractor.tinName);
        }

        // GET: Contractors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Contractors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(
            HttpPostedFileBase logoFile,
            HttpPostedFileBase blFile,
            HttpPostedFileBase cocFile,
            HttpPostedFileBase arFile,
            HttpPostedFileBase mcFile,
            HttpPostedFileBase scvFile,
            HttpPostedFileBase plFile,
            HttpPostedFileBase trFile,
            HttpPostedFileBase osFile,
            HttpPostedFileBase tcFile,
            HttpPostedFileBase vrFile,
            HttpPostedFileBase frFile,
            [Bind(Include = "OrganizationId,organizationName,logo,logoName,description,email,telephone,tinReg,tinName,businessLicence,blName,orgStruct,orgStrName,contractorLevel,annualTurnover,contractorType,certificateOfCompetency,cocName, auditReport,arName,machinaryCertificate,mcName,staffCV,scName,performanceletter,plName,taxClearance,taxClrName,vatRegistration,vatRegName,fppaReg,fppaRegName,machEquipTable,empTable")] Contractor contractor)
        {
            BinaryReader br1 = new BinaryReader(logoFile.InputStream);
            contractor.logo = br1.ReadBytes(logoFile.ContentLength);
            contractor.logoName = logoFile.FileName;
            
            br1 = new BinaryReader(blFile.InputStream);
            contractor.businessLicence = br1.ReadBytes(blFile.ContentLength);
            contractor.blName = blFile.FileName;

            br1 = new BinaryReader(cocFile.InputStream);
            contractor.certificateOfCompetency = br1.ReadBytes(cocFile.ContentLength);
            contractor.cocName = cocFile.FileName;

            br1 = new BinaryReader(arFile.InputStream);
            contractor.auditReport = br1.ReadBytes(arFile.ContentLength);
            contractor.arName = arFile.FileName;

            br1 = new BinaryReader(mcFile.InputStream);
            contractor.machinaryCertificate = br1.ReadBytes(mcFile.ContentLength);
            contractor.mcName = mcFile.FileName;

            br1 = new BinaryReader(scvFile.InputStream);
            contractor.staffCV = br1.ReadBytes(scvFile.ContentLength);
            contractor.scName = scvFile.FileName;

            br1 = new BinaryReader(trFile.InputStream);
            contractor.tinReg = br1.ReadBytes(trFile.ContentLength);
            contractor.tinName = trFile.FileName;

            br1 = new BinaryReader(plFile.InputStream);
            contractor.performanceletter = br1.ReadBytes(plFile.ContentLength);
            contractor.plName = plFile.FileName;

            br1 = new BinaryReader(osFile.InputStream);
            contractor.orgStruct = br1.ReadBytes(osFile.ContentLength);
            contractor.orgStrName = osFile.FileName;

            br1 = new BinaryReader(tcFile.InputStream);
            contractor.taxClearance = br1.ReadBytes(tcFile.ContentLength);
            contractor.taxClrName = tcFile.FileName;

            br1 = new BinaryReader(vrFile.InputStream);
            contractor.vatRegistration = br1.ReadBytes(vrFile.ContentLength);
            contractor.vatRagName = vrFile.FileName;

            br1 = new BinaryReader(frFile.InputStream);
            contractor.fppaReg = br1.ReadBytes(frFile.ContentLength);
            contractor.fppaRegName= frFile.FileName;

            if (ModelState.IsValid)
            {

                db.org.Add(contractor);
                db.SaveChanges();
                return RedirectToAction("Register", "Account", 
                    new
                    {
                        orgName = contractor.organizationName,
                        role = RoleName.contractor
                    });
                //Html.ActionLink("Register", "Register", "Account", routeValues: null, htmlAttributes: new { id = "registerLink" })
            }

            return View(contractor);
        }

        
        // GET: Contractors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contractor contractor = (Contractor)db.org.Find(id);
            if (contractor == null)
            {
                return HttpNotFound();
            }
            return View(contractor);
        }

        // POST: Contractors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(
            HttpPostedFileBase logoFile,
            HttpPostedFileBase blFile,
            HttpPostedFileBase cocFile,
            HttpPostedFileBase arFile,
            HttpPostedFileBase mcFile,
            HttpPostedFileBase scvFile,
            HttpPostedFileBase plFile,
            HttpPostedFileBase trFile,
            HttpPostedFileBase osFile,
            HttpPostedFileBase tcFile,
            HttpPostedFileBase vrFile,
            HttpPostedFileBase frFile,
            [Bind(Include = "OrganizationId,organizationName,logo,logoName,description,email,telephone,tinReg,tinName,businessLicence,blName,orgStruct,orgStrName,contractorLevel,annualTurnover,contractorType,certificateOfCompetency,cocName, auditReport,arName,machinaryCertificate,mcName,staffCV,scName,performanceletter,plName,taxClearance,taxClrName,vatRegistration,vatRegName,fppaReg,fppaRegName,machEquipTable,empTable")] Contractor contractor)
        {
            BinaryReader br1 = new BinaryReader(logoFile.InputStream);
            contractor.logo = br1.ReadBytes(logoFile.ContentLength);
            contractor.logoName = logoFile.FileName;

            br1 = new BinaryReader(blFile.InputStream);
            contractor.businessLicence = br1.ReadBytes(blFile.ContentLength);
            contractor.blName = blFile.FileName;

            br1 = new BinaryReader(cocFile.InputStream);
            contractor.certificateOfCompetency = br1.ReadBytes(cocFile.ContentLength);
            contractor.cocName = cocFile.FileName;

            br1 = new BinaryReader(arFile.InputStream);
            contractor.auditReport = br1.ReadBytes(arFile.ContentLength);
            contractor.arName = arFile.FileName;

            br1 = new BinaryReader(mcFile.InputStream);
            contractor.machinaryCertificate = br1.ReadBytes(mcFile.ContentLength);
            contractor.mcName = mcFile.FileName;

            br1 = new BinaryReader(scvFile.InputStream);
            contractor.staffCV = br1.ReadBytes(scvFile.ContentLength);
            contractor.scName = scvFile.FileName;

            br1 = new BinaryReader(trFile.InputStream);
            contractor.tinReg = br1.ReadBytes(trFile.ContentLength);
            contractor.tinName = trFile.FileName;

            br1 = new BinaryReader(plFile.InputStream);
            contractor.performanceletter = br1.ReadBytes(plFile.ContentLength);
            contractor.plName = plFile.FileName;

            br1 = new BinaryReader(osFile.InputStream);
            contractor.orgStruct = br1.ReadBytes(osFile.ContentLength);
            contractor.orgStrName = osFile.FileName;

            br1 = new BinaryReader(tcFile.InputStream);
            contractor.taxClearance = br1.ReadBytes(tcFile.ContentLength);
            contractor.taxClrName = tcFile.FileName;

            br1 = new BinaryReader(vrFile.InputStream);
            contractor.vatRegistration = br1.ReadBytes(vrFile.ContentLength);
            contractor.vatRagName = vrFile.FileName;

            br1 = new BinaryReader(frFile.InputStream);
            contractor.fppaReg = br1.ReadBytes(frFile.ContentLength);
            contractor.fppaRegName = frFile.FileName;

            if (ModelState.IsValid)
            {
                db.Entry(contractor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contractor);
        }

        [Authorize(Roles = "RoleName.admin, RoleName.contractor")]
        // GET: Contractors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contractor contractor = (Contractor)db.org.Find(id);
            if (contractor == null)
            {
                return HttpNotFound();
            }
            return View(contractor);
        }

        // POST: Contractors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Contractor contractor = (Contractor)db.org.Find(id);
            db.org.Remove(contractor);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        
        public ActionResult getLogo( int id)
        {
            Contractor contractor = (Contractor)db.org.Find(id);
            return File(contractor.logo, "image/jpg");
            //else
              //  return File(contractor.orgStruct, "image/jpg");
        }

        public ActionResult getOrgStruct(int id)
        {
            Contractor contractor = (Contractor)db.org.Find(id);
            return File(contractor.orgStruct, "image/jpg");
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
