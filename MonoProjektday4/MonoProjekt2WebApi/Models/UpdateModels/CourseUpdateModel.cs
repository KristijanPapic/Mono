using MonoProjekt2WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoProjekt2.Models.DomainModels
{
    public class CourseUpdateModel
    {
        private Guid id;
        private string name;

        public CourseUpdateModel(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public Guid Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
    }
}

