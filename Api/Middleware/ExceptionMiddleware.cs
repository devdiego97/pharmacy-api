using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Domain.Exceptions;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Api.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
		private readonly ILogger _logger;

        public ExceptionMiddleware(RequestDelegate next,ILogger<ExceptionMiddleware> logger)
		{
			_next=next;
			_logger=logger;
		}

		public async  Task Invoke(HttpContext context)
		{
			try
			{
				await _next(context);
			}catch(Exception ex)
			{
				_logger.LogError(ex,ex.Message);
				await HandleException(context,ex);
			}		
			
		}


		public static  Task HandleException(HttpContext context,Exception ex)
		{
			
			var statusCode=HttpStatusCode.InternalServerError;
			var message="Erro interno do servidor";


			if(ex is BusinessException) //BusinessException vem do domain
			{
				statusCode=HttpStatusCode.BadRequest;
				message=ex.Message;
				
			}

			var response=new
			{
				status=(int)statusCode,
				error=message
				
			};


			context.Response.ContentType="application/json";
			context.Response.StatusCode=(int)statusCode;

			return context.Response.WriteAsync(
				JsonSerializer.Serialize(response)
			);

    }
	}
}