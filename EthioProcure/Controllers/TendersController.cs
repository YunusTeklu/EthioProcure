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
    public class TendersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Tenders
        public ActionResult Index()
        {
            if (User.IsInRole(RoleName.publicBody) || User.IsInRole(RoleName.admin))
                return View("Index", db.tenders.ToList());
            return View("IndexPublic", db.tenders.ToList());
        }

        // GET: Tenders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tender tender = db.tenders.Find(id);
            if (tender == null)
            {
                return HttpNotFound();
            }
            var pubId= tender.PublicBodyId;
            PublicBody pb = db.pubo.Find(pubId);
            ViewBag.publicBodyName = pb.organizationName;

            var consId = tender.ConsultantId;
            Consultant cons = db.cons.Find(consId);
            ViewBag.consultantName = cons.organizationName;

            ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            int result = DateTime.Compare(DateTime.Now, tender.submissionDeadline);

            if((User.IsInRole(RoleName.publicBody)&&(result<0))&&(user.orgName== pb.organizationName))
                return View("DetailsPublicBody", tender);
            else if ((User.IsInRole(RoleName.publicBody) && (result >= 0)) && (user.orgName == pb.organizationName))
                return View("DetailsPublicBodyBidList", tender);
            else if ((User.IsInRole(RoleName.consultant) && (result < 0)) && (user.orgName == cons.organizationName))
                return View("DetailsConsultant", tender);
            else if ((User.IsInRole(RoleName.consultant) && (result >= 0))&&(user.orgName== cons.organizationName))
                return View("DetailsConsultantbidList", tender);
            else if (User.IsInRole(RoleName.contractor) && (result < 0))
                return View("DetailsContractorCreateBid", tender);
            else if (User.IsInRole(RoleName.admin))
                return View("Details", tender);
            else
                return View("DetailsContractorBidList", tender);

        }

        // GET: Tenders/Create
        public ActionResult Create()
        {
            ApplicationUser user= System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            
            ViewBag.PublicBodyId = new SelectList(db.pubo.Where(b=>b.organizationName== user.orgName), "OrganizationId", "organizationName");
            ViewBag.ConsultantId = new SelectList(db.cons, "OrganizationId", "organizationName");
            return View();
        }

        
        public FileResult downloadSbd( int? id)
        {
            var tender = (Tender)db.tenders.SingleOrDefault(t=> t.TenderId  == id);
            return File(tender.sbd, "application/txt", tender.sbdName);
           
        }

        public FileResult downloadDes(int? id)
        {
            var tender = (Tender)db.tenders.SingleOrDefault(t => t.TenderId == id);
            return File(tender.design, "application/pdf", tender.designName);
        }

        // POST: Tenders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(
            HttpPostedFileBase sbdFile,
            HttpPostedFileBase desFile,
            [Bind(Include = "TenderId,projectTitle,projectScope,openingDate,submissionDeadline,contractType,procurementMethod,bidSecurity,requiredContractors,contractorType,evaluationMethod,sbd,sbdName, design, designName,bidValidity,billOfQuantity,PublicBodyId,ConsultantId")] Tender tender)
        {
           
            BinaryReader br = new BinaryReader(sbdFile.InputStream);
            tender.sbd = br.ReadBytes(sbdFile.ContentLength);
            tender.sbdName = sbdFile.FileName;

            br = new BinaryReader(desFile.InputStream);
            tender.design = br.ReadBytes(desFile.ContentLength);
            tender.designName = desFile.FileName;

            if (ModelState.IsValid)
            {
                db.tenders.Add(tender);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tender);
        }

        // GET: Tenders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tender tender = db.tenders.Find(id);
            if (tender == null)
            {
                return HttpNotFound();
            }
            ViewBag.PublicBodyId = new SelectList(db.pubo, "OrganizationId", "organizationName");
            ViewBag.ConsultantId = new SelectList(db.cons, "OrganizationId", "organizationName");
            return View(tender);
        }

        // POST: Tenders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(
            HttpPostedFileBase sbdFile,
            HttpPostedFileBase desFile,
            [Bind(Include = "TenderId,projectTitle,projectScope,openingDate,submissionDeadline,contractType,procurementMethod,bidSecurity,requiredContractors,contractorType,evaluationMethod,sbd,sbdName, design, designName,bidValidity,billOfQuantity,publicBodyId,consultantId")] Tender tender)
        {
            BinaryReader br = new BinaryReader(sbdFile.InputStream);
            tender.sbd = br.ReadBytes(sbdFile.ContentLength);
            tender.sbdName = sbdFile.FileName;

            br = new BinaryReader(desFile.InputStream);
            tender.design = br.ReadBytes(desFile.ContentLength);
            tender.designName = desFile.FileName;

            if (ModelState.IsValid)
            {
                db.Entry(tender).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tender);
        }

        // GET: Tenders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tender tender = db.tenders.Find(id);
            if (tender == null)
            {
                return HttpNotFound();
            }
            return View(tender);
        }

        // POST: Tenders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tender tender = db.tenders.Find(id);
            db.tenders.Remove(tender);
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
