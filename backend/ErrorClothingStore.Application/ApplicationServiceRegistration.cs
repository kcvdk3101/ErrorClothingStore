using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Slugify;

namespace ErrorClothingStore.Application
{
    public static class ApplicationServiceRegistration
    {
        public static void RegisterApplicationService(this IServiceCollection services)
        {
            services.AddSingleton<ISlugHelper, SlugHelper>();

            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }
    }
}