using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.ViewControllers;
using Zenject;

namespace SmoothCamPlus.UI
{
    [ViewDefinition("SmoothCamPlus.Views.settings-view.bsml")]
    [HotReload(RelativePathToLayout = @"..\UI\SettingsView.bsml")]
    internal class SCPSettingsView : BSMLAutomaticViewController
    {
        private Config _config = null!;

        [UIValue("position-x")]
        protected float PositionX
        {
            get => _config.PositionX;
            set => _config.PositionX = value;
        }

        [UIValue("position-y")]
        protected float PositionY
        {
            get => _config.PositionY;
            set => _config.PositionY = value;
        }

        [UIValue("position-z")]
        protected float PositionZ
        {
            get => _config.PositionZ;
            set => _config.PositionZ = value;
        }

        [UIValue("rotation-x")]
        protected float RotationX
        {
            get => _config.RotationX;
            set => _config.RotationX = value;
        }

        [UIValue("rotation-y")]
        protected float RotationY
        {
            get => _config.RotationY;
            set => _config.RotationY = value;
        }

        [UIValue("rotation-z")]
        protected float RotationZ
        {
            get => _config.RotationZ;
            set => _config.RotationZ = value;
        }

        [UIValue("rotation-w")]
        protected float RotationW
        {
            get => _config.RotationW;
            set => _config.RotationW = value;
        }

        [Inject]
        public void Construct(Config config)
        {
            _config = config;
        }
    }
}
