using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MonoProjekt2.Model.Common;

namespace MonoProjekt2WebApi.Models
{
    public class CourseViewModel : ICourse
    {
        private Guid id;
        private string name;
        private int studentsEnrolled;

        public CourseViewModel(Guid id, string name, int studentsEnrolled)
        {
            Id = id;
            Name = name;
            StudentsEnrolled = studentsEnrolled;
        }

        public Guid Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public int StudentsEnrolled { get => studentsEnrolled; set => studentsEnrolled = value; }
    }
}