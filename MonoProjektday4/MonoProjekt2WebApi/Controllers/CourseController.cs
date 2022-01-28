using MonoProjekt2.DAL.Entities;
using MonoProjekt2.Models.DomainModels;
using MonoProjekt2.Servis;
using MonoProjekt2WebApi.Models;
using MonoProjekt2WebApi.Models.PostModels;
using MonoProjekt2WebApi.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace MonoProjekt2WebApi.Controllers
{
    public class CourseController : ApiController
    {
        public async Task<HttpResponseMessage> GetAllCourses()
        {
            CourseServis servis = new CourseServis();
            List<Course> courses = await servis.GetAllCoursesAsync();
            if (courses == null) return Request.CreateResponse(HttpStatusCode.NotFound, "there are curently no courses in the database");
            List<CourseViewModel> viewCourses = new List<CourseViewModel>();
            foreach(Course course in courses)
            {
                viewCourses.Add(new CourseViewModel(course.Id, course.Name, course.Students.Count, course.Students));
            }
            return Request.CreateResponse(HttpStatusCode.OK, viewCourses);
        }
        public async Task<HttpResponseMessage> GetCourse([FromUri] Guid id)
        {
            CourseServis servis = new CourseServis();
            Course course = await  servis.GetCourseAsync(id);
            if (course == null) return Request.CreateResponse(HttpStatusCode.NotFound, "there is curently no courses with that id");
            CourseViewModel viewCourse = new CourseViewModel(course.Id, course.Name, course.Students.Count, course.Students);
            return Request.CreateResponse(HttpStatusCode.OK, viewCourse);
        }

        public async Task<HttpResponseMessage> PostNewCourse([FromBody] CoursePostModel newCourse)
        {
            CourseServis servis = new CourseServis();
            CourseDomainModel domainCourse = new CourseDomainModel(Guid.NewGuid(), newCourse.Name);
            if (await servis.PostNewCourseAsync(domainCourse)) return Request.CreateResponse(HttpStatusCode.OK, "course posted");
            else return Request.CreateResponse(HttpStatusCode.BadRequest);


        }
        public async Task<HttpResponseMessage> Put([FromBody] CourseDomainModel updatedCourse)
        {
            CourseServis servis = new CourseServis();
            if (await servis.PutAsync(updatedCourse)) return Request.CreateResponse(HttpStatusCode.OK, "course updated");
            else return Request.CreateResponse(HttpStatusCode.NotFound, "no course with that id");
        }
        public async Task<HttpResponseMessage> Delete([FromUri] Guid id)
        {
            CourseServis servis = new CourseServis();
            if (await servis .Delete(id)) return Request.CreateResponse(HttpStatusCode.OK, "course deleted");
            else return Request.CreateResponse(HttpStatusCode.NotFound, "no course with that id");
        }
    }
}
