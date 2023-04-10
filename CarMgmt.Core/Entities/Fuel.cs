namespace CarMgmt.Core
{

	public enum fuelTypeEnum
	{

		Diesel,

		Gasoline,

		GLP,

		Kerosene,

	}

	public class Fuel
	{

		public int FuelId { get; set; }


		public string? EnumName { get; set; }


		public virtual Model? Model { get; set; }
	}
}
