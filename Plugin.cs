using System;
using MediaBrowser.Common.Plugins;
using MediaBrowser.Model.Plugins;
using MediaBrowser.Model.Serialization;
using MediaBrowser.Common.Configuration;
using System.Collections.Generic;

namespace Emby.SubEdit
{
    public class Plugin : BasePlugin, IHasWebPages
    {
        public Plugin() : base()
        {
            Instance = this;
        }

        public override string Name => "SubEdit";
        public override string Description => "Easily edit your off-synced subtitles from anywhere with ease";

        public override Guid Id => new Guid("c47beeaa-0797-4085-945c-53da24d3f84b");

        public IEnumerable<PluginPageInfo> GetPages()
        {
            return new PluginPageInfo[]
            {
                new PluginPageInfo
                {
                    Name = Name,
                    EmbeddedResourcePath = GetType().Namespace + ".Configuration.config.html" 
                },
                new PluginPageInfo
                {
                    Name = $"{Name}JS",
                    EmbeddedResourcePath = GetType().Namespace + ".Configuration.config.js"
                }
            };
        }

        public static Plugin Instance { get; private set; }
    }
}
