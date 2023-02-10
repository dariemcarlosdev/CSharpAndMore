using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace My_ASP.NET_Core_App
{
    public class MyCustomMiddleWare
    {
        private readonly RequestDelegate _next;

        public MyCustomMiddleWare(RequestDelegate next) {

            this._next = next;
        }
        //the functionality you want to execute in the middleware you should add it in this Invoke method.
        public async Task<Task> Invoke(HttpContext httpContext) {
             //logic to be executed by MyMiddleware.
            await httpContext.Response.WriteAsync("here goes functionality to be execute by Custom middleware.\n");
            return _next(httpContext);
        
        }
    }

    //Extension method used to add the middleware to the http request Pipeline
    public static class CustomMiddleWareExtension
    {
        //The type of the first parameter(in this case IApplicationBuilder) specifies the type with which the extension method will be available.
        //and it's preceded whith this keyword. This method will extend the class IApplicationBuilder, by adding new functionality.
        public static IApplicationBuilder UseCustomMiddleware(this IApplicationBuilder builder)
        {

            return builder.UseMiddleware<MyCustomMiddleWare>();

        
        }
    
    }

     
}
