using MonoProjekt2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonoProjekt2WebApi.Models.ViewModels
{
    public class CourseViewModel
    {
        private Guid id;
        private string name;
        private int numberOfStudent;
        private List<StudentListModel> students;

        public CourseViewModel(Guid id, string name, int numberOfStudent ,List<StudentListModel> students)
        {
            Id = id;
            Name = name;
            NumberOfStudent = numberOfStudent;
            Students = students;
        }

        public Guid Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public int NumberOfStudent { get => numberOfStudent; set => numberOfStudent = value; }
        public List<StudentListModel> Students { get => students; set => students = value; }
    }
}
