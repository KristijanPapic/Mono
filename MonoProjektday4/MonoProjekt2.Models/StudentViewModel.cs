using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MonoProjekt2.Model.Common;

namespace MonoProjekt2WebApi.Models
{
    public class StudentViewModel : IStudent
    {
        private Guid id;
        private string firstName;
        private string lastName;
        private Guid courseId;

        public StudentViewModel(Guid id,string firstName,string lastName,Guid courseId)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            CourseId = courseId;
            
        }

        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }

        public Guid Id { get => id; set => id = value; }
        public Guid CourseId { get => courseId; set => courseId = value; }
    }
}