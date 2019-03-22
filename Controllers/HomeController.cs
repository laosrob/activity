using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using exam.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

namespace exam.Controllers
{
    public class HomeController : Controller
    {
        private MyContext dbContext;

        public HomeController(MyContext context)
        {
            dbContext = context;
        }
        [Route("")]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [Route("login")]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [Route("loginproccess")]
        [HttpPost]
        public IActionResult LoginProccess(Login user)
        {
            {
                if (ModelState.IsValid)
                {
                    var userInDb = dbContext.users.FirstOrDefault(u => u.Email == user.Email);
                    if (userInDb == null)
                    {
                        Console.WriteLine("No Email in database");
                        ModelState.AddModelError("Email", "Invalid Email/Password");
                        return View("Login");
                    }
                    else
                    {
                        var hasher = new PasswordHasher<Login>();
                        var result = hasher.VerifyHashedPassword(user, userInDb.Password, user.Password);
                        if (result == 0)
                        {
                            Console.WriteLine("Wrong Password in database");
                            ModelState.AddModelError("email", "Invalid email/password");
                            return View("Login");
                        }
                    }
                    if (ModelState.IsValid)
                    {
                        HttpContext.Session.SetInt32("UserId", userInDb.UserId);
                        HttpContext.Session.SetString("FirstName", userInDb.FirstName);
                        return RedirectToAction("Dashboard");
                    }
                }
                return View("Login");
            }
        }
        [HttpPost("register")]
        public IActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                if (dbContext.users.Any(u => u.Email == user.Email))
                {
                    ModelState.AddModelError("Email", "Email already in use!");
                    return View("Index");
                }
                else
                {
                    PasswordHasher<User> Hasher = new PasswordHasher<User>();
                    user.Password = Hasher.HashPassword(user, user.Password);
                    dbContext.Add(user);
                    dbContext.SaveChanges();
                    var userInDb = dbContext.users.FirstOrDefault(u => u.Email == user.Email);
                    HttpContext.Session.SetInt32("UserId", userInDb.UserId);
                    HttpContext.Session.SetString("FirstName", userInDb.FirstName);
                    return RedirectToAction("Dashboard");
                }
            }
            else
            {
                return View("Index");
            }
        }
        [Route("logout")]
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
        [Route("dashboard")]
        [HttpGet]
        public IActionResult Dashboard()
        {
            if (HttpContext.Session.GetInt32("UserId") == null)
            {
                return RedirectToAction("Login");
            }
            else
            {
                List<Activityclass> Activity = dbContext.activities.Include(user => user.ActRSVP).ThenInclude(a => a.RSVPUser).OrderBy(p => p.Date).ToList();
                @ViewBag.Activity = Activity;
                HttpContext.Session.GetInt32("UserId");
                HttpContext.Session.GetString("FirstName");
                @ViewBag.User = HttpContext.Session.GetInt32("UserId");
                @ViewBag.Name = HttpContext.Session.GetString("FirstName");
                return View();
            }
        }
        [Route("new")]
        [HttpGet]
        public IActionResult New()
        {
            if (HttpContext.Session.GetInt32("UserId") == null)
            {
                return RedirectToAction("Login");
            }
            else
            {
                return View();
            }
        }
        [Route("add_activity")]
        [HttpPost]
        public IActionResult Add_Activity(Activityclass newAct)
        {
            if (ModelState.IsValid)
            {
                DateTime CurrentTime = DateTime.Now;

                if (DateTime.Parse(Request.Form["Date"]) < CurrentTime)
                {
                    ModelState.AddModelError("Date", "Date cannot be in the past");
                    return View("New");
                }
                else
                {
                    {
                        if (Request.Form["dur"] == "minutes")
                        {
                            newAct.Duration = (int)newAct.Duration;
                        }
                        if (Request.Form["dur"] == "hours")
                        {
                            newAct.Duration = (int)newAct.Duration * 60;
                        }
                        if (Request.Form["dur"] == "days")
                        {
                            newAct.Duration = (int)newAct.Duration * 1440;
                        }
                        Console.WriteLine(newAct.Duration);

                        newAct.UserId = (int)HttpContext.Session.GetInt32("UserId");
                        HttpContext.Session.GetInt32("UserId");
                        dbContext.Add(newAct);
                        dbContext.SaveChanges();
                        return Redirect("activity/" + newAct.ActivityId);
                    }
                }
            }
            else
            {
                return View("New");
            }
        }
        [Route("activity/{ActivityId}")]
        [HttpGet]
        public IActionResult ViewAct(int ActivityId)
        {
            if (HttpContext.Session.GetInt32("UserId") == null)
            {
                return RedirectToAction("Login");
            }
            else
            {
                Activityclass activity = dbContext.activities.FirstOrDefault(u => u.ActivityId == ActivityId);
                @ViewBag.Activity = activity;

                int creator = activity.UserId;
                ViewBag.theUser = dbContext.users.SingleOrDefault(u => u.UserId == creator);

                var Attending = dbContext.activities.Include(a => a.ActRSVP).ThenInclude(assoc => assoc.RSVPAct).FirstOrDefault(user => user.ActivityId == ActivityId);
                @ViewBag.People = Attending;

                List<Activityclass> Activity = dbContext.activities.Include(user => user.ActRSVP).ThenInclude(a => a.RSVPUser).OrderBy(p => p.Date).ToList();
                @ViewBag.Act = Activity;

                @ViewBag.User = HttpContext.Session.GetInt32("UserId");
            }

            return View();
        }
        [Route("rsvp/{ActivityId}/{UserId}")]
        [HttpGet]
        public IActionResult RSVP(int ActivityId, int UserId)
        {
            Activityclass newAct = dbContext.activities.Include(c => c.ActRSVP).ThenInclude(b => b.RSVPUser).FirstOrDefault(wed => wed.ActivityId == ActivityId);
            User newUser = dbContext.users.Include(c => c.UserRSVP).ThenInclude(b => b.RSVPAct).FirstOrDefault(us => us.UserId == UserId);
            foreach (var thisact in newUser.UserRSVP)
            {
                if (thisact.RSVPAct.Date.Date == newAct.Date.Date)
                {
                    return RedirectToAction("Dashboard");
                }
            }
            RSVP newRSVP = new RSVP();
            newRSVP.UserId = (int)HttpContext.Session.GetInt32("UserId");
            newRSVP.ActivityId = ActivityId;
            dbContext.Add(newRSVP);
            dbContext.SaveChanges();
            return Redirect("/activity/" + ActivityId);
        }
        [Route("unrsvp/{ActivityId}/{UserId}")]
        [HttpGet]
        public IActionResult unRSVP(int ActivityId,int UserId)
        {
            List<RSVP> rsvp = dbContext.rsvps.Where(u => u.ActivityId == ActivityId).ToList();
            RSVP singlersvp = rsvp.FirstOrDefault(a => a.UserId == (int)HttpContext.Session.GetInt32("UserId"));

            dbContext.Remove(singlersvp);
            dbContext.SaveChanges();
            return RedirectToAction("dashboard");
        }
        [Route("delete/{ActivityId}")]
        [HttpGet]
        public IActionResult Delete(int ActivityId)
        {
            Activityclass activity = dbContext.activities.FirstOrDefault(u => u.ActivityId == ActivityId);
            dbContext.activities.Remove(activity);
            dbContext.SaveChanges();
            return RedirectToAction("dashboard");
        }
    }
}
