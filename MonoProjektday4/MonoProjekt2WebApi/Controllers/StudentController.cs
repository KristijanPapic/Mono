using MonoProjekt2.Servis;
using MonoProjekt2WebApi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MonoProjekt2WebApi.Controllers
{
    public class StudentController : ApiController
    {
        public HttpResponseMessage GetAllStudents()
        {
            StudentServis servis = new StudentServis();
            List<StudentViewModel> students = servis.GetAllStudents();
            if(students.Count == 0) return Request.CreateResponse(HttpStatusCode.NotFound,"there are curently no students in the database");
            else return Request.CreateResponse(HttpStatusCode.OK,students);
        }
        public HttpResponseMessage GetStudent([FromUri] Guid id)
        {
            StudentServis servis = new StudentServis();
            StudentViewModel student = servis.GetStudent(id);
            if(student == null) return Request.CreateResponse(HttpStatusCode.NotFound,"there is curently no student with that id");
            else return Request.CreateResponse(HttpStatusCode.OK,student);
        }

        public HttpResponseMessage PostNewStudent([FromBody] StudentViewModel newStudent)
        {
            StudentServis servis = new StudentServis();
            return Request.CreateResponse(HttpStatusCode.OK, servis.PostNewStuden(newStudent));


        }
        public HttpResponseMessage Put([FromBody] StudentViewModel updatedStudent)
        {
            StudentServis servis = new StudentServis();
            return Request.CreateResponse(HttpStatusCode.OK, servis.Put(updatedStudent));
        }
        public HttpResponseMessage Delete([FromUri] Guid id)
        {
            StudentServis servis = new StudentServis();
            return Request.CreateResponse(HttpStatusCode.OK, servis.Delete(id));
        }
    }
}
