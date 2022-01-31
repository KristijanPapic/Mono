using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoProjekt2.Common.Filters
{
     public class StudentFilter
    {
        private string nameFilterParam;

        public StudentFilter(string filterParam)
        {
            NameFilterParam = filterParam;
        }

        public string NameFilterParam { get => nameFilterParam; set => nameFilterParam = value; }
    }
}
