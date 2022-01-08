using BeatSaberMarkupLanguage;
using HMUI;
using Zenject;

namespace SmoothCamPlus.UI
{
    public class SCPFlowCoordinator : FlowCoordinator
    {
        private MainFlowCoordinator _mainFlowCoordinator;
        private SCPSettingsView _scpSettingsView;

        [Inject]
        public void Construct(MainFlowCoordinator mainFlowCoordinator, SCPSettingsView scpSettingsView)
        {
            _mainFlowCoordinator = mainFlowCoordinator;
            _scpSettingsView = scpSettingsView;
        }

        protected override void DidActivate(bool firstActivation, bool addedToHierarchy, bool screenSystemEnabling)
        {
            if (firstActivation)
            {
                SetTitle("SmoothCamPlus");
                showBackButton = true;

                ProvideInitialViewControllers(_scpSettingsView);
            }
        }

        protected override void BackButtonWasPressed(ViewController topViewController)
        {
            _mainFlowCoordinator.DismissFlowCoordinator(this);
        }
    }
}
