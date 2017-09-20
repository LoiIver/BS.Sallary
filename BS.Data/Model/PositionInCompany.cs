using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BS.Data.Model
{
    public class PositionInCompany
    {
		[Key]
		public long PositionInCompanyId { get; set; }

		public DateTime? StartDate { get; set; }
		public DateTime? EndDate { get; set; }

		[ForeignKey("Employee")]
		public long EmployeeId { get; set; }
		public Employee Employee { get; set; }

		[ForeignKey("Position")]
		public long PositionId { get; set; }
		public Position Position { get; set; }

		[ForeignKey("Company")]
		public long CompanyId { get; set; }
		public Company Company { get; set; }


	}
}
