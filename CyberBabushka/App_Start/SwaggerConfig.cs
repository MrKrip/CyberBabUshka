using System.Web.Http;
using WebActivatorEx;
using CyberBabushka;
using Swashbuckle.Application;

//[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace CyberBabushka
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {
                        c.SingleApiVersion("v1", "CyberBabushka");
                    })
                .EnableSwaggerUi(c =>
                    {
                        
                    });
        }
    }
}
