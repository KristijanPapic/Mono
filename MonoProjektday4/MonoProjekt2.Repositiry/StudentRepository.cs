using MonoProjekt2.Common.Filters;
using MonoProjekt2.Common.Paging;
using MonoProjekt2.Common.Sorting;
using MonoProjekt2.Models;
using MonoProjekt2.Models.DomainModels;
using MonoProjekt2WebApi.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace MonoProjekt2.Repository
{
    public class StudentRepository : IStudentRepository
    {

        private readonly string connectionString = "Server = tcp:monoprojektdbserver.database.windows.net,1433;Initial Catalog = monoprojekt; Persist Security Info=False;User ID = kristijan; Password=Robinhoodr52600;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout = 30;";

        public StudentRepository()
        {
        }

        public async Task<IPagedList<Student>> GetAllStudentsAsync(StudentFilter studentFilter, Sort sort, Paging paging)
        {

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command;
            string queryString;

            if (studentFilter.NameFilterParam == "")
            {
                queryString = "select student.Id as studentId,course.Id as CourseId,* from student inner join course on student.CourseId = Course.Id";
                command = new SqlCommand(queryString, connection);
            }
            else
            {
                //using?
                //STRING BUILDER!
                queryString = "select student.Id as studentId,course.Id as CourseId,* from student inner join course on student.CourseId = Course.Id where FirstName like @FILTER or LastName like @FILTER";
                command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@FILTER", "%" + studentFilter.NameFilterParam + "%");
            }
            if (!(sort.SortBy == ""))
            {
                command.CommandText = command.CommandText.Insert(command.CommandText.Length, " order by " + sort.SortBy + " " + sort.SortMetod);
            }

            command.CommandText = command.CommandText.Insert(command.CommandText.Length, " offset " + paging.GetElementsStart() + " rows fetch next " + paging.Rpp + " rows only;");
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
            //if (student.Tables[0].Rows.Count == 0) return null;
            List<Student> students = new List<Student>();
            foreach (DataRow dataRow in student.Tables[0].Rows)
            {
                students.Add(new Student(Guid.Parse(Convert.ToString(dataRow["Id"])), Convert.ToString(dataRow["FirstName"]), Convert.ToString(dataRow["LastName"]), Guid.Parse(Convert.ToString(dataRow["CourseId"])), new Course(Guid.Parse(Convert.ToString(dataRow["CourseId"])), Convert.ToString(dataRow["Name"]), await StudentsByCourseAsync(Guid.Parse(Convert.ToString(dataRow["CourseId"]))))));
            }
            string countQuery = "select count(Id) as count from student";
            SqlCommand countCommand = new SqlCommand(countQuery, connection);
            DataTable count = new DataTable();
            adapter.SelectCommand = countCommand;
            await Task.Run(() => adapter.Fill(count));

            IPagedList<Student> pagedStudents = new StaticPagedList<Student>(students, paging.Page, paging.Rpp,Convert.ToInt32(count.Rows[0]["count"]));
            return pagedStudents;


        }
        public async Task<List<StudentListModel>> StudentsByCourseAsync(Guid courseId)
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

            foreach (DataRow dataRow in student.Tables[0].Rows)
            {
                students.Add(new StudentListModel(Convert.ToString(dataRow["FirstName"]), Convert.ToString(dataRow["LastName"])));
            }
            return students;


        }
        public async Task<Student> GetStudentAsync(Guid id)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string queryString = "select student.Id as studentId,course.Id as CourseId,*from student inner join course on student.CourseId = Course.Id where studentId = @ID";
            SqlCommand command = new SqlCommand(queryString, connection);
            command.Parameters.AddWithValue("@ID", id);
            SqlDataAdapter adapter = new SqlDataAdapter(command);

            DataSet studentData = new DataSet();
            try
            {
                await Task.Run(() => adapter.Fill(studentData, "students"));
                connection.Close();

            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
            //if (student.Tables[0].Rows.Count == 0) return ;

            DataRow dataRow = studentData.Tables[0].Rows[0];
            Student student = new Student(Guid.Parse(Convert.ToString(dataRow["Id"])), Convert.ToString(dataRow["FirstName"]), Convert.ToString(dataRow["LastName"]), Guid.Parse(Convert.ToString(dataRow["CourseId"])), new Course(Guid.Parse(Convert.ToString(dataRow["CourseId"])), Convert.ToString(dataRow["Name"]), await StudentsByCourseAsync(Guid.Parse(Convert.ToString(dataRow["CourseId"])))));
            return student;
        }

        public async Task<bool> PostNewStudenAsync(StudentDomainModel newStudent)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string sqlQuery = "insert into Student (Id,FirstName,LastName,CourseId) values (@ID,@FNAME,@LNAME,@CID);";
            SqlCommand command = new SqlCommand(sqlQuery, connection);
            command.Parameters.Add("@ID", SqlDbType.UniqueIdentifier);
            command.Parameters["@ID"].Value = newStudent.Id;
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
        public async Task<Boolean> DeleteAsync(Guid id)
        {

            SqlConnection connection = new SqlConnection(connectionString);
            string sqlQuery = "delete from student where id = @ID";
            SqlCommand command = new SqlCommand(sqlQuery, connection);
            command.Parameters.AddWithValue("@ID", id);

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
    }
}

