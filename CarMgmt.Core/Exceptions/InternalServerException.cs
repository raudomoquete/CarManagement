using System.Net;

namespace CarMgmt.Core
{
	public class InternalServerException : CustomException
	{
        public InternalServerException(string message, List<string>? errors = default)
            :base(message, errors, HttpStatusCode.InternalServerError)
        {
     
        }
    }
}
