using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.ViewControllers;
using SmoothCamPlus.Configuration;

namespace SmoothCamPlus.UI
{
    [ViewDefinition("SmoothCamPlus.UI.SettingsView.bsml")]
    [HotReload(RelativePathToLayout = @"..\UI\SettingsView.bsml")]
    public class SCPSettingsView : BSMLAutomaticViewController
    {
        [UIValue("position-x")]
        public float PositionX
        {
            get => PluginConfig.Instance.PositionX;
            set => PluginConfig.Instance.PositionX = value;
        }
        [UIValue("position-y")]
        public float PositionY
        {
            get => PluginConfig.Instance.PositionY;
            set => PluginConfig.Instance.PositionY = value;
        }
        [UIValue("position-z")]
        public float PositionZ
        {
            get => PluginConfig.Instance.PositionZ;
            set => PluginConfig.Instance.PositionZ = value;
        }

        [UIValue("rotation-x")]
        public float RotationX
        {
            get => PluginConfig.Instance.RotationX;
            set => PluginConfig.Instance.RotationX = value;
        }
        [UIValue("rotation-y")]
        public float RotationY
        {
            get => PluginConfig.Instance.RotationY;
            set => PluginConfig.Instance.RotationY = value;
        }
        [UIValue("rotation-z")]
        public float RotationZ
        {
            get => PluginConfig.Instance.RotationZ;
            set => PluginConfig.Instance.RotationZ = value;
        }
        [UIValue("rotation-w")]
        public float RotationW
        {
            get => PluginConfig.Instance.RotationW;
            set => PluginConfig.Instance.RotationW = value;
        }
    }
}
