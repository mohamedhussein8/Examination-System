using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
	public class User
	{

		public int UID { get; set; }
		public string userName { get; set; }
		public string password { get; set; }
		public string Fname { get; set; }
		public string Lname { get; set; }
		public string address { get; set; }
		public DateTime Date_Birth { get; set; }
		public string User_Type { get; set; }
	}

}