namespace StowageApplication
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // Configuração do roteamento MVC
            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Configurações do ambiente de desenvolvimento
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            // Configuração do roteamento MVC
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=FileStowages}/{action=Index}/{id?}");
            });
        }
    }
}
