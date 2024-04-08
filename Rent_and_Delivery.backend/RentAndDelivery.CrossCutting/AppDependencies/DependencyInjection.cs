using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RentAndDelivery.Application.Mapping;
using RentAndDelivery.Domain.Interfaces;
using RentAndDelivery.Domain.Interfaces.Input;
using RentAndDelivery.Domain.Interfaces.Output;
using RentAndDelivery.Infrastructure.Context;
using RentAndDelivery.Infrastructure.Repositories;
using RentAndDelivery.Infrastructure.Repositories.Input;
using RentAndDelivery.Infrastructure.Repositories.Output;

namespace RentAndDelivery.CrossCutting.AppDependencies
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
                  this IServiceCollection services,
                  IConfiguration configuration)
        {
            var postgresConnection = configuration
                    .GetConnectionString("DefaultConnection");

            services.AddDbContext<AppDbContext>(options =>  
                    options.UseNpgsql(postgresConnection));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IAdminInputRepository, AdminInputRepository>();
            services.AddScoped<IDeliveryPersonInputRepository, DeliveryPersonInputRepository>();
            services.AddScoped<IMotorcycleInputRepository, MotorcycleInputRepository>();
            services.AddScoped<IOrderNotificationInputRepository, OrderNotificationInputRepository>();
            services.AddScoped<IOrderInputRepository, OrderInputRepository>();
            services.AddScoped<IRentalPlanInputRepository, RentalPlanInputRepository>();
            services.AddScoped<IVehicleRentalInputRepository, VehicleRentalInputRepository>();
            services.AddScoped<IAdminOutputRepository, AdminOutputRepository>();
            services.AddScoped<IDeliveryPersonOutputRepository, DeliveryPersonOutputRepository>();
            services.AddScoped<IMotorcycleOutputRepository, MotorcycleOutputRepository>();
            services.AddScoped<IOrderNotificationOutputRepository, OrderNotificationOutputRepository>();
            services.AddScoped<IOrderOutputRepository, OrderOutputRepository>();
            services.AddScoped<IRentalPlanOutputRepository, RentalPlanOutputRepository>();
            services.AddScoped<IVehicleRentalOutputRepository, VehicleRentalOutputRepository>();

            services.AddAutoMapper(typeof(AdminMapping));
            services.AddAutoMapper(typeof(DeliveryPersonMapping));
            services.AddAutoMapper(typeof(MotorcycleMapping));
            services.AddAutoMapper(typeof(OrderNotificationMapping));
            services.AddAutoMapper(typeof(OrderMapping));
            services.AddAutoMapper(typeof(RentalPlanMapping));
            services.AddAutoMapper(typeof(VehicleRentalMapping)); 


            var myhandlers = AppDomain.CurrentDomain.Load("RentAndDelivery.Application");
            services.AddMediatR(cfg =>
                {
                    cfg.RegisterServicesFromAssemblies(myhandlers);
                });

            return services;
        }
        
    }
}