using System.Net;

namespace CarMgmt.Core
{
	public class ConflictException : CustomException
	{
        public ConflictException(string message)
            :base(message, null, HttpStatusCode.Conflict)
        {
            
        }
    }
}
