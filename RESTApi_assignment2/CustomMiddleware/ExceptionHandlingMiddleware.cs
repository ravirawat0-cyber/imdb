﻿using IMDB.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Net;
using System.Threading.Tasks;

namespace IMDB.CustomMiddleware
{
    public class ExceptionHandlingMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (KeyNotFoundException e)
            {
                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                await context.Response.WriteAsync(e.Message);
            }
            catch (ArgumentException e)
            {
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                await context.Response.WriteAsync(e.Message);
            }
            catch (SqlException ex)
            {
                if (ex.Number == (int)SqlErrorNumber.ForeignKeyViolation)
                {
                    context.Response.StatusCode = (int)HttpStatusCode.Conflict;
                    await context.Response.WriteAsync("Cannot delete this record because it is referenced by another table.");
                }
                else
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    await context.Response.WriteAsync(ex.Message);
                }
            }
            catch (Exception e)
            {
                context.Response.StatusCode = 500;
                await context.Response.WriteAsync(e.Message);
            }
        }
    }
}
