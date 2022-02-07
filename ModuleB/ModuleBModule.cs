using Prism.Unity;
using Prism.Ioc;
using Unity.Microsoft.DependencyInjection;
using Prism.Modularity;
using Microsoft.Extensions.Configuration;
using Prism.Regions;
using ModuleB.Views;

namespace ModuleB
{
    public class ModuleBModule : IModule
    {
        
        private readonly IRegionManager _regionManager;

        public ModuleBModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }
        public void OnInitialized(IContainerProvider containerProvider)
        {

        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        { 
            _regionManager.RegisterViewWithRegion<MessageListView>("MessageOutput");
        }
    }
}
