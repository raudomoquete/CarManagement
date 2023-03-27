using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMgmt.Core.Entities
{
	public class Vehicle : BaseEntity
	{
		public decimal Price { get; set; }

		public DateTime VehicleYear { get; set; }

		public int BrandId { get; set; }
		public virtual Brand? Brand { get; set; }

		/// <summary>
		/// Enum del tipo de Estado
		/// </summary>
		[DefaultValue(0)]
		public CarStatus CarStatusEnum { get; set; }

		[DefaultValue("Na")]
		public string SetVehicleStatus
		{
			set
			{
				CarStatus tmpCarStatusEnum;
				Enum.TryParse(value, out tmpCarStatusEnum);
				CarStatusEnum = tmpCarStatusEnum;
			}
		}

	}
}
