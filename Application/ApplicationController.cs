using Application.API;
using Application.Infrastructure;

namespace Application
{
    public static class ApplicationController
    {
        public static ApiController ApiController = new();
        public static InfrastructureController Infrastructure = new();
    }
}
