using ControleContatos.Models;

namespace ControleContatos
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // Aqui você registra o serviço BancoDados
            services.AddSingleton<Banco>();
            services.AddTransient<ContatoModel>();
            services.AddTransient<GeradorDeContato>();
            services.AddTransient<UsuarioModel>();
            services.AddTransient<LoginModel>();

            services.AddControllersWithViews();

            // Outros serviços podem ser registrados aqui...
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (!env.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Login}/{action=Index}/{id?}");
            });
        }
    }
}
