using MonoProjekt2.Common.Filters;
using MonoProjekt2.Common.Paging;
using MonoProjekt2.Common.Sorting;
using MonoProjekt2.Models.DomainModels;
using MonoProjekt2WebApi.Models;
using PagedList;
using System;
using System.Threading.Tasks;

namespace MonoProjekt2.Servis
{
    public interface IStudentService
    {
        Task<bool> Delete(Guid id);
        Task<IPagedList<Student>> GetAllStudentsAsync(StudentFilter studentFilter, Sort sort, Paging page);
        Task<Student> GetStudentAsync(Guid id);
        Task<bool> PostNewStudenAsync(StudentDomainModel newStudent);
        Task<bool> PutAsync(StudentDomainModel updatedStudent);
    }
}