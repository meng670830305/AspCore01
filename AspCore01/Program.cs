using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspCore01
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            //默认配置
            //加载环境变量（DOTNET开头）
            //加载命令行参数
            //加载应用配置
            //配置的默认日志组件
            Host.CreateDefaultBuilder(args)
                //调用里面的扩展方法，进行自定义配置
                //默认配置，启用kestrel
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    //组件配置
                    webBuilder.ConfigureKestrel((context, option) =>
                  option.Limits.MaxRequestBodySize = 1024);
                    webBuilder.UseStartup<Startup>();
                    //环境变量 硬编码 应用配置 命令行
                });
    }
}
