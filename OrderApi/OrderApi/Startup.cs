using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using OrderApi.Messaging.Receive.Options;
using System.Collections.Generic;
using System.Reflection;
using OrderApi.Service.Services;
using OrderApi.Data.Repository;
using OrderApi.Domain.Entities;
using OrderApi.Service.Query;
using OrderApi.Service.Command;
using MediatR;
using OrderApi.Messaging.Receive.Receiver;

namespace OrderApi
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
            services.AddHealthChecks();
            services.AddOptions();

            var serviceClientSettingsConfig = Configuration.GetSection("RabbitMq");
            var serviceClientSettings = serviceClientSettingsConfig.Get<RabbitMqConfiguration>();
            services.Configure<RabbitMqConfiguration>(serviceClientSettingsConfig);


            services.AddAutoMapper(typeof(Startup));

            services.AddMvc();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "OrderApi", Version = "v1" });
            });

            services.AddMediatR(Assembly.GetExecutingAssembly(), typeof(IProductPriceUpdateService).Assembly);

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IOrderRepository, OrderRepository>();

            //services.AddTransient<IValidator<OrderModel>, OrderModelValidator>();

            services.AddTransient<IRequestHandler<GetPaidOrdersQuery, List<Order>>, GetPaidOrdersQueryHandler>();
            services.AddTransient<IRequestHandler<GetOrderByIdQuery, Order>, GetOrderByIdQueryHandler>();
             services.AddTransient<IRequestHandler<CreateOrderCommand, Order>, CreateOrderCommandHandler >();
            services.AddTransient<IRequestHandler<PayOrderCommand, Order>, PayOrderCommandHandler>();
            services.AddTransient<IRequestHandler<UpdateOrderCommand>, UpdateOrderCommandHandler>();
            services.AddTransient<IProductPriceUpdateService, ProductPriceUpdateService>();

            if (serviceClientSettings.Enabled)
            {
                services.AddHostedService<ProductPriceUpdateReceiver>();
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "OrderApi v1"));
            }

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
