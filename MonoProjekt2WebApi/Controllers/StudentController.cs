using MonoProjekt2WebApi.Models;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MonoProjekt2WebApi.Controllers
{
    public class StudentController : ApiController
    {
        private readonly string connectionString = "Server = tcp:monoprojektdbserver.database.windows.net,1433;Initial Catalog = monoprojekt; Persist Security Info=False;User ID = kristijan; Password=Robinhoodr52600;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout = 30;";
        public HttpResponseMessage GetAllStudents()
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string queryString = "select * from [dbo].[student]";
            SqlDataAdapter adapter = new SqlDataAdapter(queryString, connection);
            DataSet student = new DataSet();
            try
            {
                adapter.Fill(student, "students");
                connection.Close();
            }
            catch (Exception exception)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, exception);
            }
            if (student.Tables[0].Rows.Count == 0) return Request.CreateResponse(HttpStatusCode.NotFound, "There are curently no students in the database");
            return Request.CreateResponse(HttpStatusCode.OK, student);

        }
        public HttpResponseMessage GetStudent([FromUri] int id)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string queryString = "select * from [dbo].[student] where id = " + id;
            SqlDataAdapter adapter = new SqlDataAdapter(queryString, connection);
            DataSet student = new DataSet();
            try
            {
                adapter.Fill(student, "studenti");
                connection.Close();

            }
            catch (Exception exception) 
            {
                
                return Request.CreateResponse(HttpStatusCode.BadRequest, exception.Message);
                
            }
            if (student.Tables[0].Rows.Count == 0) return Request.CreateResponse(HttpStatusCode.NotFound, "There is curently no student with that id");

            return Request.CreateResponse(HttpStatusCode.OK, student);
        }

        public HttpResponseMessage PostNewStudent([FromBody] StudentViewModel newStudent)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            HttpResponseMessage getStudentMessage = GetStudent(newStudent.GetId);
            if (getStudentMessage.IsSuccessStatusCode)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "student with that id already exists");
            }

                string sqlQuery = "insert into student (id,firstName,lastname,courseId) values ('" + newStudent.GetId + "','"
              + newStudent.GetFirstName + "','" + newStudent.GetLastName + "','" + newStudent.GetCourseId + "');";
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlQuery, connection);
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception exception)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, exception);

            }

            return Request.CreateResponse(HttpStatusCode.OK);

        }
        public HttpResponseMessage Put([FromBody] StudentViewModel updatedStudent)
        {

            SqlConnection connection = new SqlConnection(connectionString);
            string sqlQuery = "update student set firstName = '" + updatedStudent.GetFirstName
                + "',lastname = '" + updatedStudent.GetLastName + "',courseId = " + updatedStudent.GetCourseId + " where id =" + updatedStudent.GetId + ";";
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlQuery, connection);
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch(Exception exception)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, exception);
            }

            return Request.CreateResponse(HttpStatusCode.OK);

        }
        public HttpResponseMessage Delete([FromUri] int id)
        {
            HttpResponseMessage getStudentMessage = GetStudent(id);
            if (getStudentMessage.IsSuccessStatusCode)
            {
                SqlConnection connection = new SqlConnection(connectionString);
                string sqlQuery = "delete from student where id = " + id + ";";

                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlQuery, connection);
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception exception)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, exception);
                }

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else return getStudentMessage;

        }
    }
}
