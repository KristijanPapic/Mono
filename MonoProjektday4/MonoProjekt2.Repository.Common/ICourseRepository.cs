﻿using MonoProjekt2.Common.Filters;
using MonoProjekt2.Models.DomainModels;
using MonoProjekt2WebApi.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MonoProjekt2.Repository
{
    public interface ICourseRepository
    {
        Task<bool> DeleteAsync(Guid id);
        Task<List<Course>> GetAllCoursesAsync(bool dontGetList, CourseFilter courseFilter);
        Task<Course> GetCourseAsync(Guid id);
        Task<bool> PostNewCourseAsync(CourseDomainModel newCourse);
        Task<bool> PutAsync(CourseDomainModel updatedCourse);
    }
}