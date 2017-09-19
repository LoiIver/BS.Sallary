using System.ComponentModel.DataAnnotations;

namespace BS.Data.Model
{
	public class Company
	{
		[Key]
		public long CompanyId { get; set; }
		[MaxLength(100)]
		public string Name { get; set; }
		[MaxLength(200)]
		public string Description { get; set; }
		public int CompanyTypeId { get; set; }
		public int  LicenseCount { get; set; }
		public bool IsBase { get; set; }
	}
}
