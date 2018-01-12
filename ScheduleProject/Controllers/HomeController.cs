using ScheduleProject.Models;
using ScheduleProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ScheduleProject.Controllers
{
    public class HomeController : Controller
    {
        ScheduleEntity dbContext = new ScheduleEntity();

        public ActionResult Index()
        {
            ViewBag.text1 = TempData["Message1"];
            ViewBag.text2 = TempData["Message2"];
            return View();
        }


        [HttpPost]
        public ActionResult EnterGroup(string groupName)
        {
            if (groupName != null && groupName != "")
            {
                var item = dbContext.Groups.Where(w => w.GroupName == groupName).FirstOrDefault();
                if (item != null)
                {
                    var Monday = (from subject in dbContext.Subjects
                                  join schedule in dbContext.Schedule on subject.SubjectId equals schedule.SubjectId
                                  where schedule.TimeId == 1 && schedule.GroupId == item.GroupId
                                  select new ScheduleTable
                                  {
                                      Subjects = subject.SubjectName
                                  }).ToList();
                    ViewBag.Monday = Monday;

                    var Tuesday = (from subject in dbContext.Subjects
                                   join schedule in dbContext.Schedule on subject.SubjectId equals schedule.SubjectId
                                   where schedule.TimeId == 2 && schedule.GroupId == item.GroupId
                                   select new ScheduleTable
                                   {
                                       Subjects = subject.SubjectName
                                   }).ToList();

                    ViewBag.Tuesday = Tuesday;

                    var Wednesday = (from subject in dbContext.Subjects
                                     join schedule in dbContext.Schedule on subject.SubjectId equals schedule.SubjectId
                                     where schedule.TimeId == 3 && schedule.GroupId == item.GroupId
                                     select new ScheduleTable
                                     {
                                         Subjects = subject.SubjectName
                                     }).ToList();

                    ViewBag.Wednesday = Wednesday;


                    var Thursday = (from subject in dbContext.Subjects
                                    join schedule in dbContext.Schedule on subject.SubjectId equals schedule.SubjectId
                                    where schedule.TimeId == 4 && schedule.GroupId == item.GroupId
                                    select new ScheduleTable
                                    {
                                        Subjects = subject.SubjectName
                                    }).ToList();


                    ViewBag.Thursday = Thursday;

                    var Friday = (from subject in dbContext.Subjects
                                  join schedule in dbContext.Schedule on subject.SubjectId equals schedule.SubjectId
                                  where schedule.TimeId == 5 && schedule.GroupId == item.GroupId
                                  select new ScheduleTable
                                  {
                                      Subjects = subject.SubjectName
                                  }).ToList();

                    ViewBag.Friday = Friday;
                    return View();
                }
                else
                {
                    TempData["Message1"] = "Enter current Group";
                    return RedirectToAction("Index");
                }
            }
            else
            {
                TempData["Message2"] = "Enter your Group";
                return RedirectToAction("Index");
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