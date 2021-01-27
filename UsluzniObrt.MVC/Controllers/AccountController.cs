﻿using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UsluzniObrt.MVC.ViewModels;
using UsluzniObrt.Repository;
using UsluzniObrt.Model;
using UsluzniObrt.Service;
namespace UsluzniObrt.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;

        // GET: Account
        public AccountController()
        {

        }

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }
        
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //POST: /Account/Login
       [HttpPost]
       [AllowAnonymous]
       [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = _userService.SignIn(new SignIn
            {
                Email = model.Email,
                Password = model.Password,
                RememberMe = model.RememberMe
            });

            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(returnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.RequiresVerification:
                    return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "Invalid login attempt.");
                    return View(model);
            }
        }
        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Index", "Home");
        }
        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }


        //[Authorize]
        //public ActionResult ChangePassword()
        //{
        //    return View();
        //}

        ////
        //// POST: /Manage/ChangePassword
        //[Authorize]
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult ChangePassword(ChangePasswordViewModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(model);
        //    }

        //    var userId = User.Identity.GetUserId();

        //    var result = _userService.ChangePassword(new UserChangePassword
        //    {
        //        UserId = userId,
        //        OldPassword = model.OldPassword,
        //        NewPassword = model.NewPassword,
        //        ConfirmPassword = model.ConfirmPassword
        //    });

        //    if (result.Succeeded)
        //    {
        //        var user = _userService.GetById(userId);
        //        if (user != null)
        //        {
        //            _userService.SignIn(new UserSignIn
        //            {
        //                Email = user.Email,
        //                Password = user.PasswordHash
        //            });
        //        }

        //        return RedirectToAction("Index", new { Message = ManageMessageId.ChangePasswordSuccess });
        //    }

        //    AddErrors(result);

        //    return View(model);
        //}

    } }