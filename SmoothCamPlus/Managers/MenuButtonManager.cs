using BeatSaberMarkupLanguage;
using BeatSaberMarkupLanguage.MenuButtons;
using SmoothCamPlus.UI;
using System;
using System.Threading;
using System.Threading.Tasks;
using Zenject;

namespace SmoothCamPlus.Managers
{
    public class MenuButtonManager : IInitializable, IDisposable
    {
        private readonly MainFlowCoordinator _mainFlowCoordinator;
        private readonly SCPFlowCoordinator _scpFlowCoordinator;

        private readonly MenuButton _menuButton;

        public MenuButtonManager(MainFlowCoordinator mainFlowCoordinator, SCPFlowCoordinator scpFlowCoordinator)
        {
            _mainFlowCoordinator = mainFlowCoordinator;
            _scpFlowCoordinator = scpFlowCoordinator;

            _menuButton = new MenuButton("SmoothCamPlus", OnMenuButtonClick);
        }

        public async void Initialize()
        {
            await Task.Run(() => Thread.Sleep(100));

            MenuButtons.instance.RegisterButton(_menuButton);
        }

        public void Dispose()
        {
            if (BSMLParser.IsSingletonAvailable && MenuButtons.IsSingletonAvailable)
                MenuButtons.instance.UnregisterButton(_menuButton);
        }

        private void OnMenuButtonClick()
        {
            _mainFlowCoordinator.PresentFlowCoordinator(_scpFlowCoordinator);
        }
    }
}
