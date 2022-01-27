using MonoProjekt2.Repository;
using MonoProjekt2WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoProjekt2.Servis
{
    public class StudentServis
    {
        public List<StudentViewModel> GetAllStudents()
        {
            StudentRepository repository = new StudentRepository();
            return repository.GetAllStudents();
        }
        public StudentViewModel GetStudent(Guid id)
        {
            StudentRepository repository = new StudentRepository();
            return repository.GetStudent(id);
        }

        public Boolean PostNewStuden(StudentViewModel newStudent)
        {
            StudentRepository repository = new StudentRepository();
             return repository.PostNewStuden(newStudent);
        }
        public Boolean Put(StudentViewModel updatedStudent)
        {
            StudentRepository repository = new StudentRepository();
            return repository.Put(updatedStudent);
        }
        public Boolean Delete(Guid id)
        {
            StudentRepository repository = new StudentRepository();
            return repository.Delete(id);
        }
    }
}
