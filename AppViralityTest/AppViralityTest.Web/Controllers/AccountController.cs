using AppViralityTest.BLL;
using AppViralityTest.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace AppViralityTest.Web.Controllers
{
    public class AccountController : Controller
    {
        public readonly UserManager _userManager;
        public AccountController()
        {
            _userManager = new UserManager();
        }

        // GET: /Account/LogOn
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserDTO model, string returnUrl)
        {
            // Lets first check if the Model is valid or not
            if (ModelState.IsValid)
            {
                //using (userDbEntities entities = new userDbEntities())
                //{
                string username = model.UserName;
                string password = model.Password;

                // Now if our password was enctypted or hashed we would have done the
                // same operation on the user entered password here, But for now
                // since the password is in plain text lets just authenticate directly
                var user = _userManager.GetUserDetails(model);
                // User found in the database
                if (user != null)
                {

                    FormsAuthentication.SetAuthCookie(user.Id.ToString(), false);
                    if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                        && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "The user name or password provided is incorrect.");
                }
                //}
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }
    }
}