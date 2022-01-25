using MonoProjekt2WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MonoProjekt2WebApi.Controllers
{
    public class StudentController : ApiController
    {
        public static List<StudentViewModel> students = new List<StudentViewModel>();


        public HttpResponseMessage GetAllStudents ()
        {
            if (students.Any()){
                return Request.CreateResponse(HttpStatusCode.OK, students);
            }
            else return Request.CreateResponse(HttpStatusCode.NotFound);

        }

        public HttpResponseMessage GetStudent([FromUri] int id)
        {
            if (students.Any(student => student.Id1 == id))
            {
                return Request.CreateResponse(HttpStatusCode.OK, students.Where(student => student.Id1 == id));
            }
            else return Request.CreateResponse(HttpStatusCode.NotFound);            

        }

        public HttpResponseMessage PostNewStudent([FromBody] StudentViewModel newStudent)
        {
            if (students.Any(student => student.Id1 == newStudent.Id1))
            {
                return Request.CreateResponse(HttpStatusCode.Conflict, "student with same id already exists");
            }
            students.Add(newStudent);


            return Request.CreateResponse(HttpStatusCode.OK);
        }
        public HttpResponseMessage Put([FromBody] StudentViewModel updatedStudent)
        {
            if(students.Any(student => student.Id1 == updatedStudent.Id1))
            {
                int index= students.FindIndex(student => student.Id1 == updatedStudent.Id1);
                students[index] = updatedStudent;
                return Request.CreateResponse(HttpStatusCode.OK);
            }

            return Request.CreateResponse(HttpStatusCode.NotFound);
        }
        public HttpResponseMessage Delete([FromUri]int id)
        {
            if (students.Any(student => student.Id1 == id))
            {
                students.RemoveAll(student => student.Id1 == id);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else return Request.CreateResponse(HttpStatusCode.NotFound);
            
        }
    }
}
