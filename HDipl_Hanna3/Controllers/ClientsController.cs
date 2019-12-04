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
    public class ClientsController : Controller
    {
        private ClientContext db = new ClientContext();

        // GET: Clients
        //public ActionResult Index()
        //{
        //    var client = db.Client.Include(c => c.Employee).Include(c => c.Service);
        //    return View(client.ToList());
        //}
        public ActionResult Index(string sortOrder)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "Name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "Date_desc" : "Date";
            var clients = from c in db.Client
                           select c;
            switch (sortOrder)
            {
                case "Name_desc":
                    clients = clients.OrderByDescending(c => c.ServiceId);
                    break;
                case "Date":
                    clients = clients.OrderBy(s => s.Name);
                    break;
                case "Date_desc":
                    clients = clients.OrderByDescending(s => s.Surname);
                    break;
                default:
                    clients = clients.OrderBy(s => s.AppointmentDate);
                    break;
            }
            return View(clients.ToList());
        }
        // GET: Clients/Details/5
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

        // GET: Clients/Create
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
        public ActionResult Create([Bind(Include = "ID,AppointmentDate,ServiceId,EmployeeId,Name,Surname,PhoneNumber,EmailAddress")] Clients clients)
        {
            ViewBag.ServiceId = new SelectList(db.Service, "ServiceId", "ServiceDescritption", clients.ServiceId);

            //    if (ModelState.IsValid)
            //    {
            //        var dateAlreadyBooked = false;
            //        db.Client.ToList().ForEach(c =>
            //       {
            //           if (c.AppointmentDate == clients.AppointmentDate)
            //               dateAlreadyBooked = true;
            //       });
            //        if (dateAlreadyBooked)
            //        {
            //            clients.errorMessage = $"This date {clients.AppointmentDate} is already taken. Please try again";
            //            return View(clients);
            //        }
            //        db.Client.Add(clients);
            //        db.SaveChanges();
            //        return RedirectToAction("Index");
            //    }
            //    ViewBag.EmployeeId = new SelectList(db.Employee, "EmployeeId", "FirstName", clients.EmployeeId);
            //    ViewBag.ServiceId = new SelectList(db.Service, "ServiceId", "ServiceDescritption", clients.ServiceId);
            //    return View(clients);
            //}



            if (ModelState.IsValid)
            {
                var dateAlreadyBooked = false;
                db.Client.ToList().ForEach(c =>
               {
                   if (c.AppointmentDate == clients.AppointmentDate)
                       dateAlreadyBooked = true;
               });
                if (dateAlreadyBooked)
                {
                    clients.errorMessage = $"This date {clients.AppointmentDate} is already taken. Please try again";
                    return View(clients);
                }
                db.Client.Add(clients);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeId = new SelectList(db.Employee, "EmployeeId", "FirstName", clients.EmployeeId);
            ViewBag.ServiceId = new SelectList(db.Service, "ServiceId", "ServiceDescritption", clients.ServiceId);
            return View(clients);
        }



            // GET: Clients/Edit/5
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

        // POST: Clients/Edit/5
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

        // GET: Clients/Delete/5
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

        // POST: Clients/Delete/5
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
