using HarmonyLib;
using IPA;
using IPA.Config;
using IPA.Config.Stores;
using SiraUtil.Zenject;
using SmoothCamPlus.Configuration;
using SmoothCamPlus.Installers;
using System.Reflection;
using IPALogger = IPA.Logging.Logger;

namespace SmoothCamPlus
{
    [Plugin(RuntimeOptions.DynamicInit)]
    internal class Plugin
    {
        private const string HARMONYID = "com.github.ItsKaitlyn03.SmoothCamPlus";

        internal static IPALogger Log { get; private set; }
        internal static Harmony HarmonyInstance { get; private set; } = new Harmony(HARMONYID);

        [Init]
        public Plugin(IPALogger logger, Config conf, Zenjector zenjector)
        {
            Log = logger;

            PluginConfig.Instance = conf.Generated<PluginConfig>();

            zenjector.Install<SCPMenuInstaller>(Location.Menu);
        }

        [OnEnable]
        public void OnEnable()
        {
            HarmonyInstance.PatchAll(Assembly.GetExecutingAssembly());
        }

        [OnDisable]
        public void OnDisable()
        {
            HarmonyInstance.UnpatchSelf();
        }
    }
}
