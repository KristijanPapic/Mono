using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoProjekt2.Common.Sorting
{
    public class Sort
    {
       private string sortBy;
       private string sortMetod;

        public Sort(string sortBy, string sortMetod)
        {
            SortBy = sortBy;
            SortMetod = sortMetod;
        }

        public string SortBy { get => sortBy; set => sortBy = value; }
        public string SortMetod { get => sortMetod; set => sortMetod = value; }
    }
}
