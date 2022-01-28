using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonoProjekt2WebApi.Models.ViewModels
{
    public class StudentViewModel
    {
        private string firstName;
        private string lastName;
        private string courseName;

        //course objekt i domain model isto

        public StudentViewModel(string firstName, string lastName, string courseName)
        {
            FirstName = firstName;
            LastName = lastName;
            CourseName = courseName;

        }

        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }

        public string CourseName { get => courseName; set => courseName = value; }
    }
}
