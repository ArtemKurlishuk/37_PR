using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Shop.Data.DataBase;
using Shop.Data.Interfaces;
using Shop.Data.Mocks;
using Shop.Data.Models;

namespace Shop
{
    public class Startup
    {
        /// <summary>
        ///  ������ � ������� ������������
        /// </summary>
        public static List<ItemsBasket> BasketItem = new List<ItemsBasket>();

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // ���������� �������� � ����������� �����
            services.AddTransient<ICategorys, MockCategorys>();
            services.AddTransient<IItems, MockItems>(); 

            // �������� ��������� MVC

            services.AddMvc(option => option.EnableEndpointRouting = false);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // ���������� �������� � ��������
            app.UseDeveloperExceptionPage();
            // ���������� �������� � ������ �����
            app.UseStatusCodePages();
            // ����������� ����������� ������
            app.UseStaticFiles();
            // ������������ url �������
            app.UseMvcWithDefaultRoute();

            var provider = new FileExtensionContentTypeProvider();
            provider.Mappings[".less"] = "plain/text";

            app.UseStaticFiles(new StaticFileOptions
            {
                ContentTypeProvider = provider
            });
        }
    }
}


