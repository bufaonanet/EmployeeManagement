﻿using EmployeeManagement.Api.Business;
using EmployeeManagement.Api.DataAccess.DbContexts;
using EmployeeManagement.Api.DataAccess.Services;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Api;

public static class ServiceRegistrationExtensions
{
    public static IServiceCollection RegisterBusinessServices(this IServiceCollection services)
    {
        services.AddScoped<IEmployeeService, EmployeeService>();
        services.AddScoped<IPromotionService, PromotionService>();
        services.AddScoped<EmployeeFactory>();
        return services;
    }

    public static IServiceCollection RegisterDataServices(
            this IServiceCollection services, IConfiguration configuration)
    {
        // add the DbContext
        services.AddDbContext<EmployeeDbContext>(options =>
            options.UseSqlite(configuration.GetConnectionString("EmployeeManagementDB")));

        // register the repository
        services.AddScoped<IEmployeeManagementRepository, EmployeeManagementRepository>();
        return services;
    }
}