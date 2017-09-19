using System.ComponentModel.DataAnnotations;

namespace BS.Data.Model
{
	public class CompanyType
	{
		[Key]
		public long CompanyTypeId { get; set; }
		public string Name { get; set; }

	}
}
