using IPA;
using IPA.Config.Stores;
using IPA.Loader;
using SiraUtil.Attributes;
using SiraUtil.Zenject;
using SmoothCamPlus.AffinityPatches;
using SmoothCamPlus.Installers;
using IPAConfig = IPA.Config.Config;
using IPALogger = IPA.Logging.Logger;

namespace SmoothCamPlus
{
    [Plugin(RuntimeOptions.DynamicInit), NoEnableDisable, Slog]
    public class Plugin
    {
        [Init]
        public Plugin(IPALogger logger, IPAConfig conf, PluginMetadata metadata, Zenjector zenjector)
        {
            zenjector.UseLogger(logger);

            var config = conf.Generated<Config>();
            zenjector.Install(Location.App, container =>
            {
                container.BindInstance(config).AsSingle();
                container.BindInstance(new UBinder<Plugin, PluginMetadata>(metadata));

                container.BindInterfacesTo<SmoothCameraPatch>().AsSingle(); // We always want to patch SmoothCamera.
            });

            zenjector.Install<SCPMenuInstaller>(Location.Menu);
        }
    }
}
