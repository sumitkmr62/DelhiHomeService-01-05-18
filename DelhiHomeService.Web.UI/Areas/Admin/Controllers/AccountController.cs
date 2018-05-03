using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DelhiHomeService.Data.Admin;
using DelhiHomeService.Models.Admin;
using System.Web.Security;

namespace DelhiHomeService.Web.UI.Areas.Admin.Controllers
{
    public class AccountController : Controller
    {

        Login login = new Login();


        public ActionResult Index()
        {
            return View();
        }


        // GET: Admin/Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Account account)
        {
            if (ModelState.IsValid)
            {
                if (login.AdminLogin(account.AdminUsername, account.AdminPassword))
                {
                    FormsAuthentication.SetAuthCookie(account.AdminUsername, true);
                    Session["AdminID"] = account.AdminID;
                    Session["AdminUsername"] = account.AdminUsername;
                    return RedirectToAction("Index", "Account");
                }
                else
                {
                    ModelState.AddModelError("", "username and/or password is incorrect");
                }
            }
            return View(account);
            
        }
    }
}