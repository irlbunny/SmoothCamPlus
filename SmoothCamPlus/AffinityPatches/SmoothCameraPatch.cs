using SiraUtil.Affinity;
using UnityEngine;

namespace SmoothCamPlus.AffinityPatches
{
    internal class SmoothCameraPatch : IAffinity
    {
        private readonly Config _config;

        public SmoothCameraPatch(Config config)
        {
            _config = config;
        }

        [AffinityPrefix]
        [AffinityPatch(typeof(SmoothCamera), nameof(SmoothCamera.LateUpdate))]
        private bool Patch(SmoothCamera __instance, MainCamera ____mainCamera,
            bool ____thirdPersonEnabled, float ____rotationSmooth,
            float ____positionSmooth)
        {
            if (!____thirdPersonEnabled)
            {
                // Idk how to math, aaa.
                var customPosition = new Vector3(
                    ____mainCamera.position.x + _config.PositionX,
                    ____mainCamera.position.y + _config.PositionY,
                    ____mainCamera.position.z + _config.PositionZ
                );
                var customRotation = new Quaternion(
                    ____mainCamera.rotation.x + _config.RotationX,
                    ____mainCamera.rotation.y + _config.RotationY,
                    ____mainCamera.rotation.z + _config.RotationZ,
                    ____mainCamera.rotation.w + _config.RotationW
                );

                var position = Vector3.Lerp(__instance.transform.position, customPosition, Time.deltaTime * ____positionSmooth);
                var rotation = Quaternion.Slerp(__instance.transform.rotation, customRotation, Time.deltaTime * ____rotationSmooth);

                __instance.transform.SetPositionAndRotation(position, rotation);

                return false;
            }

            return true;
        }
    }
}
