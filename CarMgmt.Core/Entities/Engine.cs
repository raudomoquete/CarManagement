namespace CarMgmt.Core
{
	public class Engine
	{

		public int EngineId { get; set; }

		
		public int Cilinders { get; set; }


		public int Liters { get; set; }


		public virtual Model? Model { get; set; }

	}
}
