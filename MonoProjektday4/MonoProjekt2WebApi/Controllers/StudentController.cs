using MonoProjekt2.Common.Filters;
using MonoProjekt2.Common.Paging;
using MonoProjekt2.Common.Sorting;
using MonoProjekt2.Models.DomainModels;
using MonoProjekt2.Servis;
using MonoProjekt2WebApi.Models;
using MonoProjekt2WebApi.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace MonoProjekt2WebApi.Controllers
{
    public class StudentController : ApiController
    {
        StudentService service = new StudentService();
        public async Task<HttpResponseMessage> GetAllStudentsAsync(string search="",string sortBy="",string sortMethod="",int page=1)
        {
            Paging paging = new Paging(page);
            StudentFilter studentFilter = new StudentFilter(search);
            Sort sort = new Sort(sortBy, sortMethod);
            List<Student> students =await  service.GetAllStudentsAsync(studentFilter,sort,paging);
            if (students == null) return Request.CreateResponse(HttpStatusCode.NotFound, "there are curently no students in the database");
            List<StudentViewModel> viewStudents = new List<StudentViewModel>();
            foreach(Student student in students)
            {
                viewStudents.Add(new StudentViewModel(student.FirstName, student.LastName, student.Course.Name));
            }
            return Request.CreateResponse(HttpStatusCode.OK, viewStudents);
        }
        public async Task<HttpResponseMessage> GetStudentAsync([FromUri] Guid id)
        {
            Student student = await service.GetStudentAsync(id);
            if (student == null) return Request.CreateResponse(HttpStatusCode.NotFound, "there is curently no student with that id");
            StudentViewModel viewStudent = new StudentViewModel(student.FirstName, student.LastName, student.Course.Name);
             return Request.CreateResponse(HttpStatusCode.OK, viewStudent);
        }

        public async Task<HttpResponseMessage> PostNewStudentAsync([FromBody] StudentPostModel newStudent)
        {
            
            StudentDomainModel domainStudent = new StudentDomainModel(Guid.NewGuid(), newStudent.FirstName, newStudent.LastName, newStudent.CourseId);
            if ( await service.PostNewStudenAsync(domainStudent)) return Request.CreateResponse(HttpStatusCode.OK, "student posted");
            else return Request.CreateResponse(HttpStatusCode.BadRequest); 



        }
        public async Task<HttpResponseMessage> PutAsync([FromBody] StudentUpdateModel updatedStudent)
        {
            StudentDomainModel domainStudent = new StudentDomainModel(updatedStudent.Id, updatedStudent.FirstName, updatedStudent.LastName, updatedStudent.CourseId);

            if ( await service.PutAsync(domainStudent)) return Request.CreateResponse(HttpStatusCode.OK, "student updated");
            else return Request.CreateResponse(HttpStatusCode.NotFound, "no student with that id");
            
        }
        public async Task<HttpResponseMessage> DeleteAsync([FromUri] Guid id)
        {
            if(await service.Delete(id)) return Request.CreateResponse(HttpStatusCode.OK,"student deleted");
            else return Request.CreateResponse(HttpStatusCode.NotFound,"no student with that id");
        }
    }
}
