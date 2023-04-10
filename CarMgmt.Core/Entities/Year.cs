namespace CarMgmt.Core
{
	public class Year
	{

		public int YearId { get; set; }


		public int ModelYear { get; set; }


		public virtual Model? Model { get; set; }

	}
}
