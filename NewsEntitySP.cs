using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EntityModel
{
    public class NewsEntitySP
    {
        public string Title { get; set; }
        public string Spot { get; set; }
        public string CatName { get; set; }
        public int ReadCount { get; set; }

    }
}
