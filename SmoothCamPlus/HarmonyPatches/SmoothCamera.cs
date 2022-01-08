using HarmonyLib;
using SmoothCamPlus.Configuration;
using UnityEngine;

namespace SmoothCamPlus.HarmonyPatches
{
    [HarmonyPatch(typeof(SmoothCamera), "LateUpdate")]
    internal class SmoothCameraLateUpdate
    {
        private static bool Prefix(SmoothCamera __instance, MainCamera ____mainCamera,
            Vector3 ____thirdPersonPosition, Vector3 ____thirdPersonEulerAngles,
            bool ____thirdPersonEnabled, float ____rotationSmooth,
            float ____positionSmooth)
        {
            if (!____thirdPersonEnabled)
            {
                // Idk how to math, aaa.
                var customPosition = new Vector3(
                    ____mainCamera.position.x + PluginConfig.Instance.PositionX,
                    ____mainCamera.position.y + PluginConfig.Instance.PositionY,
                    ____mainCamera.position.z + PluginConfig.Instance.PositionZ
                );
                var customRotation = new Quaternion(
                    ____mainCamera.rotation.x + PluginConfig.Instance.RotationX,
                    ____mainCamera.rotation.y + PluginConfig.Instance.RotationY,
                    ____mainCamera.rotation.z + PluginConfig.Instance.RotationZ,
                    ____mainCamera.rotation.w + PluginConfig.Instance.RotationW
                );

                var position = Vector3.Lerp(__instance.transform.position, customPosition, Time.deltaTime * ____positionSmooth);
                var rotation = Quaternion.Slerp(__instance.transform.rotation, customRotation, Time.deltaTime * ____rotationSmooth);

                __instance.transform.SetPositionAndRotation(position, rotation);
            }
            else
            {
                var rotation = new Quaternion()
                {
                    eulerAngles = ____thirdPersonEulerAngles
                };

                __instance.transform.SetPositionAndRotation(____thirdPersonPosition, rotation);
            }

            return false;
        }
    }
}