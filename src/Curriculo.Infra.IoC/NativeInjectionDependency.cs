using Curriculo.Domain.CommandHandlers;
using Curriculo.Domain.Commands.Products;
using Curriculo.Domain.Commands.ProductTypes;
using Curriculo.Domain.Core.Bus;
using Curriculo.Domain.Core.Notifications;
using Curriculo.Domain.Interfaces;
using Curriculo.Domain.Interfaces.Repositories;
using Curriculo.Infra.Bus;
using Curriculo.Infra.Data.Context;
using Curriculo.Infra.Data.Repositories;
using Curriculo.Infra.Data.UoW;
using Curriculo.Infra.Identity.Interfaces;
using Curriculo.Infra.Identity.Services;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Curriculo.Infra.IoC
{
    public class NativeInjectionDependency
    {
        public static void InjectDependencies(IServiceCollection service)
        {
            service.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Infra Data
            service.AddScoped<ContextSQLS>();
            service.AddScoped<IUnitOfWork, UnitOfWork>();

            service.AddScoped<IProductRepository, ProductRepository>();
            service.AddScoped<IProductTypeRepository, ProductTypeRepository>();

            // Infra Identity
            service.AddScoped<IUserAspNet, UserAspNetService>();
            service.AddScoped<IUserService, UserService>();

            // Commands
            service.AddScoped<IMediatorHandler, InMemomyBus>();

            service.AddScoped<IRequestHandler<AddProductCommand>, ProductCommandHandler>();
            service.AddScoped<IRequestHandler<UpdateProductCommand>, ProductCommandHandler>();
            service.AddScoped<IRequestHandler<DeleteProductCommand>, ProductCommandHandler>();

            service.AddScoped<IRequestHandler<AddProductTypeCommand>, ProductTypeCommandHandler>();
            service.AddScoped<IRequestHandler<UpdateProductTypeCommand>, ProductTypeCommandHandler>();
            service.AddScoped<IRequestHandler<DeleteProductTypeCommand>, ProductTypeCommandHandler>();


            //Events
            service.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

            
        }
    }
}
