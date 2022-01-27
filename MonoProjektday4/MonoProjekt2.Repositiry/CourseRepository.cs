using MonoProjekt2WebApi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoProjekt2.Repository
{
    public class CourseRepository
    {
        private readonly string connectionString = "Server = tcp:monoprojektdbserver.database.windows.net,1433;Initial Catalog = monoprojekt; Persist Security Info=False;User ID = kristijan; Password=Robinhoodr52600;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout = 30;";
        public List<CourseViewModel> GetAllCourses()
        {
            List<CourseViewModel> courses = new List<CourseViewModel>();
            SqlConnection connection = new SqlConnection(connectionString);

            string queryString = "select * from [dbo].[Course]";
            SqlDataAdapter adapter = new SqlDataAdapter(queryString, connection);
            DataSet course = new DataSet();
            try
            {
                adapter.Fill(course, "courses");
                connection.Close();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
            foreach (DataRow dataRow in course.Tables[0].Rows)
            {
                courses.Add(new CourseViewModel(Guid.Parse(Convert.ToString(dataRow["Id"])),Convert.ToString(dataRow["Name"])));
            }
            return courses;


        }
        public CourseViewModel GetCourse(Guid id)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string queryString = "select * from [dbo].[Course] where Id = @ID";
            SqlCommand command = new SqlCommand(queryString, connection);
            command.Parameters.Add("@ID", SqlDbType.UniqueIdentifier);
            command.Parameters["@ID"].Value = id;
            SqlDataAdapter adapter = new SqlDataAdapter(command);

            DataSet course = new DataSet();
            try
            {
                adapter.Fill(course, "courses");
                connection.Close();

            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
            if (course.Tables[0].Rows.Count == 0) return null;
            DataRow dataRow = course.Tables[0].Rows[0];
            CourseViewModel courseModel = new CourseViewModel(Guid.Parse(Convert.ToString(dataRow["Id"])), Convert.ToString(dataRow["Name"]));
            return courseModel;
        }

        public Boolean PostNewCourse(CourseViewModel newCourse)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string sqlQuery = "insert into Course (Name) values (@NAME);";
            SqlCommand command = new SqlCommand(sqlQuery, connection);
            command.Parameters.Add("@NAME", SqlDbType.VarChar);
            command.Parameters["@NAME"].Value = newCourse.Name;
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                return false;

            }

            return true;

        }
        public Boolean Put(CourseViewModel updatedCourse)
        {

            SqlConnection connection = new SqlConnection(connectionString);
            string sqlQuery = "update Course set Name = @NAME where Id = @ID";
            SqlCommand command = new SqlCommand(sqlQuery, connection);
            command.Parameters.Add("@FNAME", SqlDbType.VarChar);
            command.Parameters["@FNAME"].Value = updatedCourse.Name;
            command.Parameters.Add("@ID", SqlDbType.UniqueIdentifier);
            command.Parameters["@ID"].Value = updatedCourse.Id;

            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                return false;
            }

            return true;

        }
        public Boolean Delete(Guid id)
        {

            SqlConnection connection = new SqlConnection(connectionString);
            string sqlQuery = "delete from course where id = @ID";
            SqlCommand command = new SqlCommand(sqlQuery, connection);
            command.Parameters.AddWithValue("@ID", id);

            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                return false;
            }
            return true;

        }
    }
}

