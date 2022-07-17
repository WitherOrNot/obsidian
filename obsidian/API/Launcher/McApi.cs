using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace obsidian
{
    public class McVersion
    {
        public string id { get; set; }
        public string type { get; set; }
        public string url { get; set; }
        public string time { get; set; }
        public string releaseTime { get; set; }
    }

    public class McApi {
        public static List<McVersion> GetVersions()
        {
            dynamic manifest = ApiClient.SendRequest("GET", "https://launchermeta.mojang.com/mc/game/version_manifest.json");
            return manifest.versions.ToObject<List<McVersion>>();
        }

        public static void DownloadVersion(McVersion version)
        {
            dynamic manifest = ApiClient.SendRequest("GET", version.url);
            dynamic assets = ApiClient.SendRequest("GET", manifest.assetIndex.url.Value);

            List<DownloadItem> downloads = new List<DownloadItem>
            {
                new DownloadItem
                {
                    path = $"versions/{version.id}.json",
                    url = version.url,
                    sha1 = null,
                    size = -1
                },
                new DownloadItem
                {
                    path = $"versions/{version.id}/{version.id}.jar",
                    url = manifest.downloads.client.url.Value,
                    sha1 = manifest.downloads.client.sha1.Value,
                    size = manifest.downloads.client.size.Value
                },
                new DownloadItem
                {
                    path = $"assets/indexes/{manifest.assetIndex.id.Value}.json",
                    url = manifest.assetIndex.url.Value,
                    sha1 = manifest.assetIndex.sha1.Value,
                    size = manifest.assetIndex.size.Value
                }
            };

            bool mapToResources = assets.ContainsKey("map_to_resources") && assets.map_to_resources.Value;
            bool virt = assets.ContainsKey("virtual") && assets["virtual"].Value;
            string assetFolder = mapToResources ? "resources/" : (virt ? "assets/virtual/legacy/" : "assets/objects/");

            foreach (dynamic asset in assets.objects)
            {
                string assetName = asset.Name;
                dynamic assetProps = asset.Value;
                string assetHash = assetProps.hash.Value;

                downloads.Add(new DownloadItem
                {
                    path = assetFolder + (mapToResources || virt ? assetName : $"{assetHash.Substring(0, 2)}/{assetHash}"),
                    url = $"http://resources.download.minecraft.net/{assetHash.Substring(0, 2)}/{assetHash}",
                    sha1 = assetHash,
                    size = assetProps.size.Value
                });
            }

            foreach (dynamic library in RuleParser.ParseLibs(manifest.libraries))
            {
                if (library.downloads.ContainsKey("artifact"))
                {
                    DownloadItem downloadItem = library.downloads.artifact.ToObject<DownloadItem>();
                    downloadItem.path = "libraries/" + downloadItem.path;
                    downloads.Add(downloadItem);
                }

                if (library.ContainsKey("natives") && library.natives.ContainsKey("windows"))
                {
                    DownloadItem downloadItem = library.downloads.classifiers[library.natives.windows.Value].ToObject<DownloadItem>();
                    downloadItem.path = "libraries/" + downloadItem.path;
                    downloadItem.isNative = true;
                    downloads.Add(downloadItem);
                }
            }

            DownloadProgress progressForm = new DownloadProgress(new DownloadManager(downloads));
            progressForm.Show();
        }

        public McApi()
        {
            
        }
    }
}
