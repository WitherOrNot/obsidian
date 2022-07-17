using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace obsidian
{
    public class DownloadManager
    {
        public List<DownloadItem> items;

        public DownloadManager(List<DownloadItem> items)
        {
            this.items = items;
        }

        public void Download(DownloadProgress progressForm)
        {
            List<Task> downloadTasks = new List<Task>();

            foreach (DownloadItem item in items)
            {
                string realPath = $".minecraft/{item.path}";
                
                Utils.CreateDirTree(realPath);
                downloadTasks.Add(new WebClient().DownloadFileTaskAsync(new Uri(item.url), realPath).ContinueWith((task) =>
                {
                    progressForm.Invoke(new Action(progressForm.IncrementProgress));
                }));
            }

            Task.WhenAll(downloadTasks).ContinueWith((task) => progressForm.Invoke(new Action(progressForm.Close)));
        }
    }
}
