using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class StudentGrade
    {

        public int SID { get; set; }
        public int CID { get; set; }
        public string userName { get; set; }
        public string Cname { get; set; }
        public int? Grade { get; set; }
    }
}
