using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Diagnostics;
using Orders.Contracts;
using System;
using Microsoft.AspNetCore.Http;
using System.Collections;
using Orders.Contracts.Order;
using System.Collections.Generic;

namespace SPA_Test
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSingleton<ICollection<OrderModel>>(new List<OrderModel>());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseExceptionHandler(errApp => 
            {
                errApp.Run(async context =>
                {
                    var exception = context.Features.Get<IExceptionHandlerFeature>();
                    Type exceptionType = exception.Error.GetType();

                    var model = new ErrorModel();
                    if (exceptionType.Name == "ApplicationException" || 
                        exceptionType.Name == "AggregateException")
                    {
                        context.Response.StatusCode = 400;
                        model.Message = exception.Error.Message;
                    }
                    else
                    {
                        context.Response.StatusCode = 500;
                        model.Message = "Ooops. Something went wrong.";
                    }
                    context.Response.ContentType = "application/json; charset=utf-8";
                    await context.Response.WriteAsync(model.ConvertToJson(), System.Text.Encoding.UTF8);
                });
            });

#if DEBUG
            app.UseCors(builder =>
                builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        );
#endif
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
