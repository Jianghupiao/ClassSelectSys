using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolDataPopulator
{
    class Program
    {
        static void Main(string[] args)
        {
            SchoolEntities dbContext = new SchoolEntities();
            //    for (int i = 0; i < 10; i++)
            //    {
            //        Teacher teacher = new Teacher();
            //        teacher.Name = String.Format("Teacher#{0}", i + 1);
            //        dbContext.Teachers.Add(teacher);

            //    }
            //    dbContext.SaveChanges();
            //    Console.WriteLine("Done!");
            //    Console.ReadLine();//收到回车结束
            for (int i = 1; i <=100; i++)
            {
                Student student = new Student();
                student.Name = String.Format("Student#{0}", i);
                int teacherId = i % 10;
                student.TeacherId = teacherId == 0 ? 10 : teacherId;
                dbContext.Students.Add(student);
                               
            }
            dbContext.SaveChanges();
            Console.WriteLine("Done");
            Console.ReadLine();
        }
    }
}
