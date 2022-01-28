using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MonoProjekt2.Model.Common;

namespace MonoProjekt2WebApi.Models
{
    public class Student : IStudent
    {
        private Guid id;
        private string firstName;
        private string lastName;
        private Guid courseId;
        private Course course;

        //course objekt i domain model isto

        public Student(Guid id,string firstName,string lastName,Guid courseId,Course course)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            CourseId = courseId;
            Course = course;
            
        }

        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }

        public Guid Id { get => id; set => id = value; }
        public Guid CourseId { get => courseId; set => courseId = value; }
        public Course Course { get => course; set => course = value; }
    }
}