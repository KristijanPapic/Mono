using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoProjekt2.Common.Filters
{
     public class CourseFilter
    {
        private string nameFilterParam;
        private Boolean dontGetList;

        public CourseFilter(string filterParam,Boolean dontGetList)
        {
            NameFilterParam = filterParam;
            DontGetList = dontGetList;

        }

        public string NameFilterParam { get => nameFilterParam; set => nameFilterParam = value; }
        public bool DontGetList { get => dontGetList; set => dontGetList = value; }
    }
}
