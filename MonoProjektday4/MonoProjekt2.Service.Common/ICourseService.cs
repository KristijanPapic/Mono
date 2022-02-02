using MonoProjekt2.Common.Filters;
using MonoProjekt2.Common.Paging;
using MonoProjekt2.Common.Sorting;
using MonoProjekt2.Models.DomainModels;
using MonoProjekt2WebApi.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MonoProjekt2.Servis
{
    public interface ICourseService
    {
        Task<bool> Delete(Guid id);
        Task<List<Course>> GetAllCoursesAsync(CourseFilter courseFilter,Sort sort,Paging paging);
        Task<Course> GetCourseAsync(Guid id);
        Task<bool> PostNewCourseAsync(CourseDomainModel newCourse);
        Task<bool> PutAsync(CourseDomainModel updatedCourse);
    }
}