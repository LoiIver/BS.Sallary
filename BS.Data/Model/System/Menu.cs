using System;
using System.Collections.Generic;
using System.Text;

namespace BS.Data.Model.System
{
    public class Menu
    {
		public long MenuId { get; set; }
		public string Caption { get; set; }
		public string Controller{ get; set; }
		public bool Enabled { get; set; }
		public string Action { get; set; }
		public string ActionParameter { get; set; }
		public string Url { get; set; }

	}
}
