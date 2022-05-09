using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ExamDetails
    {

        public int EID { get; set; }
        public int QID { get; set; }
        public int CID { get; set; }
        public string QDescription { get; set; }
        public int QType { get; set; }
        public string Model_Answer { get; set; }
    }
}