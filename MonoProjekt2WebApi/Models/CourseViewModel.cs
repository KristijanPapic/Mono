using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonoProjekt2WebApi.Models
{
    public class CourseViewModel
    {
        private int Id;
        private string Name;

        public int GetId { get => Id; set => Id = value; }
        public string GetName { get => Name; set => Name = value; }
    }
}