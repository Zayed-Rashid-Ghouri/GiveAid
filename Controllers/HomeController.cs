using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Give_Aid.Controllers
{
    public class HomeController : Controller
    {
        giveaidEntities db = new giveaidEntities();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult contact(FormCollection fc)
        {
            return View();
        }
        [HttpPost]
        
        public ActionResult contact(FormCollection fc, HttpPostedFileBase contactimg)
        {

            contact contact = new contact();
            contact.name = Request.Form["name"];
            contact.email = Request.Form["email"];
            contact.number = Request.Form["number"];
            contact.messag = Request.Form["messag"];
            db.contacts.Add(contact);

            db.SaveChanges();

            return RedirectToAction("contact");

        }
        public ActionResult about()
        {
            return View();
        }
        public ActionResult donation(FormCollection fc)
        {
            return View();
        }
        [HttpPost]

        public ActionResult donation(FormCollection fc, HttpPostedFileBase donationimg)
        {

            donation donation = new donation();
            donation.name = Request.Form["name"];
            donation.email = Request.Form["email"];
            donation.amount = Request.Form["amount"];
            donation.category = Request.Form["category"];
            donation.bank = Request.Form["bank"];
            donation.iban = Request.Form["iban"];
            db.donations.Add(donation);

            db.SaveChanges();

            return RedirectToAction("donation");

        }
        public ActionResult partner()
        {
            return View(db.partners.ToList());
        }



        public ActionResult register(FormCollection fc)
        {
            return View();
        }
        [HttpPost]

        public ActionResult register(FormCollection fc, HttpPostedFileBase registerimg)
        {

            register register = new register();
            register.username = Request.Form["username"];
            register.email = Request.Form["email"];
            register.companyname = Request.Form["companyname"];
            register.number = Request.Form["number"];
            register.txt = Request.Form["txt"];
            register.img = Request.Form["img"];
            db.registers.Add(register);

            db.SaveChanges();

            return RedirectToAction("register");

        }
    }
}