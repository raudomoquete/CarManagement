namespace CarMgmt.Core
{
	public class Model : BaseEntity
	{

		public int AccessoryId { get; set; }


		public virtual ICollection<Accessory>? Accessories { get; set; }


		public int BrandId { get; set; }


		public virtual Brand? Brand { get; set; }


		public int FuelId { get; set; }


		public virtual Fuel? Fuel { get; set; }


		public int TractionId { get; set; }


		public virtual Traction? Traction { get; set; }


		public int YearId { get; set; }


		public virtual Year? Year { get; set; }


		public int TransmissionId { get; set; }


		public virtual Transmission? Transmission { get; set; }


		public transmissionTypeEnum TransmissionType { get; set; }


		public string SetTransmissionEnum
		{
			set
			{
				transmissionTypeEnum transmission;
				Enum.TryParse(value, out transmission);
				this.TransmissionType = transmission;
			}
		}

		public int EngineId { get; set; }


		public virtual Engine? Engine { get; set; }

	}
}
