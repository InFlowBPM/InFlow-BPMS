using strICT.InFlow.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace strICT.InFlow.Web.Controllers
{
    public class ContactController : Controller
    {
        //
        // GET: /Contact/
        public ActionResult Index()
        {
            return View(new ContactViewModel());
        }
        [HttpPost]
        public ActionResult Contact(ContactViewModel contactVM)
        {
            if (!ModelState.IsValid)
            {
                return View(contactVM);
            }

            var contact = new Contact
            {
                Mail = contactVM.Mail,
                Name = contactVM.Name,
                Company = contactVM.Company,
                PromoCode = contactVM.PromoCode
            };

            new Email().Send(contact);

            return RedirectToAction("ContactConfirm");
        }
        public ActionResult ContactConfirm()
        {
            return View();
        }
       
	}
}