using MonoProjekt2WebApi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using MonoProjekt2.DAL.Entities;
using System.Threading.Tasks;
using MonoProjekt2.Models.DomainModels;

namespace MonoProjekt2.Repository
{
    public class CourseRepository
    {
        private readonly string connectionString = "Server = tcp:monoprojektdbserver.database.windows.net,1433;Initial Catalog = monoprojekt; Persist Security Info=False;User ID = kristijan; Password=Robinhoodr52600;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout = 30;";
        public async Task<List<CourseDomainModel>> GetAllCoursesAsync()
        {
            List<CourseDomainModel> courses = new List<CourseDomainModel>();
            SqlConnection connection = new SqlConnection(connectionString);

            string queryString = "select Course.Id,Course.Name,COUNT(Student.Id) AS NumberOfEnrolledStudents FROM Student LEFT JOIN Course ON Student.CourseId = Course.Id GROUP BY Course.Id,Course.Name;";
            SqlDataAdapter adapter = new SqlDataAdapter(queryString, connection);
            DataSet course = new DataSet();
            try
            {
                await Task.Run(() => adapter.Fill(course, "courses"));
                connection.Close();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
            if (course.Tables[0].Rows.Count == 0) return null;
            foreach (DataRow dataRow in course.Tables[0].Rows)
            {
                courses.Add(new CourseDomainModel(Guid.Parse(Convert.ToString(dataRow["Id"])), Convert.ToString(dataRow["Name"])));
            }
            return courses;


        }
        public async Task<CourseDomainModel> GetCourseAsync(Guid id)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string queryString = "select Course.Id,Course.Name,COUNT(Student.Id) AS NumberOfEnrolledStudents FROM Student LEFT JOIN Course ON Student.CourseId = Course.Id WHERE Course.Id = @ID GROUP BY Course.Id,Course.Name;";
            SqlCommand command = new SqlCommand(queryString, connection);
            command.Parameters.Add("@ID", SqlDbType.UniqueIdentifier);
            command.Parameters["@ID"].Value = id;
            SqlDataAdapter adapter = new SqlDataAdapter(command);

            DataSet course = new DataSet();
            try
            {
                await Task.Run(() => adapter.Fill(course, "courses"));
                connection.Close();

            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
            if (course.Tables[0].Rows.Count == 0) return null;
            DataRow dataRow = course.Tables[0].Rows[0];
            CourseDomainModel courseModel = new CourseDomainModel(Guid.Parse(Convert.ToString(dataRow["Id"])), Convert.ToString(dataRow["Name"]));
            return courseModel;
        }

        public async Task<Boolean> PostNewCourseAsync(Course newCourse)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string sqlQuery = "insert into Course (Name) values (@NAME);";
            SqlCommand command = new SqlCommand(sqlQuery, connection);
            command.Parameters.Add("@NAME", SqlDbType.VarChar);
            command.Parameters["@NAME"].Value = newCourse.Name;
            try
            {
                connection.Open();
                await command.ExecuteNonQueryAsync();
                connection.Close();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                return false;

            }

            return true;

        }
        public async Task<Boolean> PutAsync(Course updatedCourse)
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
               await command.ExecuteNonQueryAsync();
                connection.Close();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                return false;
            }

            return true;

        }
        public async Task<Boolean> DeleteAsync(Guid id)
        {

            SqlConnection connection = new SqlConnection(connectionString);
            string sqlQuery = "delete from course where id = @ID";
            SqlCommand command = new SqlCommand(sqlQuery, connection);
            command.Parameters.AddWithValue("@ID", id);

            try
            {
                connection.Open();
                await command.ExecuteNonQueryAsync ();
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

