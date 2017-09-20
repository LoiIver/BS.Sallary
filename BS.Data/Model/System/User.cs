using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BS.Data.Model.System
{
    public class User
    {
		[Key]
		public long UserId { get; set; }

		[MaxLength(100)]
		public string FirstName { get; set; }
		[MaxLength(100)]
		public string PatronymicName { get; set; }
		[MaxLength(100)]
		public string LastName { get; set; }
		[MaxLength(50)]
		public string Login { get; set; }
		[MaxLength(50)]
		public string Password { get; set; }

    }
}
