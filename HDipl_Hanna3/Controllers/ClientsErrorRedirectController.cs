using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HDipl_Hanna3.Models;

namespace HDipl_Hanna3.Controllers
{
    public class ClientsErrorRedirectController : Controller
    {
        private ClientContext db = new ClientContext();

        // GET: ClientsErrorRedirect
        public ActionResult Index()
        {
            var client = db.Client.Include(c => c.Employee).Include(c => c.Service);
            return View(client.ToList());
        }

        // GET: ClientsErrorRedirect/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clients clients = db.Client.Find(id);
            if (clients == null)
            {
                return HttpNotFound();
            }
            return View(clients);
        }

        // GET: ClientsErrorRedirect/Create
        public ActionResult Create()
        {
            ViewBag.EmployeeId = new SelectList(db.Employee, "EmployeeId", "FirstName");
            ViewBag.ServiceId = new SelectList(db.Service, "ServiceId", "ServiceDescritption");
            return View();
        }

        // POST: Clients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,AppointmentDate,ServiceId,EmployeeId,Name,Surname,PhoneNumber,EmailAddress")] Clients clinets)
        {
            ViewBag.ServiceId = new SelectList(db.Service, "ServiceId", "ServiceDescritption", clinets.ServiceId);
            ViewBag.EmployeeId = new SelectList(db.Employee, "EmployeeId", "FirstName", clinets.EmployeeId);
            if (ModelState.IsValid)
            {
                var dateAlreadyBooked = false;
                var employeeBooked = false;

                db.Client.ToList().ForEach(c =>
                {
                    if (c.AppointmentDate == clinets.AppointmentDate)
                        dateAlreadyBooked = true;
                    if (c.EmployeeId == clinets.EmployeeId)
                        _ = employeeBooked == true;

                });
                if (dateAlreadyBooked)
                {
                    clinets.errorMessage = $"This date {clinets.AppointmentDate} is already taken. Please try again";
                    return View("~/Views/Clients/Create.cshtml");
                }
                db.Client.Add(clinets);
                db.SaveChanges();
                return  View("~/Views/ClientsAPIbyClientID/Index.cshtml");
            }
            //ViewBag.EmployeeId = new SelectList(db.Employee, "EmployeeId", "FirstName", clients.EmployeeId);
            //ViewBag.ServiceId = new SelectList(db.Service, "ServiceId", "ServiceDescritption", clients.ServiceId);
            return View(clinets);
        }


        // GET: ClientsErrorRedirect/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clients clients = db.Client.Find(id);
            if (clients == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeId = new SelectList(db.Employee, "EmployeeId", "FirstName", clients.EmployeeId);
            ViewBag.ServiceId = new SelectList(db.Service, "ServiceId", "ServiceDescritption", clients.ServiceId);
            return View(clients);
        }

        // POST: ClientsErrorRedirect/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,AppointmentDate,ServiceId,EmployeeId,Name,Surname,PhoneNumber,EmailAddress")] Clients clients)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clients).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeId = new SelectList(db.Employee, "EmployeeId", "FirstName", clients.EmployeeId);
            ViewBag.ServiceId = new SelectList(db.Service, "ServiceId", "ServiceDescritption", clients.ServiceId);
            return View(clients);
        }

        // GET: ClientsErrorRedirect/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clients clients = db.Client.Find(id);
            if (clients == null)
            {
                return HttpNotFound();
            }
            return View(clients);
        }

        // POST: ClientsErrorRedirect/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Clients clients = db.Client.Find(id);
            db.Client.Remove(clients);
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
