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
using OrderApi.Data.Context;
using Microsoft.Extensions.Options;
using OrderApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.AspNetCore.Mvc.Filters;

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

            //services.AddSingleton<IMongoClient, MongoClient>(sp => new MongoClient(Configuration.GetConnectionString("ConnectionString")));
            services.AddEntityFrameworkSqlServer().AddDbContext<OrderContext>(option => option.UseSqlServer(Configuration.GetConnectionString("Order_Service")));
            //services.Configure<OrderServiceDatabaseSettings> (
            // Configuration.GetSection("mongoDb-OrderService"));
            //services.AddSingleton<IOrderServiceDatabaseSettings>(sp =>
            //      sp.GetRequiredService<IOptions<OrderServiceDatabaseSettings>>().Value);

            services.AddAutoMapper(typeof(Startup));
            //services.AddAutoMapper(typeof(OderModel),typeof(Order));
            services.AddMvc();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Order Api",
                    Description = "A simple API to create or update orders",
                    Contact = new OpenApiContact
                    {
                        Name = "Mohsen Rezaei",
                        Email = "mohsenr2020@gmail.com",
                        Url = new Uri("https://github.com/mohsenr2040")
                    }
                    });
            
                //var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                //var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                //c.IncludeXmlComments(xmlPath);
            });

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = actionContext =>
                {
                    var actionExecutingContext =
                        actionContext as ActionExecutingContext;

                    if (actionContext.ModelState.ErrorCount > 0
                        && actionExecutingContext?.ActionArguments.Count == actionContext.ActionDescriptor.Parameters.Count)
                    {
                        return new UnprocessableEntityObjectResult(actionContext.ModelState);
                    }

                    return new BadRequestObjectResult(actionContext.ModelState);
                };
            });


            services.AddMediatR(Assembly.GetExecutingAssembly(), typeof(IProductPriceUpdateService).Assembly);
            services.AddMediatR(Assembly.GetExecutingAssembly(), typeof(CreateOrderCommand).Assembly);

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
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
