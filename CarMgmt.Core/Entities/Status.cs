namespace CarMgmt.Core
{
	public enum getVehicleStatus
	{
		New,

		Used,

		New_used,
	}

	public class Status : BaseEntity
	{

		public int StatusId { get; set; }


		public List<int>? StatusId_List;


		public virtual Vehicle? Vehicle { get; set; }
	}
}
