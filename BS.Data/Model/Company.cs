using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
		[ForeignKey("LegalForm")]
		public long LegalFormId { get; set; }

		public LegalForm LegalForm { get; set; }
		public int  LicenseCount { get; set; }
		public bool IsBase { get; set; }
	}
}
