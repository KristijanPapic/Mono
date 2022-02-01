using MonoProjekt2.Common.Filters;
using MonoProjekt2.Common.Paging;
using MonoProjekt2.Common.Sorting;
using MonoProjekt2.Models;
using MonoProjekt2.Models.DomainModels;
using MonoProjekt2WebApi.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MonoProjekt2.Repository
{
    public interface IStudentRepository
    {
        Task<bool> DeleteAsync(Guid id);
        Task<IPagedList<Student>> GetAllStudentsAsync(StudentFilter studentFilter, Sort sort, Paging paging);
        Task<Student> GetStudentAsync(Guid id);
        Task<bool> PostNewStudenAsync(StudentDomainModel newStudent);
        Task<bool> PutAsync(StudentDomainModel updatedStudent);
        Task<List<StudentListModel>> StudentsByCourseAsync(Guid courseId);
    }
}