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
        
        public StudentViewModel(int id,string firstName,string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }

        public string FirstName1 { get => FirstName; set => FirstName = value; }
        public string LastName1 { get => LastName; set => LastName = value; }

        public int Id1 { get => Id; set => Id = value; }
    }
}