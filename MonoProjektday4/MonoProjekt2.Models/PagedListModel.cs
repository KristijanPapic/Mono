using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoProjekt2.Models
{
    public class PagedListModel
    {
        private IPagedList students;
        private int totalItemCount;

        public PagedListModel(IPagedList students, int totalItemCount)
        {
            Students = students;
            TotalItemCount = totalItemCount;
        }

        public IPagedList Students { get => students; set => students = value; }
        public int TotalItemCount { get => totalItemCount; set => totalItemCount = value; }
    }
}
