using Microsoft.AspNetCore.WebSockets;
using Microsoft.Extensions.DependencyInjection;
using SocialMedia.Application.Abstractions.Token;
using SocialMedia.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastactureServices(this IServiceCollection services) 
        { 
            services.AddScoped<ITokenHandler,TokenHandler>();
        }
    }
}
