using MonoProjekt2.Models;
using MonoProjekt2.Models.DomainModels;
using MonoProjekt2WebApi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace MonoProjekt2.Repository
{
    public class StudentRepository
    {

        private readonly string connectionString = "Server = tcp:monoprojektdbserver.database.windows.net,1433;Initial Catalog = monoprojekt; Persist Security Info=False;User ID = kristijan; Password=Robinhoodr52600;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout = 30;";
        public async Task<List<StudentDomainModel>> GetAllStudentsAsync()
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string queryString = "select * from student";
            SqlDataAdapter adapter = new SqlDataAdapter(queryString, connection);
            DataSet student = new DataSet();
            try
            {
                await Task.Run(() => adapter.Fill(student));
                connection.Close();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
            if (student.Tables[0].Rows.Count == 0) return null;
            List<StudentDomainModel> students = new List<StudentDomainModel>();
            //CourseRepository courseRepository = new CourseRepository();
            //CourseViewModel course;
            foreach (DataRow dataRow in student.Tables[0].Rows)
            {
                //course = await courseRepository.GetCourseAsync(Guid.Parse(Convert.ToString(dataRow["CourseId"])));
                students.Add(new StudentDomainModel(Guid.Parse(Convert.ToString(dataRow["Id"])), Convert.ToString(dataRow["FirstName"]), Convert.ToString(dataRow["LastName"]), Guid.Parse(Convert.ToString(dataRow["CourseId"]))));
            }
            //await
            return students;


        }
        public async Task<List<StudentListModel>> StudentByCourseAsync(Guid courseId)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string queryString = "select FirstName,LastName from student where CourseId = @CID";
            SqlCommand command = new SqlCommand(queryString, connection);
            command.Parameters.Add("@CID", SqlDbType.UniqueIdentifier);
            command.Parameters["@CID"].Value = courseId;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataSet student = new DataSet();
            try
            {
                await Task.Run(() => adapter.Fill(student));
                connection.Close();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
            if (student.Tables[0].Rows.Count == 0) return null;
            List<StudentListModel> students = new List<StudentListModel>();
            //CourseRepository courseRepository = new CourseRepository();
            //CourseViewModel course;
            foreach (DataRow dataRow in student.Tables[0].Rows)
            {
                //course = await courseRepository.GetCourseAsync(Guid.Parse(Convert.ToString(dataRow["CourseId"])));
                students.Add(new StudentListModel(Convert.ToString(dataRow["FirstName"]), Convert.ToString(dataRow["LastName"])));
            }
            //await
            return students;


        }
        public async Task<StudentDomainModel> GetStudentAsync(Guid id)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string queryString = "select * from [dbo].[Student] where Id = @ID";
            SqlCommand command = new SqlCommand(queryString, connection);
            command.Parameters.AddWithValue("@ID", id);
            SqlDataAdapter adapter = new SqlDataAdapter(command);

            DataSet student = new DataSet();
            try
            {
                await Task.Run(() => adapter.Fill(student, "students"));
                connection.Close();

            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
            if (student.Tables[0].Rows.Count == 0) return null;
            
            DataRow dataRow = student.Tables[0].Rows[0];
            //CourseRepository courseRepository = new CourseRepository();
            //CourseViewModel course = await courseRepository.GetCourseAsync(Guid.Parse(Convert.ToString(dataRow["CourseId"])));
            StudentDomainModel studentModel = new StudentDomainModel(Guid.Parse(Convert.ToString(dataRow["Id"])), Convert.ToString(dataRow["FirstName"]), Convert.ToString(dataRow["LastName"]), Guid.Parse(Convert.ToString(dataRow["CourseId"])));
            return studentModel;
        }

        public async Task<bool> PostNewStudenAsync(StudentDomainModel newStudent)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string sqlQuery = "insert into Student (FirstName,LastName,CourseId) values (@FNAME,@LNAME,@CID);";
            SqlCommand command = new SqlCommand(sqlQuery, connection);
            command.Parameters.Add("@FNAME", SqlDbType.VarChar);
            command.Parameters["@FNAME"].Value = newStudent.FirstName;
            command.Parameters.Add("@LNAME", SqlDbType.VarChar);
            command.Parameters["@LNAME"].Value = newStudent.LastName;
            command.Parameters.Add("@CID", SqlDbType.UniqueIdentifier);
            command.Parameters["@CID"].Value = newStudent.CourseId;
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
        public async Task<Boolean> PutAsync(StudentDomainModel updatedStudent)
        {

            SqlConnection connection = new SqlConnection(connectionString);
            string sqlQuery = "update Student set FirstName = @FNAME,LastName = @LNAME,CourseId = @CID where Id = @ID";
            SqlCommand command = new SqlCommand(sqlQuery, connection);
            command.Parameters.Add("@FNAME", SqlDbType.VarChar);
            command.Parameters["@FNAME"].Value = updatedStudent.FirstName;
            command.Parameters.Add("@LNAME", SqlDbType.VarChar);
            command.Parameters["@LNAME"].Value = updatedStudent.LastName;
            command.Parameters.Add("@CID", SqlDbType.UniqueIdentifier);
            command.Parameters["@CID"].Value = updatedStudent.CourseId;
            command.Parameters.Add("@ID", SqlDbType.UniqueIdentifier);
            command.Parameters["@ID"].Value = updatedStudent.Id;
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
        public async  Task<Boolean> DeleteAsync(Guid id)
        {

            SqlConnection connection = new SqlConnection(connectionString);
            string sqlQuery = "delete from student where id = @ID";
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

