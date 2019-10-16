using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EthioProcure.Models;
using EthioProcure.ViewModel;
using System.IO;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;

namespace EthioProcure.Controllers
{
    public class BidsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Bids
        public ActionResult Index(int? id)
        {
            
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tender project = db.tenders.Find(id);
            ViewBag.projectName = project.projectTitle;

            var bid = db.bid.Include(b => b.contractor).Include(b => b.tender);
            
            return View(bid.Where(b=>b.TenderId==id).ToList());
        }

        // GET: Bids/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bid bid = db.bid.Find(id);
            if (bid == null)
            {
                return HttpNotFound();
            }
            ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());

            if ((User.IsInRole(RoleName.contractor) && (bid.contractor.organizationName == user.orgName)))
                return View("DetailsContractor", bid);
            else if ((User.IsInRole(RoleName.contractor) && (bid.tender.publicBody.organizationName == user.orgName))||
                (User.IsInRole(RoleName.contractor) && (bid.tender.consultant.organizationName == user.orgName)))
                return View("DetailsEvaluate", bid);
            else if(User.IsInRole(RoleName.admin))
                return View("Details", bid);
            else
                return View("DetailsPublic", bid);
        }

        [HttpGet]
        [Route("Tenders/download/{fileName}/{id?}")]
        public FileResult download(String fileName, int? id)
        {
            var bid = (Bid)db.bid.SingleOrDefault(b => b.BidId  == id);

            if (fileName == "bl")
                return File(bid.contractor.businessLicence, "application/txt", bid.contractor.blName);
            else if (fileName == "coc")
                return File(bid.contractor.certificateOfCompetency, "application/txt", bid.contractor.cocName);
            else if (fileName == "ar")
                return File(bid.contractor.auditReport, "application/txt", bid.contractor.arName);
            else if (fileName == "mc")
                return File(bid.contractor.machinaryCertificate, "application/txt", bid.contractor.mcName);
            else if (fileName == "sc")
                return File(bid.contractor.staffCV, "application/txt", bid.contractor.scName);
            else if (fileName == "pl")
                return File(bid.contractor.performanceletter, "application/txt", bid.contractor.plName);
            else if (fileName == "tc")
                return File(bid.contractor.taxClearance, "application/txt", bid.contractor.taxClrName);
            else if (fileName == "vr")
                return File(bid.contractor.vatRegistration, "application/txt", bid.contractor.vatRagName);
            else if (fileName == "fr")
                return File(bid.contractor.fppaReg, "application/txt", bid.contractor.fppaRegName);
            else if (fileName == "tr")
                return File(bid.contractor.tinReg, "application/txt", bid.contractor.tinName);
            else if (fileName == "csv")
                return File(bid.certificateOfSiteVisit, "application/txt", bid.csvName);
            else
                return File(bid.bidSecurity, "application/txt", bid.bsName);
        }

        // GET: Bids/Create
        public ActionResult Create(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tender ten = db.tenders.Find(id);
            if (ten == null)
            {
                return HttpNotFound();
            }
            ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            
            ViewBag.OrganizationId = new SelectList(db.contr.Where(b=>b.organizationName==user.orgName), "OrganizationId", "organizationName");
            ViewBag.TenderId = new SelectList(db.tenders, "TenderId", "projectTitle", ten.TenderId);
            ViewBag.boq = ten.billOfQuantity;
            
            return View();
            
        }

        // POST: Bids/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(
            HttpPostedFileBase bidSecFile,
            HttpPostedFileBase csvFile,
            [Bind(Include = "BidId,methodology,implementationPlan,workSchedule,bidSecurity,certificateOfSiteVisit,completedBillofQuantity,TenderId,OrganizationId")] Bid bid)
        {
            BinaryReader br = new BinaryReader(bidSecFile.InputStream);
            bid.bidSecurity = br.ReadBytes(bidSecFile.ContentLength);
            bid.bsName = bidSecFile.FileName;

            br = new BinaryReader(csvFile.InputStream);
            bid.certificateOfSiteVisit = br.ReadBytes(csvFile.ContentLength);
            bid.csvName = csvFile.FileName;

            if (ModelState.IsValid)
            {
                db.bid.Add(bid);
                db.SaveChanges();
                return RedirectToAction("Index",new { id=bid.TenderId });
            }
			
			ViewBag.OrganizationId = new SelectList(db.org, "OrganizationId", "organizationName", bid.OrganizationId);
            ViewBag.TenderId = new SelectList(db.tenders, "TenderId", "projectTitle", bid.TenderId);
            return View(bid);
        }

        // GET: Bids/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bid bid = db.bid.Find(id);
            if (bid == null)
            {
                return HttpNotFound();
            }
            ViewBag.TenderId = new SelectList(db.tenders, "TenderId", "projectTitle", bid.tender.TenderId);
            ViewBag.OrganizationId = new SelectList(db.contr, "OrganizationId", "organizationName", bid.OrganizationId);
            return View(bid);
        }

        // POST: Bids/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(
            HttpPostedFileBase bidSecFile,
            HttpPostedFileBase csvFile,
            [Bind(Include = "BidId,methodology,implementationPlan,workSchedule,bidSecurity,certificateOfSiteVisit,completedBillofQuantity,TenderId,OrganizationId")] Bid bid)
        {
            BinaryReader br = new BinaryReader(bidSecFile.InputStream);
            bid.bidSecurity = br.ReadBytes(bidSecFile.ContentLength);
            bid.bsName = bidSecFile.FileName;

            br = new BinaryReader(csvFile.InputStream);
            bid.certificateOfSiteVisit = br.ReadBytes(csvFile.ContentLength);
            bid.csvName = csvFile.FileName;

            if (ModelState.IsValid)
            {
                db.Entry(bid).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TenderId = new SelectList(db.tenders, "TenderId", "projectTitle", bid.TenderId);
            ViewBag.OrganizationId = new SelectList(db.org, "OrganizationId", "organizationName", bid.OrganizationId);
            return View(bid);
        }
        
        public ActionResult getLogo(int id)
        {
            Bid bid = db.bid.Find(id);
            return File(bid.contractor.logo, "image/jpg");
            
        }

        public ActionResult getOrgStruct(int id)
        {
            Bid bid = db.bid.Find(id);
            return File(bid.contractor.orgStruct, "image/jpg");
        }

        // GET: Bids/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bid bid = db.bid.Find(id);
            if (bid == null)
            {
                return HttpNotFound();
            }
            return View(bid);
        }

        // POST: Bids/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bid bid = db.bid.Find(id);
            db.bid.Remove(bid);
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
