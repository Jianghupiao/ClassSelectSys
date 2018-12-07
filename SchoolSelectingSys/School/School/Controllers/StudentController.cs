using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using School;

namespace School.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Show()
        {
            List<Student> showAllStudents = null;
            using (SchoolEntities dbContext = new SchoolEntities())
            {
                showAllStudents = dbContext.Students.ToList();

            }
            return View("StudentList", showAllStudents);
        }
        [HttpGet]
        public ActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Create(Student student)
        {
            using (SchoolEntities dbContext = new SchoolEntities())
            {
                dbContext.Students.Add(student);
                dbContext.SaveChanges();

            }
            return View("Show");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Student targetStudent = null;
            using (SchoolEntities dbContext = new SchoolEntities())
            {
                targetStudent = dbContext.Students.SingleOrDefault(m => m.Id == id);
            }
            return View(targetStudent);
        }
        [HttpPost]
        public ActionResult Edit(Student student)
        {

            return RedirectToAction("Show");
        }



        [HttpGet]
        public ActionResult Delete(int id)
        {

            using (SchoolEntities dbContext = new SchoolEntities())
            {
                Student targetStudent = dbContext.Students.SingleOrDefault(m => m.Id == id);
                if (targetStudent != null)
                {
                    dbContext.Entry(targetStudent).State = System.Data.Entity.EntityState.Deleted;
                    //dbContext.Students.Remove(targetStudent);
                    dbContext.SaveChanges();
                }
            }
            return RedirectToAction("Show");
        }

        //Delete need to detail program.

        [HttpGet]
        public ActionResult Detail(int id)
        {
            Student targetStudent = null;
            using (SchoolEntities dbContext = new SchoolEntities())
            {
                targetStudent = dbContext.Students.SingleOrDefault(m => m.Id == id);

            }
            return View(targetStudent);
        }


    }
}