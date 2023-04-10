namespace CarMgmt.Core
{
	public enum vehicleTypeEnum
	{
		Sedan, 

		Compact,

		Suv,

		Van,

		Coupe,

		Sport,

		All,
	}

	public enum bodyStyleEnum
	{
		two_doors,

		three_doors,

		four_doors,
	}

	public class VehicleType : BaseEntity
	{
		public int VehicleTypeId { get; set; }


		public string EnumName { get; set; } = string.Empty;


		public virtual Vehicle? Vehicle { get; set; }
	}
}
