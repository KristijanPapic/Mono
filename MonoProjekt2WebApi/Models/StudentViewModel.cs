using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonoProjekt2WebApi.Models
{
    public class StudentViewModel
    {
        private int Id;
        private string FirstName;
        private string LastName;
        private int CourseId;
        
        public StudentViewModel(int id,string firstName,string lastName,int courseId)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            CourseId = courseId;
            
        }

        public string GetFirstName { get => FirstName; set => FirstName = value; }
        public string GetLastName { get => LastName; set => LastName = value; }

        public int GetId { get => Id; set => Id = value; }
        public int GetCourseId { get => CourseId; set => CourseId = value; }
    }
}