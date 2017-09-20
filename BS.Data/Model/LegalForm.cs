using System.ComponentModel.DataAnnotations;

namespace BS.Data.Model
{
	public class LegalForm
	{
		[Key]
		public long LegalFormId { get; set; }
		public string Name { get; set; }

		public bool IsCommercial { get; set; }

	}
}
