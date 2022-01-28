using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonoProjekt2WebApi.Models
{
    public class StudentPostModel
    {
        private string firstName;
        private string lastName;
        private Guid courseId;

        //course objekt i domain model isto

        public StudentPostModel(string firstName, string lastName, Guid courseId)
        {
            FirstName = firstName;
            LastName = lastName;
            CourseId = courseId;

        }

        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }

        public Guid CourseId { get => courseId; set => courseId = value; }
    }
}