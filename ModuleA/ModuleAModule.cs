using ModuleA.Views;
using Prism.Modularity;
using Prism.Regions;
using Prism.Ioc;
namespace ModuleA
{
    public class ModuleAModule : IModule
    {
        
        private readonly IRegionManager _regionManager;

        public ModuleAModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }
        public void OnInitialized(IContainerProvider containerProvider)
        {
          
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            _regionManager.RegisterViewWithRegion<MessageInputView>("MessageInput");
        }
    }
}
