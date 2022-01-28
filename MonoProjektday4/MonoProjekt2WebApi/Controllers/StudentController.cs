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
        public async Task<HttpResponseMessage> GetAllStudentsAsync()
        {
            StudentServis servis = new StudentServis();
            List<Student> students =await  servis.GetAllStudentsAsync();
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
            StudentServis servis = new StudentServis();
            Student student = await servis.GetStudentAsync(id);
            if (student == null) return Request.CreateResponse(HttpStatusCode.NotFound, "there is curently no student with that id");
            StudentViewModel viewStudent = new StudentViewModel(student.FirstName, student.LastName, student.Course.Name);
             return Request.CreateResponse(HttpStatusCode.OK, viewStudent);
        }

        public async Task<HttpResponseMessage> PostNewStudentAsync([FromBody] StudentPostModel newStudent)
        {
            
            StudentServis servis = new StudentServis();
            StudentDomainModel domainStudent = new StudentDomainModel(Guid.NewGuid(), newStudent.FirstName, newStudent.LastName, newStudent.CourseId);
            if ( await servis.PostNewStudenAsync(domainStudent)) return Request.CreateResponse(HttpStatusCode.OK, "student posted");
            else return Request.CreateResponse(HttpStatusCode.BadRequest); 



        }
        public async Task<HttpResponseMessage> PutAsync([FromBody] StudentDomainModel updatedStudent)
        {
            StudentServis servis = new StudentServis();
            if ( await servis.PutAsync(updatedStudent)) return Request.CreateResponse(HttpStatusCode.OK, "student updated");
            else return Request.CreateResponse(HttpStatusCode.NotFound, "no student with that id");
            
        }
        public async Task<HttpResponseMessage> DeleteAsync([FromUri] Guid id)
        {
            StudentServis servis = new StudentServis();
            if(await servis.Delete(id)) return Request.CreateResponse(HttpStatusCode.OK,"student deleted");
            else return Request.CreateResponse(HttpStatusCode.NotFound,"no student with that id");
        }
    }
}
