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
                var mainCameraPosition = ____mainCamera.position;
                var mainCameraRotation = ____mainCamera.rotation;

                var positionOffset = new Vector3(_config.PositionX, _config.PositionY, _config.PositionZ);
                mainCameraPosition += positionOffset;

                var rotationOffset = new Vector3(_config.RotationX, _config.RotationY, _config.RotationZ);
                var eulerAngles = mainCameraRotation.eulerAngles;
                eulerAngles += rotationOffset;
                mainCameraRotation.eulerAngles = eulerAngles;

                var position = Vector3.Lerp(__instance.transform.position, mainCameraPosition, Time.deltaTime * ____positionSmooth);
                var rotation = Quaternion.Slerp(__instance.transform.rotation, mainCameraRotation, Time.deltaTime * ____rotationSmooth);

                __instance.transform.SetPositionAndRotation(position, rotation);

                return false;
            }

            return true;
        }
    }
}
