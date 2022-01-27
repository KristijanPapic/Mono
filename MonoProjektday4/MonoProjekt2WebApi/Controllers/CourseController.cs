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
    public class CourseController : ApiController
    {
        public HttpResponseMessage GetAllCourses()
        {
            CourseServis servis = new CourseServis();
            List<CourseViewModel> Courses = servis.GetAllCourses();
            return Request.CreateResponse(HttpStatusCode.OK, Courses);
        }
        public HttpResponseMessage GetCourse([FromUri] Guid id)
        {
            CourseServis servis = new CourseServis();
            return Request.CreateResponse(HttpStatusCode.OK, servis.GetCourse(id));
        }

        public HttpResponseMessage PostNewCourse([FromBody] CourseViewModel newCourse)
        {
            CourseServis servis = new CourseServis();
            return Request.CreateResponse(HttpStatusCode.OK, servis.PostNewStuden(newCourse));


        }
        public HttpResponseMessage Put([FromBody] CourseViewModel updatedCourse)
        {
            CourseServis servis = new CourseServis();
            return Request.CreateResponse(HttpStatusCode.OK, servis.Put(updatedCourse));
        }
        public HttpResponseMessage Delete([FromUri] Guid id)
        {
            CourseServis servis = new CourseServis();
            return Request.CreateResponse(HttpStatusCode.OK, servis.Delete(id));
        }
    }
}
