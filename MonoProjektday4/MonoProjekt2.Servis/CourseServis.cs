using MonoProjekt2.DAL.Entities;
using MonoProjekt2.Repository;
using MonoProjekt2WebApi.Models;
using System;
using System.Collections.Generic;

namespace MonoProjekt2.Servis
{
    public class CourseServis
    {
        public List<CourseViewModel> GetAllCourses()
        {
            CourseRepository repository = new CourseRepository();
            return repository.GetAllCourses();
        }
        public CourseViewModel GetCourse(Guid id)
        {
            CourseRepository repository = new CourseRepository();
            return repository.GetCourse(id);
        }

        public Boolean PostNewStuden(CourseEntity newCourse)
        {
            CourseRepository repository = new CourseRepository();
            return repository.PostNewCourse(newCourse);
        }
        public Boolean Put(CourseEntity updatedCourse)
        {
            CourseRepository repository = new CourseRepository();
            return repository.Put(updatedCourse);
        }
        public Boolean Delete(Guid id)
        {
            CourseRepository repository = new CourseRepository();
            return repository.Delete(id);
        }
    }
}
