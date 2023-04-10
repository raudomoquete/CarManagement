namespace CarMgmt.Core
{

	public class Traction
	{

		public int TractionId { get; set; } = 0;


		public string? TractionName { get; set; }


		public string? TractionDescription { get; set;}


		public virtual Model? Model { get; set; }
	}
}
