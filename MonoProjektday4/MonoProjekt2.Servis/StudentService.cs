using MonoProjekt2.Common.Filters;
using MonoProjekt2.Common.Paging;
using MonoProjekt2.Common.Sorting;
using MonoProjekt2.Models.DomainModels;
using MonoProjekt2.Repository;
using MonoProjekt2WebApi.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MonoProjekt2.Servis
{
    public class StudentService
    {
        public async Task<List<Student>> GetAllStudentsAsync(StudentFilter studentFilter,Sort sort,Paging page)
        {
            StudentRepository studentRepository = new StudentRepository();
            CourseService courseServis = new CourseService();
            List<StudentDomainModel> domainStudents = await studentRepository.GetAllStudentsAsync(studentFilter,sort,page);
            List<Student> students = new List<Student>();
            List<Course> courses = await courseServis.GetAllCoursesAsync(null);
            foreach(StudentDomainModel domainStudent in domainStudents)
            {
                students.Add(new Student(domainStudent.Id, domainStudent.FirstName, domainStudent.LastName, domainStudent.CourseId, courses.Find(course => course.Id == domainStudent.CourseId)));
            }
            return students;
        }
        public async Task<Student> GetStudentAsync(Guid id)
        {
            StudentRepository studentRepository = new StudentRepository();
            CourseService courseServis = new CourseService();
            StudentDomainModel domainStudent = await studentRepository.GetStudentAsync(id);
            Student student = new Student(domainStudent.Id,domainStudent.FirstName,domainStudent.LastName,domainStudent.CourseId,await courseServis.GetCourseAsync(domainStudent.CourseId));

            return student;
        }

        public async Task<Boolean> PostNewStudenAsync(StudentDomainModel newStudent)
        {
            StudentRepository repository = new StudentRepository();
            Boolean result = await repository.PostNewStudenAsync(newStudent);
            return result;
        }
        public async Task<Boolean> PutAsync(StudentDomainModel updatedStudent)
        {
            StudentRepository repository = new StudentRepository();
            Boolean result = await repository.PutAsync(updatedStudent);
            return result;
        }
        public async Task<Boolean> Delete(Guid id)
        {
            StudentRepository repository = new StudentRepository();
            Boolean result = await repository.DeleteAsync(id);
            return result;
        }
    }
}
