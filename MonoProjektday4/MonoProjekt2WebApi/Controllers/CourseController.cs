using MonoProjekt2.DAL.Entities;
using MonoProjekt2.Servis;
using MonoProjekt2WebApi.Models;
using System;
using System.Collections.Generic;
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
            List<CourseViewModel> courses = servis.GetAllCourses();
            if (courses == null) return Request.CreateResponse(HttpStatusCode.NotFound, "there are curently no courses in the database");
            else return Request.CreateResponse(HttpStatusCode.OK, courses);
        }
        public HttpResponseMessage GetCourse([FromUri] Guid id)
        {
            CourseServis servis = new CourseServis();
            CourseViewModel course = servis.GetCourse(id);
            if (course == null) return Request.CreateResponse(HttpStatusCode.NotFound, "there is curently no courses with that id");
            else return Request.CreateResponse(HttpStatusCode.OK, course);
        }

        public HttpResponseMessage PostNewCourse([FromBody] CourseEntity newCourse)
        {
            CourseServis servis = new CourseServis();
            if (servis.PostNewStuden(newCourse)) return Request.CreateResponse(HttpStatusCode.OK, "course posted");
            else return Request.CreateResponse(HttpStatusCode.BadRequest);


        }
        public HttpResponseMessage Put([FromBody] CourseEntity updatedCourse)
        {
            CourseServis servis = new CourseServis();
            if (servis.Put(updatedCourse)) return Request.CreateResponse(HttpStatusCode.OK, "course updated");
            else return Request.CreateResponse(HttpStatusCode.NotFound, "no course with that id");
        }
        public HttpResponseMessage Delete([FromUri] Guid id)
        {
            CourseServis servis = new CourseServis();
            if (servis.Delete(id)) return Request.CreateResponse(HttpStatusCode.OK, "course deleted");
            else return Request.CreateResponse(HttpStatusCode.NotFound, "no course with that id");
        }
    }
}
