using SmoothCamPlus.Managers;
using SmoothCamPlus.UI;
using Zenject;

namespace SmoothCamPlus.Installers
{
    internal class SCPMenuInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.Bind<SCPSettingsView>().FromNewComponentAsViewController().AsSingle();
            Container.Bind<SCPFlowCoordinator>().FromNewComponentOnNewGameObject().AsSingle();

            Container.BindInterfacesTo<MenuButtonManager>().AsSingle();
        }
    }
}
