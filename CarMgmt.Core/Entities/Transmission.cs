namespace CarMgmt.Core
{
	public enum automaticTransmissionTypeEnum
	{

		Torque_Converter,

		CVT,

		Semi_Automatic,

		Dual_Clutch,

	}

	public enum transmissionTypeEnum
	{

		Manual,

		Automatic,

		CVT,

		Tiptronic

	}

	public class Transmission
	{

		public int TransmissionId { get; set; }


		public string EnumName { get; set; } = string.Empty;


		public string AutomaticEnumName { get; set; } = string.Empty;


		public virtual Model? Model { get; set; }


		public int speed { get; set; }

	}
}
