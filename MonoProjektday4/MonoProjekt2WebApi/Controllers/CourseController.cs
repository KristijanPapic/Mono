using AutoMapper;
using MonoProjekt2.Common.Filters;
using MonoProjekt2.Common.Paging;
using MonoProjekt2.Common.Sorting;
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
        ICourseService courseService;
        IMapper mapper;

        public CourseController(ICourseService courseService,IMapper mapper)
        {
            this.courseService = courseService;
            this.mapper = mapper;
        }

        public async Task<HttpResponseMessage> GetAllCourses(Boolean dontGetList = false,string search="", string sortBy = "Name", string sortMethod = "", int page = 1)
        {
            CourseFilter courseFilter = new CourseFilter(search,dontGetList);
            Sort sort = new Sort(sortBy, sortMethod);
            Paging paging = new Paging(page);
            /* List<Course> courses = await courseService.GetAllCoursesAsync(courseFilter,sort,paging);
            if (courses == null) return Request.CreateResponse(HttpStatusCode.NotFound, "there are curently no courses in the database");
            List<CourseViewModel> viewCourses = new List<CourseViewModel>();
            foreach(Course course in courses)
            {
                viewCourses.Add(new CourseViewModel(course.Id, course.Name,course.Students.Count, course.Students));
            } */
            List<Course> courses = await courseService.GetAllCoursesAsync(courseFilter, sort, paging);
            List<CourseViewModel> coursesVM = mapper.Map<List<CourseViewModel>>(courses);
            List<Course> coursetest = mapper.Map<List<Course>>(coursesVM);
            return Request.CreateResponse(HttpStatusCode.OK, coursetest);
        }
        public async Task<HttpResponseMessage> GetCourse([FromUri] Guid id)
        {
            Course course = await  courseService.GetCourseAsync(id);
            if (course == null) return Request.CreateResponse(HttpStatusCode.NotFound, "there is curently no courses with that id");
            CourseViewModel viewCourse = new CourseViewModel(course.Id, course.Name, course.Students, course.Students.Count)
            {

            };
            return Request.CreateResponse(HttpStatusCode.OK, viewCourse);
        }

        public async Task<HttpResponseMessage> PostNewCourse([FromBody] CoursePostModel newCourse)
        {
            CourseDomainModel domainCourse = new CourseDomainModel(Guid.NewGuid(), newCourse.Name);
            if (await courseService.PostNewCourseAsync(domainCourse)) return Request.CreateResponse(HttpStatusCode.OK, "course posted");
            else return Request.CreateResponse(HttpStatusCode.BadRequest);


        }
        public async Task<HttpResponseMessage> Put([FromBody] CourseUpdateModel updatedCourse)
        {
            CourseDomainModel domainCourse = new CourseDomainModel(updatedCourse.Id, updatedCourse.Name);

            if (await courseService.PutAsync(domainCourse)) return Request.CreateResponse(HttpStatusCode.OK, "course updated");
            else return Request.CreateResponse(HttpStatusCode.NotFound, "no course with that id");
        }
        public async Task<HttpResponseMessage> Delete([FromUri] Guid id)
        {
            if (await courseService .Delete(id)) return Request.CreateResponse(HttpStatusCode.OK, "course deleted");
            else return Request.CreateResponse(HttpStatusCode.NotFound, "no course with that id");
        }
    }
}
