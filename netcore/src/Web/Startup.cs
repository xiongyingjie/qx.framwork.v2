
using erp.invoicing.Interfaces;
using erp.invoicing.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Web.Controllers.Filter;
using xyj.acs.Interfaces;
using xyj.acs.Services;
using xyj.core.Interfaces;
using xyj.core.Services;
using xyj.study.Interfaces;
using xyj.study.Services;


namespace Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            
            services.AddSession();//使用session
            services.AddTransient<IAcsService, AcsService>();
            services.AddTransient<IReportServices, ReportServices>();
            services.AddTransient<IYlService, YlService>();
            services.AddTransient<IInvoicingService, InvoicingService>();

            //  services.AddDbContext<qx.permmision.v2.Entity.MyContext>(options => options.UseSqlServer("qx.permmision.v2"));
            //异常处理
            services.AddMvc(options =>
            {
                options.Filters.Add<HttpGlobalExceptionFilter>();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //异常错误页
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //    app.UseBrowserLink();
            //}
            //else
            //{
            //    app.UseExceptionHandler("/Home/Error");
            //}

            

            //允许跨域
            //app.UseCors(builder =>
            //{
            //    builder.AllowAnyHeader();
            //    builder.AllowAnyMethod();
            //    builder.WithOrigins("http://localhost:16421");
            //});
            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().AllowCredentials());
            //配置路由
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            //配置区域
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "areaRoute",
                    template: "{area:exists}/{controller}/{action=Index}/{id?}");
            });

            app.UseStaticFiles();
           

        }
    }
}
