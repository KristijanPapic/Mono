﻿using MonoProjekt2.DAL.Entities;
using MonoProjekt2.Models;
using MonoProjekt2.Models.DomainModels;
using MonoProjekt2.Repository;
using MonoProjekt2WebApi.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MonoProjekt2.Servis
{
    public class CourseServis
    {
        public async Task<List<Course>> GetAllCoursesAsync()
        {
            CourseRepository courseRepository = new CourseRepository();
            StudentRepository studentRepository = new StudentRepository();
            List<CourseDomainModel> domainCourses = await courseRepository.GetAllCoursesAsync();
            List<Course> courses = new List<Course>();
            List<StudentListModel> students;
            foreach(CourseDomainModel domainCourse in domainCourses)
            {
                students = await studentRepository.StudentByCourseAsync(domainCourse.Id);
                courses.Add(new Course(domainCourse.Id, domainCourse.Name,students));
            }
            return courses;
        }
        public async Task<Course> GetCourseAsync(Guid id)
        {
            CourseRepository courseRepository = new CourseRepository();
            StudentRepository studentRepository = new StudentRepository();
            CourseDomainModel domainCourse = await courseRepository.GetCourseAsync(id);
            Course course = new Course(domainCourse.Id, domainCourse.Name, await studentRepository.StudentByCourseAsync(domainCourse.Id));
            return course;
        }

        public async Task<Boolean> PostNewCourseAsync(Course newCourse)
        {
            CourseRepository repository = new CourseRepository();
            Boolean result = await repository.PostNewCourseAsync(newCourse);
            return result;
        }
        public async Task<Boolean> PutAsync(Course updatedCourse)
        {
            CourseRepository repository = new CourseRepository();
            Boolean result = await repository.PutAsync(updatedCourse);
            return result;
        }
        public async Task<Boolean> Delete(Guid id)
        {
            CourseRepository repository = new CourseRepository();
            Boolean result = await repository.DeleteAsync(id);
            return result;
        }
    }
}
