using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MonoProjekt2.Model.Common;
using MonoProjekt2.Models;

namespace MonoProjekt2WebApi.Models
{
    public class Course : ICourse
    {
        private Guid id;
        private string name;
        private List<StudentListModel> students;

        public Course(Guid id, string name, List<StudentListModel> students)
        {
            Id = id;
            Name = name;
            Students = students;
        }

        public Guid Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public List<StudentListModel> Students { get => students; set => students = value; }
    }
}