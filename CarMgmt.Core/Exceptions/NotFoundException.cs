using System.Net;

namespace CarMgmt.Core
{
	public class NotFoundException : CustomException
	{
		public NotFoundException(string message) 
			: base(message, null, HttpStatusCode.NotFound) { }
	}
}
