using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using SoapCore;

namespace dotnetcoresoapcore
{
    public class Startup
    {
        /// <summary>
        /// Singleton In memory collection
        /// </summary>
        internal static readonly IDictionary<Guid, Models.Product> Products = new Dictionary<Guid, Models.Product>(16);

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            /// ... Load the Interface and Service class as Singleton pattern
            services.AddSoapCore();
            services.AddTransient<Models.IProductService, Services.ProductService>();
            //services.AddScoped<Models.IProductService, Services.ProductService>();
            //services.AddSingleton<Models.IProductService, Services.ProductService>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            /// ... SOAP service endpoint call execution; follows init Routing
            app.UseSoapEndpoint<Models.IProductService>("/Products.svc"
                , encoder: null
                , serializer: SoapSerializer.XmlSerializer);
        }
    }
}
