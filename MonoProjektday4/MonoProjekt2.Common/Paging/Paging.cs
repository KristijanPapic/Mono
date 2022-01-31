using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoProjekt2.Common.Paging
{
    public class Paging
    {
        private int rpp = 3;
        private int page;

        public Paging(int page)
        {
            Page = page;
        }
        
        public int Rpp { get => rpp; set => rpp = value; }
        public int Page { get => page; set => page = value; }

        public int GetPage()
        {
            return Rpp * (Page-1);
        }
    }
}
