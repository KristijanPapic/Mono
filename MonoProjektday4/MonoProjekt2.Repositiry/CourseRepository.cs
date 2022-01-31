using MonoProjekt2WebApi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using MonoProjekt2.DAL.Entities;
using System.Threading.Tasks;
using MonoProjekt2.Models.DomainModels;
using MonoProjekt2.Common.Filters;

namespace MonoProjekt2.Repository
{
    public class CourseRepository
    {
        private readonly string connectionString = "Server = tcp:monoprojektdbserver.database.windows.net,1433;Initial Catalog = monoprojekt; Persist Security Info=False;User ID = kristijan; Password=Robinhoodr52600;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout = 30;";
        public async Task<List<Course>> GetAllCoursesAsync(CourseFilter courseFilter)
        {
            
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command;
            string queryString;
            if (courseFilter == null)
            {
                queryString = "select * from course";
                command = new SqlCommand(queryString, connection);
            }
            else
            {
                queryString = "select * from course where Name like @FILTER";
                command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@FILTER", "%" + courseFilter.NameFilterParam + "%");                  //napravim paging i sort za course kad paging za studenta do kraja napravim
            }
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
            StudentRepository studentRepository = new StudentRepository();

            if (course.Tables[0].Rows.Count == 0) return null;
            List<Course> courses = new List<Course>();
            foreach (DataRow dataRow in course.Tables[0].Rows)
            {
                courses.Add(new Course(Guid.Parse(Convert.ToString(dataRow["Id"])), Convert.ToString(dataRow["Name"]),await studentRepository.StudentsByCourseAsync(Guid.Parse(Convert.ToString(dataRow["Id"])))));
            }
            return courses;


        }
        public async Task<CourseDomainModel> GetCourseAsync(Guid id)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string queryString = "select * from course where id = @ID;";
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

        public async Task<Boolean> PostNewCourseAsync(CourseDomainModel newCourse)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string sqlQuery = "insert into Course (Id,Name) values (@ID,@NAME);";
            SqlCommand command = new SqlCommand(sqlQuery, connection);
            command.Parameters.Add("@ID", SqlDbType.UniqueIdentifier);
            command.Parameters["@ID"].Value = newCourse.Id;
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
        public async Task<Boolean> PutAsync(CourseDomainModel updatedCourse)
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

