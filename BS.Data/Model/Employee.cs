using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BS.Data.Model.System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BS.Data.Model
{
	public  class Employee
	{
		[Key]
		public long EmployeeId{ get; set; }
		[ForeignKey("User")]
		public long UserId { get; set; }
		public User User { get; set; }
	}
}
