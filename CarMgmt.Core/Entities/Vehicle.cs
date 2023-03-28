using System.ComponentModel;

namespace CarMgmt.Core
{
	public class Vehicle : BaseEntity
	{

		public decimal Price { get; set; }

		public DateTime VehicleYear { get; set; }

		public int BrandId { get; set; }
		public virtual Brand? Brand { get; set; }

		public int StatusId { get; set; }

		public virtual Status? Status { get; set; }

	}
}
