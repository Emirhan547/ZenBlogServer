using ZenBlog.API.Endpoints;

namespace ZenBlog.API.Registrations
{
    public static class EndpointRegistrations
    {
        public static void RegisterEndpoints(this IEndpointRouteBuilder app)
        {
            app.RegisterCategoryEndpoints();

        }
    }
}
