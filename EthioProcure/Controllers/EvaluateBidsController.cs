using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EthioProcure.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace EthioProcure.Controllers
{
    public class EvaluateBidsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: EvaluateBids
        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tender project = db.tenders.Find(id);
            ViewBag.pName = project.projectTitle;
            ViewBag.pEval = project.evaluationMethod;
            ViewBag.pContract = project.contractType;
            ViewBag.pboq = project.billOfQuantity;

            //Find the number of bids for this tender
            int bidNo = db.bid.Where(b => b.TenderId == id).ToList().Count;

            var evaluateBid = db.evaluateBid.Include(e => e.bid);

            //To find the number of evaluated bids
            int evalNo = db.evaluateBid.Where(b => b.bid.TenderId == id).ToList().Count;

            ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            int result = DateTime.Compare(DateTime.Now, project.submissionDeadline);
            ViewBag.EroorEval = "All the submitted bids have not yet been evaluated !";

            if (bidNo==evalNo)
                return View(evaluateBid.Where(b => b.bid.TenderId == id).ToList());
            return RedirectToAction("Details","Tenders", new {id=id });
            
        }

        public ActionResult ReportList()
        {
            return View(db.tenders.ToList());
        }

        // GET: EvaluateBids/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EvaluateBid evaluateBid = db.evaluateBid.Find(id);
            if (evaluateBid == null)
            {
                return HttpNotFound();
            }
            return View(evaluateBid);
        }

        // GET: EvaluateBids/Create
        public ActionResult Create(int? id)
        {
            if(id== null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bid bid = db.bid.Find(id);
            if (bid == null)
            {
                return HttpNotFound();
            }
            EvaluateBid eb = new EvaluateBid();
            eb.bid = bid;
            eb.BidId = (int)id;
            return View(eb);
        }

        // POST: EvaluateBids/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EvaluateBidId,contractorTypeScore,contractorLevelScore,methodologyScore,workScheduleScore,implementationPlanScore,tinScore,busLiScore,cocScore,audRepScore,machCertScore,profCertScore,perfLetScore,taxClrScore,vatRegScore,fppaRegScore,bidSecScore,csvScore,BidId,equipScore,profQuaScore,anualTurnoverScore")] EvaluateBid evaluateBid)
        {
            if (ModelState.IsValid)
            {
                db.evaluateBid.Add(evaluateBid);
                db.SaveChanges();
                return RedirectToAction("Details","Bids", new { id = evaluateBid.BidId });
            }

            ViewBag.BidId = new SelectList(db.bid, "BidId", "methodology", evaluateBid.BidId);
            return View(evaluateBid);
        }

        // GET: EvaluateBids/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EvaluateBid evaluateBid = db.evaluateBid.Find(id);
            if (evaluateBid == null)
            {
                return HttpNotFound();
            }
            ViewBag.BidId = new SelectList(db.bid, "BidId", "methodology", evaluateBid.BidId);
            return View(evaluateBid);
        }

        // POST: EvaluateBids/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EvaluateBidId,contractorTypeScore,contractorLevelScore,methodologyScore,workScheduleScore,implementationPlanScore,tinScore,busLiScore,cocScore,audRepScore,machCertScore,profCertScore,perfLetScore,taxClrScore,vatRegScore,fppaRegScore,bidSecScore,csvScore,BidId")] EvaluateBid evaluateBid)
        {
            if (ModelState.IsValid)
            {
                db.Entry(evaluateBid).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BidId = new SelectList(db.bid, "BidId", "methodology", evaluateBid.BidId);
            return View(evaluateBid);
        }

        // GET: EvaluateBids/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EvaluateBid evaluateBid = db.evaluateBid.Find(id);
            if (evaluateBid == null)
            {
                return HttpNotFound();
            }
            return View(evaluateBid);
        }

        // POST: EvaluateBids/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EvaluateBid evaluateBid = db.evaluateBid.Find(id);
            db.evaluateBid.Remove(evaluateBid);
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
