namespace ChatApp
{
    public static class ConfigureService
    {
        public static IServiceCollection AddWebUIServices(this IServiceCollection services)
        {

            services.AddHttpContextAccessor();
            services.AddRazorPages();

            return services;
        }
    }
}
