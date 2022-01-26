using MonoProjekt2WebApi.Models;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MonoProjekt2WebApi.Controllers
{
    public class CourseController : ApiController
    {
        private readonly string connectionString = "Server = tcp:monoprojektdbserver.database.windows.net,1433;Initial Catalog = monoprojekt; Persist Security Info=False;User ID = kristijan; Password=Robinhoodr52600;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout = 30;";
        public HttpResponseMessage GetAllCourses()
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string queryString = "select * from [dbo].[course]";
            SqlDataAdapter adapter = new SqlDataAdapter(queryString, connection);
            DataSet course = new DataSet();
            try
            {
                adapter.Fill(course, "courses");
                connection.Close();
            }
            catch (Exception exception)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, exception);
            }
            if (course.Tables[0].Rows.Count == 0) return Request.CreateResponse(HttpStatusCode.NotFound, "There are curently no courses in the database");
            return Request.CreateResponse(HttpStatusCode.OK, course);

        }
        public HttpResponseMessage GetCourse([FromUri] int id)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string courseQueryString = "select * from [dbo].[course] where id = " + id;
            SqlDataAdapter courseAdapter = new SqlDataAdapter(courseQueryString, connection);
            string studentsQueryString = "select * from [dbo].[student] where courseId = " + id;
            SqlDataAdapter studentsAdapter = new SqlDataAdapter(studentsQueryString, connection);
            DataSet course = new DataSet();
            try
            {
                courseAdapter.Fill(course, "course");
                studentsAdapter.Fill(course, "students in course");
                connection.Close();

            }
            catch (Exception exception)
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest, exception.Message);

            }
            if (course.Tables[0].Rows.Count == 0) return Request.CreateResponse(HttpStatusCode.NotFound, "There is curently no course with that id");

            return Request.CreateResponse(HttpStatusCode.OK, course);
        }

        public HttpResponseMessage PostNewCourse([FromBody] CourseViewModel newCourse)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            HttpResponseMessage getCourseMessage = GetCourse(newCourse.GetId);
            if (getCourseMessage.IsSuccessStatusCode)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "course with that id already exists");
            }

            string sqlQuery = "insert into course (id,name) values (" + newCourse.GetId + ",'"
              + newCourse.GetName + "');";
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlQuery, connection);
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception exception)
            {
                if (exception.Message.Contains("duplicate key")) return Request.CreateResponse(HttpStatusCode.BadRequest, "course with that id already exists");
                return Request.CreateResponse(HttpStatusCode.BadRequest, exception);

            }

            return Request.CreateResponse(HttpStatusCode.OK);

        }
        public HttpResponseMessage Put([FromBody] CourseViewModel updatedCourse)
        {

            SqlConnection connection = new SqlConnection(connectionString);
            string sqlQuery = "update course set name = '" + updatedCourse.GetName + "' where id = " + updatedCourse.GetId + ";";
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
        public HttpResponseMessage Delete([FromUri] int id)          //fali mi brisanje studenata koji su na tom coursu, napravim to sutra.
        {
            HttpResponseMessage getCourseMessage = GetCourse(id);
            if (getCourseMessage.IsSuccessStatusCode)
            {
                SqlConnection connection = new SqlConnection(connectionString);
                string sqlQuery = "delete from course where id = " + id + ";";

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
            else return getCourseMessage;

        }
    }
}
