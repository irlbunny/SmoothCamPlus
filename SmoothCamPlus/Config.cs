using IPA.Config.Stores;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo(GeneratedStore.AssemblyVisibilityTarget)]
namespace SmoothCamPlus
{
    internal class Config
    {
        public virtual float PositionX { get; set; }
        public virtual float PositionY { get; set; }
        public virtual float PositionZ { get; set; }

        public virtual float RotationX { get; set; }
        public virtual float RotationY { get; set; }
        public virtual float RotationZ { get; set; }
    }
}