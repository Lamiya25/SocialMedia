using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using SocialMedia.Application.Automapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationService(this  IServiceCollection services)
        {
            services.AddMediatR(cfg=>cfg.RegisterServicesFromAssembly(typeof(ServiceRegistration).Assembly));



            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
