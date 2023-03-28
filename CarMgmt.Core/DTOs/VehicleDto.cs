using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMgmt.Core
{
	public enum vehicleStatus
	{
		Nuevo,

		Usado,
	}

	public class VehicleDto
	{
		public int Id { get; set; }

		public string Brand { get; set; } = null!;

		public string Model { get; set; } = null!;

		public vehicleStatus VehicleStatusEnum { get; set;}

		public string SetVehicleStatus
		{
			set
			{
				VehicleStatusEnum = (vehicleStatus)Enum.Parse(typeof(vehicleStatus), value);
			}
		}

		public decimal Price { get; set; }

		public DateTime VehicleYear { get; set; }

	}
}
