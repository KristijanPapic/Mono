using MonoProjekt2WebApi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MonoProjekt2WebApi.Controllers
{
    public class StudentController : ApiController
    {
        List<StudentViewModel> students = new List<StudentViewModel>();
        
        public HttpResponseMessage GetAllStudents ()
        {
            string connectionString = "Server=tcp:monoprojektdbserver.database.windows.net,1433;Initial Catalog=monoprojekt;Persist Security Info=False;User ID=kristijan;Password=Robinhoodr52600;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            SqlConnection connection = new SqlConnection(connectionString);

            string queryString = "select * from [dbo].[student]";
            using (connection)
            {
                SqlDataAdapter adapter = new SqlDataAdapter(queryString, connection);
                DataSet student = new DataSet();
                adapter.Fill(student,"students");
                return Request.CreateResponse(HttpStatusCode.OK, student);

            }
                
                

        }

    

        public HttpResponseMessage GetStudent([FromUri] int id)
        {
            string connectionString = "Server=tcp:monoprojektdbserver.database.windows.net,1433;Initial Catalog=monoprojekt;Persist Security Info=False;User ID=kristijan;Password=Robinhoodr52600;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            SqlConnection connection = new SqlConnection(connectionString);

            string queryString = "select * from [dbo].[student] where id = " + id;
                SqlDataAdapter adapter = new SqlDataAdapter(queryString, connection);
                DataSet student = new DataSet();
                adapter.Fill(student, "studenti");
                return Request.CreateResponse(HttpStatusCode.OK, student);
                
                
            
            

        }

        public HttpResponseMessage PostNewStudent([FromBody] StudentViewModel newStudent)
        {
            string connectionString = "Server=tcp:monoprojektdbserver.database.windows.net,1433;Initial Catalog=monoprojekt;Persist Security Info=False;User ID=kristijan;Password=Robinhoodr52600;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            SqlConnection connection = new SqlConnection(connectionString);

            string sqlQuery = "insert into student (id,firstName,lastname) values ('" + newStudent.GetId + "','"
              + newStudent.GetFirstName + "','" + newStudent.GetLastName + "');";
            connection.Open();
            SqlCommand command = new SqlCommand(sqlQuery, connection);
            command.ExecuteNonQuery();
            connection.Close();
            return Request.CreateResponse(HttpStatusCode.OK);

        }
        public HttpResponseMessage Put([FromBody] StudentViewModel updatedStudent)
        {
           
                string connectionString = "Server=tcp:monoprojektdbserver.database.windows.net,1433;Initial Catalog=monoprojekt;Persist Security Info=False;User ID=kristijan;Password=Robinhoodr52600;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                SqlConnection connection = new SqlConnection(connectionString);
                string sqlQuery = "update student set firstName = '" + updatedStudent.GetFirstName 
                    + "',lastname = '" + updatedStudent.GetLastName + "' where id =" + updatedStudent.GetId + ";";
                connection.Open();
                SqlCommand command = new SqlCommand(sqlQuery, connection);
                command.ExecuteNonQuery();
                connection.Close();
                return Request.CreateResponse(HttpStatusCode.OK);

            

        }
        public HttpResponseMessage Delete([FromUri]int id)
        {
            string connectionString = "Server=tcp:monoprojektdbserver.database.windows.net,1433;Initial Catalog=monoprojekt;Persist Security Info=False;User ID=kristijan;Password=Robinhoodr52600;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            SqlConnection connection = new SqlConnection(connectionString);
            string sqlQuery = "delete from student where id = " + id + ";";
            connection.Open();
            SqlCommand command = new SqlCommand(sqlQuery, connection);
            command.ExecuteNonQuery();
            connection.Close();
            return Request.CreateResponse(HttpStatusCode.OK);


        }
    }
}
