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

        public CourseViewModel(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public Guid Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
    }
}