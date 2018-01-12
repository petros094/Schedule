using ScheduleProject.Models;
using ScheduleProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ScheduleProject.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        // GET: Admin
        ScheduleEntity dbContext = new ScheduleEntity();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Groups()
        {
            ViewBag.text = TempData["Message1"];
            var result=dbContext.Groups.ToList();
            return View(result);
        }
        [HttpPost]
        public ActionResult AddGroup(Group model)
        {
            if (model.GroupName == null)
            {
                TempData["Message1"] = "Write the group number";
                return RedirectToAction("Groups");
            }
            try
            {
                dbContext.Groups.Add(model);
                dbContext.SaveChanges();
                return RedirectToAction("Groups");
            }
            catch (Exception)
            {
                return View("ErrorView");
            }
        }
        [HttpGet]
        public ActionResult Subject()
        {
            ViewBag.text = TempData["Message2"];
            var result = dbContext.Subjects.ToList();
            return View(result);
        }
        [HttpPost]
        public ActionResult AddSubject(Subject model)
        {
            if (model.SubjectName == null)
            {
                TempData["Message2"] = "Write the subject name";
                return RedirectToAction("Subject");
            }
            try
            {
                dbContext.Subjects.Add(model);
                dbContext.SaveChanges();
                return RedirectToAction("Subject");
            }
            catch (Exception)
            {
                return View("ErrorView");
            }
        }

        [HttpGet]
        public ActionResult CreateSchedule()
        {


            var groups =dbContext.Groups.ToList();
            var result = new SelectList(groups, "GroupId", "GroupName");
            ViewBag.Result = result;
            var subjects = dbContext.Subjects.ToList();
            var subject = new SelectList(subjects, "SubjectId", "SubjectName");
            ViewBag.Subject = subject;
            ViewBag.text = TempData["Message3"];
            ViewBag.text1 = TempData["Message4"];
            return View();
        }

        [HttpPost]
        public ActionResult Create(ScheduleModel model)
        {
            Schedule schedule = new Schedule();
            schedule.DayId = model.DayId;
            schedule.TimeId = model.TimeId;
            schedule.GroupId = model.GroupId;
            schedule.SubjectId = model.SubjectId;
            if (model.DayId == 0 || model.TimeId == 0 || model.GroupId == 0)
            {
                TempData["Message3"] = "Day,Time,Group are Requiared";
                return RedirectToAction("CreateSchedule");
            }
            if (dbContext.Schedule.Select(s => s.GroupId).Count() >= 20)
            {
                TempData["Message4"] = "Shabatva hamar xmberi qanaky bavarara";
                return RedirectToAction("CreateSchedule");
            }
            try
            {
                dbContext.Schedule.Add(schedule);
                dbContext.SaveChanges();
                return RedirectToAction("CreateSchedule");
            }
            catch
            {
                return View("ErrorView");
            }
            
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                dbContext.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}