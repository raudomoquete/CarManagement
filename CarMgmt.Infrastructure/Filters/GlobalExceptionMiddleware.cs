using CarMgmt.Core;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Serilog;
using Serilog.Context;
using System.Net;

namespace CarMgmt.Infrastructure
{
	public class GlobalExceptionMiddleware : IMiddleware
	{
		public async Task InvokeAsync(HttpContext context, RequestDelegate next)
		{
			try
			{
				await next(context);
			}
			catch (Exception exception)
			{
				string errorId = Guid.NewGuid().ToString();
				LogContext.PushProperty("ErrorId", errorId);
				LogContext.PushProperty("StackTrace", exception.StackTrace);
				var errorResult = new ErrorResult
				{
					Source = exception.TargetSite?.DeclaringType?.FullName,
					Exception = exception.Message.Trim(),
					ErrorId = errorId,
					SupportMessage = $"Provee el Id del Error: {errorId} al equipo de soporte para un mayor analisis."
				};
				errorResult.Messages.Add(exception.Message);

				if (exception is not CustomException && exception.InnerException != null)
				{
					while (exception.InnerException != null)
					{
						exception = exception.InnerException;
					}
				}

				switch (exception)
				{
					case CustomException e:
						errorResult.StatusCode = (int)e.StatusCode;
						if (e.ErrorMessages is not null)
						{
							errorResult.Messages = e.ErrorMessages;
						}

						break;

					case KeyNotFoundException:
						errorResult.StatusCode = (int)HttpStatusCode.NotFound;
						break;

					default:
						errorResult.StatusCode = (int)HttpStatusCode.InternalServerError;
						break;
				}

				Log.Error($"{errorResult.Exception} El Requerimiento fallo con el Codigo de estatus {context.Response.StatusCode} y el Id de Error {errorId}.");
				var response = context.Response;
				if (!response.HasStarted)
				{
					response.ContentType = "application/json";
					response.StatusCode = errorResult.StatusCode;
					await response.WriteAsync(JsonConvert.SerializeObject(errorResult));
				}
				else
				{
					Log.Warning("No puede escribir la respuesta del error. La Respuesta ya ha comenzado.");
				}
			}
		}
	}
}
