namespace CarMgmt.Core
{
	public class Accessory
	{

		public int AccessoryId { get; set; } = 0;


		public string Name { get; set; } = null!;


		public virtual Model? Model { get; set; }

	}
}
