using PreduzeceProjektniCentar.Models;
using PreduzeceProjektniCentar.Models.EFRepository;
using PreduzeceProjektniCentar.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace PreduzeceProjektniCentar.Controllers
{
    public class AccountController : Controller
    {
        private IAuthRepository authRepository = new AuthRepository();
        // GET: Korisnik
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(UserBO user)
        {
            if(authRepository.IsValid(user))
            {
                FormsAuthentication.SetAuthCookie(user.Username, false);
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("", "Uneti podaci nisu validni.");
            return View();
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(UserBO user)
        {
            authRepository.AddUser(user);
            return RedirectToAction("Login");
        }
    }
}