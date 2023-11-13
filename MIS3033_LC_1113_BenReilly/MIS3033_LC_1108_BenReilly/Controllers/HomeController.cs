using Microsoft.AspNetCore.Mvc;
using MIS3033_LC_1108_BenReilly.Data;
using MIS3033_LC_1108_BenReilly.Models;

namespace MIS3033_LC_1108_BenReilly.Controllers
{
    public class HomeController : Controller
    {
        StuDB db = new StuDB();

        public JsonResult EditStu(string id, string name, DateTime dob)
        {
            Student stu; // complex
                         // stu = new Student();
            stu = db.Students.Where(x => x.Id == id).FirstOrDefault();
            // if there is any student in the where, we are going to pick the first one
            // if not, null

            //stu.Id = id;
            stu.Name = name;
            //stu.DOB = dob.ToLocalTime(); // could not change the primary key
            stu.DOB = dob.ToUniversalTime();

            //db.Students.Add(stu);
            db.SaveChanges();


            Message mes; // complex 
            mes = new Message();
            mes.status = "success";
            mes.message = "Student edited successfully";
            return Json(mes);
        }



        public JsonResult DeleteStu(string id)
        {
            Message mes; // complex 
            mes = new Message();

            if(id == null)
            {
                mes.status="fail";
                mes.message = "You need to provide a student ID";
                return Json(mes);

            }
            id = id.Trim(); // delete spaces at beginning and end of string 
            if (id == "")
            {
                mes.status = "fail";
                mes.message = "You need to provide a student ID";
                return Json(mes);

            }


            Student stu; // complex
            stu = db.Students.Where(x => x.Id.ToLower() == id.ToLower()).FirstOrDefault();

            if (stu == null)
            {
                mes.status = "fail";
                mes.message = $"Student ID {id} does not exist in the DB!";
                return Json(mes);

            }



            db.Students.Remove(stu);
            db.SaveChanges();          


           
            mes.status = "success";
            mes.message = "Student deleted successfully";
            return Json(mes);
        }



        public JsonResult AddStu(string id, string name, DateTime dob) 
        {
            Student stu; // complex
            stu = new Student();
            stu.Id = id;
            stu.Name = name;
            //stu.DOB = dob.ToLocalTime(); 
            stu.DOB = dob.ToUniversalTime(); 

            db.Students.Add(stu);
            db.SaveChanges();


            Message mes; // complex 
            mes = new Message();

            return Json(mes);
        }

        public JsonResult GetStus()
        {
            var r = db.Students.Select(x => new {id = x.Id, name = x.Name, dob = x.DOB.ToString("MMMM dd, yyyy ") });
            return Json(r);
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
