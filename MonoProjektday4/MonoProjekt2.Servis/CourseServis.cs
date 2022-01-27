using MonoProjekt2.Repository;
using MonoProjekt2WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public Boolean PostNewStuden(CourseViewModel newCourse)
        {
            CourseRepository repository = new CourseRepository();
            return repository.PostNewCourse(newCourse);
        }
        public Boolean Put(CourseViewModel updatedCourse)
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
