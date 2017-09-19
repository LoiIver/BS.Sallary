using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BS.Data.Model.System
{
	public class Role
	{
		[Key]
		public long RoleId { get; set; }
		public string Name { get; set; }
	}
}
