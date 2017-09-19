using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BS.Data.Model.System
{
	public class UsersRole
	{
		[Key]
		public int UsersRoleId { get; set; }
		[ForeignKey("UserId")]
		public int UserId { get; set; }
		public virtual User User { get; set; }

		[ForeignKey("RoleId")]
		public int RoleId { get; set; }
		public virtual Role Role { get; set; }
	}
}
