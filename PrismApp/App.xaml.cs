using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Prism.Unity;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using PrismApp.Core.Regions;
using PrismApp.Views;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Unity.Microsoft.DependencyInjection;
using PrismApp.Services;

namespace PrismApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        private string _connectionString;
        
        IConfiguration configuration = new ConfigurationBuilder()
       .AddJsonFile("appSettings.json", true, true)
       .Build();

        private readonly IRegionManager _regionManager = new RegionManager();

        protected override Window CreateShell()
        {
            return Container.Resolve<ShellWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            var services = new ServiceCollection();
            _connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(_connectionString, serverOptions => serverOptions.EnableRetryOnFailure()));
            services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
            services.AddScoped<IProductsRepository, ProductsRepository>();
            var container = containerRegistry.GetContainer();
            services.BuildServiceProvider(container);
            //_regionManager.RegisterViewWithRegion<ProductListView>("MessageOutput");
        }

        protected override void ConfigureRegionAdapterMappings(RegionAdapterMappings regionAdapterMappings)
        {
            base.ConfigureRegionAdapterMappings(regionAdapterMappings);
            regionAdapterMappings.RegisterMapping(typeof(StackPanel),
                Container.Resolve<StackPanelRegionAdapter>());
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            //moduleCatalog.AddModule<ModuleAModule>();
            moduleCatalog.AddModule<ModuleA.ModuleAModule>();
            moduleCatalog.AddModule<ModuleB.ModuleBModule>();
        }
    }
}
