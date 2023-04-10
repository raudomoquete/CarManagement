namespace CarMgmt.Core
{
	public class Vehicle : BaseEntity
	{

		public decimal? Price { get; set; }


		public string? VIN { get; set; }


		public int BrandId { get; set; }


		public virtual Brand? Brand { get; set; }


		public int StatusId { get; set; }


		public virtual Status? Status { get; set; }


		public getVehicleStatus VehicleStatusEnum { get; set; }


		public string SetVehicleStatusEnum
		{
			set
			{
				getVehicleStatus vehicleStatus;
				Enum.TryParse(value, out vehicleStatus);
				this.VehicleStatusEnum = vehicleStatus;
			}
		}


		public int VehicleTypeId { get; set; }


		public virtual VehicleType? VehicleType { get; set; }


		public vehicleTypeEnum VehicleTypeEnum { get; set; }


		public string SetVehicleType
		{
			set
			{
				vehicleTypeEnum vehicleType;
				Enum.TryParse(value, out vehicleType);
				this.VehicleTypeEnum = vehicleType;
			}
		}

		public bodyStyleEnum BodyStyleEnum { get; set; }

		public string SetBodyStyle
		{
			set
			{
				bodyStyleEnum bodyStyle;
				Enum.TryParse(value, out bodyStyle);
				this.BodyStyleEnum = bodyStyle;
			}
		}
	}
}
