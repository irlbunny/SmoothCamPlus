using IPA.Config.Stores;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo(GeneratedStore.AssemblyVisibilityTarget)]
namespace SmoothCamPlus.Configuration
{
    internal class PluginConfig
    {
        public static PluginConfig Instance { get; set; }

        public virtual float PositionX { get; set; }
        public virtual float PositionY { get; set; }
        public virtual float PositionZ { get; set; }

        public virtual float RotationX { get; set; }
        public virtual float RotationY { get; set; }
        public virtual float RotationZ { get; set; }
        public virtual float RotationW { get; set; }
    }
}