using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonoProjekt2WebApi.Models.PostModels
{
    public class CoursePostModel
    {
        private string name;

        public CoursePostModel(string name)
        {
            Name = name;
        }

        public string Name { get => name; set => name = value; }
    }
}