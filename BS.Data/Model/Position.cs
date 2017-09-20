using System.ComponentModel.DataAnnotations;

namespace BS.Data.Model
{
	public class Position
    {
		[Key]
		public long PositionId { get; set;}

		public string Name { get; set; }
	}
}
