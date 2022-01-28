using MonoProjekt2WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoProjekt2.Models.DomainModels
{
    public class StudentDomainModel
    {
        private Guid id;
        private string firstName;
        private string lastName;
        private Guid courseId;



        //course objekt i domain model isto

        public StudentDomainModel(Guid id, string firstName, string lastName, Guid courseId)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            CourseId = courseId;

        }

        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }

        public Guid Id { get => id; set => id = value; }
        public Guid CourseId { get => courseId; set => courseId = value; }
    }
}
