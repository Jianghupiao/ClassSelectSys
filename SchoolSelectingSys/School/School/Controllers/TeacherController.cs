using System;
using School;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace School.Controllers
{
    public class TeacherController : Controller
    {
        // GET: Teacher
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Show()//查的功能 show function
        {
            List<Teacher> showAllTeachers = null;
            using (SchoolEntities dbContext = new SchoolEntities())
            {
                showAllTeachers = dbContext.Teachers.ToList();

            }
            return View("TeacherList", showAllTeachers);
        }


        [HttpGet]//增，create function
        public ActionResult Create()
        {

            return View("Create");

        }
        [HttpPost]
        public ActionResult Create(Teacher teacher)
        {

            using (SchoolEntities dbContext = new SchoolEntities())
            {
                dbContext.Teachers.Add(teacher);
                dbContext.SaveChanges();

            }
            return RedirectToAction("Show");
        }

        [HttpGet]//Edit function ;update, 改。
        public ActionResult Edit(int id)
        {
            Teacher targetTeacher = null;
            using (SchoolEntities dbContext =new SchoolEntities())
            {
                targetTeacher = dbContext.Teachers.SingleOrDefault(m => m.Id == id);

            }
            return View(targetTeacher);
        }
        [HttpPost]
        public ActionResult Edit(Teacher teacher)
        {

            return RedirectToAction ("Show");
        }

        [HttpGet] //Delete function，删
        public ActionResult Delete(int id)
        {
            Teacher targetTeacher = null;
            using (SchoolEntities dbContext =new SchoolEntities())
            {
                targetTeacher = dbContext.Teachers.SingleOrDefault(m => m.Id == id);
                
            }
            return View(targetTeacher);
        }
        [HttpPost]
        public ActionResult Delete (Teacher teacher)
        {

           using (SchoolEntities dbContext=new SchoolEntities())
            {
                if (teacher!=null)
                {
                    dbContext.Entry(teacher).State = System.Data.Entity.EntityState.Deleted;
                    dbContext.SaveChanges();
                }
                //dbContext.Teachers.Remove(teacher);
                //dbContext.SaveChanges();
                //Have problem to run ,because the foreign key, have to delete the student, then you can delete the teacher.
            }
            return RedirectToAction("Show");
        }
        [HttpGet]//Detail function 具体细节链接
        public ActionResult Detail(int id)
        {
            Teacher targetTeacher = null;
            using (SchoolEntities dbContext=new SchoolEntities())
            {
                              targetTeacher = dbContext.Teachers.Include("Students").SingleOrDefault(m => m.Id == id);
                            }

            return View(targetTeacher);
                    }
     
    }
}