using Application.Infrastructure;
using Application.WebApiServices;

namespace Application
{
    public static class ApplicationController
    {
        public static WebApiServicesController WebApiServices = new();
        public static InfrastructureController Infrastructure = new();
    }
}
