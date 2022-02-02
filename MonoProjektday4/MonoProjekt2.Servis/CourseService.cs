using MonoProjekt2.Common.Filters;
using MonoProjekt2.Common.Paging;
using MonoProjekt2.Common.Sorting;
using MonoProjekt2.DAL.Entities;
using MonoProjekt2.Models;
using MonoProjekt2.Models.DomainModels;
using MonoProjekt2.Repository;
using MonoProjekt2WebApi.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MonoProjekt2.Servis
{
    public class CourseService : ICourseService
    {
        ICourseRepository courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            this.courseRepository = courseRepository;
        }

        public async Task<List<Course>> GetAllCoursesAsync(CourseFilter courseFilter, Sort sort, Paging paging)
        {
            List<Course> courses = await courseRepository.GetAllCoursesAsync(courseFilter,sort,paging);
            return courses;
        }
        public async Task<Course> GetCourseAsync(Guid id)
        {
            Course course = await courseRepository.GetCourseAsync(id);
            return course;
        }

        public async Task<Boolean> PostNewCourseAsync(CourseDomainModel newCourse)
        {
            Boolean result = await courseRepository.PostNewCourseAsync(newCourse);
            return result;
        }
        public async Task<Boolean> PutAsync(CourseDomainModel updatedCourse)
        {
            Boolean result = await courseRepository.PutAsync(updatedCourse);
            return result;
        }
        public async Task<Boolean> Delete(Guid id)
        {
            Boolean result = await courseRepository.DeleteAsync(id);
            return result;
        }
    }
}
