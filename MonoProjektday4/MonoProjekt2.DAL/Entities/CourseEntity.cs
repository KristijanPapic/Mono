using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoProjekt2.DAL.Entities
{
     public class CourseEntity
    {
        private Guid id;
        private string name;

        public CourseEntity(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public Guid Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
    }
}
