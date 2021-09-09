using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspCore01
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
            //服务容器 IOC(控制反转)容器
            //为什么用IoC容器，为了依赖注入
            services.AddSession();
            services.AddRazorPages();
            //内置的服务
            //第三方的EF CORE 日志框架Swagger等
            //注册自定义服务的时候，必须选择一个生存周期
            //有几种生存周期
            //1瞬时 每次从服务容器里进行请求实例时都会创建一个新的实例
            //2作用域 单例 在同一个线程（请求）里只实例化一次
            //3单例，全局单例
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.

        /// <summary>
        /// 配置中间件 
        /// 必须的 中间件就是处理HTTP请求和相应的东西
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
