using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using TeendokLista.DAL;
using TeendokLista.Data.Repositories;
using TeendokLista.Models;
using TeendokLista.WPF.ViewModels;
using TeendokLista.WPF.Views;

namespace TeendokLista.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public IServiceProvider ServiceProvider { get; private set; }

        public App()
        {
            ServiceCollection services = new ServiceCollection();
            ConfigureServices(services);
            ServiceProvider = services.BuildServiceProvider();
        }

        private void OnStartup(object sender, StartupEventArgs e)
        {
            var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            //services.AddDbContext<TeendokContext>();
            services.AddScoped<FeladatRepository>();
            services.AddScoped<MainViewModel>();
            services.AddScoped<MainWindow>();
        }
    }
}
