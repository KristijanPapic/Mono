using MonoProjekt2.Common.Filters;
using MonoProjekt2.Common.Paging;
using MonoProjekt2.Common.Sorting;
using MonoProjekt2.Models.DomainModels;
using MonoProjekt2.Repository;
using MonoProjekt2WebApi.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace MonoProjekt2.Servis.Common
{
    public class StudentService : IStudentService
    {
        IStudentRepository studentRepository;
        ICourseService courseService;

        //StudentRepository studentRepository = new StudentRepository();

        public StudentService(IStudentRepository studentRepository,ICourseService courseService)
        {
            this.studentRepository = studentRepository;
            this.courseService = courseService;
        }

        public async Task<IPagedList<Student>> GetAllStudentsAsync(StudentFilter studentFilter, Sort sort, Paging page)
        {

            return await studentRepository.GetAllStudentsAsync(studentFilter, sort, page);
        }
        public async Task<Student> GetStudentAsync(Guid id)
        {
            Student student = await studentRepository.GetStudentAsync(id);

            return student;
        }

        public async Task<Boolean> PostNewStudenAsync(StudentDomainModel newStudent)
        {
            Boolean result = await studentRepository.PostNewStudenAsync(newStudent);
            return result;
        }
        public async Task<Boolean> PutAsync(StudentDomainModel updatedStudent)
        {
            Boolean result = await studentRepository.PutAsync(updatedStudent);
            return result;
        }
        public async Task<Boolean> Delete(Guid id)
        {
            Boolean result = await studentRepository.DeleteAsync(id);
            return result;
        }
    }
}
