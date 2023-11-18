using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Give_Aid.Controllers
{
   
    public class AccountController : Controller
    {
        giveaidEntities db = new giveaidEntities();
        // GET: Account

        public ActionResult login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult login(string email, string passwords)
        {
            var logincheck = db.login1.FirstOrDefault(e => e.email == email && e.passwords == passwords);
            if (logincheck != null)
            {
                Session["pageopen"] = logincheck.email;
                return RedirectToAction("index");
            }
            else
            {
                ViewBag.loginerror = "Invalid email or password";
                return View();
            }
        }
        public ActionResult logout()
        {
            Session.Abandon();
            Session.Clear();
            return View("login");

        }
        public ActionResult Index()
        {
            if (Session["pageopen"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("login");
            }
        }
       
        
        public ActionResult contact()
        {
            return View(db.contacts.ToList());
        }
        public ActionResult Delete_contact(int? id)
        {
            var iddata = db.contacts.Find(id);
            if(id != null)
            {
                db.contacts.Remove(iddata);
                db.SaveChanges();
                return RedirectToAction("Contact");
            }
            else
            {
                return HttpNotFound();
            }
        }
        public ActionResult edit_contact(int? id)
        {
            var iddata = db.contacts.Find(id);

            if (iddata != null)
            {
                return View(iddata);
            }
            else
            {
                return HttpNotFound();
            }
        }
        [HttpPost]
        public ActionResult edit_contact()
        {
            int id = int.Parse(Request.Form["id"]);
            String contactname = Request.Form["name"];
            String contactemail = Request.Form["email"];
            String contactnumber = Request.Form["number"];
            String contactmessag = Request.Form["messag"];
            
            contact tbl = new contact();
            tbl.name = contactname;
            tbl.email = contactemail;
            tbl.number = contactnumber;
            tbl.messag = contactmessag;
            tbl.id = id;
            db.Entry(tbl).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("contact");
        }

        public ActionResult partner()
        {
            return View(db.partners.ToList());
        }

        public ActionResult Delete_partner(int? id)
        {
            var iddata = db.partners.Find(id);
            if (id != null)
            {
                db.partners.Remove(iddata);
                db.SaveChanges();
                return RedirectToAction("partner");
            }
            else
            {
                return HttpNotFound();
            }
        }
        public ActionResult partner_createnew(FormCollection fc)
        {
            return View();
        }

        [HttpPost]

        public ActionResult partner_createnew(FormCollection fc, HttpPostedFileBase partnerimg)
        {

            partner partner = new partner();
            partner.name = Request.Form["name"];
            partner.img = Request.Form["img"];
            db.partners.Add(partner);

            db.SaveChanges();

            return RedirectToAction("partner");

        }
        public ActionResult edit_partner(int? id)
        {
            var iddata = db.partners.Find(id);

            if (iddata != null)
            {
                return View(iddata);
            }
            else
            {
                return HttpNotFound();
            }
        }
        [HttpPost]
        public ActionResult edit_partner()
        {
            int id = int.Parse(Request.Form["id"]);
            String partnername = Request.Form["name"];
            String partnerimg = Request.Form["img"];


            partner tbl = new partner();
            tbl.name = partnername;
            tbl.img = partnerimg;

            tbl.id = id;
            db.Entry(tbl).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("partner");
        }



        public ActionResult donation()
        {
            return View(db.donations.ToList());
        }

        public ActionResult Delete_donation(int? id)
        {
            var iddata = db.donations.Find(id);
            if (id != null)
            {
                db.donations.Remove(iddata);
                db.SaveChanges();
                return RedirectToAction("donation");
            }
            else
            {
                return HttpNotFound();
            }
        }
        public ActionResult register()
        {
            return View(db.registers.ToList());
        }
        public ActionResult edit_register(int? id)
        {
            var iddata = db.registers.Find(id);

            if (iddata != null)
            {
                return View(iddata);
            }
            else
            {
                return HttpNotFound();
            }
        }
        [HttpPost]
        public ActionResult edit_register()
        {
            int id = int.Parse(Request.Form["id"]);
            String registerusername = Request.Form["username"];
            String registeremail = Request.Form["email"];
            String registercompanyname = Request.Form["companyname"];
            String registernumber = Request.Form["number"];
            String registertxt = Request.Form["txt"];
            String registerimg = Request.Form["img"];

            register tbl = new register();
            tbl.username = registerusername;
            tbl.email = registeremail;
            tbl.companyname = registercompanyname;
            tbl.number = registernumber;
            tbl.txt = registertxt;
            tbl.img = registerimg;
            tbl.id = id;
            db.Entry(tbl).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("register");
        }
        public ActionResult Delete_register(int? id)
        {
            var iddata = db.registers.Find(id);
            if (id != null)
            {
                db.registers.Remove(iddata);
                db.SaveChanges();
                return RedirectToAction("register");
            }
            else
            {
                return HttpNotFound();
            }
        }

    }
}